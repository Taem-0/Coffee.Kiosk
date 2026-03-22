<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirm
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
        components = New ComponentModel.Container()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        lblMessage = New Label()
        btnYes = New Guna.UI2.WinForms.Guna2Button()
        btnNo = New Guna.UI2.WinForms.Guna2Button()
        Label1 = New Label()
        Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(components)
        pnlBackground = New Guna.UI2.WinForms.Guna2Panel()
        SuspendLayout()
        ' 
        ' lblMessage
        ' 
        lblMessage.AutoSize = True
        lblMessage.BackColor = Color.White
        lblMessage.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMessage.Location = New Point(92, 49)
        lblMessage.Name = "lblMessage"
        lblMessage.Size = New Size(357, 28)
        lblMessage.TabIndex = 0
        lblMessage.Text = "Some items are not marked as done."
        ' 
        ' btnYes
        ' 
        btnYes.BorderRadius = 10
        btnYes.BorderThickness = 2
        btnYes.CustomizableEdges = CustomizableEdges1
        btnYes.DisabledState.BorderColor = Color.DarkGray
        btnYes.DisabledState.CustomBorderColor = Color.DarkGray
        btnYes.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnYes.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnYes.FillColor = Color.Red
        btnYes.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnYes.ForeColor = Color.White
        btnYes.Location = New Point(64, 152)
        btnYes.Name = "btnYes"
        btnYes.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnYes.Size = New Size(178, 56)
        btnYes.TabIndex = 1
        btnYes.Text = "Yes, Complete"
        ' 
        ' btnNo
        ' 
        btnNo.BorderRadius = 10
        btnNo.BorderThickness = 2
        btnNo.CustomizableEdges = CustomizableEdges3
        btnNo.DisabledState.BorderColor = Color.DarkGray
        btnNo.DisabledState.CustomBorderColor = Color.DarkGray
        btnNo.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnNo.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnNo.FillColor = Color.LimeGreen
        btnNo.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnNo.ForeColor = Color.White
        btnNo.Location = New Point(277, 152)
        btnNo.Name = "btnNo"
        btnNo.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnNo.Size = New Size(178, 56)
        btnNo.TabIndex = 2
        btnNo.Text = "Cancel"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.White
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(157, 87)
        Label1.Name = "Label1"
        Label1.Size = New Size(189, 28)
        Label1.TabIndex = 3
        Label1.Text = "Complete anyway?"
        ' 
        ' pnlBackground
        ' 
        pnlBackground.BackColor = Color.Transparent
        pnlBackground.BorderColor = Color.Black
        pnlBackground.BorderRadius = 20
        pnlBackground.BorderThickness = 2
        pnlBackground.CustomizableEdges = CustomizableEdges5
        pnlBackground.Dock = DockStyle.Fill
        pnlBackground.FillColor = Color.White
        pnlBackground.Location = New Point(0, 0)
        pnlBackground.Margin = New Padding(0)
        pnlBackground.Name = "pnlBackground"
        pnlBackground.ShadowDecoration.Color = Color.Transparent
        pnlBackground.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        pnlBackground.Size = New Size(517, 251)
        pnlBackground.TabIndex = 4
        pnlBackground.UseTransparentBackground = True
        ' 
        ' frmConfirm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Magenta
        ClientSize = New Size(517, 251)
        Controls.Add(Label1)
        Controls.Add(btnNo)
        Controls.Add(btnYes)
        Controls.Add(lblMessage)
        Controls.Add(pnlBackground)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmConfirm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmConfirm"
        TransparencyKey = Color.Magenta
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblMessage As Label
    Friend WithEvents btnYes As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnNo As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
    Friend WithEvents pnlBackground As Guna.UI2.WinForms.Guna2Panel
End Class
