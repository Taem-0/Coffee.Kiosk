Imports Guna.UI2.WinForms
Imports TheArtOfDevHtmlRenderer.Adapters.Entities

Public Class frmConfirm

    Public Property UserConfirmed As Boolean = False

    Private Sub frmConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(49, 51, 51)
        Me.TransparencyKey = Color.FromArgb(49, 51, 51)


        btnYes.FillColor = Color.FromArgb(192, 57, 43)
        btnYes.ForeColor = Color.White
        btnYes.BorderRadius = 10

        btnNo.FillColor = Color.FromArgb(33, 176, 23)
        btnNo.ForeColor = Color.White
        btnNo.BorderRadius = 10


        'lblMessage.ForeColor = Color.FromArgb(30, 30, 30)
        'lblMessage.BackColor = Color.Transparent

        ' fix magenta showing behind button corners
        pnlBackground.FillColor = Color.White
        btnYes.Parent = pnlBackground
        btnNo.Parent = pnlBackground
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        UserConfirmed = True
        Me.Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        UserConfirmed = False
        Me.Close()
    End Sub

    Private Sub frmConfirm_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        UserConfirmed = False
        Me.Close()
    End Sub

    Private Sub pnlBackground_Paint(sender As Object, e As PaintEventArgs) Handles pnlBackground.Paint

    End Sub
End Class