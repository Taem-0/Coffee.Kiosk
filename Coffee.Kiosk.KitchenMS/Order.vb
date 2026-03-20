Public Class Order
    Public Property OrderId As Integer
    Public Property OrderNumber As String
    Public Property OrderTime As DateTime
    Public Property Status As OrderStatus
    Public Property OrderType As String
    Public Property Items As New List(Of OrderItem)
End Class

Public Class OrderItem
    Public Property ItemId As Integer
    Public Property ItemName As String

    Public Property Quantity As Integer
    Public Property Customizations As New List(Of String)
End Class

Public Enum OrderStatus
    Pending
    Paid
    Canceled
    Completed
End Enum
