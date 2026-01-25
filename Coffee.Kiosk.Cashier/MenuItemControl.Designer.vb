<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuItemControl
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
        lblName = New Label()
        lblPrice = New Label()
        SuspendLayout()
        ' 
        ' lblName
        ' 
        lblName.Anchor = AnchorStyles.Top
        lblName.AutoSize = True
        lblName.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblName.Location = New Point(20, 32)
        lblName.Name = "lblName"
        lblName.Size = New Size(51, 20)
        lblName.TabIndex = 0
        lblName.Text = "Label1"
        lblName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPrice
        ' 
        lblPrice.AutoSize = True
        lblPrice.Dock = DockStyle.Fill
        lblPrice.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        lblPrice.Location = New Point(0, 0)
        lblPrice.Name = "lblPrice"
        lblPrice.Size = New Size(51, 20)
        lblPrice.TabIndex = 1
        lblPrice.Text = "Label1"
        lblPrice.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' MenuItemControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Controls.Add(lblPrice)
        Controls.Add(lblName)
        Cursor = Cursors.Hand
        ForeColor = SystemColors.ButtonHighlight
        Margin = New Padding(10)
        Name = "MenuItemControl"
        Size = New Size(205, 66)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblName As Label
    Friend WithEvents lblPrice As Label

End Class
