Imports System.Drawing.Printing

Module ReceiptHelper

    Private receiptContent As String = ""

    Public Function GenerateReceiptText(orderId As Integer, queueNumber As String, staffName As String,
                                   cart As List(Of OrderItem), totalAmount As Decimal,
                                   paymentMethod As String, amountPaid As Decimal, changeAmount As Decimal,
                                   Optional referenceNumber As String = Nothing) As String

        If cart Is Nothing OrElse cart.Count = 0 Then
            Return "No items in cart"
        End If

        Dim receipt As New System.Text.StringBuilder()
        Dim line As String = "================================"
        Dim width As Integer = 32

        receipt.AppendLine(line)
        receipt.AppendLine(CenterText("CAFE FILIPINO", width))
        receipt.AppendLine(line)
        receipt.AppendLine($"Date: {DateTime.Now:MM/dd/yyyy  hh:mm tt}")
        receipt.AppendLine($"Order ID: {orderId}")
        receipt.AppendLine($"Queue: {queueNumber}")
        receipt.AppendLine($"Cashier: {staffName}")
        receipt.AppendLine(line)
        receipt.AppendLine()

        For Each item In cart
            If item Is Nothing Then Continue For

            Dim displayName As String = ""

            If Not String.IsNullOrEmpty(item.ItemName) Then
                displayName = item.ItemName
            ElseIf item.Drink IsNot Nothing AndAlso Not String.IsNullOrEmpty(item.Drink.Name) Then
                displayName = item.Drink.Name
            Else
                displayName = "Unknown Item"
            End If

            Dim itemLine As String = $"{item.Quantity}x {displayName}"
            Dim price As String = $"₱{item.TotalPrice:F2}"

            Dim spaces As Integer = width - itemLine.Length - price.Length
            If spaces < 1 Then spaces = 1
            receipt.AppendLine(itemLine & New String(" "c, spaces) & price)

            If Not String.IsNullOrEmpty(item.Size) Then
                receipt.AppendLine($"   Size: {item.Size}")
            End If
            If Not String.IsNullOrEmpty(item.Temperature) Then
                receipt.AppendLine($"   Temp: {item.Temperature}")
            End If
            If Not String.IsNullOrEmpty(item.SugarLevel) Then
                receipt.AppendLine($"   Sugar: {item.SugarLevel}")
            End If
            If item.Toppings IsNot Nothing AndAlso item.Toppings.Count > 0 Then
                receipt.AppendLine($"   Toppings: {String.Join(", ", item.Toppings)}")
            End If
            If item.Syrups IsNot Nothing AndAlso item.Syrups.Count > 0 Then
                receipt.AppendLine($"   Syrups: {String.Join(", ", item.Syrups)}")
            End If
            If Not String.IsNullOrEmpty(item.Rice) Then
                receipt.AppendLine($"   Rice: {item.Rice}")
            End If
            If Not String.IsNullOrEmpty(item.Side) AndAlso item.Side <> "No Side" Then
                receipt.AppendLine($"   Side: {item.Side}")
            End If

            receipt.AppendLine()
        Next

        receipt.AppendLine("--------------------------------")
        Dim totalLine As String = "TOTAL:"
        Dim totalPrice As String = $"₱{totalAmount:F2}"
        Dim totalSpaces As Integer = width - totalLine.Length - totalPrice.Length
        receipt.AppendLine(totalLine & New String(" "c, totalSpaces) & totalPrice)
        receipt.AppendLine()

        receipt.AppendLine(CenterText($"Payment: {paymentMethod}", width))

        If paymentMethod = "Cash" Then
            Dim paidLine As String = "Amount Paid:"
            Dim paidAmount As String = $"₱{amountPaid:F2}"
            Dim paidSpaces As Integer = width - paidLine.Length - paidAmount.Length
            receipt.AppendLine(paidLine & New String(" "c, paidSpaces) & paidAmount)

            Dim changeLine As String = "Change:"
            Dim changeAmt As String = $"₱{changeAmount:F2}"
            Dim changeSpaces As Integer = width - changeLine.Length - changeAmt.Length
            receipt.AppendLine(changeLine & New String(" "c, changeSpaces) & changeAmt)
        Else
            receipt.AppendLine(CenterText($"Reference: {If(referenceNumber, "N/A")}", width))
        End If

        receipt.AppendLine()
        receipt.AppendLine(line)
        receipt.AppendLine(CenterText("Thank you! Come again!", width))
        receipt.AppendLine(line)

        Return receipt.ToString()
    End Function

    Private Function CenterText(text As String, width As Integer) As String
        If text.Length >= width Then Return text
        Dim totalPadding As Integer = width - text.Length
        Dim leftPadding As Integer = totalPadding \ 2
        Return New String(" "c, leftPadding) & text
    End Function

    Public Sub PrintReceipt(receiptText As String)
        Try
            receiptContent = receiptText

            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintPage

            Dim printDialog As New PrintDialog()
            printDialog.Document = printDoc

            If printDialog.ShowDialog() = DialogResult.OK Then
                printDoc.Print()
            End If

        Catch ex As Exception
            MessageBox.Show("Failed to print receipt: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim font As New Font("Courier New", 10)
        Dim brush As New SolidBrush(Color.Black)

        Dim x As Single = e.MarginBounds.Left
        Dim y As Single = e.MarginBounds.Top

        Dim lines() As String = receiptContent.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)
        For Each line As String In lines
            e.Graphics.DrawString(line, font, brush, x, y)
            y += font.GetHeight(e.Graphics)
        Next

        e.HasMorePages = False
    End Sub

    Public Sub PreviewReceipt(receiptText As String)
        Dim previewForm As New Form()
        previewForm.Text = "Receipt Preview"
        previewForm.Size = New Size(400, 600)
        previewForm.StartPosition = FormStartPosition.CenterScreen

        Dim rtb As New RichTextBox()
        rtb.Dock = DockStyle.Fill
        rtb.Font = New Font("Courier New", 9)
        rtb.Text = receiptText
        rtb.ReadOnly = True

        Dim btnClose As New Button()
        btnClose.Text = "Close"
        btnClose.Dock = DockStyle.Bottom
        btnClose.Height = 40
        AddHandler btnClose.Click, Sub() previewForm.Close()

        previewForm.Controls.Add(rtb)
        previewForm.Controls.Add(btnClose)
        previewForm.ShowDialog()
    End Sub

End Module