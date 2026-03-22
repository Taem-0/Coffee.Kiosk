Imports System.Runtime

Public Class frmKitchenDisplay

    Private _displayedOrderIds As New List(Of Integer)
    Private _lastCompletedOrderId As Integer = -1

    Private Sub frmKitchenDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTime.Text = Date.Now.ToString("HH:mm:ss")
        tmrClock.Interval = 1000
        tmrClock.Start()
        pnl1.BackColor = Color.FromArgb(92, 51, 23)
        lblTime.BackColor = Color.FromArgb(92, 51, 23)
        Timer1.Interval = 2000
        Timer1.Start()
        UpdateActiveOrderCount()

        ' disable recall button on load
        btnRecall.Enabled = False
        btnRecall.DisabledState.FillColor = Color.FromArgb(60, 60, 60)
        btnRecall.DisabledState.ForeColor = Color.FromArgb(150, 150, 150)
        btnRecall.DisabledState.BorderColor = Color.FromArgb(60, 60, 60)
    End Sub

    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        lblTime.Text = Date.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            ' check for new paid orders
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


End Class