Public Class OrderCustomize

    Public Sub ShowCustomizeDrink(drink As DrinkItem)

        CustomizePanel.Controls.Clear()

        Dim ctrl As New CustomizeDrinkControl
        ctrl.Dock = DockStyle.Fill


        ctrl.LoadDrink(drink)
        CustomizePanel.Controls.Add(ctrl)

    End Sub

End Class
