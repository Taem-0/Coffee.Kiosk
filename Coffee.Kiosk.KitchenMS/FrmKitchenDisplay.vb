Imports System.Runtime
Imports Coffee.Kiosk.CMS.CoffeeKDB
Imports Coffee.Kiosk.CMS.Models
Imports Microsoft.Extensions.Configuration
Imports MySql.Data.MySqlClient

Public Class frmKitchenDisplay

    Private _displayedOrderIds As New List(Of Integer)
    Private _lastCompletedOrderId As Integer = -1

    Private _lastPrimaryColor As String = ""
    Private _lastLogoPath As String = ""

    Private Sub frmKitchenDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTime.Text = Date.Now.ToString("HH:mm:ss")
        tmrClock.Interval = 1000
        tmrClock.Start()
        pnl1.BackColor = Color.FromArgb(92, 51, 23)
        lblTime.BackColor = Color.FromArgb(92, 51, 23)
        Timer1.Interval = 2000
        Timer1.Start()
        UpdateActiveOrderCount()

        ApplyShopTheme()

        '        ' --- TEST DATA --- remove this when DB is connected
        '        Dim testOrder1 As New Order With {
        '    .OrderId = 1,
        '    .OrderNumber = "001",
        '    .OrderTime = DateTime.Now.AddMinutes(-3),
        '    .Status = OrderStatus.Paid,
        '    .OrderType = "DineIn",
        '    .Items = New List(Of OrderItem) From {
        '        New OrderItem With {.ItemId = 1, .ItemName = "Coffee", .Quantity = 1,
        '            .Customizations = New List(Of String) From {"Arabica Beans", "Low Sugar", "Extra Whip"}},
        '        New OrderItem With {.ItemId = 2, .ItemName = "Burger", .Quantity = 2,
        '            .Customizations = New List(Of String)},
        '        New OrderItem With {.ItemId = 3, .ItemName = "Fries", .Quantity = 1,
        '            .Customizations = New List(Of String) From {"Large Size", "Extra Salt"}}
        '    }
        '}
        ' disable recall button on load
        btnRecall.Enabled = False
        btnRecall.DisabledState.FillColor = Color.FromArgb(60, 60, 60)
        btnRecall.DisabledState.ForeColor = Color.FromArgb(150, 150, 150)
        btnRecall.DisabledState.BorderColor = Color.FromArgb(60, 60, 60)
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        lblTime.Text = Date.Now.ToString("HH:mm:ss")
    End Sub


    ' every 3 seconds, check DB for new paid orders

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            ApplyShopTheme()

            '  check for New paid orders
            Dim newOrders = GetPaidOrdersFromDB()
            For Each order In newOrders
                If _displayedOrderIds.Contains(order.OrderId) Then
                    Continue For
                End If
                AddOrderCard(order)
            Next

            ' check for canceled orders and remove them
            Dim canceledIds = DatabaseHelper.GetCanceledOrderIds()
            For Each canceledId In canceledIds
                If _displayedOrderIds.Contains(canceledId) Then
                    RemoveCanceledOrder(canceledId)
                End If
            Next

        Catch ex As Exception
            Console.WriteLine("Poll error: " & ex.Message)
        End Try
    End Sub

    Private Function GetPaidOrdersFromDB() As List(Of Order)
        Return DatabaseHelper.GetPaidOrders()
    End Function

    Private Sub AddOrderCard(order As Order)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() AddOrderCard(order)))
            Return
        End If

        Dim card As New ucOrderCard()
        card.LoadOrder(order)
        AddHandler card.OnOrderCompleted, AddressOf HandleOrderCompleted
        flpOrders.Controls.Add(card)
        _displayedOrderIds.Add(order.OrderId)
        UpdateActiveOrderCount()
    End Sub

    Private Sub HandleOrderCompleted(card As ucOrderCard, orderId As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() HandleOrderCompleted(card, orderId)))
            Return
        End If

        flpOrders.Controls.Remove(card)
        card.Dispose()

        ' save last completed order for recall
        _lastCompletedOrderId = orderId

        flpOrders.Controls.Remove(card)
        card.Dispose()
        _displayedOrderIds.Remove(orderId)
        UpdateActiveOrderCount()

        ' enable recall button
        btnRecall.Enabled = True
        '  btnRecall.FillColor = Color.FromArgb(92, 51, 23)
        btnRecall.ForeColor = Color.White
    End Sub

    Private Sub UpdateActiveOrderCount()
        lblActiveOrders.Text = flpOrders.Controls.Count.ToString()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnl1.Paint
    End Sub

    Private Sub RemoveCanceledOrder(orderId As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() RemoveCanceledOrder(orderId)))
            Return
        End If

        For Each ctrl As Control In flpOrders.Controls
            If TypeOf ctrl Is ucOrderCard Then
                Dim card As ucOrderCard = DirectCast(ctrl, ucOrderCard)
                If card.OrderId = orderId Then
                    flpOrders.Controls.Remove(card)
                    card.Dispose()
                    _displayedOrderIds.Remove(orderId)
                    UpdateActiveOrderCount()
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub btnRecall_Click(sender As Object, e As EventArgs) Handles btnRecall.Click
        If _lastCompletedOrderId = -1 Then Return

        ' set status back to Paid in DB
        DatabaseHelper.UpdateOrderStatus(_lastCompletedOrderId, "Paid")

        ' fetch the order from DB
        Dim order = DatabaseHelper.GetOrderById(_lastCompletedOrderId)

        If order IsNot Nothing Then
            _displayedOrderIds.Remove(_lastCompletedOrderId)

            ' add card back in correct position
            Dim card As New ucOrderCard()
            card.LoadOrder(order)
            AddHandler card.OnOrderCompleted, AddressOf HandleOrderCompleted
            flpOrders.Controls.Add(card)

            ' find correct position based on OrderId
            Dim correctIndex As Integer = 0
            For i As Integer = 0 To flpOrders.Controls.Count - 1
                Dim existingCard As ucOrderCard = TryCast(flpOrders.Controls(i), ucOrderCard)
                If existingCard IsNot Nothing Then
                    If existingCard.OrderId < order.OrderId Then
                        correctIndex = i + 1
                    End If
                End If
            Next
            flpOrders.Controls.SetChildIndex(card, correctIndex)

            _displayedOrderIds.Add(order.OrderId)
            UpdateActiveOrderCount()

            ' reset recall
            _lastCompletedOrderId = -1
            btnRecall.Enabled = False
            btnRecall.DisabledState.FillColor = Color.FromArgb(60, 60, 60)
            btnRecall.DisabledState.ForeColor = Color.FromArgb(150, 150, 150)
            btnRecall.DisabledState.BorderColor = Color.FromArgb(60, 60, 60)
        End If
    End Sub

    Private Sub ApplyShopTheme()
        Try
            Using conn As New MySqlConnection("Server=localhost;Database=coffeekioskdb;Uid=root;Pwd=;")
                conn.Open()

                Dim sql = "SELECT Primary_Color, LogoPath FROM shop LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then

                            Dim primaryColor As String = If(reader.IsDBNull(0), "", reader.GetString(0))
                            Dim logoPath As String = If(reader.IsDBNull(1), "", reader.GetString(1))

                            If primaryColor = _lastPrimaryColor AndAlso logoPath = _lastLogoPath Then
                                Return
                            End If

                            _lastPrimaryColor = primaryColor
                            _lastLogoPath = logoPath

                            If Not String.IsNullOrEmpty(primaryColor) Then
                                Dim panelColor As Color = ColorTranslator.FromHtml(primaryColor)
                                pnl1.BackColor = panelColor
                                lblTime.BackColor = panelColor
                            End If

                            If Not String.IsNullOrEmpty(logoPath) AndAlso IO.File.Exists(logoPath) Then
                                If PictureBox1.Image IsNot Nothing Then
                                    PictureBox1.Image.Dispose()
                                    PictureBox1.Image = Nothing
                                End If

                                Dim bytes = IO.File.ReadAllBytes(logoPath)
                                Using ms As New IO.MemoryStream(bytes)
                                    PictureBox1.Image = Image.FromStream(ms)
                                End Using

                                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                            Else
                                Console.WriteLine("Logo not found: " & logoPath)
                            End If

                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("Theme load error: " & ex.Message)
        End Try
    End Sub

End Class