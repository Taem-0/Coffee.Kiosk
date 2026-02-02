Public Class OrderCustomize

    Public Sub ShowCustomizeDrink(drink As DrinkItem)

        CustomizePanel.Controls.Clear()

        Dim ctrl As New CustomizeDrinkControl
        ctrl.Dock = DockStyle.Fill

        AddHandler ctrl.OrderAdded, AddressOf OnOrderAdded

        ctrl.LoadDrink(drink)
        CustomizePanel.Controls.Add(ctrl)

    End Sub

    Private Sub OnOrderAdded(order As OrderItem)
        OrderCart.CurrentOrders.Add(order)
        Me.Close()
    End Sub

End Class
