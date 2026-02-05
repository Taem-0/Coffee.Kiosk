<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderCustomize
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
        CustomizePanel = New Panel()
        SuspendLayout()
        ' 
        ' CustomizePanel
        ' 
        CustomizePanel.Dock = DockStyle.Fill
        CustomizePanel.Location = New Point(0, 0)
        CustomizePanel.Name = "CustomizePanel"
        CustomizePanel.Size = New Size(974, 689)
        CustomizePanel.TabIndex = 1
        ' 
        ' OrderCustomize
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.OldLace
        ClientSize = New Size(974, 689)
        ControlBox = False
        Controls.Add(CustomizePanel)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "OrderCustomize"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
    End Sub
    Friend WithEvents CustomizePanel As Panel
End Class
