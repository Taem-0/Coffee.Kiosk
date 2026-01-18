<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox1 = New PictureBox()
        btnLogIn = New Button()
        btnSignUp = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(646, 83)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(626, 597)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' btnLogIn
        ' 
        btnLogIn.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnLogIn.FlatStyle = FlatStyle.Popup
        btnLogIn.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnLogIn.ForeColor = Color.White
        btnLogIn.Location = New Point(437, 777)
        btnLogIn.Name = "btnLogIn"
        btnLogIn.Size = New Size(424, 81)
        btnLogIn.TabIndex = 1
        btnLogIn.Text = "LOG IN"
        btnLogIn.UseVisualStyleBackColor = False
        ' 
        ' btnSignUp
        ' 
        btnSignUp.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSignUp.FlatStyle = FlatStyle.Popup
        btnSignUp.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnSignUp.ForeColor = Color.White
        btnSignUp.Location = New Point(1057, 777)
        btnSignUp.Name = "btnSignUp"
        btnSignUp.Size = New Size(424, 81)
        btnSignUp.TabIndex = 2
        btnSignUp.Text = "SIGN UP"
        btnSignUp.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        ClientSize = New Size(1878, 998)
        ControlBox = False
        Controls.Add(btnSignUp)
        Controls.Add(btnLogIn)
        Controls.Add(PictureBox1)
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        FormBorderStyle = FormBorderStyle.None
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnLogIn As Button
    Friend WithEvents btnSignUp As Button

End Class
