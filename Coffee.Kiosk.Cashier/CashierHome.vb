Public Class CashierHome
    Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        Dim frm As New LoginForm

        frm.Show()
        Me.Hide()
    End Sub
End Class