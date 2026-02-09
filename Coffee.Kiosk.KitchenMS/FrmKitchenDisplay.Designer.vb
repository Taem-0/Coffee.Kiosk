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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKitchenDisplay))
        flOrders = New FlowLayoutPanel()
        lblTime = New Label()
        ColorDialog1 = New ColorDialog()
        TimerClock = New Timer(components)
        Panel1 = New Panel()
        Label1 = New Label()
        lblActiveOrder = New Label()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' flOrders
        ' 
        flOrders.Location = New Point(-2, 80)
        flOrders.Name = "flOrders"
        flOrders.Size = New Size(1831, 1080)
        flOrders.TabIndex = 1
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.BackColor = Color.FromArgb(CByte(160), CByte(120), CByte(86))
        lblTime.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime.ForeColor = Color.White
        lblTime.Location = New Point(809, 22)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(145, 28)
        lblTime.TabIndex = 2
        lblTime.Text = "Date and Time"
        ' 
        ' TimerClock
        ' 
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(160), CByte(120), CByte(86))
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(lblActiveOrder)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Panel2)
        Panel1.Location = New Point(-2, -3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1831, 77)
        Panel1.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(1664, 11)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 20)
        Label1.TabIndex = 2
        Label1.Text = "Active"
        ' 
        ' lblActiveOrder
        ' 
        lblActiveOrder.AutoSize = True
        lblActiveOrder.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblActiveOrder.ForeColor = Color.White
        lblActiveOrder.Location = New Point(1677, 20)
        lblActiveOrder.Name = "lblActiveOrder"
        lblActiveOrder.Size = New Size(40, 46)
        lblActiveOrder.TabIndex = 5
        lblActiveOrder.Text = "0"
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
        ' Button1
        ' 
        Button1.Location = New Point(275, 15)
        Button1.Name = "Button1"
        Button1.Size = New Size(152, 50)
        Button1.TabIndex = 0
        Button1.Text = "Try"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Location = New Point(1655, 9)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(95, 61)
        Panel2.TabIndex = 6
        ' 
        ' FrmKitchenDisplay
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        ClientSize = New Size(1760, 1102)
        Controls.Add(lblTime)
        Controls.Add(flOrders)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "FrmKitchenDisplay"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents flOrders As FlowLayoutPanel
    Friend WithEvents lblTime As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents TimerClock As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblActiveOrder As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel

End Class
