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
        btnLogIn = New Button()
        btnSignUp = New Button()
        CType(LogoBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LogoBox
        ' 
        LogoBox.BackgroundImage = CType(resources.GetObject("LogoBox.BackgroundImage"), Image)
        LogoBox.BackgroundImageLayout = ImageLayout.Zoom
        LogoBox.Location = New Point(126, 119)
        LogoBox.Name = "LogoBox"
        LogoBox.Size = New Size(698, 644)
        LogoBox.TabIndex = 0
        LogoBox.TabStop = False
        ' 
        ' btnLogIn
        ' 
        btnLogIn.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnLogIn.FlatStyle = FlatStyle.Popup
        btnLogIn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnLogIn.ForeColor = Color.White
        btnLogIn.Location = New Point(53, 843)
        btnLogIn.Name = "btnLogIn"
        btnLogIn.Size = New Size(339, 67)
        btnLogIn.TabIndex = 1
        btnLogIn.Text = "LOG IN"
        btnLogIn.UseVisualStyleBackColor = False
        ' 
        ' btnSignUp
        ' 
        btnSignUp.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSignUp.FlatStyle = FlatStyle.Popup
        btnSignUp.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnSignUp.ForeColor = Color.White
        btnSignUp.Location = New Point(566, 843)
        btnSignUp.Name = "btnSignUp"
        btnSignUp.Size = New Size(339, 67)
        btnSignUp.TabIndex = 2
        btnSignUp.Text = "SIGN UP"
        btnSignUp.UseVisualStyleBackColor = False
        ' 
        ' SignInControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(btnSignUp)
        Controls.Add(btnLogIn)
        Controls.Add(LogoBox)
        Name = "SignInControl"
        Size = New Size(968, 1073)
        CType(LogoBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents LogoBox As PictureBox
    Friend WithEvents btnLogIn As Button
    Friend WithEvents btnSignUp As Button

End Class
