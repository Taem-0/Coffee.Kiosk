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
        Panel1 = New Panel()
        Panel3 = New Panel()
        btnFinish = New Button()
        btnStart = New Button()
        Panel2 = New Panel()
        lblPlaceEat = New Label()
        lblWaitTime = New Label()
        lblTimeOrder = New Label()
        lblOrderNumber = New Label()
        lstBxOrder = New ListBox()
        tmrWait = New Timer(components)
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(lstBxOrder)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(345, 530)
        Panel1.TabIndex = 5
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(160), CByte(120), CByte(86))
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(btnFinish)
        Panel3.Controls.Add(btnStart)
        Panel3.Location = New Point(-1, 459)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(345, 69)
        Panel3.TabIndex = 1
        ' 
        ' btnFinish
        ' 
        btnFinish.BackColor = Color.White
        btnFinish.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnFinish.Location = New Point(191, 14)
        btnFinish.Name = "btnFinish"
        btnFinish.Size = New Size(123, 39)
        btnFinish.TabIndex = 1
        btnFinish.Text = "COMPLETE"
        btnFinish.UseVisualStyleBackColor = False
        ' 
        ' btnStart
        ' 
        btnStart.BackColor = Color.White
        btnStart.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnStart.Location = New Point(32, 14)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(123, 39)
        btnStart.TabIndex = 0
        btnStart.Text = "START"
        btnStart.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(160), CByte(120), CByte(86))
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(lblPlaceEat)
        Panel2.Controls.Add(lblWaitTime)
        Panel2.Controls.Add(lblTimeOrder)
        Panel2.Controls.Add(lblOrderNumber)
        Panel2.Location = New Point(-1, -1)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(345, 69)
        Panel2.TabIndex = 0
        ' 
        ' lblPlaceEat
        ' 
        lblPlaceEat.AutoSize = True
        lblPlaceEat.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPlaceEat.ForeColor = Color.White
        lblPlaceEat.Location = New Point(258, 8)
        lblPlaceEat.Name = "lblPlaceEat"
        lblPlaceEat.Size = New Size(67, 23)
        lblPlaceEat.TabIndex = 3
        lblPlaceEat.Text = "Dine In"
        ' 
        ' lblWaitTime
        ' 
        lblWaitTime.AutoSize = True
        lblWaitTime.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWaitTime.ForeColor = Color.White
        lblWaitTime.Location = New Point(269, 35)
        lblWaitTime.Name = "lblWaitTime"
        lblWaitTime.Size = New Size(50, 23)
        lblWaitTime.TabIndex = 2
        lblWaitTime.Text = "Time"
        ' 
        ' lblTimeOrder
        ' 
        lblTimeOrder.AutoSize = True
        lblTimeOrder.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTimeOrder.ForeColor = Color.White
        lblTimeOrder.Location = New Point(13, 35)
        lblTimeOrder.Name = "lblTimeOrder"
        lblTimeOrder.Size = New Size(50, 23)
        lblTimeOrder.TabIndex = 1
        lblTimeOrder.Text = "Time"
        ' 
        ' lblOrderNumber
        ' 
        lblOrderNumber.AutoSize = True
        lblOrderNumber.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderNumber.ForeColor = Color.White
        lblOrderNumber.Location = New Point(11, 8)
        lblOrderNumber.Name = "lblOrderNumber"
        lblOrderNumber.Size = New Size(72, 23)
        lblOrderNumber.TabIndex = 0
        lblOrderNumber.Text = "Order #"
        ' 
        ' lstBxOrder
        ' 
        lstBxOrder.BorderStyle = BorderStyle.None
        lstBxOrder.FormattingEnabled = True
        lstBxOrder.Location = New Point(0, 74)
        lstBxOrder.Name = "lstBxOrder"
        lstBxOrder.Size = New Size(341, 380)
        lstBxOrder.TabIndex = 2
        ' 
        ' tmrWait
        ' 
        tmrWait.Interval = 1000
        ' 
        ' ucOrderCard
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "ucOrderCard"
        Size = New Size(345, 530)
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFinish As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents lblOrderNumber As Label
    Friend WithEvents lblTimeOrder As Label
    Friend WithEvents lblPlaceEat As Label
    Friend WithEvents lblWaitTime As Label
    Friend WithEvents tmrWait As Timer
    Friend WithEvents lstBxOrder As ListBox

End Class
