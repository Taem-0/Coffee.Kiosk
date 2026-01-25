Public Class SnacksMenuControl

    Private Sub SnacksMenuControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlpMenu.Controls.Clear()
        LoadSnacks()
    End Sub

    Private Sub LoadSnacks()
        AddSnack("Special Cheese Sticks", 49)
        AddSnack("Regular Fries", 69)
        AddSnack("Special Potato Fries", 99)
        AddSnack("Corndog", 69)
        AddSnack("Hotdog Sandwich", 99)
        AddSnack("Chicken Fingers (Snack)", 159)
    End Sub

    Private Sub AddSnack(name As String, price As Decimal)
        Dim item As New MenuItemControl()
        item.SetData(name, price)
        FlpMenu.Controls.Add(item)
    End Sub

End Class
