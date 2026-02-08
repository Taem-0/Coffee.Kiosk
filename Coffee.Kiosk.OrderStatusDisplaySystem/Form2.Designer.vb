<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lvOrderNum = New ListView()
        Label1 = New Label()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Monitoring_buttons3 = New Monitoring_buttons()
        Monitoring_buttons1 = New Monitoring_buttons()
        Monitoring_buttons2 = New Monitoring_buttons()
        Monitoring_buttons4 = New Monitoring_buttons()
        Monitoring_buttons5 = New Monitoring_buttons()
        Monitoring_buttons6 = New Monitoring_buttons()
        Monitoring_buttons7 = New Monitoring_buttons()
        Monitoring_buttons8 = New Monitoring_buttons()
        Monitoring_buttons9 = New Monitoring_buttons()
        Monitoring_buttons10 = New Monitoring_buttons()
        Label2 = New Label()
        FlowLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' lvOrderNum
        ' 
        ListView1.BackColor = Color.OldLace
        ListView1.Font = New Font("Arial Rounded MT Bold", 24.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListView1.Location = New Point(70, 109)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(460, 836)
        ListView1.TabIndex = 0
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Rounded MT Bold", 32.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.WhiteSmoke
        Label1.Location = New Point(122, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(360, 50)
        Label1.TabIndex = 1
        Label1.Text = "Order's Number"
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons3)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons1)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons2)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons4)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons5)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons6)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons7)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons8)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons9)
        FlowLayoutPanel1.Controls.Add(Monitoring_buttons10)
        FlowLayoutPanel1.Location = New Point(544, 109)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(1299, 836)
        FlowLayoutPanel1.TabIndex = 2
        ' 
        ' Monitoring_buttons3
        ' 
        Monitoring_buttons3.Location = New Point(3, 3)
        Monitoring_buttons3.Name = "Monitoring_buttons3"
        Monitoring_buttons3.Size = New Size(1299, 80)
        Monitoring_buttons3.TabIndex = 2
        ' 
        ' Monitoring_buttons1
        ' 
        Monitoring_buttons1.Location = New Point(3, 89)
        Monitoring_buttons1.Name = "Monitoring_buttons1"
        Monitoring_buttons1.Size = New Size(1299, 77)
        Monitoring_buttons1.TabIndex = 0
        ' 
        ' Monitoring_buttons2
        ' 
        Monitoring_buttons2.Location = New Point(3, 172)
        Monitoring_buttons2.Name = "Monitoring_buttons2"
        Monitoring_buttons2.Size = New Size(1299, 77)
        Monitoring_buttons2.TabIndex = 1
        ' 
        ' Monitoring_buttons4
        ' 
        Monitoring_buttons4.Location = New Point(3, 255)
        Monitoring_buttons4.Name = "Monitoring_buttons4"
        Monitoring_buttons4.Size = New Size(1299, 77)
        Monitoring_buttons4.TabIndex = 3
        ' 
        ' Monitoring_buttons5
        ' 
        Monitoring_buttons5.Location = New Point(3, 338)
        Monitoring_buttons5.Name = "Monitoring_buttons5"
        Monitoring_buttons5.Size = New Size(1299, 77)
        Monitoring_buttons5.TabIndex = 4
        ' 
        ' Monitoring_buttons6
        ' 
        Monitoring_buttons6.Location = New Point(3, 421)
        Monitoring_buttons6.Name = "Monitoring_buttons6"
        Monitoring_buttons6.Size = New Size(1299, 77)
        Monitoring_buttons6.TabIndex = 5
        ' 
        ' Monitoring_buttons7
        ' 
        Monitoring_buttons7.Location = New Point(3, 504)
        Monitoring_buttons7.Name = "Monitoring_buttons7"
        Monitoring_buttons7.Size = New Size(1299, 77)
        Monitoring_buttons7.TabIndex = 6
        ' 
        ' Monitoring_buttons8
        ' 
        Monitoring_buttons8.Location = New Point(3, 587)
        Monitoring_buttons8.Name = "Monitoring_buttons8"
        Monitoring_buttons8.Size = New Size(1299, 77)
        Monitoring_buttons8.TabIndex = 7
        ' 
        ' Monitoring_buttons9
        ' 
        Monitoring_buttons9.Location = New Point(3, 670)
        Monitoring_buttons9.Name = "Monitoring_buttons9"
        Monitoring_buttons9.Size = New Size(1299, 77)
        Monitoring_buttons9.TabIndex = 8
        ' 
        ' Monitoring_buttons10
        ' 
        Monitoring_buttons10.Location = New Point(3, 753)
        Monitoring_buttons10.Name = "Monitoring_buttons10"
        Monitoring_buttons10.Size = New Size(1299, 77)
        Monitoring_buttons10.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 32.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(1037, 55)
        Label2.Name = "Label2"
        Label2.Size = New Size(432, 50)
        Label2.TabIndex = 3
        Label2.Text = "Order Status Board"
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 17.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Tan
        ClientSize = New Size(1902, 1001)
        ControlBox = False
        Controls.Add(Label2)
        Controls.Add(FlowLayoutPanel1)
        Controls.Add(Label1)
        Controls.Add(ListView1)
        Controls.Add(FlowLayoutPanel1)
        Name = "Form2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form2"
        FlowLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lvOrderNum As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Monitoring_buttons3 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons1 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons2 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons4 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons5 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons6 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons7 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons8 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons9 As Monitoring_buttons
    Friend WithEvents Monitoring_buttons10 As Monitoring_buttons
    Friend WithEvents Label2 As Label
End Class
