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
        btnLogIn = New Button()
        lblUsername = New Label()
        LogoBox = New PictureBox()
        lblPassword = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        lnkForgot = New LinkLabel()
        btnSee = New Button()
        CType(LogoBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnLogIn
        ' 
        btnLogIn.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnLogIn.FlatStyle = FlatStyle.Popup
        btnLogIn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnLogIn.ForeColor = Color.White
        btnLogIn.Location = New Point(430, 872)
        btnLogIn.Name = "btnLogIn"
        btnLogIn.Size = New Size(290, 65)
        btnLogIn.TabIndex = 0
        btnLogIn.Text = "LOG IN"
        btnLogIn.UseVisualStyleBackColor = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblUsername.Location = New Point(244, 572)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(78, 20)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Username"
        ' 
        ' LogoBox
        ' 
        LogoBox.BackgroundImage = CType(resources.GetObject("LogoBox.BackgroundImage"), Image)
        LogoBox.BackgroundImageLayout = ImageLayout.Zoom
        LogoBox.Location = New Point(383, 159)
        LogoBox.Name = "LogoBox"
        LogoBox.Size = New Size(367, 347)
        LogoBox.TabIndex = 2
        LogoBox.TabStop = False
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblPassword.Location = New Point(244, 678)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(73, 20)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Password"
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = Color.White
        txtUsername.Location = New Point(244, 608)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(655, 38)
        txtUsername.TabIndex = 5
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = Color.White
        txtPassword.Location = New Point(244, 711)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(655, 38)
        txtPassword.TabIndex = 6
        ' 
        ' lnkForgot
        ' 
        lnkForgot.ActiveLinkColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lnkForgot.AutoSize = True
        lnkForgot.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic)
        lnkForgot.LinkColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lnkForgot.Location = New Point(492, 827)
        lnkForgot.Name = "lnkForgot"
        lnkForgot.Size = New Size(159, 28)
        lnkForgot.TabIndex = 7
        lnkForgot.TabStop = True
        lnkForgot.Text = "Forgot Password"
        ' 
        ' btnSee
        ' 
        btnSee.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSee.FlatStyle = FlatStyle.Flat
        btnSee.ForeColor = Color.White
        btnSee.Location = New Point(867, 711)
        btnSee.Name = "btnSee"
        btnSee.Size = New Size(32, 38)
        btnSee.TabIndex = 8
        btnSee.Text = "👁️"
        btnSee.UseVisualStyleBackColor = False
        ' 
        ' LogInControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(btnSee)
        Controls.Add(lnkForgot)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(lblPassword)
        Controls.Add(LogoBox)
        Controls.Add(lblUsername)
        Controls.Add(btnLogIn)
        Name = "LogInControl"
        Size = New Size(1172, 1081)
        CType(LogoBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnLogIn As Button
    Friend WithEvents lblUsername As Label
    Friend WithEvents LogoBox As PictureBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lnkForgot As LinkLabel
    Friend WithEvents btnSee As Button

End Class
