Imports System.Runtime

Public Class frmKitchenDisplay

    ' tracks which orders are already on screen
    ' so we don't add the same order twice
    Private _displayedOrderIds As New List(Of Integer)

    ' -------------------------------------------------------
    ' STEP A: when form loads, start the polling timer
    ' -------------------------------------------------------
    Private Sub frmKitchenDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTime.Text = Date.Now.ToString("HH:mm:ss")
        pnl1.BackColor = Color.FromArgb(92, 51, 23) 'Panel color
        lblTime.BackColor = Color.FromArgb(92, 51, 23)
        Timer1.Interval = 3000
        Timer1.Start()
        UpdateActiveOrderCount()

        ' --- TEST DATA --- remove this when DB is connected
        Dim testOrder1 As New Order With {
    .OrderId = 1,
    .OrderNumber = "001",
    .OrderTime = DateTime.Now.AddMinutes(-3),
    .Status = OrderStatus.Paid,
    .OrderType = "DineIn",
    .Items = New List(Of OrderItem) From {
        New OrderItem With {.ItemId = 1, .ItemName = "Coffee", .Quantity = 1,
            .Customizations = New List(Of String) From {"Arabica Beans", "Low Sugar", "Extra Whip"}},
        New OrderItem With {.ItemId = 2, .ItemName = "Burger", .Quantity = 2,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 3, .ItemName = "Fries", .Quantity = 1,
            .Customizations = New List(Of String) From {"Large Size", "Extra Salt"}}
    }
}

        Dim testOrder2 As New Order With {
    .OrderId = 2,
    .OrderNumber = "002",
    .OrderTime = DateTime.Now.AddMinutes(-1),
    .Status = OrderStatus.Paid,
    .OrderType = "TakeOut",
    .Items = New List(Of OrderItem) From {
        New OrderItem With {.ItemId = 4, .ItemName = "Latte", .Quantity = 2,
            .Customizations = New List(Of String) From {"Oat Milk", "No Sugar"}},
        New OrderItem With {.ItemId = 5, .ItemName = "Cheesecake", .Quantity = 1,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 6, .ItemName = "Iced Tea", .Quantity = 3,
            .Customizations = New List(Of String) From {"Less Ice"}},
        New OrderItem With {.ItemId = 7, .ItemName = "Sandwich", .Quantity = 1,
            .Customizations = New List(Of String) From {"No Onions", "Extra Cheese"}},
        New OrderItem With {.ItemId = 8, .ItemName = "Muffin", .Quantity = 2,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 9, .ItemName = "Orange Juice", .Quantity = 1,
            .Customizations = New List(Of String) From {"No Ice"}},
        New OrderItem With {.ItemId = 10, .ItemName = "Croissant", .Quantity = 2,
            .Customizations = New List(Of String)}
    }
}

        Dim testOrder3 As New Order With {
    .OrderId = 3,
    .OrderNumber = "003",
    .OrderTime = DateTime.Now.AddMinutes(-6),
    .Status = OrderStatus.Paid,
    .OrderType = "Delivery",
    .Items = New List(Of OrderItem) From {
        New OrderItem With {.ItemId = 11, .ItemName = "Cappuccino", .Quantity = 1,
            .Customizations = New List(Of String) From {"Extra Shot", "Almond Milk"}},
        New OrderItem With {.ItemId = 12, .ItemName = "Pasta", .Quantity = 2,
            .Customizations = New List(Of String) From {"Extra Sauce"}},
        New OrderItem With {.ItemId = 13, .ItemName = "Caesar Salad", .Quantity = 1,
            .Customizations = New List(Of String) From {"No Croutons"}},
        New OrderItem With {.ItemId = 14, .ItemName = "Sparkling Water", .Quantity = 3,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 15, .ItemName = "Tiramisu", .Quantity = 2,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 16, .ItemName = "Garlic Bread", .Quantity = 1,
            .Customizations = New List(Of String) From {"Extra Butter"}},
        New OrderItem With {.ItemId = 17, .ItemName = "Chicken Wings", .Quantity = 8,
            .Customizations = New List(Of String) From {"BBQ Sauce", "Extra Spicy"}},
        New OrderItem With {.ItemId = 18, .ItemName = "Nachos", .Quantity = 1,
            .Customizations = New List(Of String) From {"Extra Cheese", "Sour Cream"}},
        New OrderItem With {.ItemId = 19, .ItemName = "Brownie", .Quantity = 2,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 20, .ItemName = "Espresso", .Quantity = 1,
            .Customizations = New List(Of String) From {"Double Shot"}}
    }
}

        Dim testOrder4 As New Order With {
    .OrderId = 4,
    .OrderNumber = "004",
    .OrderTime = DateTime.Now.AddMinutes(-2),
    .Status = OrderStatus.Paid,
    .OrderType = "DineIn",
    .Items = New List(Of OrderItem) From {
        New OrderItem With {.ItemId = 21, .ItemName = "Matcha Latte", .Quantity = 1,
            .Customizations = New List(Of String) From {"Oat Milk", "Less Sweet"}},
        New OrderItem With {.ItemId = 22, .ItemName = "Club Sandwich", .Quantity = 2,
            .Customizations = New List(Of String) From {"No Mayo"}},
        New OrderItem With {.ItemId = 23, .ItemName = "Onion Rings", .Quantity = 1,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 24, .ItemName = "Smoothie", .Quantity = 2,
            .Customizations = New List(Of String) From {"Mango", "No Ice"}},
        New OrderItem With {.ItemId = 25, .ItemName = "Waffles", .Quantity = 1,
            .Customizations = New List(Of String) From {"Extra Syrup", "Whipped Cream"}},
        New OrderItem With {.ItemId = 26, .ItemName = "Hot Chocolate", .Quantity = 2,
            .Customizations = New List(Of String) From {"Extra Marshmallows"}},
        New OrderItem With {.ItemId = 27, .ItemName = "Pancakes", .Quantity = 1,
            .Customizations = New List(Of String) From {"Blueberry", "No Butter"}}
    }
}

        Dim testOrder5 As New Order With {
    .OrderId = 5,
    .OrderNumber = "005",
    .OrderTime = DateTime.Now.AddMinutes(-20),
    .Status = OrderStatus.Paid,
    .OrderType = "TakeOut",
    .Items = New List(Of OrderItem) From {
        New OrderItem With {.ItemId = 28, .ItemName = "Americano", .Quantity = 1,
            .Customizations = New List(Of String) From {"Extra Shot"}},
        New OrderItem With {.ItemId = 29, .ItemName = "BLT Sandwich", .Quantity = 1,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 30, .ItemName = "Sweet Potato Fries", .Quantity = 2,
            .Customizations = New List(Of String) From {"Aioli Dip"}}
    }
}

        Dim testOrder6 As New Order With {
    .OrderId = 6,
    .OrderNumber = "006",
    .OrderTime = DateTime.Now.AddMinutes(-11),
    .Status = OrderStatus.Paid,
    .OrderType = "Delivery",
    .Items = New List(Of OrderItem) From {
        New OrderItem With {.ItemId = 31, .ItemName = "Flat White", .Quantity = 2,
            .Customizations = New List(Of String) From {"Full Cream Milk"}},
        New OrderItem With {.ItemId = 32, .ItemName = "Beef Burger", .Quantity = 3,
            .Customizations = New List(Of String) From {"Extra Patty", "No Pickles"}},
        New OrderItem With {.ItemId = 33, .ItemName = "Coleslaw", .Quantity = 2,
            .Customizations = New List(Of String)},
        New OrderItem With {.ItemId = 34, .ItemName = "Milkshake", .Quantity = 2,
            .Customizations = New List(Of String) From {"Chocolate", "Extra Thick"}},
        New OrderItem With {.ItemId = 35, .ItemName = "Mushroom Soup", .Quantity = 1,
            .Customizations = New List(Of String) From {"Extra Bread"}},
        New OrderItem With {.ItemId = 36, .ItemName = "Cheesy Fries", .Quantity = 2,
            .Customizations = New List(Of String) From {"Jalapenos"}},
        New OrderItem With {.ItemId = 37, .ItemName = "Greek Salad", .Quantity = 1,
            .Customizations = New List(Of String) From {"Extra Feta"}},
        New OrderItem With {.ItemId = 38, .ItemName = "Lemonade", .Quantity = 3,
            .Customizations = New List(Of String) From {"Extra Lemon", "Less Sugar"}},
        New OrderItem With {.ItemId = 39, .ItemName = "Fried Chicken", .Quantity = 4,
            .Customizations = New List(Of String) From {"Spicy", "Extra Sauce"}}
    }
}

        AddOrderCard(testOrder1)
        AddOrderCard(testOrder2)
        AddOrderCard(testOrder3)
        AddOrderCard(testOrder4)
        AddOrderCard(testOrder5)
        AddOrderCard(testOrder6)
        ' --- END TEST DATA ---
    End Sub

    ' -------------------------------------------------------
    ' STEP B: every 3 seconds, check DB for new paid orders
    ' -------------------------------------------------------
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Try
        ' check for new paid orders
        '     Dim newOrders = GetPaidOrdersFromDB()
        '     For Each order In newOrders
        '         If _displayedOrderIds.Contains(order.OrderId) Then
        '             Continue For
        '        End If
        '        AddOrderCard(order)
        '     Next

        ' check for canceled orders and remove them
        '    Dim canceledIds = DatabaseHelper.GetCanceledOrderIds()
        '     For Each canceledId In canceledIds
        '        If _displayedOrderIds.Contains(canceledId) Then
        '             RemoveCanceledOrder(canceledId)
        '        End If
        '     Next

        ' Catch ex As Exception
        '    Console.WriteLine("Poll error: " & ex.Message)
        ' End Try
    End Sub
    ' -------------------------------------------------------
    ' STEP C: fetch only PAID orders from your database
    ' replace YourDbContext with your actual DB context name
    ' -------------------------------------------------------
    'Private Function GetPaidOrdersFromDB() As List(Of Order)
    '    Using db As New YourDbContext()
    '        Return db.Orders.Where(Function(o) o.Status = OrderStatus.Paid).ToList()
    '    End Using
    'End Function

    ' -------------------------------------------------------
    ' STEP D: create an OrderCard and add it to flpOrders
    ' -------------------------------------------------------
    Private Sub AddOrderCard(order As Order)
        ' always update UI from the UI thread
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() AddOrderCard(order)))
            Return
        End If

        ' create a new OrderCard user control
        Dim card As New ucOrderCard()

        ' pass the order data into it
        card.LoadOrder(order)

        ' listen for when kitchen taps Done
        AddHandler card.OnOrderCompleted, AddressOf HandleOrderCompleted

        ' add to flpOrders
        flpOrders.Controls.Add(card)

        ' remember this order so we don't add it again
        _displayedOrderIds.Add(order.OrderId)
    End Sub

    ' -------------------------------------------------------
    ' STEP E: when Done is tapped, remove the card
    ' -------------------------------------------------------
    Private Sub HandleOrderCompleted(card As ucOrderCard, orderId As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() HandleOrderCompleted(card, orderId)))
            Return
        End If

        ' remove from screen
        flpOrders.Controls.Remove(card)
        card.Dispose()

        ' remove from tracking list
        _displayedOrderIds.Remove(orderId)
        UpdateActiveOrderCount()
    End Sub


    Private Sub UpdateActiveOrderCount()
        lblActiveOrders.Text = flpOrders.Controls.Count.ToString()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles pnl1.Paint
        'Panel1.BackColor = Color.FromArgb(201, 185, 159)
    End Sub

    Private Sub RemoveCanceledOrder(orderId As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub() RemoveCanceledOrder(orderId)))
            Return
        End If

        ' find the card with matching orderId and remove it
        For Each ctrl As Control In flpOrders.Controls
            If TypeOf ctrl Is ucOrderCard Then
                Dim card As ucOrderCard = DirectCast(ctrl, ucOrderCard)
                '''    If card.OrderId = orderId Then
                flpOrders.Controls.Remove(card)
                    card.Dispose()
                    _displayedOrderIds.Remove(orderId)
                    UpdateActiveOrderCount()
                    Exit For
                End If
            ''' End If
        Next
    End Sub

End Class
