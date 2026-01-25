Public Class LogInForm

    Private Sub LogInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowSignIn()
    End Sub

    Public Sub ShowControl(ctrl As UserControl)
        LogInPanel.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        LogInPanel.Controls.Add(ctrl)
    End Sub

    Public Sub ShowSignIn()
        ShowControl(New SignInControl())
    End Sub

    Public Sub ShowLogin()
        ShowControl(New LogInControl())
    End Sub

    Public Sub ShowSignUp()
        ShowControl(New SignUpControl())
    End Sub

End Class
