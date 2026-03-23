<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmKitchenDisplay
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKitchenDisplay))
        flpOrders = New FlowLayoutPanel()
        lblTime = New Label()
        ColorDialog1 = New ColorDialog()
        TimerClock = New Timer(components)
        pnl1 = New Panel()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Label1 = New Label()
        lblActiveOrders = New Label()
        btnRecall = New Guna.UI2.WinForms.Guna2Button()
        lblShopName = New Label()
        PictureBox1 = New PictureBox()
        Timer1 = New Timer(components)
        tmrClock = New Timer(components)
        pnl1.SuspendLayout()
        Guna2Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' flpOrders
        ' 
        flpOrders.Location = New Point(-2, 80)
        flpOrders.Name = "flpOrders"
        flpOrders.Size = New Size(1831, 1080)
        flpOrders.TabIndex = 1
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblTime.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime.ForeColor = Color.White
        lblTime.Location = New Point(809, 22)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(145, 28)
        lblTime.TabIndex = 2
        lblTime.Text = "Date and Time"
        ' 
        ' pnl1
        ' 
        pnl1.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        pnl1.Controls.Add(Guna2Panel1)
        pnl1.Controls.Add(btnRecall)
        pnl1.Controls.Add(lblShopName)
        pnl1.Controls.Add(PictureBox1)
        pnl1.Location = New Point(-2, -3)
        pnl1.Name = "pnl1"
        pnl1.Size = New Size(1831, 77)
        pnl1.TabIndex = 3
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.BackColor = Color.Transparent
        Guna2Panel1.BorderColor = Color.Black
        Guna2Panel1.BorderRadius = 10
        Guna2Panel1.BorderThickness = 1
        Guna2Panel1.Controls.Add(Label1)
        Guna2Panel1.Controls.Add(lblActiveOrders)
        Guna2Panel1.CustomizableEdges = CustomizableEdges1
        Guna2Panel1.FillColor = Color.Transparent
        Guna2Panel1.Location = New Point(1639, 9)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Panel1.Size = New Size(106, 64)
        Guna2Panel1.TabIndex = 9
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(28, 6)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 20)
        Label1.TabIndex = 2
        Label1.Text = "Active"
        ' 
        ' lblActiveOrders
        ' 
        lblActiveOrders.AutoSize = True
        lblActiveOrders.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActiveOrders.ForeColor = Color.White
        lblActiveOrders.Location = New Point(34, 15)
        lblActiveOrders.Name = "lblActiveOrders"
        lblActiveOrders.Size = New Size(40, 46)
        lblActiveOrders.TabIndex = 5
        lblActiveOrders.Text = "0"
        ' 
        ' btnRecall
        ' 
        btnRecall.BorderRadius = 10
        btnRecall.BorderThickness = 1
        btnRecall.CustomizableEdges = CustomizableEdges3
        btnRecall.DisabledState.BorderColor = Color.DarkGray
        btnRecall.DisabledState.CustomBorderColor = Color.DarkGray
        btnRecall.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnRecall.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnRecall.FillColor = Color.DarkRed
        btnRecall.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRecall.ForeColor = Color.White
        btnRecall.Location = New Point(1536, 14)
        btnRecall.Name = "btnRecall"
        btnRecall.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnRecall.Size = New Size(97, 52)
        btnRecall.TabIndex = 8
        btnRecall.Text = "RECALL"
        ' 
        ' lblShopName
        ' 
        lblShopName.AutoSize = True
        lblShopName.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblShopName.ForeColor = Color.White
        lblShopName.Location = New Point(83, 20)
        lblShopName.Name = "lblShopName"
        lblShopName.Size = New Size(224, 41)
        lblShopName.TabIndex = 7
        lblShopName.Text = "CAFÉ FILIPINO"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(14, 7)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(63, 65)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Timer1
        ' 
        ' 
        ' tmrClock
        ' 
        ' 
        ' FrmKitchenDisplay
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(1760, 1102)
        Controls.Add(lblTime)
        Controls.Add(flpOrders)
        Controls.Add(pnl1)
        FormBorderStyle = FormBorderStyle.None
        Name = "FrmKitchenDisplay"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        WindowState = FormWindowState.Maximized
        pnl1.ResumeLayout(False)
        pnl1.PerformLayout()
        Guna2Panel1.ResumeLayout(False)
        Guna2Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents flpOrders As FlowLayoutPanel
    Friend WithEvents lblTime As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents TimerClock As Timer
    Friend WithEvents pnl1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblActiveOrders As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tmrClock As Timer
    Friend WithEvents lblShopName As Label
    Private WithEvents btnRecall As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel

End Class
