<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class monitoringButtons
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
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        Button1.Font = New Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(51, 16)
        Button1.Name = "Button1"
        Button1.Size = New Size(378, 56)
        Button1.TabIndex = 0
        Button1.Text = "Preparing Orders"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.LightGreen
        Button2.Font = New Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(463, 16)
        Button2.Name = "Button2"
        Button2.Size = New Size(378, 56)
        Button2.TabIndex = 1
        Button2.Text = "Ready for Pick-Up"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.ActiveCaption
        Button3.Font = New Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(882, 19)
        Button3.Name = "Button3"
        Button3.Size = New Size(378, 56)
        Button3.TabIndex = 2
        Button3.Text = "Order Complete"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' monitoringButtons
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "monitoringButtons"
        Size = New Size(1288, 91)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button

End Class
