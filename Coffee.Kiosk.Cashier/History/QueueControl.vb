Imports System.Linq

Public Class QueueControl
    Private currentFilter As String = "All"
    Private selectedOrderID As Integer = -1

    Private Sub QueueControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()
        LoadQueueData("All")
        SetActiveFilterButton(rbAll)
    End Sub

    Private Sub SetupDataGridView()
        dgvQueue.AutoGenerateColumns = False
        dgvQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvQueue.MultiSelect = False
        dgvQueue.AllowUserToAddRows = False
        dgvQueue.ReadOnly = True
        dgvQueue.RowHeadersVisible = False
        dgvQueue.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        dgvQueue.DefaultCellStyle.SelectionBackColor = Color.FromArgb(101, 67, 33)
        dgvQueue.DefaultCellStyle.SelectionForeColor = Color.White
        dgvQueue.RowTemplate.Height = 40
        dgvQueue.Columns.Clear()

        dgvQueue.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "OrderID",
            .HeaderText = "Order ID",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvQueue.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Queue",
            .HeaderText = "Queue",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvQueue.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Time",
            .HeaderText = "Time",
            .Width = 180,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvQueue.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "StaffName",
            .HeaderText = "Staff",
            .Width = 350,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleLeft}
        })

        dgvQueue.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Total",
            .HeaderText = "Total",
            .Width = 180,
            .DefaultCellStyle = New DataGridViewCellStyle With {
                .Format = "₱ 0.00",
                .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        })

        dgvQueue.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Status",
            .HeaderText = "Status",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
    End Sub

    Private Sub LoadQueueData(filter As String)
        currentFilter = filter

        Dim allOrders As List(Of CompletedOrder) = OrderManager.LoadOrders()
        Dim filteredOrders As List(Of CompletedOrder)
        Dim today As Date = Date.Today

        Select Case filter
            Case "Today"
                filteredOrders = allOrders.Where(Function(o) o.OrderDate.Date = today).ToList()
            Case "ThisWeek"
                Dim startOfWeek As Date = today.AddDays(-(today.DayOfWeek))
                Dim endOfWeek As Date = startOfWeek.AddDays(6)
                filteredOrders = allOrders.Where(Function(o) o.OrderDate.Date >= startOfWeek And o.OrderDate.Date <= endOfWeek).ToList()
            Case Else
                filteredOrders = allOrders
        End Select

        filteredOrders = filteredOrders.OrderByDescending(Function(o) o.OrderDate).ToList()

        dgvQueue.Rows.Clear()

        For Each order In filteredOrders
            Dim status As String = "Served"

            dgvQueue.Rows.Add(
                order.OrderId,
                order.QueueNumber,
                order.OrderDate.ToString("hh:mm tt"),
                order.StaffName,
                order.TotalAmount,
                status
            )
        Next

        UpdateStatistics(filteredOrders)
    End Sub

    Private Sub UpdateStatistics(orders As List(Of CompletedOrder))
        Dim todayOrders = orders.Where(Function(o) o.OrderDate.Date = Date.Today).ToList()

        Dim inQueue As Integer = 0
        Dim served As Integer = todayOrders.Count

        lblInQueue.Text = $"Total Orders in Queue: {inQueue}"
        Label1.Text = $"Total Orders Served Today: {served}"
    End Sub

    Private Sub rbAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbAll.CheckedChanged
        If rbAll.Checked Then
            LoadQueueData("All")
            SetActiveFilterButton(rbAll)
        End If
    End Sub

    Private Sub rbToday_CheckedChanged(sender As Object, e As EventArgs) Handles rbToday.CheckedChanged
        If rbToday.Checked Then
            LoadQueueData("Today")
            SetActiveFilterButton(rbToday)
        End If
    End Sub

    Private Sub rbThisWeek_CheckedChanged(sender As Object, e As EventArgs) Handles rbThisWeek.CheckedChanged
        If rbThisWeek.Checked Then
            LoadQueueData("ThisWeek")
            SetActiveFilterButton(rbThisWeek)
        End If
    End Sub

    Private Sub SetActiveFilterButton(activeRadio As RadioButton)
        rbAll.ForeColor = Color.FromArgb(62, 39, 35)
        rbToday.ForeColor = Color.FromArgb(62, 39, 35)
        rbThisWeek.ForeColor = Color.FromArgb(62, 39, 35)

        activeRadio.ForeColor = Color.FromArgb(101, 67, 33)
        activeRadio.Font = New Font(activeRadio.Font, FontStyle.Bold)
    End Sub

    Private Sub dgvHistory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQueue.CellClick
        If e.RowIndex >= 0 Then
            selectedOrderID = Convert.ToInt32(dgvQueue.Rows(e.RowIndex).Cells("OrderID").Value)
        End If
    End Sub

    Private Sub dgvHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvQueue.CellContentClick
        If e.RowIndex >= 0 Then
            selectedOrderID = Convert.ToInt32(dgvQueue.Rows(e.RowIndex).Cells("OrderID").Value)
        End If
    End Sub

    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If selectedOrderID = -1 Then
            MessageBox.Show("Please select an order first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim allOrders = OrderManager.LoadOrders()
        Dim order = allOrders.FirstOrDefault(Function(o) o.OrderId = selectedOrderID)

        If order IsNot Nothing Then
            Dim detailsForm As New OrderDetails(order)
            detailsForm.ShowDialog()
        Else
            MessageBox.Show("Order not found.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadQueueData(currentFilter)
        selectedOrderID = -1
        MessageBox.Show("Queue refreshed!", "Refresh",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim historyControl As New HistoryPageControl()

        Dim mainForm As CashierHome = DirectCast(Me.FindForm(), CashierHome)
        mainForm.HomeScreenPanel.Controls.Clear()
        mainForm.HomeScreenPanel.Controls.Add(historyControl)
        historyControl.Dock = DockStyle.Fill
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
    End Sub

    Private Sub lblFilterLabel_Click(sender As Object, e As EventArgs) Handles lblFilterLabel.Click
    End Sub

    Private Sub lblInQueue_Click(sender As Object, e As EventArgs) Handles lblInQueue.Click
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub

End Class