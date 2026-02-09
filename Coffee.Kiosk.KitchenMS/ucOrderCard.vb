Imports System.Drawing.Drawing2D

Public Class ucOrderCard



    Private Sub ucOrderCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnFinish.Enabled = False
        'Panel2.BackColor = Color.FromArgb(201, 185, 159)
        'Panel3.BackColor = Color.FromArgb(201, 185, 159)

        lstBxOrder.Items.Add("Latte (Medium)        x1")
        lstBxOrder.Items.Add("Cappuccino (Large)    x1")
        lstBxOrder.Items.Add("Americano (Small)     x1")
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

        'Dim result As DialogResult = MessageBox.Show("Are you sure you want to finish this order?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If result = DialogResult.Yes Then

        Me.Visible = False

        Dim parentForm As FrmKitchenDisplay = TryCast(Me.FindForm(), FrmKitchenDisplay)
        If parentForm IsNot Nothing Then
            parentForm.UpdateActiveOrders()
        End If
        'End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint


    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint



    End Sub

    Public Sub lstBxOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBxOrder.SelectedIndexChanged



    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim radius As Integer = 5
        Dim pnl As Panel = CType(sender, Panel)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As Rectangle = pnl.ClientRectangle
        rect.Width -= 1
        rect.Height -= 1

        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2

        ' Top-left
        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        ' Top-right
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        ' Bottom-right
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        ' Bottom-left
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)

        path.CloseFigure()

        pnl.Region = New Region(path)
    End Sub


End Class
