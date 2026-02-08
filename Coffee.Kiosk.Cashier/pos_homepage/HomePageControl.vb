Imports System.Linq
Public Class HomePageControl
    Private cart As New List(Of OrderItem)
    Private orderCounter As Integer = 0
    Private Sub HomePageControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OrderList.ReadOnly = True
        OrderList.BorderStyle = BorderStyle.FixedSingle
        OrderList.ScrollBars = RichTextBoxScrollBars.Vertical
        OrderList.Font = New Font("Courier New", 9)
        OrderList.BackColor = Color.White
        OrderList.Clear()
        lblTotal.Text = "TOTAL: ₱0.00"
    End Sub
    Public Sub SetUsername(name As String)
        lblUsername.Text = "Staff Name: " & name
    End Sub
    Public Sub OpenDrinkCustomize(drink As DrinkItem)
        Dim customize As New DrinksCustomizeControl()
        customize.LoadDrink(drink)
        customize.Dock = DockStyle.Fill
        AddHandler customize.OrderAdded, AddressOf AddOrderToCart
        AddHandler customize.RequestBackToMenu, AddressOf ShowDrinksMenu
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(customize)
    End Sub
    Public Sub OpenMealCustomize(meal As MealItem)
        Dim customize As New MealsCustomizeControl()
        customize.LoadMeal(meal)
        customize.Dock = DockStyle.Fill
        AddHandler customize.OrderAdded, AddressOf AddOrderToCart
        AddHandler customize.RequestBackToMenu, AddressOf ShowMealsMenu
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(customize)
    End Sub
    Public Sub AddSimpleItem(item As SimpleItem)
        Dim qtyInput As String = InputBox($"Enter quantity for {item.Name}:", "Quantity", "1")
        If String.IsNullOrEmpty(qtyInput) Then Return
        Dim qty As Decimal
        If Not Decimal.TryParse(qtyInput, qty) OrElse qty <= 0 Then
            MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim order As New OrderItem With {
            .ItemName = item.Name,
            .ItemType = item.ItemType,
            .Quantity = qty,
            .BasePrice = item.Price,
            .TotalPrice = item.Price * qty
        }
        AddOrderToCart(order)
    End Sub
    Private Sub ShowDrinksMenu()
        Dim drinksMenu As New DrinksMenuControl()
        drinksMenu.Dock = DockStyle.Fill
        AddHandler drinksMenu.DrinkSelected, AddressOf OpenDrinkCustomize
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(drinksMenu)
    End Sub
    Private Sub ShowMealsMenu()
        Dim mealsMenu As New MealsMenuControl()
        mealsMenu.Dock = DockStyle.Fill
        AddHandler mealsMenu.MealSelected, AddressOf OpenMealCustomize
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(mealsMenu)
    End Sub
    Private Sub ShowPastryMenu()
        Dim pastryMenu As New PastryMenuControl()
        pastryMenu.Dock = DockStyle.Fill
        AddHandler pastryMenu.PastrySelected, AddressOf AddSimpleItem
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(pastryMenu)
    End Sub
    Private Sub ShowSnacksMenu()
        Dim snacksMenu As New SnacksMenuControl()
        snacksMenu.Dock = DockStyle.Fill
        AddHandler snacksMenu.SnackSelected, AddressOf AddSimpleItem
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(snacksMenu)
    End Sub
    Public Sub AddOrderToCart(order As OrderItem)
        orderCounter += 1
        order.OrderNumber = orderCounter
        cart.Add(order)
        RefreshOrderList()
        UpdateTotal()
    End Sub
    Private Sub RefreshOrderList()
        OrderList.Clear()
        For i As Integer = 0 To cart.Count - 1
            If i > 0 Then OrderList.AppendText(vbCrLf & "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" & vbCrLf & vbCrLf)
            Dim text = cart(i).ToDisplayText()
            Dim parts = text.Split(New String() {"[BOLD]", "[/BOLD]"}, StringSplitOptions.None)
            For j As Integer = 0 To parts.Length - 1
                If j Mod 2 = 1 Then
                    Dim start = OrderList.TextLength
                    OrderList.AppendText(parts(j))
                    OrderList.Select(start, parts(j).Length)
                    OrderList.SelectionFont = New Font("Courier New", 9, FontStyle.Bold)
                Else
                    OrderList.AppendText(parts(j))
                End If
            Next
        Next
        OrderList.Select(OrderList.TextLength, 0)
    End Sub
    Private Sub UpdateTotal()
        Dim total As Decimal = cart.Sum(Function(o) o.TotalPrice)
        lblTotal.Text = "TOTAL: ₱" & total.ToString("0.00")
    End Sub
    Private Sub btnRemoveOrder_Click(sender As Object, e As EventArgs) Handles btnRemoveOrder.Click
        If cart.Count = 0 Then
            MessageBox.Show("No orders to remove.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim orderNum As String = InputBox("Enter Order Number to Remove:", "Remove Order", "")
        If String.IsNullOrEmpty(orderNum) Then Return
        Dim num As Integer
        If Not Integer.TryParse(orderNum, num) Then
            MessageBox.Show("Invalid order number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim orderToRemove = cart.FirstOrDefault(Function(o) o.OrderNumber = num)
        If orderToRemove Is Nothing Then
            MessageBox.Show($"Order #{num} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        cart.Remove(orderToRemove)
        RefreshOrderList()
        UpdateTotal()
        MessageBox.Show($"Order #{num} removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub ShowMenu(ctrl As UserControl)
        txtSearch.Text = ""
        MenuPanel.Controls.Clear()
        ctrl.Dock = DockStyle.Fill
        MenuPanel.Controls.Add(ctrl)
    End Sub

    Private Sub FilterMenu(keyword As String)
        If MenuPanel.Controls.Count = 0 Then Exit Sub
        Dim menuCtrl = TryCast(MenuPanel.Controls(0), UserControl)
        If menuCtrl Is Nothing Then Exit Sub
        Dim flp = menuCtrl.Controls.OfType(Of FlowLayoutPanel)().FirstOrDefault()
        If flp Is Nothing Then Exit Sub
        For Each btn As Button In flp.Controls.OfType(Of Button)()
            btn.Visible = btn.Text.ToLower().Contains(keyword.ToLower())
        Next
    End Sub

    Private Sub btnDrinks_Click(sender As Object, e As EventArgs) Handles btnDrinks.Click
        ShowDrinksMenu()
    End Sub

    Private Sub btnPastry_Click(sender As Object, e As EventArgs) Handles btnPastry.Click
        ShowPastryMenu()
    End Sub

    Private Sub btnSnacks_Click(sender As Object, e As EventArgs) Handles btnSnacks.Click
        ShowSnacksMenu()
    End Sub

    Private Sub btnMeals_Click(sender As Object, e As EventArgs) Handles btnMeals.Click
        ShowMealsMenu()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterMenu(txtSearch.Text)
    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        ProcessPayment("Cash")
    End Sub

    Private Sub btnGcash_Click(sender As Object, e As EventArgs) Handles btnGcash.Click
        ProcessPayment("Gcash")
    End Sub

    Private Sub btnMaya_Click(sender As Object, e As EventArgs) Handles btnMaya.Click
        ProcessPayment("Maya")
    End Sub

    Private Sub ProcessPayment(paymentMethod As String)
        If cart.Count = 0 Then
            MessageBox.Show("No items in the cart. Please add items before processing payment.",
                       "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim total As Decimal = cart.Sum(Function(o) o.TotalPrice)

        Dim paymentDialog As New PaymentDialog()
        paymentDialog.OrderCart = New List(Of OrderItem)(cart)
        paymentDialog.Total = total

        Dim staff As String = ""
        If lblUsername IsNot Nothing AndAlso Not String.IsNullOrEmpty(lblUsername.Text) Then
            staff = lblUsername.Text.Replace("Staff Name: ", "").Trim()
        Else
            staff = "Cashier"
        End If
        paymentDialog.Username = staff

        paymentDialog.SelectedPaymentMethod = paymentMethod

        If paymentDialog.ShowDialog() = DialogResult.OK Then
            cart.Clear()
            orderCounter = 0
            RefreshOrderList()
            UpdateTotal()

            MessageBox.Show("Order completed successfully!", "Success",
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class