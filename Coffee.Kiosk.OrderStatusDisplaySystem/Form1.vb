Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f2 As New Form2()
        f2.Show()
        Me.Hide()
    End Sub
End Class
