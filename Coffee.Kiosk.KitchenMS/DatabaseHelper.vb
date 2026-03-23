Imports MySql.Data.MySqlClient

Public Class DatabaseHelper

    Private Const ConnectionString As String =
        "Server=localhost;Database=coffeekioskdb;Uid=root;Pwd=;"

    Public Shared Function GetPaidOrders() As List(Of Order)
        Dim orders As New List(Of Order)

        Using conn As New MySqlConnection(ConnectionString)
            Try
                conn.Open()

                ' STEP A: get all Paid orders
                Dim orderSql = "SELECT ID, OrderType, Status, CreatedAt 
                                FROM customer_orders 
                                WHERE Status = 'Paid'"

                Using orderCmd As New MySqlCommand(orderSql, conn)
                    Using orderReader = orderCmd.ExecuteReader()
                        While orderReader.Read()
                            Dim order As New Order With {
                                .OrderId = orderReader.GetInt32("ID"),
                                .OrderNumber = orderReader.GetInt32("ID").ToString(),
                                .OrderTime = orderReader.GetDateTime("CreatedAt"),
                                .Status = OrderStatus.Paid,
                                .OrderType = If(orderReader.IsDBNull(orderReader.GetOrdinal("OrderType")),
                                               "DineIn",
                                               orderReader.GetString("OrderType")),
                                .Items = New List(Of OrderItem)
                            }
                            orders.Add(order)
                        End While
                    End Using
                End Using

                ' STEP B: for each order get its items
                For Each order In orders
                    Using itemConn As New MySqlConnection(ConnectionString)
                        itemConn.Open()
                        Dim itemSql = "SELECT ID, ProductName, Quantity 
                                       FROM customer_order_item 
                                       WHERE CustomerOrderId = @orderId"

                        Using itemCmd As New MySqlCommand(itemSql, itemConn)
                            itemCmd.Parameters.AddWithValue("@orderId", order.OrderId)

                            Using itemReader = itemCmd.ExecuteReader()
                                While itemReader.Read()
                                    Dim item As New OrderItem With {
                                        .ItemId = itemReader.GetInt32("ID"),
                                        .ItemName = itemReader.GetString("ProductName"),
                                        .Quantity = itemReader.GetInt32("Quantity"),
                                        .Customizations = New List(Of String)
                                    }
                                    order.Items.Add(item)
                                End While
                            End Using
                        End Using
                    End Using

                    ' STEP C: for each item get its modifiers
                    For Each item In order.Items
                        Using modConn As New MySqlConnection(ConnectionString)
                            modConn.Open()
                            Dim modSql = "SELECT ModifierGroupName, ModifierOptionName 
                                          FROM customer_order_item_modifier 
                                          WHERE CustomerOrderItemId = @itemId
                                          ORDER BY ID"

                            Using modCmd As New MySqlCommand(modSql, modConn)
                                modCmd.Parameters.AddWithValue("@itemId", item.ItemId)

                                Using modReader = modCmd.ExecuteReader()
                                    While modReader.Read()
                                        Dim groupName = modReader.GetString("ModifierGroupName")
                                        Dim optionName = modReader.GetString("ModifierOptionName")
                                        item.Customizations.Add(groupName & ": " & optionName)
                                    End While
                                End Using
                            End Using
                        End Using
                    Next
                Next

            Catch ex As MySqlException
                Console.WriteLine("DB Error: " & ex.Message)
            End Try
        End Using

        Return orders
    End Function

    Public Shared Function GetCanceledOrderIds() As List(Of Integer)
        Dim canceledIds As New List(Of Integer)

        Using conn As New MySqlConnection(ConnectionString)
            Try
                conn.Open()
                Dim sql = "SELECT ID FROM customer_orders WHERE Status = 'Canceled'"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            canceledIds.Add(reader.GetInt32("ID"))
                        End While
                    End Using
                End Using
            Catch ex As MySqlException
                Console.WriteLine("DB Error: " & ex.Message)
            End Try
        End Using

        Return canceledIds
    End Function

    Public Shared Sub UpdateOrderStatus(orderId As Integer, status As String)
        Using conn As New MySqlConnection(ConnectionString)
            Try
                conn.Open()
                Dim sql = "UPDATE customer_orders SET Status = @status WHERE ID = @orderId"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@status", status)
                    cmd.Parameters.AddWithValue("@orderId", orderId)
                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As MySqlException
                Console.WriteLine("DB Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Shared Function GetOrderById(orderId As Integer) As Order
        Dim order As Order = Nothing

        Using conn As New MySqlConnection(ConnectionString)
            Try
                conn.Open()

                Dim orderSql = "SELECT ID, OrderType, Status, CreatedAt 
                            FROM customer_orders WHERE ID = @orderId"

                Using orderCmd As New MySqlCommand(orderSql, conn)
                    orderCmd.Parameters.AddWithValue("@orderId", orderId)

                    Using orderReader = orderCmd.ExecuteReader()
                        If orderReader.Read() Then
                            order = New Order With {
                                .OrderId = orderReader.GetInt32("ID"),
                                .OrderNumber = orderReader.GetInt32("ID").ToString(),
                                .OrderTime = orderReader.GetDateTime("CreatedAt"),
                                .Status = OrderStatus.Paid,
                                .OrderType = If(orderReader.IsDBNull(orderReader.GetOrdinal("OrderType")),
                                               "DineIn",
                                               orderReader.GetString("OrderType")),
                                .Items = New List(Of OrderItem)
                            }
                        End If
                    End Using
                End Using

                If order IsNot Nothing Then
                    ' get items
                    Using itemConn As New MySqlConnection(ConnectionString)
                        itemConn.Open()
                        Dim itemSql = "SELECT ID, ProductName, Quantity 
                                   FROM customer_order_item 
                                   WHERE CustomerOrderId = @orderId"

                        Using itemCmd As New MySqlCommand(itemSql, itemConn)
                            itemCmd.Parameters.AddWithValue("@orderId", orderId)

                            Using itemReader = itemCmd.ExecuteReader()
                                While itemReader.Read()
                                    Dim item As New OrderItem With {
                                        .ItemId = itemReader.GetInt32("ID"),
                                        .ItemName = itemReader.GetString("ProductName"),
                                        .Quantity = itemReader.GetInt32("Quantity"),
                                        .Customizations = New List(Of String)
                                    }
                                    order.Items.Add(item)
                                End While
                            End Using
                        End Using
                    End Using

                    ' get modifiers
                    For Each item In order.Items
                        Using modConn As New MySqlConnection(ConnectionString)
                            modConn.Open()
                            Dim modSql = "SELECT ModifierGroupName, ModifierOptionName 
                                      FROM customer_order_item_modifier 
                                      WHERE CustomerOrderItemId = @itemId
                                      ORDER BY ID"

                            Using modCmd As New MySqlCommand(modSql, modConn)
                                modCmd.Parameters.AddWithValue("@itemId", item.ItemId)

                                Using modReader = modCmd.ExecuteReader()
                                    While modReader.Read()
                                        Dim groupName = modReader.GetString("ModifierGroupName")
                                        Dim optionName = modReader.GetString("ModifierOptionName")
                                        item.Customizations.Add(groupName & ": " & optionName)
                                    End While
                                End Using
                            End Using
                        End Using
                    Next
                End If

            Catch ex As MySqlException
                Console.WriteLine("DB Error: " & ex.Message)
            End Try
        End Using

        Return order
    End Function

End Class