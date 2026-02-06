Public Class CashierHome
    Public Property Username As String
    Private currentHomePage As HomePageControl
    Private Sub CashierHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowHomePage()
    End Sub
    Private Sub ShowPage(ctrl As UserControl)
        HomeScreenPanel.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        HomeScreenPanel.Controls.Add(ctrl)
    End Sub
    Public Sub ShowHomePage()
        If currentHomePage Is Nothing Then
            currentHomePage = New HomePageControl()
            currentHomePage.SetUsername(Username)
        End If
        ShowPage(currentHomePage)
    End Sub
    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        ShowHomePage()
    End Sub
    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        ShowPage(New HistoryPageControl())
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ShowPage(New SettingsPageControl())
    End Sub
    Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        If currentHomePage IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(currentHomePage.OrderList.Text) Then
            Dim result = MessageBox.Show(
                "You still have items in the order. Are you sure you want to cancel the order and sign out?",
                "Confirm Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            )
            If result = DialogResult.No Then
                Return
            End If
        End If
        Dim frm = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
        If frm Is Nothing Then frm = New LoginForm()
        frm.Show()
        Me.Close()
    End Sub
End Class