Public Class SignUpControl
    Private Sub llblLogInAcc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblLogInAcc.LinkClicked
        Dim frm As LogInForm = TryCast(Me.FindForm(), LogInForm)

        If frm IsNot Nothing Then
            frm.ShowLogInControl()
        End If
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim frm As LogInForm = TryCast(Me.FindForm(), LogInForm)

        If frm IsNot Nothing Then
            frm.ShowSignInControl()
        End If
    End Sub
End Class
