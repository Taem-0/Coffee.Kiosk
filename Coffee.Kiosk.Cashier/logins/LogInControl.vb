Imports System.IO

Public Class LogInControl
    Private Const DEFAULT_PASSWORD As String = "CafeFilipino1234"
    Private usersFile As String = "users.txt"

    Private Sub LogInControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
        If Not File.Exists(usersFile) Then
            Dim defaultUsers As String() = {
                "Louie Jein Banting|" & DEFAULT_PASSWORD & "|True",
                "Rex Taeza|" & DEFAULT_PASSWORD & "|True",
                "Michael Litang|" & DEFAULT_PASSWORD & "|True",
                "Bernadette Lalata|" & DEFAULT_PASSWORD & "|True",
                "Dwaye Ruper Casenillo|" & DEFAULT_PASSWORD & "|True"
            }
            File.WriteAllLines(usersFile, defaultUsers)
        End If
    End Sub

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim username = txtUsername.Text.Trim()
        Dim password = txtPassword.Text.Trim()
        If username = "" OrElse password = "" Then MessageBox.Show("Enter username and password") : Return
        Dim lines = File.ReadAllLines(usersFile).ToList()
        For i = 0 To lines.Count - 1
            Dim parts = lines(i).Split("|")
            Dim fileUser = parts(0)
            Dim filePass = parts(1)
            Dim isDefault = Boolean.Parse(parts(2))
            If fileUser = username Then
                If filePass <> password Then MessageBox.Show("Wrong password") : Return
                If isDefault Then
                    Dim newPass = InputBox("Change your password:", "Change Password")
                    If String.IsNullOrWhiteSpace(newPass) Then Return
                    lines(i) = username & "|" & newPass & "|False"
                    File.WriteAllLines(usersFile, lines)
                End If
                Dim home As New CashierHome()
                home.Username = username
                home.Show()
                Me.FindForm().Hide()
                Return
            End If
        Next
        MessageBox.Show("User not found")
    End Sub

    Private Sub lnkForgot_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkForgot.LinkClicked
        Dim username = txtUsername.Text.Trim()
        If username = "" Then MessageBox.Show("Enter username first") : Return
        Dim lines = File.ReadAllLines(usersFile).ToList()
        For i = 0 To lines.Count - 1
            Dim parts = lines(i).Split("|")
            If parts(0) = username Then
                lines(i) = username & "|" & DEFAULT_PASSWORD & "|True"
                File.WriteAllLines(usersFile, lines)
                MessageBox.Show("Password reset to default: " & DEFAULT_PASSWORD)
                Return
            End If
        Next
        MessageBox.Show("User not found")
    End Sub

    Private Sub btnSee_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSee.MouseDown
        txtPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub btnSee_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSee.MouseUp
        txtPassword.UseSystemPasswordChar = True
    End Sub
End Class
