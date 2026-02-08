Public Class PaymentDialog
    Private cart As List(Of OrderItem)
    Private totalAmount As Decimal
    Private staffName As String
    Private completedOrder As OrderManager.CompletedOrder = Nothing

    Public Property OrderCart As List(Of OrderItem)
        Get
            Return cart
        End Get
        Set(value As List(Of OrderItem))
            cart = value
        End Set
    End Property

    Public Property Total As Decimal
        Get
            Return totalAmount
        End Get
        Set(value As Decimal)
            totalAmount = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return staffName
        End Get
        Set(value As String)
            staffName = value
        End Set
    End Property

    Public Property SelectedPaymentMethod As String = "Cash"

    Private Sub PaymentDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTotalAmount.Text = "₱" & totalAmount.ToString("0.00")
        DisplayOrderSummary()

        If SelectedPaymentMethod = "Cash" Then
            rbCash.Checked = True
        ElseIf SelectedPaymentMethod = "Gcash" Then
            rbGcash.Checked = True
        ElseIf SelectedPaymentMethod = "Maya" Then
            rbMaya.Checked = True
        End If

        UpdateReceiptPreview()
    End Sub

    Private Sub DisplayOrderSummary()
        rtbOrderSummary.Clear()

        For Each item In cart
            Dim displayName As String = If(String.IsNullOrEmpty(item.ItemName),
                                          If(item.Drink IsNot Nothing, item.Drink.Name, "Unknown Item"),
                                          item.ItemName)

            rtbOrderSummary.AppendText($"{item.Quantity}x {displayName}" & vbCrLf)
            rtbOrderSummary.AppendText($"   ₱{item.TotalPrice:F2}" & vbCrLf)

            If Not String.IsNullOrEmpty(item.Size) Then
                rtbOrderSummary.AppendText($"   Size: {item.Size}" & vbCrLf)
            End If
            If Not String.IsNullOrEmpty(item.Temperature) Then
                rtbOrderSummary.AppendText($"   Temp: {item.Temperature}" & vbCrLf)
            End If
            If Not String.IsNullOrEmpty(item.SugarLevel) Then
                rtbOrderSummary.AppendText($"   Sugar: {item.SugarLevel}" & vbCrLf)
            End If
            If item.Toppings IsNot Nothing AndAlso item.Toppings.Count > 0 Then
                rtbOrderSummary.AppendText($"   Toppings: {String.Join(", ", item.Toppings)}" & vbCrLf)
            End If
            If item.Syrups IsNot Nothing AndAlso item.Syrups.Count > 0 Then
                rtbOrderSummary.AppendText($"   Syrups: {String.Join(", ", item.Syrups)}" & vbCrLf)
            End If
            If Not String.IsNullOrEmpty(item.Rice) Then
                rtbOrderSummary.AppendText($"   Rice: {item.Rice}" & vbCrLf)
            End If
            If Not String.IsNullOrEmpty(item.Side) AndAlso item.Side <> "No Side" Then
                rtbOrderSummary.AppendText($"   Side: {item.Side}" & vbCrLf)
            End If

            rtbOrderSummary.AppendText(vbCrLf)
        Next

        rtbOrderSummary.AppendText("─────────────────────────" & vbCrLf)
        rtbOrderSummary.AppendText($"TOTAL: ₱{totalAmount:F2}" & vbCrLf)
    End Sub

    Private Sub UpdateReceiptPreview()
        Dim paymentMethod As String = GetSelectedPaymentMethod()
        Dim amountPaid As Decimal = 0
        Dim changeAmount As Decimal = 0
        Dim referenceNumber As String = Nothing

        If paymentMethod = "Cash" Then
            Decimal.TryParse(txtAmountPaid.Text, amountPaid)
            changeAmount = amountPaid - totalAmount
        Else
            amountPaid = totalAmount
            referenceNumber = txtReference.Text
        End If

        Dim tempQueueNumber As String = QueueManager.GetCurrentQueueNumber()

        Dim receiptText As String = ReceiptHelper.GenerateReceiptText(
            0,
            tempQueueNumber,
            staffName,
            cart,
            totalAmount,
            paymentMethod,
            amountPaid,
            changeAmount,
            referenceNumber
        )

        rtbReceiptPreview.Text = receiptText
    End Sub

    Private Sub rbCash_CheckedChanged(sender As Object, e As EventArgs) Handles rbCash.CheckedChanged
        If rbCash.Checked Then
            pnlCashPayment.Visible = True
            pnlDigitalPayment.Visible = False
            txtAmountPaid.Clear()
            txtAmountPaid.Focus()
            lblChange.Text = "₱0.00"
            UpdateReceiptPreview()
        End If
    End Sub

    Private Sub rbGcash_CheckedChanged(sender As Object, e As EventArgs) Handles rbGcash.CheckedChanged
        If rbGcash.Checked Then
            pnlCashPayment.Visible = False
            pnlDigitalPayment.Visible = True
            lblDigitalAmount.Text = "₱" & totalAmount.ToString("0.00")
            txtReference.Clear()
            txtReference.Focus()
            UpdateReceiptPreview()
        End If
    End Sub

    Private Sub rbMaya_CheckedChanged(sender As Object, e As EventArgs) Handles rbMaya.CheckedChanged
        If rbMaya.Checked Then
            pnlCashPayment.Visible = False
            pnlDigitalPayment.Visible = True
            lblDigitalAmount.Text = "₱" & totalAmount.ToString("0.00")
            txtReference.Clear()
            txtReference.Focus()
            UpdateReceiptPreview()
        End If
    End Sub

    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        Dim amountPaid As Decimal = 0
        If Decimal.TryParse(txtAmountPaid.Text, amountPaid) Then
            Dim change As Decimal = amountPaid - totalAmount
            lblChange.Text = "₱" & change.ToString("0.00")

            If change < 0 Then
                lblChange.ForeColor = Color.Red
            Else
                lblChange.ForeColor = Color.Green
            End If
        Else
            lblChange.Text = "₱0.00"
            lblChange.ForeColor = Color.Black
        End If

        UpdateReceiptPreview()
    End Sub

    Private Sub txtReferenceNumber_TextChanged(sender As Object, e As EventArgs) Handles txtReference.TextChanged
        UpdateReceiptPreview()
    End Sub

    Private Function GetSelectedPaymentMethod() As String
        If rbCash.Checked Then
            Return "Cash"
        ElseIf rbGcash.Checked Then
            Return "Gcash"
        ElseIf rbMaya.Checked Then
            Return "Maya"
        Else
            Return "Cash"
        End If
    End Function

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If Not ValidatePayment() Then
            Return
        End If

        Dim paymentMethod As String = GetSelectedPaymentMethod()
        Dim amountPaid As Decimal = 0
        Dim changeAmount As Decimal = 0
        Dim referenceNumber As String = Nothing

        If paymentMethod = "Cash" Then
            Decimal.TryParse(txtAmountPaid.Text, amountPaid)
            changeAmount = amountPaid - totalAmount
        Else
            amountPaid = totalAmount
            changeAmount = 0
            referenceNumber = txtReference.Text.Trim()
        End If

        Try
            completedOrder = OrderManager.SaveOrder(
                staffName,
                cart,
                totalAmount,
                paymentMethod,
                amountPaid,
                changeAmount,
                referenceNumber
            )

            If completedOrder IsNot Nothing Then
                Dim receiptText As String = ReceiptHelper.GenerateReceiptText(
                    completedOrder.OrderId,
                    completedOrder.QueueNumber,
                    staffName,
                    cart,
                    totalAmount,
                    paymentMethod,
                    amountPaid,
                    changeAmount,
                    referenceNumber
                )

                Dim result = MessageBox.Show(
                    $"Payment successful!{vbCrLf}Order ID: {completedOrder.OrderId}{vbCrLf}Queue Number: {completedOrder.QueueNumber}{vbCrLf}{vbCrLf}Do you want to print the receipt?",
                    "Payment Complete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                )

                If result = DialogResult.Yes Then
                    ReceiptHelper.PrintReceipt(receiptText)
                End If

                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to save order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error processing payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidatePayment() As Boolean
        Dim paymentMethod As String = GetSelectedPaymentMethod()

        If paymentMethod = "Cash" Then
            Dim amountPaid As Decimal = 0
            If Not Decimal.TryParse(txtAmountPaid.Text, amountPaid) Then
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAmountPaid.Focus()
                Return False
            End If

            If amountPaid < totalAmount Then
                MessageBox.Show("Amount paid is less than the total amount.", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAmountPaid.Focus()
                Return False
            End If

        Else
            If String.IsNullOrWhiteSpace(txtReference.Text) Then
                MessageBox.Show("Please enter a reference number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReference.Focus()
                Return False
            End If

            If txtReference.Text.Trim().Length < 8 Then
                MessageBox.Show("Reference number must be at least 8 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReference.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtAmountPaid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountPaid.KeyPress
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        If Char.IsDigit(e.KeyChar) Then
            Return
        End If

        If e.KeyChar = "."c AndAlso Not txtAmountPaid.Text.Contains(".") Then
            Return
        End If

        e.Handled = True
    End Sub

End Class