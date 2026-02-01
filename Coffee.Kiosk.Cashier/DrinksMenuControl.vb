Public Class DrinksMenuControl

    Private Sub DrinksMenuControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlpMenu.Controls.Clear()
        LoadCoffee()
        LoadMilkTea()
        LoadFruitTea()
        LoadFrappuccino()
        LoadNonCoffee()
    End Sub

    Private Sub LoadCoffee()
        AddDrink("Americano", 109)
        AddDrink("Latte", 129)
        AddDrink("Vanilla Cream", 139)
        AddDrink("Cappuccino", 149)
        AddDrink("Spanish Latte", 149)
        AddDrink("Dark Mocha", 149)
        AddDrink("Caramel Macchiato", 149)
        AddDrink("Salted Caramel", 149)
        AddDrink("White Chocolate Mocha", 149)
        AddDrink("Dirty Matcha Latte", 159)
        AddDrink("Biscoff Latte", 149)
    End Sub

    Private Sub LoadMilkTea()
        AddDrink("Pearl Milk Tea", 99)
        AddDrink("Wintermelon Milk Tea", 99)
        AddDrink("Okinawa Milk Tea", 99)
        AddDrink("Taro Milk Tea", 99)
        AddDrink("Matcha Milk Tea", 99)
        AddDrink("Dark Choco Milk Tea", 99)
        AddDrink("Cookies & Cream Milk Tea", 99)
        AddDrink("Strawberry Milk Tea", 99)
    End Sub

    Private Sub LoadFruitTea()
        AddDrink("Grapes Fruit Tea", 89)
        AddDrink("Mango Fruit Tea", 89)
        AddDrink("Lemon Fruit Tea", 89)
        AddDrink("Lychee Fruit Tea", 89)
        AddDrink("Passionfruit Tea", 89)
        AddDrink("Strawberry Fruit Tea", 89)
        AddDrink("Blueberry Fruit Tea", 89)
    End Sub

    Private Sub LoadFrappuccino()
        AddDrink("Coffee Frappuccino", 149)
        AddDrink("Caramel Frappuccino", 149)
        AddDrink("Salted Caramel Frappuccino", 149)
        AddDrink("Java Chip Frappuccino", 149)
        AddDrink("Dark Mocha Frappuccino", 149)
        AddDrink("White Mocha Frappuccino", 149)
        AddDrink("Matcha Frappuccino", 139)
        AddDrink("Strawberry Creme Frappuccino", 139)
        AddDrink("Lotus Biscoff Frappuccino", 189)
        AddDrink("Nutella Frappuccino", 179)
    End Sub

    Private Sub LoadNonCoffee()
        AddDrink("Dark Chocolate", 139)
        AddDrink("White Chocolate", 139)
        AddDrink("Matcha Latte", 149)
        AddDrink("Strawberry Matcha Latte", 159)
        AddDrink("Ube Latte", 159)
    End Sub

    Private Sub AddDrink(drinkName As String, price As Integer)
        Dim btn As New Button()
        btn.Width = 205
        btn.Height = 66
        btn.Text = drinkName & vbCrLf & "₱" & price
        btn.Tag = price
        btn.BackColor = Color.FromArgb(111, 77, 56)
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        AddHandler btn.Click, AddressOf Drink_Click
        FlpMenu.Controls.Add(btn)
    End Sub

    Private Sub Drink_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim drinkName As String = btn.Text.Split(vbCrLf)(0)
        Dim price As Decimal = CDec(btn.Tag)
        Dim drink As New DrinkItem With {
            .Name = drinkName,
            .BasePrice = price,
            .Category = GetDrinkCategory(drinkName)
        }
        Dim customizeForm As New DrinksCustomize()
        customizeForm.LoadDrink(drink)
        AddHandler customizeForm.OrderAdded, AddressOf HandleOrderAdded
        customizeForm.ShowDialog()
    End Sub

    Private Function GetDrinkCategory(drinkName As String) As DrinkCategory
        If drinkName.Contains("Latte") Or drinkName.Contains("Mocha") Or drinkName.Contains("Americano") Or drinkName.Contains("Cappuccino") Or drinkName.Contains("Macchiato") Then
            Return DrinkCategory.Coffee
        ElseIf drinkName.Contains("Milk Tea") Then
            Return DrinkCategory.MilkTea
        ElseIf drinkName.Contains("Fruit Tea") Then
            Return DrinkCategory.FruitTea
        ElseIf drinkName.Contains("Frappuccino") Then
            Return DrinkCategory.Frappuccino
        Else
            Return DrinkCategory.NonCoffee
        End If
    End Function

    Private Sub HandleOrderAdded(order As OrderItem)
        MessageBox.Show($"Added {order.Quantity}x {order.Drink.Name} ({order.Temperature}, {order.Size}) to the order!")
    End Sub

End Class
