<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrderCard
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
        components = New ComponentModel.Container()
        flpItems = New FlowLayoutPanel()
        tmrWait = New Timer(components)
        lblOrderNumber = New Label()
        lblOrderTime = New Label()
        lblWaitTime = New Label()
        lblOrderType = New Label()
        btnAction = New RoundedButton()
        pnlBody = New Panel()
        pnlFooter = New Panel()
        pnlHeader = New Panel()
        pnlBody.SuspendLayout()
        pnlFooter.SuspendLayout()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' flpItems
        ' 
        flpItems.AutoScroll = True
        flpItems.BackColor = Color.White
        flpItems.Location = New Point(1, 3)
        flpItems.Name = "flpItems"
        flpItems.Size = New Size(339, 368)
        flpItems.TabIndex = 2
        ' 
        ' tmrWait
        ' 
        tmrWait.Interval = 1000
        ' 
        ' lblOrderNumber
        ' 
        lblOrderNumber.AutoSize = True
        lblOrderNumber.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderNumber.ForeColor = Color.White
        lblOrderNumber.Location = New Point(9, 13)
        lblOrderNumber.Name = "lblOrderNumber"
        lblOrderNumber.Size = New Size(72, 23)
        lblOrderNumber.TabIndex = 0
        lblOrderNumber.Text = "Order #"
        ' 
        ' lblOrderTime
        ' 
        lblOrderTime.AutoSize = True
        lblOrderTime.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderTime.ForeColor = Color.White
        lblOrderTime.Location = New Point(11, 40)
        lblOrderTime.Name = "lblOrderTime"
        lblOrderTime.Size = New Size(159, 23)
        lblOrderTime.TabIndex = 1
        lblOrderTime.Text = "Time Order Placed"
        ' 
        ' lblWaitTime
        ' 
        lblWaitTime.AutoSize = True
        lblWaitTime.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWaitTime.ForeColor = Color.White
        lblWaitTime.Location = New Point(267, 40)
        lblWaitTime.Name = "lblWaitTime"
        lblWaitTime.Size = New Size(67, 23)
        lblWaitTime.TabIndex = 2
        lblWaitTime.Text = "WTime"
        ' 
        ' lblOrderType
        ' 
        lblOrderType.AutoSize = True
        lblOrderType.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderType.ForeColor = Color.White
        lblOrderType.Location = New Point(256, 13)
        lblOrderType.Name = "lblOrderType"
        lblOrderType.Size = New Size(67, 23)
        lblOrderType.TabIndex = 3
        lblOrderType.Text = "Dine In"
        ' 
        ' btnAction
        ' 
        btnAction.BackColor = Color.White
        btnAction.BorderColor = Color.FromArgb(CByte(92), CByte(51), CByte(23))
        btnAction.BorderSize = 2
        btnAction.CornerRadius = 10
        btnAction.FlatAppearance.BorderColor = Color.FromArgb(CByte(0), CByte(255), CByte(255), CByte(255))
        btnAction.FlatAppearance.BorderSize = 0
        btnAction.FlatStyle = FlatStyle.Flat
        btnAction.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAction.Location = New Point(12, 16)
        btnAction.Name = "btnAction"
        btnAction.Size = New Size(323, 47)
        btnAction.TabIndex = 0
        btnAction.Text = "Start"
        btnAction.UseVisualStyleBackColor = False
        ' 
        ' pnlBody
        ' 
        pnlBody.BackColor = Color.White
        pnlBody.BorderStyle = BorderStyle.FixedSingle
        pnlBody.Controls.Add(pnlFooter)
        pnlBody.Controls.Add(flpItems)
        pnlBody.Location = New Point(0, 76)
        pnlBody.Name = "pnlBody"
        pnlBody.Size = New Size(345, 459)
        pnlBody.TabIndex = 5
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.White
        pnlFooter.Controls.Add(btnAction)
        pnlFooter.Location = New Point(-1, 376)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(347, 81)
        pnlFooter.TabIndex = 3
        ' 
        ' pnlHeader
        ' 
        pnlHeader.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlHeader.BackColor = Color.DimGray
        pnlHeader.Controls.Add(lblOrderType)
        pnlHeader.Controls.Add(lblOrderTime)
        pnlHeader.Controls.Add(lblWaitTime)
        pnlHeader.Controls.Add(lblOrderNumber)
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(345, 77)
        pnlHeader.TabIndex = 0
        ' 
        ' ucOrderCard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(pnlHeader)
        Controls.Add(pnlBody)
        Name = "ucOrderCard"
        Size = New Size(345, 530)
        pnlBody.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents tmrWait As Timer
    Friend WithEvents flpItems As FlowLayoutPanel
    Friend WithEvents lblOrderType As Label
    Friend WithEvents lblWaitTime As Label
    Friend WithEvents lblOrderTime As Label
    Friend WithEvents lblOrderNumber As Label
    Friend WithEvents btnAction As RoundedButton
    Friend WithEvents pnlBody As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlFooter As Panel

End Class
