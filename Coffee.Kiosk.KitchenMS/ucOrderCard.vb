Public Class ucOrderCard

    Private Sub ucOrderCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnFinish.Enabled = False
    End Sub


    Private orderStartTime As DateTime


    Public Sub SetOrderTime(orderTime As DateTime)
        orderStartTime = orderTime
        lblTimeOrder.Text = orderTime.ToString("HH:mm")


        tmrWait.Start()
    End Sub


    Private Sub tmrWait_Tick(sender As Object, e As EventArgs) Handles tmrWait.Tick
        Dim elapsed As TimeSpan = DateTime.Now - orderStartTime

        lblWaitTime.Text = elapsed.Minutes.ToString("00") & ":" &
                       elapsed.Seconds.ToString("00")
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        SetStatusPreparing()
    End Sub

    Private Sub SetStatusPreparing()
        Panel2.BackColor = Color.FromArgb(0, 180, 0)
        Panel3.BackColor = Color.FromArgb(0, 180, 0)
        lblOrderNumber.ForeColor = Color.White
        lblPlaceEat.ForeColor = Color.White
        lblTimeOrder.ForeColor = Color.White
        lblWaitTime.ForeColor = Color.White
        btnFinish.Enabled = True
        btnStart.Enabled = False

    End Sub

    Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to finish this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then

            Me.Visible = False

            Dim parentForm As FrmKitchenDisplay = TryCast(Me.FindForm(), FrmKitchenDisplay)
            If parentForm IsNot Nothing Then
                parentForm.UpdateActiveOrders()
            End If
        End If
    End Sub

End Class
