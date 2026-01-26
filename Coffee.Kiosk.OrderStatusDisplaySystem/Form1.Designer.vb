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
        lvPreparing = New ListView()
        lvReady = New ListView()
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' lvPreparing
        ' 
        lvPreparing.BackColor = Color.Beige
        lvPreparing.Location = New Point(784, 109)
        lvPreparing.Name = "lvPreparing"
        lvPreparing.Size = New Size(536, 860)
        lvPreparing.TabIndex = 0
        lvPreparing.UseCompatibleStateImageBehavior = False
        ' 
        ' lvReady
        ' 
        lvReady.BackColor = Color.Beige
        lvReady.Location = New Point(1350, 109)
        lvReady.Name = "lvReady"
        lvReady.Size = New Size(536, 860)
        lvReady.TabIndex = 1
        lvReady.UseCompatibleStateImageBehavior = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(838, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(435, 55)
        Label1.TabIndex = 2
        Label1.Text = "Preparing Orders"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(1405, 36)
        Label2.Name = "Label2"
        Label2.Size = New Size(440, 55)
        Label2.TabIndex = 3
        Label2.Text = "Ready for Pick-up"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(60, 949)
        Button1.Name = "Button1"
        Button1.Size = New Size(97, 28)
        Button1.TabIndex = 4
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1902, 1001)
        ControlBox = False
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(lvReady)
        Controls.Add(lvPreparing)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lvPreparing As ListView
    Friend WithEvents lvReady As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button


End Class
