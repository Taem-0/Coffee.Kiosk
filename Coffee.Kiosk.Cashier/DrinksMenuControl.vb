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

    Private Sub LoadHotCoffee()
        AddDrink("Hot Americano", 109)
        AddDrink("Hot Latte", 129)
        AddDrink("Hot Vanilla Cream", 139)
        AddDrink("Hot Cappuccino", 149)
        AddDrink("Hot Spanish Latte", 149)
        AddDrink("Hot Dark Mocha", 149)
        AddDrink("Hot Caramel Macchiato", 149)
        AddDrink("Hot Salted Caramel", 149)
        AddDrink("Hot White Chocolate Mocha", 149)
        AddDrink("Hot Dirty Matcha Latte", 159)
    End Sub

    Private Sub LoadIcedCoffee()
        AddDrink("Iced Americano", 109)
        AddDrink("Iced Latte", 119)
        AddDrink("Iced Vanilla Cream", 119)
        AddDrink("Iced Cappuccino", 129)
        AddDrink("Iced Spanish Latte", 129)
        AddDrink("Iced Dark Mocha", 139)
        AddDrink("Iced Caramel Macchiato", 139)
        AddDrink("Iced Salted Caramel", 139)
        AddDrink("Iced White Chocolate Mocha", 139)
        AddDrink("Iced Biscoff Latte", 149)
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

    Private Sub AddDrink(name As String, price As Decimal)
        Dim item As New MenuItemControl()
        item.SetData(name, price)
        FlpMenu.Controls.Add(item)
    End Sub

End Class
