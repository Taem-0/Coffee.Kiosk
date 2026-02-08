Imports System.Linq


Public Class OrderDetails
    Private currentOrder As CompletedOrder

    Public Sub New(order As CompletedOrder)
        InitializeComponent()
        Me.currentOrder = order
    End Sub

    Private Sub OrderDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Order Details - " & currentOrder.OrderId
        Me.Size = New Size(600, 700)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        DisplayOrderDetails()
    End Sub

    Private Sub DisplayOrderDetails()
        Dim details As New System.Text.StringBuilder()

        details.AppendLine("═══════════════════════════════════════")
        details.AppendLine("           ORDER DETAILS")
        details.AppendLine("═══════════════════════════════════════")
        details.AppendLine()
        details.AppendLine($"Order ID       : {currentOrder.OrderId}")
        details.AppendLine($"Queue Number   : {currentOrder.QueueNumber}")
        details.AppendLine($"Order Date     : {currentOrder.OrderDate:MM/dd/yyyy hh:mm tt}")
        details.AppendLine($"Staff Name     : {currentOrder.StaffName}")
        details.AppendLine($"Payment Method : {currentOrder.PaymentMethod}")
        details.AppendLine()
        details.AppendLine("───────────────────────────────────────")
        details.AppendLine("              ORDER ITEMS")
        details.AppendLine("───────────────────────────────────────")
        details.AppendLine()

        For Each item In currentOrder.Items
            Dim displayName As String = ""

            If Not String.IsNullOrEmpty(item.ItemName) Then
                displayName = item.ItemName
            ElseIf item.Drink IsNot Nothing AndAlso Not String.IsNullOrEmpty(item.Drink.Name) Then
                displayName = item.Drink.Name
            Else
                displayName = "Unknown Item"
            End If

            details.AppendLine($"{item.Quantity}x {displayName}")
            details.AppendLine($"   Price: ₱{item.TotalPrice:F2}")

            If Not String.IsNullOrEmpty(item.Size) Then
                details.AppendLine($"   Size: {item.Size}")
            End If
            If Not String.IsNullOrEmpty(item.Temperature) Then
                details.AppendLine($"   Temperature: {item.Temperature}")
            End If
            If Not String.IsNullOrEmpty(item.SugarLevel) Then
                details.AppendLine($"   Sugar Level: {item.SugarLevel}")
            End If
            If item.Toppings IsNot Nothing AndAlso item.Toppings.Count > 0 Then
                details.AppendLine($"   Toppings: {String.Join(", ", item.Toppings)}")
            End If
            If item.Syrups IsNot Nothing AndAlso item.Syrups.Count > 0 Then
                details.AppendLine($"   Syrups: {String.Join(", ", item.Syrups)}")
            End If
            If Not String.IsNullOrEmpty(item.Rice) Then
                details.AppendLine($"   Rice: {item.Rice}")
            End If
            If Not String.IsNullOrEmpty(item.Side) AndAlso item.Side <> "No Side" Then
                details.AppendLine($"   Side: {item.Side}")
            End If

            details.AppendLine()
        Next

        details.AppendLine("───────────────────────────────────────")
        details.AppendLine($"TOTAL AMOUNT   : ₱{currentOrder.TotalAmount:F2}")

        If currentOrder.PaymentMethod = "Cash" Then
            details.AppendLine($"Amount Paid    : ₱{currentOrder.AmountPaid:F2}")
            details.AppendLine($"Change         : ₱{currentOrder.ChangeAmount:F2}")
        Else
            If Not String.IsNullOrEmpty(currentOrder.ReferenceNumber) Then
                details.AppendLine($"Reference No.  : {currentOrder.ReferenceNumber}")
            End If
        End If

        details.AppendLine("═══════════════════════════════════════")

        Dim rtbDetails As New RichTextBox With {
            .Dock = DockStyle.Fill,
            .Text = details.ToString(),
            .Font = New Font("Courier New", 10),
            .ReadOnly = True,
            .BackColor = Color.White
        }

        Dim btnClose As New Button With {
            .Text = "Close",
            .Dock = DockStyle.Bottom,
            .Height = 50,
            .BackColor = Color.FromArgb(139, 90, 43),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold)
        }
        btnClose.FlatAppearance.BorderSize = 0

        AddHandler btnClose.Click, Sub() Me.Close()

        Me.Controls.Add(rtbDetails)
        Me.Controls.Add(btnClose)
    End Sub
End Class