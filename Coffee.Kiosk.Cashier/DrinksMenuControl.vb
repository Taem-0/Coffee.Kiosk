Public Class DrinksMenuControl

    Private Sub DrinksMenuControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlpMenu.Controls.Clear()
        LoadHotCoffee()
        LoadIcedCoffee()
        LoadMilkTea()
        LoadFruitTea()
        LoadFrappuccino()
        LoadNonCoffee()
    End Sub

    Private Sub LoadCoffee()
        AddDrink("Americano", 109, DrinkCategory.Coffee)
        AddDrink("Latte", 129, DrinkCategory.Coffee)
        AddDrink("Vanilla Cream", 139, DrinkCategory.Coffee)
        AddDrink("Cappuccino", 149, DrinkCategory.Coffee)
        AddDrink("Spanish Latte", 149, DrinkCategory.Coffee)
        AddDrink("Dark Mocha", 149, DrinkCategory.Coffee)
        AddDrink("Caramel Macchiato", 149, DrinkCategory.Coffee)
        AddDrink("Salted Caramel", 149, DrinkCategory.Coffee)
        AddDrink("White Chocolate Mocha", 149, DrinkCategory.Coffee)
        AddDrink("Dirty Matcha Latte", 159, DrinkCategory.Coffee)
        AddDrink("Biscoff Latte", 149, DrinkCategory.Coffee)
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
        AddDrink("Hot Dark Chocolate", 139)
        AddDrink("Hot White Chocolate", 139)
        AddDrink("Hot Matcha Latte", 149)
        AddDrink("Iced Dark Chocolate", 139)
        AddDrink("Iced White Chocolate", 139)
        AddDrink("Iced Matcha Latte", 149)
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
    End Sub

End Class
