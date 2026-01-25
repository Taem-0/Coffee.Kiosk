<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogInControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogInControl))
        Button1 = New Button()
        LogoBox = New PictureBox()
        lblUsername = New Label()
        txtUsername = New TextBox()
        LinkLabel1 = New LinkLabel()
        txtPassword = New TextBox()
        lblPassword = New Label()
        CType(LogoBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(352, 821)
        Button1.Name = "Button1"
        Button1.Size = New Size(240, 50)
        Button1.TabIndex = 0
        Button1.Text = "LOGIN"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' LogoBox
        ' 
        LogoBox.BackgroundImage = CType(resources.GetObject("LogoBox.BackgroundImage"), Image)
        LogoBox.BackgroundImageLayout = ImageLayout.Zoom
        LogoBox.Location = New Point(290, 154)
        LogoBox.Name = "LogoBox"
        LogoBox.Size = New Size(354, 314)
        LogoBox.TabIndex = 1
        LogoBox.TabStop = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblUsername.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblUsername.Location = New Point(185, 521)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(104, 28)
        lblUsername.TabIndex = 2
        lblUsername.Text = "Username"
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = Color.White
        txtUsername.Location = New Point(189, 554)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(566, 38)
        txtUsername.TabIndex = 3
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.SaddleBrown
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        LinkLabel1.LinkColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        LinkLabel1.Location = New Point(394, 735)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(168, 28)
        LinkLabel1.TabIndex = 4
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Forgot Password?"
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = Color.White
        txtPassword.Location = New Point(189, 660)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(566, 38)
        txtPassword.TabIndex = 5
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        lblPassword.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblPassword.Location = New Point(185, 629)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(97, 28)
        lblPassword.TabIndex = 6
        lblPassword.Text = "Password"
        ' 
        ' LogInControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(lblPassword)
        Controls.Add(txtPassword)
        Controls.Add(LinkLabel1)
        Controls.Add(txtUsername)
        Controls.Add(lblUsername)
        Controls.Add(LogoBox)
        Controls.Add(Button1)
        Name = "LogInControl"
        Size = New Size(968, 1073)
        CType(LogoBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents LogoBox As PictureBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label

End Class
