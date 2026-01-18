Public Class Form3
    Private Sub btnSignUp2_Click(sender As Object, e As EventArgs) Handles btnSignUp2.Click
        Dim frm As New Form1

        frm.Show()
        Me.Hide()
    End Sub

    Private Sub llblAccount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblAccount.LinkClicked
        Dim frm As New Form2

        frm.Show()
        Me.Hide()
    End Sub
End Class