Public Class LogInControl

    Private Const DEFAULT_PASSWORD As String = "CafeFilipino1234"

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If username = "" OrElse password = "" Then
            MessageBox.Show("Please enter username and password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If username <> DEFAULT_USERNAME OrElse password <> DEFAULT_PASSWORD Then
            MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim cashier As New CashierHome()
        cashier.Username = username
        cashier.Show()

        Dim frm As LogInForm = CType(Me.FindForm(), LogInForm)
        frm.Hide()
    End Sub

End Class
