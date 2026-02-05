Public Class OrderItem
    Public Property Drink As DrinkItem
    Public Property Temperature As String
    Public Property Beans As String
    Public Property Size As String
    Public Property SugarLevel As String
    Public Property SugarType As String
    Public Property IceLevel As String
    Public Property Milk As String
    Public Property Toppings As List(Of String)
    Public Property Syrups As List(Of String)
    Public Property WhippedCream As String
    Public Property Quantity As Decimal
    Public Property TotalPrice As Decimal

    Public ReadOnly Property DisplayName As String
        Get
            Dim name = Drink.Name
            If Toppings IsNot Nothing AndAlso Toppings.Count > 0 Then name &= " (" & String.Join(", ", Toppings) & ")"
            If Syrups IsNot Nothing AndAlso Syrups.Count > 0 Then name &= " [" & String.Join(", ", Syrups) & "]"
            If WhippedCream IsNot Nothing Then name &= " {" & WhippedCream & "}"
            Return name
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return $"{DisplayName} x{Quantity} - ₱{TotalPrice:0.00}"
    End Function
End Class
