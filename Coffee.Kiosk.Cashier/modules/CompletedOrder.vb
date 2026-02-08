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