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

End Class
