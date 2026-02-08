Public Class MealsCustomizeControl
    Private _meal As MealItem
    Private _currentPrice As Decimal
    Private _isLoading As Boolean = False
    Public Event OrderAdded(order As OrderItem)
    Public Event RequestBackToMenu()

    Public Sub LoadMeal(meal As MealItem)
        _isLoading = True
        _meal = meal
        _currentPrice = meal.BasePrice
        lblMealName.Text = meal.Name
        lblBasePrice.Text = "₱" & _currentPrice.ToString("0.00")
        rbRegularRice.Checked = True
        rbNoSide.Checked = True
        nudQty.Value = 1
        _isLoading = False
        CalculateTotal()
    End Sub

    Private Function GetRiceOption() As String
        If rbExtraRice.Checked Then Return "Extra Rice"
        Return "Regular Rice"
    End Function

    Private Function GetSideOption() As String
        If rbFries.Checked Then Return "Fries"
        If rbSalad.Checked Then Return "Salad"
        Return "No Side"
    End Function

    Private Function CalculateRicePrice() As Decimal
        If rbExtraRice.Checked Then Return 10
        Return 0
    End Function

    Private Function CalculateSidePrice() As Decimal
        If rbFries.Checked Then Return 40
        If rbSalad.Checked Then Return 40
        Return 0
    End Function

    Private Sub CalculateTotal()
        If _meal Is Nothing Then Return
        Dim ricePrice As Decimal = CalculateRicePrice()
        Dim sidePrice As Decimal = CalculateSidePrice()
        _currentPrice = _meal.BasePrice + ricePrice + sidePrice
        lblTotal.Text = "₱" & (_currentPrice * nudQty.Value).ToString("0.00")
    End Sub

    Private Sub btnAddOrder_Click(sender As Object, e As EventArgs) Handles btnAddOrder.Click
        Dim ricePrice As Decimal = CalculateRicePrice()
        Dim sidePrice As Decimal = CalculateSidePrice()

        Dim order As New OrderItem With {
            .ItemName = _meal.Name,
            .ItemType = "Meal",
            .Rice = GetRiceOption(),
            .Side = GetSideOption(),
            .Quantity = nudQty.Value,
            .BasePrice = _meal.BasePrice,
            .RicePrice = ricePrice,
            .SidePrice = sidePrice,
            .TotalPrice = (_meal.BasePrice + ricePrice + sidePrice) * nudQty.Value
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
        Handles rbRegularRice.CheckedChanged, rbExtraRice.CheckedChanged,
                rbNoSide.CheckedChanged, rbFries.CheckedChanged, rbSalad.CheckedChanged, nudQty.ValueChanged
        If _isLoading Then Return
        CalculateTotal()
    End Sub
End Class