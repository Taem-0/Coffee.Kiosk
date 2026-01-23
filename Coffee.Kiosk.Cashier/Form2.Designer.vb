<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        PictureBox1 = New PictureBox()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        lblUsername = New Label()
        lblPassword = New Label()
        llblForgotPass = New LinkLabel()
        btnLogIn2 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(815, 71)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(276, 275)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtUsername.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = Color.White
        txtUsername.Location = New Point(622, 517)
        txtUsername.Multiline = True
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(677, 63)
        txtUsername.TabIndex = 1
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtPassword.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = Color.White
        txtPassword.Location = New Point(622, 662)
        txtPassword.Multiline = True
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(677, 60)
        txtPassword.TabIndex = 2
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblUsername.Location = New Point(623, 488)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(104, 28)
        lblUsername.TabIndex = 3
        lblUsername.Text = "Username"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblPassword.Location = New Point(623, 634)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(97, 28)
        lblPassword.TabIndex = 4
        lblPassword.Text = "Password"
        ' 
        ' llblForgotPass
        ' 
        llblForgotPass.AutoSize = True
        llblForgotPass.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        llblForgotPass.LinkColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        llblForgotPass.Location = New Point(867, 748)
        llblForgotPass.Name = "llblForgotPass"
        llblForgotPass.Size = New Size(192, 31)
        llblForgotPass.TabIndex = 5
        llblForgotPass.TabStop = True
        llblForgotPass.Text = "Forgot Password"
        ' 
        ' btnLogIn2
        ' 
        btnLogIn2.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnLogIn2.FlatStyle = FlatStyle.Popup
        btnLogIn2.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnLogIn2.ForeColor = Color.White
        btnLogIn2.Location = New Point(788, 835)
        btnLogIn2.Name = "btnLogIn2"
        btnLogIn2.Size = New Size(350, 63)
        btnLogIn2.TabIndex = 6
        btnLogIn2.Text = "LOG IN"
        btnLogIn2.UseVisualStyleBackColor = False
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        ClientSize = New Size(1920, 1080)
        ControlBox = False
        Controls.Add(btnLogIn2)
        Controls.Add(llblForgotPass)
        Controls.Add(lblPassword)
        Controls.Add(lblUsername)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents llblForgotPass As LinkLabel
    Friend WithEvents btnLogIn2 As Button
End Class
