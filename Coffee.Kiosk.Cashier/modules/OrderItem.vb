Public Class OrderItem
    Public Property OrderNumber As Integer
    Public Property ItemType As String
    Public Property ItemName As String
    Public Property Quantity As Decimal
    Public Property BasePrice As Decimal
    Public Property TotalPrice As Decimal
    Public Property Drink As DrinkItem
    Public Property Temperature As String
    Public Property Size As String
    Public Property Beans As String
    Public Property Toppings As List(Of String)
    Public Property Syrups As List(Of String)
    Public Property WhippedCream As String
    Public Property SugarLevel As String
    Public Property SugarType As String
    Public Property SizePrice As Decimal
    Public Property ToppingsPrice As Decimal
    Public Property SyrupPrice As Decimal
    Public Property WhippedPrice As Decimal
    Public Property Rice As String
    Public Property Side As String
    Public Property RicePrice As Decimal
    Public Property SidePrice As Decimal

    Public Function ToDisplayText() As String
        Dim lines As New List(Of String)
        lines.Add($"[BOLD]ORDER #{OrderNumber}[/BOLD]")

        If ItemType = "Drink" Then
            lines.Add($"[BOLD]{ItemName}[/BOLD]")
            lines.Add($"  Qty: {Quantity}")
            lines.Add("")
            lines.Add($"  Temperature    : {Temperature}")
            lines.Add($"  Size           : {Size} {FormatPrice(SizePrice)}")
            If Not String.IsNullOrEmpty(Beans) Then lines.Add($"  Beans          : {Beans}")
            If Toppings IsNot Nothing AndAlso Toppings.Count > 0 Then
                lines.Add($"  Toppings       : {String.Join(", ", Toppings)}")
                lines.Add($"                   {FormatPrice(ToppingsPrice)}")
            Else
                lines.Add("  Toppings       : None")
            End If
            If Syrups IsNot Nothing AndAlso Syrups.Count > 0 Then
                lines.Add($"  Syrups         : {String.Join(", ", Syrups)}")
                lines.Add($"                   {FormatPrice(SyrupPrice)}")
            Else
                lines.Add("  Syrups         : None")
            End If
            lines.Add($"  Whipped Cream  : {If(WhippedPrice > 0, "Yes", "No")} {FormatPrice(WhippedPrice)}")
            lines.Add($"  Sugar Type     : {SugarType}")
            lines.Add($"  Sugar Level    : {SugarLevel}")
        ElseIf ItemType = "Meal" Then
            lines.Add($"[BOLD]{ItemName}[/BOLD]")
            lines.Add($"  Qty: {Quantity}")
            lines.Add("")
            lines.Add($"  Rice           : {Rice} {FormatPrice(RicePrice)}")
            lines.Add($"  Side Dish      : {Side} {FormatPrice(SidePrice)}")
        Else
            lines.Add($"[BOLD]{ItemName}[/BOLD]")
            lines.Add($"  Qty: {Quantity}")
            lines.Add($"  Price: ₱{BasePrice:0.00}")
        End If

        lines.Add("")
        lines.Add($"[BOLD]  ITEM TOTAL     : ₱{TotalPrice:0.00}[/BOLD]")
        Return String.Join(vbCrLf, lines)
    End Function

    Private Function FormatPrice(price As Decimal) As String
        If price > 0 Then
            Return $"+₱{price:0.00}"
        End If
        Return ""
    End Function
End Class