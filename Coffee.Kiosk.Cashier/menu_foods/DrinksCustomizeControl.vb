Public Class DrinksCustomizeControl
    Private _drink As DrinkItem
    Private _currentPrice As Decimal
    Private _isLoading As Boolean = False
    Public Event OrderAdded(order As OrderItem)
    Public Event RequestBackToMenu()

    Public Sub LoadDrink(drink As DrinkItem)
        _isLoading = True
        _drink = drink
        _currentPrice = CDec(drink.BasePrice)
        lblDrinkName.Text = drink.Name
        lblBasePrice.Text = "₱" & _currentPrice.ToString("0.00")
        grpTemp.Enabled = (drink.Category = DrinkCategory.Coffee)
        rbHot.Checked = False
        rbIce.Checked = True
        rbSmall.Checked = True
        rbMedium.Checked = False
        rbLarge.Checked = False
        rbNoSyrup.Checked = True
        rbVelvet.Checked = False
        rbCoffeeJelly.Checked = False
        rbJellyStrips.Checked = False
        rbButterCreme.Checked = False
        rbSeasaltCreme.Checked = False
        rbWhipped.Checked = False
        rb100.Checked = True
        rbStandard.Checked = True
        rbLydia.Checked = True
        grpIceLevel.Enabled = rbIce.Checked
        _isLoading = False
        CalculateTotal()
    End Sub

    Private Function GetSelectedSyrups() As List(Of String)
        Dim list As New List(Of String)
        If rbSaltedCaramel.Checked Then list.Add("Salted Caramel")
        If rbFrenchVanilla.Checked Then list.Add("French Vanilla")
        Return list
    End Function

    Private Function GetSelectedToppings() As List(Of String)
        Dim list As New List(Of String)
        If rbVelvet.Checked Then list.Add("Velvet")
        If rbCoffeeJelly.Checked Then list.Add("Coffee Jelly")
        If rbJellyStrips.Checked Then list.Add("Jelly Strips")
        If rbButterCreme.Checked Then list.Add("Butter Creme")
        If rbSeasaltCreme.Checked Then list.Add("Seasalt Creme")
        Return list
    End Function

    Private Function GetSelectedBeans() As String
        If rbLydia.Checked Then Return "Lydia"
        If rbBoss.Checked Then Return "Boss"
        Return ""
    End Function

    Private Function GetSugarLevel() As String
        If rb100.Checked Then Return "100%"
        If rb75.Checked Then Return "75%"
        If rb50.Checked Then Return "50%"
        If rb25.Checked Then Return "25%"
        If rb0.Checked Then Return "0%"
        Return "100%"
    End Function

    Private Function GetSugarType() As String
        If rbNoSugar.Checked Then Return "No Sugar"
        If rbStandard.Checked Then Return "Standard"
        If rbCane.Checked Then Return "Cane"
        If rbMuscavado.Checked Then Return "Muscovado"
        Return "Standard"
    End Function

    Private Function CalculateToppingsPrice() As Decimal
        Dim total As Decimal = 0
        If rbVelvet.Checked Then total += 25
        If rbCoffeeJelly.Checked Then total += 25
        If rbJellyStrips.Checked Then total += 25
        If rbButterCreme.Checked Then total += 25
        If rbSeasaltCreme.Checked Then total += 25
        Return total
    End Function

    Private Function CalculateSyrupPrice() As Decimal
        If rbSaltedCaramel.Checked Or rbFrenchVanilla.Checked Then Return 20
        Return 0
    End Function

    Private Function CalculateWhippedPrice() As Decimal
        If rbWhipped.Checked Then Return 20
        Return 0
    End Function

    Private Sub CalculateTotal()
        If _drink Is Nothing Then Return
        Dim sizePrice As Decimal = If(rbMedium.Checked, 10D, If(rbLarge.Checked, 20D, 0D))
        Dim toppingsPrice As Decimal = CalculateToppingsPrice()
        Dim syrupPrice As Decimal = CalculateSyrupPrice()
        Dim whippedPrice As Decimal = CalculateWhippedPrice()
        _currentPrice = _drink.BasePrice + sizePrice + toppingsPrice + syrupPrice + whippedPrice
        lblTotal.Text = "₱" & (_currentPrice * nudQty.Value).ToString("0.00")
    End Sub

    Private Sub btnAddOrder_Click(sender As Object, e As EventArgs) Handles btnAddOrder.Click
        Dim sizePrice As Decimal = If(rbMedium.Checked, 10D, If(rbLarge.Checked, 20D, 0D))
        Dim toppingsPrice As Decimal = CalculateToppingsPrice()
        Dim syrupPrice As Decimal = CalculateSyrupPrice()
        Dim whippedPrice As Decimal = CalculateWhippedPrice()

        Dim order As New OrderItem With {
        .ItemType = "Drink",
        .ItemName = _drink.Name,
        .Drink = _drink,
        .Temperature = If(rbHot.Checked, "Hot", "Iced"),
        .Size = If(rbSmall.Checked, "Small", If(rbMedium.Checked, "Medium", "Large")),
        .Beans = GetSelectedBeans(),
        .Toppings = GetSelectedToppings(),
        .Syrups = GetSelectedSyrups(),
        .WhippedCream = If(rbWhipped.Checked, "Add Whipped Cream", "No Whipped Cream"),
        .SugarLevel = GetSugarLevel(),
        .SugarType = GetSugarType(),
        .Quantity = nudQty.Value,
        .BasePrice = _drink.BasePrice,
        .SizePrice = sizePrice,
        .ToppingsPrice = toppingsPrice,
        .SyrupPrice = syrupPrice,
        .WhippedPrice = whippedPrice,
        .TotalPrice = (_drink.BasePrice + sizePrice + toppingsPrice + syrupPrice + whippedPrice) * nudQty.Value
    }

        RaiseEvent OrderAdded(order)
        RaiseEvent RequestBackToMenu()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent RequestBackToMenu()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        RaiseEvent RequestBackToMenu()
    End Sub

    Private Sub OptionChanged(sender As Object, e As EventArgs) _
        Handles rbHot.CheckedChanged, rbIce.CheckedChanged, rbSmall.CheckedChanged, rbMedium.CheckedChanged, rbLarge.CheckedChanged,
                rbVelvet.CheckedChanged, rbCoffeeJelly.CheckedChanged, rbJellyStrips.CheckedChanged, rbButterCreme.CheckedChanged, rbSeasaltCreme.CheckedChanged,
                rbSaltedCaramel.CheckedChanged, rbFrenchVanilla.CheckedChanged, rbNoSyrup.CheckedChanged, rbWhipped.CheckedChanged,
                rb100.CheckedChanged, rb75.CheckedChanged, rb50.CheckedChanged, rb25.CheckedChanged, rb0.CheckedChanged,
                rbNoSugar.CheckedChanged, rbStandard.CheckedChanged, rbCane.CheckedChanged, rbMuscavado.CheckedChanged, rbLydia.CheckedChanged, rbBoss.CheckedChanged, nudQty.ValueChanged
        If _isLoading Then Return
        CalculateTotal()
        If _drink IsNot Nothing AndAlso _drink.Category = DrinkCategory.Coffee Then
            grpIceLevel.Enabled = rbIce.Checked
        End If
    End Sub
End Class