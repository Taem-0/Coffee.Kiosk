<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Monitoring_buttons
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
        btnPreparing = New Button()
        btnReady = New Button()
        btnComplete = New Button()
        SuspendLayout()
        ' 
        ' btnPreparing
        ' 
        btnPreparing.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(128))
        btnPreparing.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPreparing.ForeColor = Color.White
        btnPreparing.Location = New Point(35, 8)
        btnPreparing.Name = "btnPreparing"
        btnPreparing.Size = New Size(386, 58)
        btnPreparing.TabIndex = 0
        btnPreparing.Text = "Preparing Orders"
        btnPreparing.UseVisualStyleBackColor = False
        ' 
        ' btnReady
        ' 
        btnReady.BackColor = Color.LightGreen
        btnReady.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReady.ForeColor = Color.White
        btnReady.Location = New Point(459, 9)
        btnReady.Name = "btnReady"
        btnReady.Size = New Size(386, 58)
        btnReady.TabIndex = 1
        btnReady.Text = "Ready for Pick-Up"
        btnReady.UseVisualStyleBackColor = False
        ' 
        ' btnComplete
        ' 
        btnComplete.BackColor = SystemColors.ActiveCaption
        btnComplete.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnComplete.ForeColor = Color.White
        btnComplete.Location = New Point(878, 9)
        btnComplete.Name = "btnComplete"
        btnComplete.Size = New Size(386, 58)
        btnComplete.TabIndex = 2
        btnComplete.Text = "Order's Complete"
        btnComplete.UseVisualStyleBackColor = False
        ' 
        ' Monitoring_buttons
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnComplete)
        Controls.Add(btnReady)
        Controls.Add(btnPreparing)
        Name = "Monitoring_buttons"
        Size = New Size(1299, 77)
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnPreparing As Button
    Friend WithEvents btnReady As Button
    Friend WithEvents btnComplete As Button

End Class
