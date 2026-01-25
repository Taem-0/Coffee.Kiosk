<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignInControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignInControl))
        LogoBox = New PictureBox()
        btnLogin = New Button()
        btnSignup = New Button()
        CType(LogoBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LogoBox
        ' 
        LogoBox.BackgroundImage = CType(resources.GetObject("LogoBox.BackgroundImage"), Image)
        LogoBox.BackgroundImageLayout = ImageLayout.Zoom
        LogoBox.Location = New Point(231, 141)
        LogoBox.Name = "LogoBox"
        LogoBox.Size = New Size(694, 624)
        LogoBox.TabIndex = 0
        LogoBox.TabStop = False
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnLogin.FlatStyle = FlatStyle.Popup
        btnLogin.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Italic)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(86, 847)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(385, 80)
        btnLogin.TabIndex = 1
        btnLogin.Text = "LOG IN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' btnSignup
        ' 
        btnSignup.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSignup.FlatStyle = FlatStyle.Popup
        btnSignup.Font = New Font("Segoe UI", 12F, FontStyle.Bold Or FontStyle.Italic)
        btnSignup.ForeColor = Color.White
        btnSignup.Location = New Point(677, 847)
        btnSignup.Name = "btnSignup"
        btnSignup.Size = New Size(385, 80)
        btnSignup.TabIndex = 2
        btnSignup.Text = "SIGN UP"
        btnSignup.UseVisualStyleBackColor = False
        ' 
        ' SignInControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(btnSignup)
        Controls.Add(btnLogin)
        Controls.Add(LogoBox)
        Name = "SignInControl"
        Size = New Size(1172, 1081)
        CType(LogoBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LogoBox As PictureBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnSignup As Button

End Class
