Public Class Form4
    Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        Dim frm As New Form1

        frm.Show()
        Me.Hide()
    End Sub
End Class