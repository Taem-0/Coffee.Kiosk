<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrinksMenuControl
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
        FlpMenu = New FlowLayoutPanel()
        SuspendLayout()
        ' 
        ' FlpMenu
        ' 
        FlpMenu.AutoScroll = True
        FlpMenu.Dock = DockStyle.Fill
        FlpMenu.Location = New Point(0, 0)
        FlpMenu.Name = "FlpMenu"
        FlpMenu.Size = New Size(907, 724)
        FlpMenu.TabIndex = 0
        ' 
        ' DrinksMenuControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(FlpMenu)
        Name = "DrinksMenuControl"
        Size = New Size(907, 724)
        ResumeLayout(False)
    End Sub

    Friend WithEvents FlpMenu As FlowLayoutPanel

End Class
