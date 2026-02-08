<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistoryPageControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistoryPageControl))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        txtSearch = New TextBox()
        ProfileBox = New PictureBox()
        lblUsername = New Label()
        lblOrderHistory = New Label()
        btnToday = New Button()
        btnThisWeek = New Button()
        pnlFilters = New Panel()
        btnAllTime = New Button()
        pnlStats = New Panel()
        lblSales = New Label()
        lblSalesLabel = New Label()
        lblTodayOrders = New Label()
        lblTodayLabel = New Label()
        dgvHistory = New DataGridView()
        OrderID = New DataGridViewTextBoxColumn()
        Queue = New DataGridViewTextBoxColumn()
        DateTime = New DataGridViewTextBoxColumn()
        StaffName = New DataGridViewTextBoxColumn()
        Total = New DataGridViewTextBoxColumn()
        Payment = New DataGridViewTextBoxColumn()
        btnViewDetails = New Button()
        btnViewReceipt = New Button()
        btnQueue = New Button()
        btnRefresh = New Button()
        CType(ProfileBox, ComponentModel.ISupportInitialize).BeginInit()
        pnlFilters.SuspendLayout()
        pnlStats.SuspendLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(932, 23)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = " 🔍 Search"
        txtSearch.Size = New Size(611, 38)
        txtSearch.TabIndex = 6
        ' 
        ' ProfileBox
        ' 
        ProfileBox.BackgroundImage = CType(resources.GetObject("ProfileBox.BackgroundImage"), Image)
        ProfileBox.BackgroundImageLayout = ImageLayout.Zoom
        ProfileBox.Location = New Point(1558, 25)
        ProfileBox.Name = "ProfileBox"
        ProfileBox.Size = New Size(84, 78)
        ProfileBox.TabIndex = 5
        ProfileBox.TabStop = False
        ' 
        ' lblUsername
        ' 
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblUsername.Location = New Point(1235, 55)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(317, 36)
        lblUsername.TabIndex = 4
        lblUsername.Text = "Staff Name " & vbCrLf
        lblUsername.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblOrderHistory
        ' 
        lblOrderHistory.AutoSize = True
        lblOrderHistory.Font = New Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblOrderHistory.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblOrderHistory.Location = New Point(39, 27)
        lblOrderHistory.Name = "lblOrderHistory"
        lblOrderHistory.Size = New Size(286, 46)
        lblOrderHistory.TabIndex = 7
        lblOrderHistory.Text = "ORDER HISTORY"
        ' 
        ' btnToday
        ' 
        btnToday.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnToday.FlatStyle = FlatStyle.Flat
        btnToday.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnToday.ForeColor = Color.White
        btnToday.Location = New Point(27, 23)
        btnToday.Name = "btnToday"
        btnToday.Size = New Size(229, 40)
        btnToday.TabIndex = 7
        btnToday.Text = "Today"
        btnToday.UseVisualStyleBackColor = False
        ' 
        ' btnThisWeek
        ' 
        btnThisWeek.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnThisWeek.FlatStyle = FlatStyle.Flat
        btnThisWeek.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnThisWeek.ForeColor = Color.White
        btnThisWeek.Location = New Point(325, 23)
        btnThisWeek.Name = "btnThisWeek"
        btnThisWeek.Size = New Size(229, 40)
        btnThisWeek.TabIndex = 8
        btnThisWeek.Text = "This Week"
        btnThisWeek.UseVisualStyleBackColor = False
        ' 
        ' pnlFilters
        ' 
        pnlFilters.BackColor = Color.White
        pnlFilters.Controls.Add(btnAllTime)
        pnlFilters.Controls.Add(btnToday)
        pnlFilters.Controls.Add(txtSearch)
        pnlFilters.Controls.Add(btnThisWeek)
        pnlFilters.Location = New Point(39, 125)
        pnlFilters.Name = "pnlFilters"
        pnlFilters.Size = New Size(1588, 80)
        pnlFilters.TabIndex = 9
        ' 
        ' btnAllTime
        ' 
        btnAllTime.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnAllTime.FlatStyle = FlatStyle.Flat
        btnAllTime.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAllTime.ForeColor = Color.White
        btnAllTime.Location = New Point(641, 23)
        btnAllTime.Name = "btnAllTime"
        btnAllTime.Size = New Size(229, 40)
        btnAllTime.TabIndex = 9
        btnAllTime.Text = "All Time"
        btnAllTime.UseVisualStyleBackColor = False
        ' 
        ' pnlStats
        ' 
        pnlStats.BackColor = Color.White
        pnlStats.Controls.Add(lblSales)
        pnlStats.Controls.Add(lblSalesLabel)
        pnlStats.Controls.Add(lblTodayOrders)
        pnlStats.Controls.Add(lblTodayLabel)
        pnlStats.Location = New Point(39, 226)
        pnlStats.Name = "pnlStats"
        pnlStats.Size = New Size(1588, 70)
        pnlStats.TabIndex = 10
        ' 
        ' lblSales
        ' 
        lblSales.AutoSize = True
        lblSales.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSales.Location = New Point(554, 17)
        lblSales.Name = "lblSales"
        lblSales.Size = New Size(99, 38)
        lblSales.TabIndex = 3
        lblSales.Text = "₱ 0.00"
        ' 
        ' lblSalesLabel
        ' 
        lblSalesLabel.AutoSize = True
        lblSalesLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSalesLabel.Location = New Point(407, 24)
        lblSalesLabel.Name = "lblSalesLabel"
        lblSalesLabel.Size = New Size(141, 28)
        lblSalesLabel.TabIndex = 2
        lblSalesLabel.Text = "Today's Sales:"
        ' 
        ' lblTodayOrders
        ' 
        lblTodayOrders.AutoSize = True
        lblTodayOrders.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTodayOrders.Location = New Point(201, 14)
        lblTodayOrders.Name = "lblTodayOrders"
        lblTodayOrders.Size = New Size(49, 38)
        lblTodayOrders.TabIndex = 1
        lblTodayOrders.Text = "00"
        ' 
        ' lblTodayLabel
        ' 
        lblTodayLabel.AutoSize = True
        lblTodayLabel.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTodayLabel.Location = New Point(27, 24)
        lblTodayLabel.Name = "lblTodayLabel"
        lblTodayLabel.Size = New Size(156, 28)
        lblTodayLabel.TabIndex = 0
        lblTodayLabel.Text = "Today's Orders:"
        ' 
        ' dgvHistory
        ' 
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToResizeColumns = False
        dgvHistory.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.White
        dgvHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvHistory.BackgroundColor = Color.White
        dgvHistory.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvHistory.Columns.AddRange(New DataGridViewColumn() {OrderID, Queue, DateTime, StaffName, Total, Payment})
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle4.Padding = New Padding(10)
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False
        dgvHistory.DefaultCellStyle = DataGridViewCellStyle4
        dgvHistory.GridColor = Color.LightGray
        dgvHistory.Location = New Point(39, 328)
        dgvHistory.MultiSelect = False
        dgvHistory.Name = "dgvHistory"
        dgvHistory.ReadOnly = True
        dgvHistory.RowHeadersVisible = False
        dgvHistory.RowHeadersWidth = 51
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHistory.Size = New Size(1588, 650)
        dgvHistory.TabIndex = 11
        ' 
        ' OrderID
        ' 
        OrderID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Padding = New Padding(10)
        OrderID.DefaultCellStyle = DataGridViewCellStyle3
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
        ' Payment
        ' 
        Payment.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Payment.HeaderText = "Payment"
        Payment.MinimumWidth = 6
        Payment.Name = "Payment"
        Payment.ReadOnly = True
        Payment.Width = 200
        ' 
        ' btnViewDetails
        ' 
        btnViewDetails.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnViewDetails.FlatStyle = FlatStyle.Flat
        btnViewDetails.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnViewDetails.ForeColor = Color.White
        btnViewDetails.Location = New Point(39, 999)
        btnViewDetails.Name = "btnViewDetails"
        btnViewDetails.Size = New Size(200, 60)
        btnViewDetails.TabIndex = 12
        btnViewDetails.Text = "View Details"
        btnViewDetails.UseVisualStyleBackColor = False
        ' 
        ' btnViewReceipt
        ' 
        btnViewReceipt.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnViewReceipt.FlatStyle = FlatStyle.Flat
        btnViewReceipt.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnViewReceipt.ForeColor = Color.White
        btnViewReceipt.Location = New Point(334, 999)
        btnViewReceipt.Name = "btnViewReceipt"
        btnViewReceipt.Size = New Size(200, 60)
        btnViewReceipt.TabIndex = 13
        btnViewReceipt.Text = "View Receipt"
        btnViewReceipt.UseVisualStyleBackColor = False
        ' 
        ' btnQueue
        ' 
        btnQueue.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnQueue.FlatStyle = FlatStyle.Flat
        btnQueue.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnQueue.ForeColor = Color.White
        btnQueue.Location = New Point(1134, 999)
        btnQueue.Name = "btnQueue"
        btnQueue.Size = New Size(200, 60)
        btnQueue.TabIndex = 14
        btnQueue.Text = "Queue Tracker"
        btnQueue.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(1427, 999)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(200, 60)
        btnRefresh.TabIndex = 15
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' HistoryPageControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(btnRefresh)
        Controls.Add(btnQueue)
        Controls.Add(btnViewReceipt)
        Controls.Add(btnViewDetails)
        Controls.Add(dgvHistory)
        Controls.Add(pnlStats)
        Controls.Add(pnlFilters)
        Controls.Add(lblOrderHistory)
        Controls.Add(ProfileBox)
        Controls.Add(lblUsername)
        Name = "HistoryPageControl"
        Size = New Size(1669, 1082)
        CType(ProfileBox, ComponentModel.ISupportInitialize).EndInit()
        pnlFilters.ResumeLayout(False)
        pnlFilters.PerformLayout()
        pnlStats.ResumeLayout(False)
        pnlStats.PerformLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtSearch As TextBox
    Friend WithEvents ProfileBox As PictureBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblOrderHistory As Label
    Friend WithEvents btnThisWeek As Button
    Friend WithEvents btnToday As Button
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents btnAllTime As Button
    Friend WithEvents pnlStats As Panel
    Friend WithEvents lblTodayLabel As Label
    Friend WithEvents lblTodayOrders As Label
    Friend WithEvents lblSalesLabel As Label
    Friend WithEvents lblSales As Label
    Friend WithEvents dgvHistory As DataGridView
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents btnViewReceipt As Button
    Friend WithEvents btnQueue As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents OrderID As DataGridViewTextBoxColumn
    Friend WithEvents Queue As DataGridViewTextBoxColumn
    Friend WithEvents DateTime As DataGridViewTextBoxColumn
    Friend WithEvents StaffName As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Payment As DataGridViewTextBoxColumn

End Class
