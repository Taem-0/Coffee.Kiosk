Public Class SignInControl
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim frm As LoginForm = TryCast(Me.FindForm(), LoginForm)

        If frm IsNot Nothing Then
            frm.ShowLogInControl()
        End If

    End Sub

    Private Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Dim frm As LogInForm = TryCast(Me.FindForm(), LogInForm)

        If frm IsNot Nothing Then
            frm.ShowSignUpControl()
        End If
    End Sub
End Class
