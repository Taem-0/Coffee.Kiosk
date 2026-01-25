Public Class MenuItemControl

    Public Property ItemName As String
    Public Property Price As Decimal

    Public Sub SetData(name As String, price As Decimal)
        ItemName = name
        Me.Price = price
        lblName.Text = name
        lblPrice.Text = "₱" & price.ToString("0.00")
    End Sub

End Class