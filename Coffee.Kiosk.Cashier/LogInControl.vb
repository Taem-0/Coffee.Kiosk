Public Class LogInControl
    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim frm As New CashierHome

        frm.Show()
        Me.Hide()
    End Sub
End Class
