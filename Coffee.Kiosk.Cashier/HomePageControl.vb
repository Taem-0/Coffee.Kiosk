Public Class HomePageControl

    Private Sub ShowMenu(ctrl As UserControl)
        MenuPanel.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        MenuPanel.Controls.Add(ctrl)
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

End Class
