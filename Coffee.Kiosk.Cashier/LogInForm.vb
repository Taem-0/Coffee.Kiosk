Public Class LogInForm

    Private Sub LogInForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowSignInControl()
    End Sub

    Public Sub ShowSignInControl()
        LogInPanel.Controls.Clear()

        Dim signIn As New SignInControl()
        signIn.Dock = DockStyle.Fill

        LogInPanel.Controls.Add(signIn)
    End Sub

    Public Sub ShowLogInControl()
        LogInPanel.Controls.Clear()

        Dim login As New LogInControl()
        login.Dock = DockStyle.Fill

        LogInPanel.Controls.Add(login)
    End Sub

    Public Sub ShowSignUpControl()
        LogInPanel.Controls.Clear()

        Dim signUp As New SignUpControl()
        signUp.Dock = DockStyle.Fill

        LogInPanel.Controls.Add(signUp)
    End Sub

End Class
