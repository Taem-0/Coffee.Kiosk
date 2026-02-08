Imports System.IO
Imports Newtonsoft.Json

Module OrderManager
    Private ReadOnly ordersFilePath As String = Path.Combine(Application.StartupPath, "orders.json")
    Private ReadOnly queueFilePath As String = Path.Combine(Application.StartupPath, "queue.json")

    Public Class CompletedOrder
        Public Property OrderId As Integer
        Public Property QueueNumber As String
        Public Property StaffName As String
        Public Property OrderDate As DateTime
        Public Property TotalAmount As Decimal
        Public Property PaymentMethod As String
        Public Property AmountPaid As Decimal
        Public Property ChangeAmount As Decimal
        Public Property ReferenceNumber As String
        Public Property Items As List(Of OrderItem)

        Public Sub New()
            Items = New List(Of OrderItem)()
        End Sub
    End Class

    Public Class QueueData
        Public Property LastQueueDate As Date
        Public Property LastQueueNumber As Integer

        Public Sub New()
            LastQueueDate = DateTime.Now.Date
            LastQueueNumber = 0
        End Sub
    End Class

    Public Function SaveOrder(staffName As String, cart As List(Of OrderItem), totalAmount As Decimal,
                             paymentMethod As String, amountPaid As Decimal, changeAmount As Decimal,
                             Optional referenceNumber As String = Nothing) As CompletedOrder

        Try
            Dim orders As List(Of CompletedOrder) = LoadOrders()
            Dim nextOrderId As Integer = If(orders.Count > 0, orders.Max(Function(o) o.OrderId) + 1, 1)
            Dim queueNumber As String = QueueManager.GenerateQueueNumber()

            Dim newOrder As New CompletedOrder With {
                .OrderId = nextOrderId,
                .QueueNumber = queueNumber,
                .StaffName = staffName,
                .OrderDate = DateTime.Now,
                .TotalAmount = totalAmount,
                .PaymentMethod = paymentMethod,
                .AmountPaid = amountPaid,
                .ChangeAmount = changeAmount,
                .ReferenceNumber = referenceNumber,
                .Items = New List(Of OrderItem)(cart)
            }

            orders.Add(newOrder)

            Dim json As String = JsonConvert.SerializeObject(orders, Formatting.Indented)
            File.WriteAllText(ordersFilePath, json)

            Return newOrder

        Catch ex As Exception
            MessageBox.Show("Failed to save order: " & ex.Message & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function LoadOrders() As List(Of CompletedOrder)
        Try
            If File.Exists(ordersFilePath) Then
                Dim json As String = File.ReadAllText(ordersFilePath)
                Return JsonConvert.DeserializeObject(Of List(Of CompletedOrder))(json)
            Else
                Return New List(Of CompletedOrder)()
            End If
        Catch ex As Exception
            Return New List(Of CompletedOrder)()
        End Try
    End Function

    Public Function GetTodaysOrders() As List(Of CompletedOrder)
        Dim allOrders = LoadOrders()
        Dim today As Date = DateTime.Now.Date
        Return allOrders.Where(Function(o) o.OrderDate.Date = today).ToList()
    End Function

    Public Function LoadQueueData() As QueueData
        Try
            If File.Exists(queueFilePath) Then
                Dim json As String = File.ReadAllText(queueFilePath)
                Return JsonConvert.DeserializeObject(Of QueueData)(json)
            Else
                Return New QueueData()
            End If
        Catch ex As Exception
            Return New QueueData()
        End Try
    End Function

    Public Sub SaveQueueData(queueData As QueueData)
        Try
            Dim json As String = JsonConvert.SerializeObject(queueData, Formatting.Indented)
            File.WriteAllText(queueFilePath, json)
        Catch ex As Exception
        End Try
    End Sub

End Module