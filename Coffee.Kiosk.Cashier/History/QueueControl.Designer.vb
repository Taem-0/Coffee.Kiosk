<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QueueControl
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
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        lblTitle = New Label()
        lblFilterLabel = New Label()
        rbAll = New RadioButton()
        rbToday = New RadioButton()
        rbThisWeek = New RadioButton()
        dgvQueue = New DataGridView()
        OrderID = New DataGridViewTextBoxColumn()
        Queue = New DataGridViewTextBoxColumn()
        DateTime = New DataGridViewTextBoxColumn()
        StaffName = New DataGridViewTextBoxColumn()
        Total = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        btnRefresh = New Button()
        btnBack = New Button()
        btnViewDetails = New Button()
        lblInQueue = New Label()
        Label1 = New Label()
        CType(dgvQueue, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblTitle.Location = New Point(42, 31)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(663, 46)
        lblTitle.TabIndex = 8
        lblTitle.Text = "QUEUE TRACKER - Order Sent to Display"
        ' 
        ' lblFilterLabel
        ' 
        lblFilterLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFilterLabel.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblFilterLabel.Location = New Point(42, 118)
        lblFilterLabel.Name = "lblFilterLabel"
        lblFilterLabel.Size = New Size(94, 36)
        lblFilterLabel.TabIndex = 9
        lblFilterLabel.Text = "Filter:"
        lblFilterLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' rbAll
        ' 
        rbAll.AutoSize = True
        rbAll.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbAll.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        rbAll.Location = New Point(167, 118)
        rbAll.Name = "rbAll"
        rbAll.Size = New Size(59, 32)
        rbAll.TabIndex = 10
        rbAll.TabStop = True
        rbAll.Text = "All"
        rbAll.UseVisualStyleBackColor = True
        ' 
        ' rbToday
        ' 
        rbToday.AutoSize = True
        rbToday.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbToday.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        rbToday.Location = New Point(308, 118)
        rbToday.Name = "rbToday"
        rbToday.Size = New Size(89, 32)
        rbToday.TabIndex = 11
        rbToday.TabStop = True
        rbToday.Text = "Today"
        rbToday.UseVisualStyleBackColor = True
        ' 
        ' rbThisWeek
        ' 
        rbThisWeek.AutoSize = True
        rbThisWeek.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbThisWeek.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        rbThisWeek.Location = New Point(460, 120)
        rbThisWeek.Name = "rbThisWeek"
        rbThisWeek.Size = New Size(130, 32)
        rbThisWeek.TabIndex = 12
        rbThisWeek.TabStop = True
        rbThisWeek.Text = "This Week"
        rbThisWeek.UseVisualStyleBackColor = True
        ' 
        ' dgvQueue
        ' 
        dgvQueue.AllowUserToAddRows = False
        dgvQueue.AllowUserToResizeColumns = False
        dgvQueue.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = Color.White
        dgvQueue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        dgvQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvQueue.BackgroundColor = Color.White
        dgvQueue.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.White
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        dgvQueue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        dgvQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvQueue.Columns.AddRange(New DataGridViewColumn() {OrderID, Queue, DateTime, StaffName, Total, Status})
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = SystemColors.Window
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle8.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        DataGridViewCellStyle8.Padding = New Padding(10)
        DataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dgvQueue.DefaultCellStyle = DataGridViewCellStyle8
        dgvQueue.GridColor = Color.LightGray
        dgvQueue.Location = New Point(42, 180)
        dgvQueue.MultiSelect = False
        dgvQueue.Name = "dgvQueue"
        dgvQueue.ReadOnly = True
        dgvQueue.RowHeadersVisible = False
        dgvQueue.RowHeadersWidth = 51
        dgvQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvQueue.Size = New Size(1588, 650)
        dgvQueue.TabIndex = 13
        ' 
        ' OrderID
        ' 
        OrderID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Padding = New Padding(10)
        OrderID.DefaultCellStyle = DataGridViewCellStyle7
        OrderID.HeaderText = "Order ID"
        OrderID.MinimumWidth = 6
        OrderID.Name = "OrderID"
        OrderID.ReadOnly = True
        OrderID.Width = 250
        ' 
        ' Queue
        ' 
        Queue.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Queue.HeaderText = "Queue"
        Queue.MinimumWidth = 6
        Queue.Name = "Queue"
        Queue.ReadOnly = True
        Queue.Width = 235
        ' 
        ' DateTime
        ' 
        DateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        DateTime.HeaderText = "Date/Time"
        DateTime.MinimumWidth = 6
        DateTime.Name = "DateTime"
        DateTime.ReadOnly = True
        DateTime.Width = 300
        ' 
        ' StaffName
        ' 
        StaffName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        StaffName.HeaderText = "Staff Name"
        StaffName.MinimumWidth = 6
        StaffName.Name = "StaffName"
        StaffName.ReadOnly = True
        StaffName.Width = 400
        ' 
        ' Total
        ' 
        Total.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Total.HeaderText = "Total"
        Total.MinimumWidth = 6
        Total.Name = "Total"
        Total.ReadOnly = True
        Total.Width = 200
        ' 
        ' Status
        ' 
        Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Status.HeaderText = "Status"
        Status.MinimumWidth = 6
        Status.Name = "Status"
        Status.ReadOnly = True
        Status.Width = 200
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(1432, 1002)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(200, 60)
        btnRefresh.TabIndex = 18
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(1139, 1002)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(200, 60)
        btnBack.TabIndex = 17
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' btnViewDetails
        ' 
        btnViewDetails.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnViewDetails.FlatStyle = FlatStyle.Flat
        btnViewDetails.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnViewDetails.ForeColor = Color.White
        btnViewDetails.Location = New Point(44, 1002)
        btnViewDetails.Name = "btnViewDetails"
        btnViewDetails.Size = New Size(200, 60)
        btnViewDetails.TabIndex = 16
        btnViewDetails.Text = "View Details"
        btnViewDetails.UseVisualStyleBackColor = False
        ' 
        ' lblInQueue
        ' 
        lblInQueue.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblInQueue.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblInQueue.Location = New Point(42, 858)
        lblInQueue.Name = "lblInQueue"
        lblInQueue.Size = New Size(307, 38)
        lblInQueue.TabIndex = 19
        lblInQueue.Text = "Total Orders in Queue: 0"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Label1.Location = New Point(44, 907)
        Label1.Name = "Label1"
        Label1.Size = New Size(331, 38)
        Label1.TabIndex = 20
        Label1.Text = "Total Orders Served Today: 0"
        ' 
        ' QueueControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(Label1)
        Controls.Add(lblInQueue)
        Controls.Add(btnRefresh)
        Controls.Add(btnBack)
        Controls.Add(btnViewDetails)
        Controls.Add(dgvQueue)
        Controls.Add(rbThisWeek)
        Controls.Add(rbToday)
        Controls.Add(rbAll)
        Controls.Add(lblFilterLabel)
        Controls.Add(lblTitle)
        ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Name = "QueueControl"
        Size = New Size(1669, 1082)
        CType(dgvQueue, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblFilterLabel As Label
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents rbToday As RadioButton
    Friend WithEvents rbThisWeek As RadioButton
    Friend WithEvents dgvQueue As DataGridView
    Friend WithEvents OrderID As DataGridViewTextBoxColumn
    Friend WithEvents Queue As DataGridViewTextBoxColumn
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents StaffName As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents lblInQueue As Label
    Friend WithEvents Label1 As Label

End Class
