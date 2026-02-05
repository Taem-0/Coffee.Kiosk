Public Class CashierHome

    Public Username As String

    Private Sub CashierHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowHomePage()
    End Sub

    Private Sub ShowPage(ctrl As UserControl)
        HomeScreenPanel.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        HomeScreenPanel.Controls.Add(ctrl)
    End Sub

    Public Sub ShowHomePage()
        ShowPage(New HomePageControl())
    End Sub

    Public Sub ShowHistoryPage()
        ShowPage(New HistoryPageControl())
    End Sub

    Public Sub ShowSettingsPage()
        ShowPage(New SettingsPageControl())
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        ShowHomePage()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        ShowHistoryPage()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ShowSettingsPage()
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        Dim frm As New LogInForm()
        frm.Show()
        Me.Close()
    End Sub

End Class
