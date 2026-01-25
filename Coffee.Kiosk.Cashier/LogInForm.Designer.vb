<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogInForm
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
        LogInPanel = New Panel()
        SuspendLayout()
        ' 
        ' LogInPanel
        ' 
        LogInPanel.Location = New Point(493, 1)
        LogInPanel.Name = "LogInPanel"
        LogInPanel.Size = New Size(968, 1073)
        LogInPanel.TabIndex = 0
        ' 
        ' LogInForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        ClientSize = New Size(1918, 1078)
        ControlBox = False
        Controls.Add(LogInPanel)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "LogInForm"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
    End Sub

    Friend WithEvents LogInPanel As Panel
End Class
