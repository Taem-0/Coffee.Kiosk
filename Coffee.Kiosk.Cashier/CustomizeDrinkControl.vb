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

        grpIceLevel.Enabled = True
        CalculateTotal()
    End Sub

    Private Sub CalculateTotal()
        If _drink Is Nothing Then Exit Sub

        Dim sizePrice As Decimal = 0
        If rbMedium.Checked Then sizePrice = 10D
        If rbLarge.Checked Then sizePrice = 20D

        Dim toppingsPrice As Decimal = 0
        If rbVelvet.Checked Then toppingsPrice += 25
        If rbCoffeeJelly.Checked Then toppingsPrice += 25
        If rbJellyStrips.Checked Then toppingsPrice += 25
        If rbButterCreme.Checked Then toppingsPrice += 25
        If rbSeasaltCreme.Checked Then toppingsPrice += 25

        _currentPrice = _drink.BasePrice + sizePrice + toppingsPrice
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
        CloseControl()
    End Sub

    Private Sub OptionChanged(sender As Object, e As EventArgs) _
        Handles rbSmall.CheckedChanged, rbMedium.CheckedChanged, rbLarge.CheckedChanged,
                rbHot.CheckedChanged, rbIce.CheckedChanged,
                rbVelvet.CheckedChanged, rbCoffeeJelly.CheckedChanged,
                rbJellyStrips.CheckedChanged, rbButterCreme.CheckedChanged,
                rbSeasaltCreme.CheckedChanged, nudQty.ValueChanged

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

    Private Function GetSelectedToppings() As List(Of String)
        Dim toppings As New List(Of String)
        If rbVelvet.Checked Then toppings.Add("Velvet")
        If rbCoffeeJelly.Checked Then toppings.Add("Coffee Jelly")
        If rbJellyStrips.Checked Then toppings.Add("Jelly Strips")
        If rbButterCreme.Checked Then toppings.Add("Butter Creme")
        If rbSeasaltCreme.Checked Then toppings.Add("Seasalt Creme")
        Return toppings
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CloseControl()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        CloseControl()
    End Sub

    Private Sub CloseControl()
        Me.Parent.Controls.Remove(Me)
        Me.Dispose()
    End Sub

End Class
