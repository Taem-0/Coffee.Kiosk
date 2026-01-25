Public Class SignInControl

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim frm As LogInForm = CType(Me.FindForm(), LogInForm)
        frm.ShowLogin()
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim frm As LogInForm = CType(Me.FindForm(), LogInForm)
        frm.ShowSignUp()
    End Sub

End Class
