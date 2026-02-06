Public Class DrinksCustomize

    Private _drink As DrinkItem
    Private _currentPrice As Decimal
    Public Event OrderAdded(order As OrderItem)

    Public Sub LoadDrink(drink As DrinkItem)
        _drink = drink
        _currentPrice = CDec(drink.BasePrice)
        lblDrinkName.Text = drink.Name
        lblBasePrice.Text = "₱" & _currentPrice.ToString("0.00")

        grpTemp.Enabled = (drink.Category = DrinkCategory.Coffee)
        rbHot.Checked = False
        rbIce.Checked = True

        rbSaltedCaramel.Checked = True
        rbFrenchVanilla.Checked = False

        grpIceLevel.Enabled = rbIce.Checked
        CalculateTotal()
    End Sub

    Private Function GetSelectedSyrups() As String
        If rbSaltedCaramel.Checked Then Return "Salted Caramel"
        If rbFrenchVanilla.Checked Then Return "French Vanilla"
        Return "No Syrup"
    End Function

    Private Sub CalculateTotal()
        If _drink Is Nothing Then
            lblTotal.Text = "₱0.00"
            Return
        End If

        Dim sizePrice As Decimal = 0
        If rbMedium.Checked Then sizePrice = 10D
        If rbLarge.Checked Then sizePrice = 20D

        Dim toppingsPrice As Decimal = 0
        If rbVelvet.Checked Then toppingsPrice += 25
        If rbCoffeeJelly.Checked Then toppingsPrice += 25
        If rbJellyStrips.Checked Then toppingsPrice += 25
        If rbButterCreme.Checked Then toppingsPrice += 25
        If rbSeasaltCreme.Checked Then toppingsPrice += 25

        Dim syrupPrice As Decimal = 0
        If rbSaltedCaramel.Checked Or rbFrenchVanilla.Checked Then
            syrupPrice = 20D
        End If

        _currentPrice = _drink.BasePrice + sizePrice + toppingsPrice + syrupPrice
        lblTotal.Text = "₱" & (_currentPrice * nudQty.Value).ToString("0.00")
    End Sub

    Private Sub btnAddOrder_Click(sender As Object, e As EventArgs) Handles btnAddOrder.Click
        Dim order As New OrderItem With {
            .Drink = _drink,
            .Temperature = If(rbHot.Checked, "Hot", "Iced"),
            .Size = If(rbSmall.Checked, "Small", If(rbMedium.Checked, "Medium", "Large")),
            .Toppings = GetSelectedToppings(),
            .Quantity = nudQty.Value,
            .TotalPrice = _currentPrice * nudQty.Value
        }
        RaiseEvent OrderAdded(order)
        Me.Close()
    End Sub

    Private Sub OptionChanged(sender As Object, e As EventArgs) _
    Handles rbSmall.CheckedChanged, rbMedium.CheckedChanged, rbLarge.CheckedChanged,
        rbVelvet.CheckedChanged, rbCoffeeJelly.CheckedChanged, rbJellyStrips.CheckedChanged,
        rbButterCreme.CheckedChanged, rbSeasaltCreme.CheckedChanged,
        rbSaltedCaramel.CheckedChanged, rbFrenchVanilla.CheckedChanged,
        nudQty.ValueChanged, rbHot.CheckedChanged, rbIce.CheckedChanged

        If _drink Is Nothing Then Exit Sub
        If _drink.Category = DrinkCategory.Coffee Then
            grpIceLevel.Enabled = rbIce.Checked
        Else
            rbHot.Checked = False
            rbIce.Checked = True
            grpIceLevel.Enabled = True
        End If
        CalculateTotal()
    End Sub

End Class
