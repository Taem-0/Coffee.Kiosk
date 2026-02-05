Public Class OrderItem
    Public Property Drink As DrinkItem
    Public Property Temperature As String
    Public Property Size As String
    Public Property Toppings As List(Of String)
    Public Property Quantity As Integer
    Public Property TotalPrice As Decimal

    Public ReadOnly Property DisplayName As String
        Get
            Dim temp = If(String.IsNullOrEmpty(Temperature), "", Temperature & " ")
            Dim toppingsText = If(Toppings IsNot Nothing AndAlso Toppings.Count > 0,
                                 " [" & String.Join(", ", Toppings) & "]", "")
            Return $"{Quantity}x {temp}{Drink.Name}{toppingsText}"
        End Get
    End Property
End Class
