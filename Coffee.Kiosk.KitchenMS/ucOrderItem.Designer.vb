<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrderItem
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
        lblQuantity = New Label()
        lblItemName = New Label()
        lblCustomizations = New Label()
        Panel1 = New Panel()
        SuspendLayout()
        ' 
        ' lblQuantity
        ' 
        lblQuantity.AutoSize = True
        lblQuantity.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQuantity.Location = New Point(282, 14)
        lblQuantity.Name = "lblQuantity"
        lblQuantity.Size = New Size(18, 20)
        lblQuantity.TabIndex = 0
        lblQuantity.Text = "2"
        ' 
        ' lblItemName
        ' 
        lblItemName.AutoSize = True
        lblItemName.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblItemName.Location = New Point(17, 17)
        lblItemName.Name = "lblItemName"
        lblItemName.Size = New Size(93, 20)
        lblItemName.TabIndex = 1
        lblItemName.Text = "Match Latte"
        ' 
        ' lblCustomizations
        ' 
        lblCustomizations.BackColor = Color.Transparent
        lblCustomizations.Location = New Point(20, 40)
        lblCustomizations.Name = "lblCustomizations"
        lblCustomizations.Size = New Size(96, 20)
        lblCustomizations.TabIndex = 2
        lblCustomizations.Text = "Arabica I 50 I"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 106)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(333, 1)
        Panel1.TabIndex = 3
        ' 
        ' ucOrderItem
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(Panel1)
        Controls.Add(lblCustomizations)
        Controls.Add(lblItemName)
        Controls.Add(lblQuantity)
        Name = "ucOrderItem"
        Size = New Size(333, 107)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblItemName As Label
    Friend WithEvents lblCustomizations As Label
    Friend WithEvents Panel1 As Panel

End Class
