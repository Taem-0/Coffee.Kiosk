Public Class CustomizeDrinkControl
    Private _drink As DrinkItem
    Private _currentPrice As Decimal

    Public Event OrderAdded(order As OrderItem)

    Public Sub LoadDrink(drink As DrinkItem)
        _drink = drink
        _currentPrice = drink.BasePrice
        lblDrinkName.Text = drink.Name
        lblBasePrice.Text = "₱" & _currentPrice.ToString("0.00")
        grpTemp.Enabled = (drink.Category = DrinkCategory.Coffee)
        rbIce.Checked = True
        rbHot.Checked = False
        rbSmall.Checked = True
        rbVelvet.Checked = True
        rbSaltedCaramel.Checked = True
        rbNoWhipped.Checked = True
        CalculateTotal()
    End Sub

    Private Sub CalculateTotal()
        If _drink Is Nothing Then Exit Sub
        Dim sizePrice As Decimal = 0
        If rbMedium.Checked Then sizePrice = 10
        If rbLarge.Checked Then sizePrice = 20
        Dim toppingPrice As Decimal = 0
        If rbVelvet.Checked Then toppingPrice += 25
        If rbCoffeeJelly.Checked Then toppingPrice += 25
        If rbJellyStrips.Checked Then toppingPrice += 25
        If rbButterCreme.Checked Then toppingPrice += 25
        If rbSeasaltCreme.Checked Then toppingPrice += 25
        Dim syrupPrice As Decimal = 0
        If rbSaltedCaramel.Checked Then syrupPrice += 20
        If rbFrenchVanilla.Checked Then syrupPrice += 20
        Dim whippedPrice As Decimal = 0
        If rbWhipped.Checked Then whippedPrice += 15
        _currentPrice = _drink.BasePrice + sizePrice + toppingPrice + syrupPrice + whippedPrice
        lblTotal.Text = "₱" & (_currentPrice * nudQty.Value).ToString("0.00")
    End Sub

    Private Sub btnAddOrder_Click(sender As Object, e As EventArgs) Handles btnAddOrder.Click
        Dim order As New OrderItem With {
            .Drink = _drink,
            .Temperature = If(rbHot.Checked, "Hot", "Ice"),
            .Beans = If(rbLydia.Checked, "Lydia", "Boss"),
            .Size = If(rbSmall.Checked, "12oz", If(rbMedium.Checked, "16oz", "20oz")),
            .SugarLevel = GetSugarLevel(),
            .SugarType = GetSugarType(),
            .IceLevel = GetIceLevel(),
            .Milk = If(rbDairy.Checked, "Dairy", "Non-Dairy"),
            .Toppings = GetSelectedToppings(),
            .Syrups = GetSelectedSyrups(),
            .WhippedCream = If(rbWhipped.Checked, "Add Whipped Cream", "No Whipped Cream"),
            .Quantity = nudQty.Value,
            .TotalPrice = _currentPrice * nudQty.Value
        }
        RaiseEvent OrderAdded(order)
        Me.Parent.Controls.Remove(Me)
        Me.Dispose()
    End Sub

    Private Function GetSelectedToppings() As List(Of String)
        Dim list As New List(Of String)
        If rbVelvet.Checked Then list.Add("Velvet")
        If rbCoffeeJelly.Checked Then list.Add("Coffee Jelly")
        If rbJellyStrips.Checked Then list.Add("Jelly Strips")
        If rbButterCreme.Checked Then list.Add("Butter Creme")
        If rbSeasaltCreme.Checked Then list.Add("Seasalt Creme")
        Return list
    End Function

    Private Function GetSelectedSyrups() As List(Of String)
        Dim list As New List(Of String)
        If rbSaltedCaramel.Checked Then list.Add("Salted Caramel")
        If rbFrenchVanilla.Checked Then list.Add("French Vanilla")
        Return list
    End Function

    Private Function GetSugarLevel() As String
        If rb0.Checked Then Return "0%"
        If rb25.Checked Then Return "25%"
        If rb50.Checked Then Return "50%"
        If rb75.Checked Then Return "75%"
        Return "100%"
    End Function

    Private Function GetSugarType() As String
        If rbNoSugar.Checked Then Return "No Sugar"
        If rbStandard.Checked Then Return "Standard"
        If rbCane.Checked Then Return "Cane"
        Return "Muscovado"
    End Function

    Private Function GetIceLevel() As String
        If rbNormal.Checked Then Return "Normal"
        If rbLess.Checked Then Return "Less Ice"
        Return "No Ice"
    End Function

    Private Sub OptionChanged(sender As Object, e As EventArgs) _
        Handles rbHot.CheckedChanged, rbIce.CheckedChanged,
                rbSmall.CheckedChanged, rbMedium.CheckedChanged, rbLarge.CheckedChanged,
                rbVelvet.CheckedChanged, rbCoffeeJelly.CheckedChanged, rbJellyStrips.CheckedChanged,
                rbButterCreme.CheckedChanged, rbSeasaltCreme.CheckedChanged,
                rbSaltedCaramel.CheckedChanged, rbFrenchVanilla.CheckedChanged,
                rbWhipped.CheckedChanged, rbNoWhipped.CheckedChanged,
                rb0.CheckedChanged, rb25.CheckedChanged, rb50.CheckedChanged, rb75.CheckedChanged, rb100.CheckedChanged,
                rbNoSugar.CheckedChanged, rbStandard.CheckedChanged, rbCane.CheckedChanged, rbMuscavado.CheckedChanged,
                rbNormal.CheckedChanged, rbLess.CheckedChanged, rbNoIce.CheckedChanged,
                rbDairy.CheckedChanged, rbNonDairy.CheckedChanged,
                rbLydia.CheckedChanged, rbBoss.CheckedChanged,
                nudQty.ValueChanged
        CalculateTotal()
    End Sub
End Class
