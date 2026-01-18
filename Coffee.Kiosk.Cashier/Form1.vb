Public Class Form1
    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim frm As New Form2
        frm.Show()
        Me.Hide()
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim frm As New Form3
        frm.Show()
        Me.Hide()
    End Sub
End Class
