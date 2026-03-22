Public Class ucOrderCard

    ' -------------------------------------------------------
    ' EVENT
    ' -------------------------------------------------------
    Public Event OnOrderCompleted(card As ucOrderCard, orderId As Integer)

    ' -------------------------------------------------------
    ' PRIVATE VARIABLES
    ' -------------------------------------------------------
    Private _orderId As Integer
    Private _elapsedSeconds As Integer = 0
    Private _totalWaitSeconds As Integer = 0
    Private _isStarted As Boolean = False
    Private _borderColor As Color = Color.FromArgb(80, 50, 20)

    ' -------------------------------------------------------
    ' COLORS — based on the reference image
    Private Shared ReadOnly ColorHeaderBrown As Color = Color.FromArgb(92, 51, 23)      ' #5C3317 dark coffee brown
    Private Shared ReadOnly ColorFooter As Color = Color.FromArgb(255, 255, 255)      ' #5C3317 dark coffee brow
    Private Shared ReadOnly ColorBodyCream As Color = Color.FromArgb(255, 255, 255)     ' #F5ECD7 warm cream
    Private Shared ReadOnly ColorBorderBrown As Color = Color.FromArgb(92, 51, 23)      ' #5C3317 same as header
    Private Shared ReadOnly ColorOrangeTimer As Color = Color.FromArgb(193, 127, 58)    ' #C17F3A warning orange
    Private Shared ReadOnly ColorRedTimer As Color = Color.FromArgb(192, 57, 43)        ' #C0392B urgent red


    ' -------------------------------------------------------
    ' CONSTRUCTOR — add this right here
    ' -------------------------------------------------------
    Public Sub New()
        InitializeComponent()

        Me.SetStyle(ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.DoubleBuffered = True

        ' hide scrollbar but keep mouse wheel scrolling
        pnlBody.AutoScroll = False
        flpItems.AutoScroll = True
        AddHandler flpItems.MouseWheel, AddressOf flpItems_MouseWheel
    End Sub

    ' -------------------------------------------------------
    ' STEP A: load order data into the card
    ' -------------------------------------------------------
    Public Sub LoadOrder(order As Order)
        _orderId = order.OrderId
        ApplyRoundedCorners()

        ' header info
        lblOrderNumber.Text = "Order #" & order.OrderNumber
        lblOrderTime.Text = order.OrderTime.ToString("HH:mm")

        ' order type badge color
        ' order type badge
        lblOrderType.Text = If(String.IsNullOrEmpty(order.OrderType), "DINE IN", order.OrderType.ToUpper())
        Dim orderType As String = If(String.IsNullOrEmpty(order.OrderType), "dinein", order.OrderType.ToLower())


        ' button default — cream bg, brown border
        btnAction.Text = "Start"
        btnAction.BorderColor = Color.Black
        btnAction.BorderSize = 1


        ' apply default color
        SetCardColor(
    header:=ColorHeaderBrown,
    footer:=ColorFooter,
    border:=ColorBorderBrown
)
        ' 5 mins per quantity instead of per item
        Dim totalQuantity As Integer = 0
        For Each item In order.Items
            totalQuantity += item.Quantity
        Next
        _totalWaitSeconds = totalQuantity * 300

        ' calculate elapsed seconds since order was placed
        _elapsedSeconds = CInt((DateTime.Now - order.OrderTime).TotalSeconds)

        ' show current elapsed time immediately
        UpdateTimerDisplay()

        ' load items into flpItems
        flpItems.Controls.Clear()
        flpItems.Controls.Clear()
        flpItems.AutoScroll = False
        flpItems.HorizontalScroll.Maximum = 0
        flpItems.HorizontalScroll.Enabled = False
        flpItems.HorizontalScroll.Visible = False
        flpItems.VerticalScroll.Maximum = 0
        flpItems.VerticalScroll.Enabled = False
        flpItems.VerticalScroll.Visible = False
        flpItems.AutoScroll = True
        For Each item In order.Items
            Dim uc As New ucOrderItem()
            uc.LoadItem(item)
            flpItems.Controls.Add(uc)
        Next

        ' button default state
        btnAction.Text = "Start"
        btnAction.BorderColor = Color.Black
        btnAction.BorderSize = 1

        ' apply default brown color
        SetCardColor(
    header:=ColorHeaderBrown,
    footer:=ColorFooter,
    border:=ColorBorderBrown
)

        ' start timer immediately from order time
        tmrWait.Interval = 1000
        tmrWait.Start()   ' <-- changed from Stop() to Start()
    End Sub

    ' -------------------------------------------------------
    ' STEP B: tick every second
    ' -------------------------------------------------------
    Private Sub tmrWait_Tick(sender As Object, e As EventArgs) Handles tmrWait.Tick
        _elapsedSeconds += 1
        UpdateTimerDisplay()

        Dim halfWait As Integer = _totalWaitSeconds \ 2

        If _elapsedSeconds >= _totalWaitSeconds Then
            ' URGENT — red
            pnlHeader.BackColor = Color.FromArgb(192, 57, 43)


        ElseIf _elapsedSeconds >= halfWait Then
            ' WARNING — orange
            pnlHeader.BackColor = Color.FromArgb(193, 127, 58)


        Else
            ' NORMAL — keep current header color
            If _isStarted Then
                pnlHeader.BackColor = Color.FromArgb(33, 176, 23)  ' green if started
            Else
                pnlHeader.BackColor = ColorHeaderBrown            ' brown if not started yet
            End If
            lblWaitTime.ForeColor = Color.White
        End If
    End Sub

    ' -------------------------------------------------------
    ' STEP C: format MM:SS on lblWaitTime
    ' -------------------------------------------------------
    Private Sub UpdateTimerDisplay()
        Dim minutes As Integer = _elapsedSeconds \ 60
        Dim seconds As Integer = _elapsedSeconds Mod 60
        lblWaitTime.Text = String.Format("{0:00}:{1:00}", minutes, seconds)
    End Sub

    ' -------------------------------------------------------
    ' STEP D: set colors on all panels + border
    ' -------------------------------------------------------
    Private Sub SetCardColor(header As Color, footer As Color, border As Color)
        pnlHeader.BackColor = header
        pnlFooter.BackColor = footer
        pnlBody.BackColor = Color.White ' body always cream
        _borderColor = border
        Me.Invalidate()
    End Sub

    ' -------------------------------------------------------
    ' STEP E: paint rounded border around the whole card
    ' -------------------------------------------------------
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

        Dim radius As Integer = 20
        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        Using path As New Drawing2D.GraphicsPath()
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90)
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90)
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90)
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90)
            path.CloseFigure()

            ' thick black pen — covers pixelated Region edge completely
            Using outerPen As New Pen(Color.Black, 6)
                g.DrawPath(outerPen, path)
            End Using

            ' thin black border on top — clean smooth visible border
            Using innerPen As New Pen(Color.Black, 1.5F)
                g.DrawPath(innerPen, path)
            End Using
        End Using
    End Sub

    ' -------------------------------------------------------
    ' STEP F: Start → Complete
    ' -------------------------------------------------------
    Private Sub btnAction_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        If Not _isStarted Then
            ' first click — START
            _isStarted = True
            btnAction.Text = "Complete"
            btnAction.BackColor = Color.White
            btnAction.ForeColor = Color.Black
            btnAction.BorderColor = Color.Black
            '  pnlHeader.BackColor = Color.FromArgb(33, 176, 23)
            tmrWait.Start()
        Else
            ' check if all items are finished
            Dim allDone As Boolean = True
            For Each ctrl As Control In flpItems.Controls
                If TypeOf ctrl Is ucOrderItem Then
                    Dim uc As ucOrderItem = DirectCast(ctrl, ucOrderItem)
                    If Not uc.IsFinished Then
                        allDone = False
                        Exit For
                    End If
                End If
            Next

            If Not allDone Then
                Using confirm As New frmConfirm()
                    confirm.ShowDialog(Me)
                    If Not confirm.UserConfirmed Then Return
                End Using
            End If

            tmrWait.Stop()
            DatabaseHelper.UpdateOrderStatus(_orderId, "Completed")
            RaiseEvent OnOrderCompleted(Me, _orderId)
        End If
    End Sub
    Private Sub ApplyRoundedCorners()
        Dim radius As Integer = 20
        Dim path As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90)
        path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90)
        path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90)
        path.CloseFigure()
        Me.Region = New Region(path)
    End Sub

    Private Sub ucOrderCard_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ApplyRoundedCorners()
    End Sub

    Private Sub flpItems_MouseWheel(sender As Object, e As MouseEventArgs)
        Dim newValue As Integer = flpItems.VerticalScroll.Value - e.Delta
        newValue = Math.Max(flpItems.VerticalScroll.Minimum, newValue)
        newValue = Math.Min(flpItems.VerticalScroll.Maximum, newValue)
        flpItems.VerticalScroll.Value = newValue
        flpItems.PerformLayout()
    End Sub

    ' -------------------------------------------------------
    ' BUTTON HOVER AND CLICK EFFECTS
    ' -------------------------------------------------------
    Private Sub btnAction_MouseEnter(sender As Object, e As EventArgs) Handles btnAction.MouseEnter
        If Not _isStarted Then
            ' Start button hover — light brown tint
            'btnAction.BackColor = Color.FromArgb(237, 217, 176)
            'btnAction.ForeColor = Color.FromArgb(92, 51, 23)
        Else
            ' Complete button hover — light green tint
            'btnAction.BackColor = Color.FromArgb(200, 240, 210)
            'btnAction.ForeColor = Color.FromArgb(30, 100, 50)
        End If
    End Sub

    Private Sub btnAction_MouseLeave(sender As Object, e As EventArgs) Handles btnAction.MouseLeave
        ' restore original colors when mouse leaves
        btnAction.BackColor = Color.White
        btnAction.ForeColor = Color.Black
    End Sub

    Private Sub btnAction_MouseDown(sender As Object, e As MouseEventArgs) Handles btnAction.MouseDown
        If Not _isStarted Then
            ' Start button pressed — darker brown
            btnAction.BackColor = Color.FromArgb(92, 51, 23)
            btnAction.ForeColor = Color.White
        Else
            ' Complete button pressed — darker green
            btnAction.BackColor = Color.FromArgb(92, 51, 23)
            btnAction.ForeColor = Color.White
        End If
    End Sub

    Private Sub btnAction_MouseUp(sender As Object, e As MouseEventArgs) Handles btnAction.MouseUp
        ' restore hover color after releasing click
        If Not _isStarted Then
            'btnAction.BackColor = Color.FromArgb(237, 217, 176)
            'btnAction.ForeColor = Color.FromArgb(92, 51, 23)
        Else
            'btnAction.BackColor = Color.FromArgb(200, 240, 210)
            'btnAction.ForeColor = Color.FromArgb(30, 100, 50)
        End If
    End Sub



    ' expose OrderId so frmKitchenDisplay can find the card
    Public ReadOnly Property OrderId As Integer
        Get
            Return _orderId
        End Get
    End Property

End Class