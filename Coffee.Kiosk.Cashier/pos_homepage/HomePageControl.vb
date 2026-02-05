Public Class HomePageControl

    Public Sub SetUsername(name As String)
        lblUsername.Text = "Staff Name: " & name
    End Sub

    Private Sub FilterMenu(keyword As String)
        If MenuPanel.Controls.Count = 0 Then Exit Sub
        Dim menuCtrl = TryCast(MenuPanel.Controls(0), UserControl)
        If menuCtrl Is Nothing Then Exit Sub
        Dim flp = menuCtrl.Controls.OfType(Of FlowLayoutPanel)().FirstOrDefault()
        If flp Is Nothing Then Exit Sub
        For Each btn As Button In flp.Controls.OfType(Of Button)()
            btn.Visible = btn.Text.ToLower().Contains(keyword.ToLower())
        Next
    End Sub

    Private Sub btnDrinks_Click(sender As Object, e As EventArgs) Handles btnDrinks.Click
        ShowMenu(New DrinksMenuControl())
    End Sub

    Private Sub btnPastry_Click(sender As Object, e As EventArgs) Handles btnPastry.Click
        ShowMenu(New PastryMenuControl())
    End Sub

    Private Sub btnSnacks_Click(sender As Object, e As EventArgs) Handles btnSnacks.Click
        ShowMenu(New SnacksMenuControl())
    End Sub

    Private Sub btnMeals_Click(sender As Object, e As EventArgs) Handles btnMeals.Click
        ShowMenu(New MealsMenuControl())
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterMenu(txtSearch.Text)
    End Sub
End Class
