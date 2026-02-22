Public Class Monitoring_buttons
    Private Sub Monitoring_buttons_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnPreparing_Click(sender As Object, e As EventArgs) Handles btnPreparing.Click
        If MessageBox.Show("Set to PREPARING?",
                       "Confirm",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then

            btnPreparing.Enabled = False
            btnPreparing.Text = "ON GOING/TAKEN"
            btnPreparing.BackColor = Color.DarkOrange
            btnPreparing.ForeColor = Color.White
        End If
    End Sub

    Private Sub btnReady_Click(sender As Object, e As EventArgs) Handles btnReady.Click
        If MessageBox.Show("Set to READY FOR PICK UP?",
                   "Confirm",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) = DialogResult.Yes Then

            btnReady.Enabled = False
            btnReady.Text = "PENDING/TAKEN"
            btnReady.BackColor = Color.SeaGreen
            btnReady.ForeColor = Color.White
        End If
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        Dim parentPanel As Panel = Me.Parent
        If MessageBox.Show("Mark this order as COMPLETE?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Remove the whole order panel from its container
            parentPanel.Controls.Remove(Me)
            Me.Dispose()
        End If

    End Sub
End Class
