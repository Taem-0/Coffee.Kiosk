Public Class MealsMenuControl
    Public Event MealSelected(meal As MealItem)
    Private Sub MealsMenuControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlpMenu.Controls.Clear()
        LoadAllDayBreakfast()
        LoadRiceMeals()
        LoadBurgers()
        LoadComboMeals()
    End Sub

    Private Sub LoadAllDayBreakfast()
        AddMeal("Bacon & Egg", 139)
        AddMeal("Tocino & Egg", 129)
        AddMeal("Longganisa & Egg", 139)
        AddMeal("Jumbo Sausage & Egg", 129)
        AddMeal("Cheesy Sausage & Egg", 139)
        AddMeal("Corned Beef & Egg", 139)
        AddMeal("Chicken Fingers & Egg", 139)
        AddMeal("Bangus & Egg", 139)
        AddMeal("Porkchop & Egg", 139)
    End Sub

    Private Sub LoadRiceMeals()
        AddMeal("Fried Chicken Rice Meal", 149)
        AddMeal("Chicken Fingers Rice Meal", 139)
        AddMeal("Bangus Rice Meal", 144)
        AddMeal("Porkchop Rice Meal", 144)
        AddMeal("Corned Beef Rice Meal", 144)
        AddMeal("Tocino Rice Meal", 144)
    End Sub

    Private Sub LoadBurgers()
        AddMeal("Special Burger", 129)
        AddMeal("Chicken Burger", 109)
        AddMeal("Aloha Burger", 109)
        AddMeal("Jalapeno Burger", 149)
        AddMeal("Bacon Burger", 189)
        AddMeal("Overload Burger", 199)
    End Sub

    Private Sub LoadComboMeals()
        AddMeal("Burger + Fries", 159)
        AddMeal("Burger + Fries + Drink", 199)
        AddMeal("Chicken Fingers + Fries", 159)
        AddMeal("Breakfast Combo", 179)
    End Sub

    Private Sub AddMeal(mealName As String, price As Integer)
        Dim btn As New Button()
        btn.Width = 205
        btn.Height = 66
        btn.Text = mealName & vbCrLf & "₱" & price
        btn.Tag = price
        btn.BackColor = Color.FromArgb(111, 77, 56)
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        AddHandler btn.Click, AddressOf Meal_Click
        FlpMenu.Controls.Add(btn)
    End Sub

    Private Sub Meal_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim mealName As String = btn.Text.Split(vbCrLf)(0)
        Dim price As Decimal = CDec(btn.Tag)
        Dim meal As New MealItem With {
            .Name = mealName,
            .BasePrice = price
        }
        RaiseEvent MealSelected(meal)
    End Sub

End Class