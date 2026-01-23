<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        PictureBox1 = New PictureBox()
        txtFullName = New TextBox()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        txtConfirmPass = New TextBox()
        btnSignUp2 = New Button()
        llblAccount = New LinkLabel()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(806, 51)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(276, 275)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' txtFullName
        ' 
        txtFullName.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtFullName.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFullName.ForeColor = Color.White
        txtFullName.Location = New Point(495, 438)
        txtFullName.Multiline = True
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(905, 62)
        txtFullName.TabIndex = 2
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtUsername.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.ForeColor = Color.White
        txtUsername.Location = New Point(495, 563)
        txtUsername.Multiline = True
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(905, 62)
        txtUsername.TabIndex = 3
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtPassword.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.ForeColor = Color.White
        txtPassword.Location = New Point(495, 675)
        txtPassword.Multiline = True
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(396, 62)
        txtPassword.TabIndex = 4
        ' 
        ' txtConfirmPass
        ' 
        txtConfirmPass.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        txtConfirmPass.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtConfirmPass.ForeColor = Color.White
        txtConfirmPass.Location = New Point(1004, 675)
        txtConfirmPass.Multiline = True
        txtConfirmPass.Name = "txtConfirmPass"
        txtConfirmPass.Size = New Size(396, 62)
        txtConfirmPass.TabIndex = 5
        ' 
        ' btnSignUp2
        ' 
        btnSignUp2.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSignUp2.FlatStyle = FlatStyle.Popup
        btnSignUp2.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnSignUp2.ForeColor = Color.White
        btnSignUp2.Location = New Point(757, 856)
        btnSignUp2.Name = "btnSignUp2"
        btnSignUp2.Size = New Size(389, 74)
        btnSignUp2.TabIndex = 6
        btnSignUp2.Text = "SIGN UP"
        btnSignUp2.UseVisualStyleBackColor = False
        ' 
        ' llblAccount
        ' 
        llblAccount.AutoSize = True
        llblAccount.Font = New Font("Segoe UI Semibold", 13.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        llblAccount.LinkColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        llblAccount.Location = New Point(813, 764)
        llblAccount.Name = "llblAccount"
        llblAccount.Size = New Size(269, 31)
        llblAccount.TabIndex = 7
        llblAccount.TabStop = True
        llblAccount.Text = "Already have an acount?"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Label1.Location = New Point(492, 408)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 28)
        Label1.TabIndex = 8
        Label1.Text = "Full Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Label2.Location = New Point(492, 533)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 28)
        Label2.TabIndex = 9
        Label2.Text = "Username"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Label3.Location = New Point(492, 646)
        Label3.Name = "Label3"
        Label3.Size = New Size(97, 28)
        Label3.TabIndex = 10
        Label3.Text = "Password"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Label4.Location = New Point(1000, 644)
        Label4.Name = "Label4"
        Label4.Size = New Size(176, 28)
        Label4.TabIndex = 11
        Label4.Text = "Confirm Password"
        ' 
        ' Form3
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        ClientSize = New Size(1920, 1080)
        ControlBox = False
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(llblAccount)
        Controls.Add(btnSignUp2)
        Controls.Add(txtConfirmPass)
        Controls.Add(txtPassword)
        Controls.Add(txtUsername)
        Controls.Add(txtFullName)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form3"
        StartPosition = FormStartPosition.CenterScreen
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfirmPass As TextBox
    Friend WithEvents btnSignUp2 As Button
    Friend WithEvents llblAccount As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
