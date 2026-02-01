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
        ListView1 = New ListView()
        ListView2 = New ListView()
        ListView3 = New ListView()
        ListView4 = New ListView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' ListView1
        ' 
        ListView1.BackColor = Color.OldLace
        ListView1.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListView1.ForeColor = Color.FromArgb(CByte(128), CByte(64), CByte(0))
        ListView1.Location = New Point(576, 64)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(320, 907)
        ListView1.TabIndex = 0
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' ListView2
        ' 
        ListView2.BackColor = Color.OldLace
        ListView2.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListView2.ForeColor = Color.FromArgb(CByte(128), CByte(64), CByte(0))
        ListView2.Location = New Point(907, 64)
        ListView2.Name = "ListView2"
        ListView2.Size = New Size(320, 905)
        ListView2.TabIndex = 1
        ListView2.UseCompatibleStateImageBehavior = False
        ' 
        ' ListView3
        ' 
        ListView3.BackColor = Color.OldLace
        ListView3.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListView3.ForeColor = Color.FromArgb(CByte(128), CByte(64), CByte(0))
        ListView3.Location = New Point(1238, 64)
        ListView3.Name = "ListView3"
        ListView3.Size = New Size(320, 905)
        ListView3.TabIndex = 2
        ListView3.UseCompatibleStateImageBehavior = False
        ' 
        ' ListView4
        ' 
        ListView4.BackColor = Color.OldLace
        ListView4.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListView4.ForeColor = Color.FromArgb(CByte(128), CByte(64), CByte(0))
        ListView4.Location = New Point(1568, 64)
        ListView4.Name = "ListView4"
        ListView4.Size = New Size(320, 905)
        ListView4.TabIndex = 3
        ListView4.UseCompatibleStateImageBehavior = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(616, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(236, 33)
        Label1.TabIndex = 4
        Label1.Text = "Gcash Payment"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(962, 25)
        Label2.Name = "Label2"
        Label2.Size = New Size(217, 33)
        Label2.TabIndex = 5
        Label2.Text = "Cash Payment"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(1270, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(270, 33)
        Label3.TabIndex = 6
        Label3.Text = "Preparing Orders "
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(1595, 26)
        Label4.Name = "Label4"
        Label4.Size = New Size(270, 33)
        Label4.TabIndex = 7
        Label4.Text = "Ready for Pick-Up"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(12, 948)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 41)
        Button1.TabIndex = 8
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.orderingdisplay_bg
        ClientSize = New Size(1904, 1001)
        ControlBox = False
        Controls.Add(Button1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(ListView4)
        Controls.Add(ListView3)
        Controls.Add(ListView2)
        Controls.Add(ListView1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents ListView2 As ListView
    Friend WithEvents ListView3 As ListView
    Friend WithEvents ListView4 As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button

End Class
