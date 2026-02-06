Public Class LogInForm
    Private Sub LogInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogInPanel.Controls.Clear()
        Dim login As New LogInControl()
        login.Dock = DockStyle.Fill

    End Sub

End Class
