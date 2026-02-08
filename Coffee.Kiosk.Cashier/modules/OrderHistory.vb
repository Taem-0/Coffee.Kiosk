Module OrderHistory

    Public Structure OrderItem
        Public ItemName As String
        Public Quantity As Decimal
        Public Price As Decimal
        Public Subtotal As Decimal
        Public Customizations As String
    End Structure


    Public Structure OrderRecord
        Public OrderID As String
        Public QueueNumber As Integer
        Public OrderDate As DateTime
        Public StaffName As String
        Public Items As List(Of OrderItem)
        Public TotalAmount As Decimal
        Public PaymentMethod As String
        Public Status As String
    End Structure


    Public OrderHistory As New List(Of OrderRecord)


    Public CurrentQueueNumber As Integer = 0


    Public Sub AddOrderToHistory(order As OrderRecord)
        OrderHistory.Add(order)
    End Sub


    Public Function GetFilteredOrders(filter As String) As List(Of OrderRecord)
        Dim filteredOrders As New List(Of OrderRecord)
        Dim today As Date = Date.Today

        Select Case filter
            Case "Today"
                filteredOrders = OrderHistory.Where(Function(o) o.OrderDate.Date = today).ToList()
            Case "ThisWeek"
                Dim startOfWeek As Date = today.AddDays(-(today.DayOfWeek))
                Dim endOfWeek As Date = startOfWeek.AddDays(6)
                filteredOrders = OrderHistory.Where(Function(o) o.OrderDate.Date >= startOfWeek And o.OrderDate.Date <= endOfWeek).ToList()
            Case "AllTime"
                filteredOrders = OrderHistory
        End Select


        Return filteredOrders.OrderByDescending(Function(o) o.OrderDate).ToList()
    End Function


    Public Function GetOrderByID(orderID As String) As OrderRecord?
        For Each order In OrderHistory
            If order.OrderID = orderID Then
                Return order
            End If
        Next
        Return Nothing
    End Function


    Public Function GetNextQueueNumber() As Integer
        CurrentQueueNumber += 1
        Return CurrentQueueNumber
    End Function


    Public Function GetTotalSales(orders As List(Of OrderRecord)) As Decimal
        Dim total As Decimal = 0
        For Each order In orders
            total += order.TotalAmount
        Next
        Return total
    End Function


    Public Sub ResetQueueNumber()
        CurrentQueueNumber = 0
    End Sub
End Module