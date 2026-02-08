Public Class SnacksMenuControl
    Public Event SnackSelected(snack As SimpleItem)
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

    Private Sub AddSnack(snackName As String, price As Integer)
        Dim btn As New Button()
        btn.Width = 205
        btn.Height = 66
        btn.Text = snackName & vbCrLf & "₱" & price
        btn.Tag = price
        btn.BackColor = Color.FromArgb(111, 77, 56)
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        AddHandler btn.Click, AddressOf Snack_Click
        FlpMenu.Controls.Add(btn)
    End Sub

    Private Sub Snack_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim snackName As String = btn.Text.Split(vbCrLf)(0)
        Dim price As Decimal = CDec(btn.Tag)
        Dim snack As New SimpleItem With {
            .Name = snackName,
            .Price = price,
            .ItemType = "Snack"
        }
        RaiseEvent SnackSelected(snack)
    End Sub

End Class