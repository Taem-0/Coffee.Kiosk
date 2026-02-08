Imports System.Linq

Public Class HistoryPageControl
    Private currentFilter As String = "Today"
    Private selectedOrderID As Integer = -1

    Private Sub HistoryPageControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDataGridView()

        Dim mainForm = TryCast(Me.FindForm(), CashierHome)
        If mainForm IsNot Nothing Then
            lblUsername.Text = mainForm.Username
        End If

        LoadOrderHistory("Today")
        SetActiveFilterButton(btnToday)
    End Sub

    Private Sub SetupDataGridView()
        dgvHistory.AutoGenerateColumns = False
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHistory.MultiSelect = False
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.ReadOnly = True
        dgvHistory.RowHeadersVisible = False
        dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(101, 67, 33)
        dgvHistory.DefaultCellStyle.SelectionForeColor = Color.White
        dgvHistory.RowTemplate.Height = 40
        dgvHistory.Columns.Clear()

        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "OrderID",
            .HeaderText = "Order ID",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Queue",
            .HeaderText = "Queue",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "DateTime",
            .HeaderText = "Date/Time",
            .Width = 200,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })

        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "StaffName",
            .HeaderText = "Staff Name",
            .Width = 200,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleLeft}
        })

        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Total",
            .HeaderText = "Total",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle With {
                .Format = "₱ 0.00",
                .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        })

        dgvHistory.Columns.Add(New DataGridViewTextBoxColumn With {
            .Name = "Payment",
            .HeaderText = "Payment",
            .Width = 150,
            .DefaultCellStyle = New DataGridViewCellStyle With {.Alignment = DataGridViewContentAlignment.MiddleCenter}
        })
    End Sub

    Private Sub LoadOrderHistory(filter As String)
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
            Case "AllTime"
                filteredOrders = allOrders
            Case Else
                filteredOrders = allOrders
        End Select

        filteredOrders = filteredOrders.OrderByDescending(Function(o) o.OrderDate).ToList()

        dgvHistory.Rows.Clear()

        For Each order In filteredOrders
            dgvHistory.Rows.Add(
                order.OrderId,
                order.QueueNumber,
                order.OrderDate.ToString("MM/dd/yyyy hh:mm tt"),
                order.StaffName,
                order.TotalAmount,
                order.PaymentMethod
            )
        Next

        UpdateStatistics(filteredOrders)
    End Sub

    Private Sub UpdateStatistics(orders As List(Of CompletedOrder))
        lblTodayOrders.Text = orders.Count.ToString("00")

        Dim totalSales As Decimal = 0
        For Each order In orders
            totalSales += order.TotalAmount
        Next

        lblSales.Text = "₱ " & totalSales.ToString("0.00")
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        LoadOrderHistory("Today")
        SetActiveFilterButton(btnToday)
    End Sub

    Private Sub btnThisWeek_Click(sender As Object, e As EventArgs) Handles btnThisWeek.Click
        LoadOrderHistory("ThisWeek")
        SetActiveFilterButton(btnThisWeek)
    End Sub

    Private Sub btnAllTime_Click(sender As Object, e As EventArgs) Handles btnAllTime.Click
        LoadOrderHistory("AllTime")
        SetActiveFilterButton(btnAllTime)
    End Sub

    Private Sub SetActiveFilterButton(activeButton As Button)
        btnToday.BackColor = Color.FromArgb(139, 90, 43)
        btnThisWeek.BackColor = Color.FromArgb(139, 90, 43)
        btnAllTime.BackColor = Color.FromArgb(139, 90, 43)

        activeButton.BackColor = Color.FromArgb(101, 67, 33)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Then
            LoadOrderHistory(currentFilter)
        Else
            Dim allOrders As List(Of CompletedOrder) = OrderManager.LoadOrders()
            Dim today As Date = Date.Today

            Select Case currentFilter
                Case "Today"
                    allOrders = allOrders.Where(Function(o) o.OrderDate.Date = today).ToList()
                Case "ThisWeek"
                    Dim startOfWeek As Date = today.AddDays(-(today.DayOfWeek))
                    Dim endOfWeek As Date = startOfWeek.AddDays(6)
                    allOrders = allOrders.Where(Function(o) o.OrderDate.Date >= startOfWeek And o.OrderDate.Date <= endOfWeek).ToList()
            End Select

            dgvHistory.Rows.Clear()

            For Each order In allOrders
                If order.OrderId.ToString().Contains(searchText) OrElse
                   order.StaffName.ToLower().Contains(searchText) OrElse
                   order.QueueNumber.ToLower().Contains(searchText) OrElse
                   order.PaymentMethod.ToLower().Contains(searchText) Then

                    dgvHistory.Rows.Add(
                        order.OrderId,
                        order.QueueNumber,
                        order.OrderDate.ToString("MM/dd/yyyy hh:mm tt"),
                        order.StaffName,
                        order.TotalAmount,
                        order.PaymentMethod
                    )
                End If
            Next
        End If
    End Sub

    Private Sub dgvHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellContentClick
        If e.RowIndex >= 0 Then
            selectedOrderID = Convert.ToInt32(dgvHistory.Rows(e.RowIndex).Cells("OrderID").Value)
        End If
    End Sub

    Private Sub dgvHistory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellClick
        If e.RowIndex >= 0 Then
            selectedOrderID = Convert.ToInt32(dgvHistory.Rows(e.RowIndex).Cells("OrderID").Value)
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

    Private Sub btnViewReceipt_Click(sender As Object, e As EventArgs) Handles btnViewReceipt.Click
        If selectedOrderID = -1 Then
            MessageBox.Show("Please select an order first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim allOrders = OrderManager.LoadOrders()
        Dim order = allOrders.FirstOrDefault(Function(o) o.OrderId = selectedOrderID)

        If order IsNot Nothing Then
            Dim receiptText As String = ReceiptHelper.GenerateReceiptText(
                order.OrderId,
                order.QueueNumber,
                order.StaffName,
                order.Items,
                order.TotalAmount,
                order.PaymentMethod,
                order.AmountPaid,
                order.ChangeAmount,
                order.ReferenceNumber
            )

            ReceiptHelper.PreviewReceipt(receiptText)
        Else
            MessageBox.Show("Order not found.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnQueue_Click(sender As Object, e As EventArgs) Handles btnQueue.Click
        Dim queueControl As New QueueControl()

        Dim mainForm As CashierHome = DirectCast(Me.FindForm(), CashierHome)
        mainForm.HomeScreenPanel.Controls.Clear()
        mainForm.HomeScreenPanel.Controls.Add(queueControl)
        queueControl.Dock = DockStyle.Fill
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadOrderHistory(currentFilter)
        selectedOrderID = -1
        MessageBox.Show("History refreshed!", "Refresh",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class