Public Class LogInControl
    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim cashier As New CashierHome()
        cashier.Show()

        Dim frm As LogInForm = CType(Me.FindForm(), LogInForm)
        frm.Hide()
    End Sub
End Class
