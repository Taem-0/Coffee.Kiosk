<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignUpControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignUpControl))
        lblFullName = New Label()
        llblLogInAcc = New LinkLabel()
        btnSignUp = New Button()
        txtFullName = New TextBox()
        LogoBox = New PictureBox()
        lblUsername = New Label()
        lblPassword = New Label()
        lblConfirm = New Label()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        txtConfirm = New TextBox()
        CType(LogoBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.BackColor = Color.Transparent
        lblFullName.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFullName.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblFullName.Location = New Point(251, 495)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(104, 28)
        lblFullName.TabIndex = 0
        lblFullName.Text = "Full Name"
        ' 
        ' llblLogInAcc
        ' 
        llblLogInAcc.ActiveLinkColor = Color.SaddleBrown
        llblLogInAcc.AutoSize = True
        llblLogInAcc.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        llblLogInAcc.LinkColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        llblLogInAcc.Location = New Point(449, 820)
        llblLogInAcc.Name = "llblLogInAcc"
        llblLogInAcc.Size = New Size(242, 28)
        llblLogInAcc.TabIndex = 1
        llblLogInAcc.TabStop = True
        llblLogInAcc.Text = "Already have an account?"
        ' 
        ' btnSignUp
        ' 
        btnSignUp.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSignUp.FlatStyle = FlatStyle.Popup
        btnSignUp.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnSignUp.ForeColor = Color.White
        btnSignUp.Location = New Point(425, 874)
        btnSignUp.Name = "btnSignUp"
        btnSignUp.Size = New Size(292, 55)
        btnSignUp.TabIndex = 2
        btnSignUp.Text = "SIGN UP"
        btnSignUp.UseVisualStyleBackColor = False
        ' 
        ' txtFullName
        ' 
        txtFullName.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtFullName.BorderStyle = BorderStyle.FixedSingle
        txtFullName.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFullName.ForeColor = Color.White
        txtFullName.Location = New Point(251, 532)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(638, 38)
        txtFullName.TabIndex = 3
        ' 
        ' LogoBox
        ' 
        LogoBox.BackgroundImage = CType(resources.GetObject("LogoBox.BackgroundImage"), Image)
        LogoBox.BackgroundImageLayout = ImageLayout.Zoom
        LogoBox.Location = New Point(382, 129)
        LogoBox.Name = "LogoBox"
        LogoBox.Size = New Size(357, 303)
        LogoBox.TabIndex = 4
        LogoBox.TabStop = False
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblUsername.Location = New Point(251, 597)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(104, 28)
        lblUsername.TabIndex = 5
        lblUsername.Text = "Username"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblPassword.Location = New Point(251, 688)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(97, 28)
        lblPassword.TabIndex = 6
        lblPassword.Text = "Password"
        ' 
        ' lblConfirm
        ' 
        lblConfirm.AutoSize = True
        lblConfirm.BackColor = Color.Transparent
        lblConfirm.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblConfirm.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblConfirm.Location = New Point(585, 688)
        lblConfirm.Name = "lblConfirm"
        lblConfirm.Size = New Size(176, 28)
        lblConfirm.TabIndex = 7
        lblConfirm.Text = "Confirm Password"
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = Color.White
        txtUsername.Location = New Point(251, 632)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(638, 38)
        txtUsername.TabIndex = 8
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = Color.White
        txtPassword.Location = New Point(251, 731)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(304, 38)
        txtPassword.TabIndex = 9
        ' 
        ' txtConfirm
        ' 
        txtConfirm.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtConfirm.BorderStyle = BorderStyle.FixedSingle
        txtConfirm.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtConfirm.ForeColor = Color.White
        txtConfirm.Location = New Point(585, 731)
        txtConfirm.Name = "txtConfirm"
        txtConfirm.Size = New Size(304, 38)
        txtConfirm.TabIndex = 10
        ' 
        ' SignUpControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        BackgroundImageLayout = ImageLayout.Zoom
        Controls.Add(txtConfirm)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(lblConfirm)
        Controls.Add(lblPassword)
        Controls.Add(lblUsername)
        Controls.Add(LogoBox)
        Controls.Add(txtFullName)
        Controls.Add(btnSignUp)
        Controls.Add(llblLogInAcc)
        Controls.Add(lblFullName)
        Name = "SignUpControl"
        Size = New Size(1172, 1081)
        CType(LogoBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblFullName As Label
    Friend WithEvents llblLogInAcc As LinkLabel
    Friend WithEvents btnSignUp As Button
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents LogoBox As PictureBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblConfirm As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirm As TextBox

End Class
