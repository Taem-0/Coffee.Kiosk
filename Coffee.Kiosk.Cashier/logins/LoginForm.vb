Public Class LogInForm

    Private Sub LogInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowLogInControl()
    End Sub


    Public Sub ShowLogInControl()
        LogInPanel.Controls.Clear()

        Dim login As New LogInControl()
        login.Dock = DockStyle.Fill

        LogInPanel.Controls.Add(login)
    End Sub

End Class
