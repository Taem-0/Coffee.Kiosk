Public Class LogInForm
    Private Sub LogInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogInPanel.Controls.Clear()

        Dim login As New LogInControl()

        login.Dock = DockStyle.Fill
        LogInPanel.Controls.Add(login)

    End Sub

End Class
