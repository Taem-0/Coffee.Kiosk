Imports System.Linq
Public Class HomePageControl
    Private cart As New List(Of OrderItem)
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
    Private Sub ShowDrinksMenu()
        Dim drinksMenu As New DrinksMenuControl()
        drinksMenu.Dock = DockStyle.Fill
        AddHandler drinksMenu.DrinkSelected, AddressOf OpenDrinkCustomize
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(drinksMenu)
    End Sub
    Public Sub AddOrderToCart(order As OrderItem)
        cart.Add(order)
        If OrderList.Text.Length > 0 Then
            OrderList.AppendText(vbCrLf & "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" & vbCrLf & vbCrLf)
        End If
        Dim text = order.ToDisplayText()
        Dim parts = text.Split(New String() {"[BOLD]", "[/BOLD]"}, StringSplitOptions.None)
        For i As Integer = 0 To parts.Length - 1
            If i Mod 2 = 1 Then
                Dim start = OrderList.TextLength
                OrderList.AppendText(parts(i))
                OrderList.Select(start, parts(i).Length)
                OrderList.SelectionFont = New Font("Courier New", 9, FontStyle.Bold)
            Else
                OrderList.AppendText(parts(i))
            End If
        Next
        OrderList.Select(OrderList.TextLength, 0)
        UpdateTotal()
    End Sub
    Private Sub UpdateTotal()
        Dim total As Decimal = cart.Sum(Function(o) o.TotalPrice)
        lblTotal.Text = "TOTAL: ₱" & total.ToString("0.00")
    End Sub
    Private Sub btnRemoveOrder_Click(sender As Object, e As EventArgs) Handles btnRemoveOrder.Click
        If cart.Count = 0 Then Return
        cart.RemoveAt(cart.Count - 1)
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
        UpdateTotal()
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
        Dim drinksMenu As New DrinksMenuControl()
        drinksMenu.Dock = DockStyle.Fill
        AddHandler drinksMenu.DrinkSelected, AddressOf OpenDrinkCustomize
        MenuPanel.Controls.Clear()
        MenuPanel.Controls.Add(drinksMenu)
    End Sub

    Private Sub btnPastry_Click(sender As Object, e As EventArgs) Handles btnPastry.Click
        ShowMenu(New PastryMenuControl())
    End Sub

    Private Sub btnSnacks_Click(sender As Object, e As EventArgs) Handles btnSnacks.Click
        ShowMenu(New SnacksMenuControl())
    End Sub

    Private Sub btnMeals_Click(sender As Object, e As EventArgs) Handles btnMeals.Click
        ShowMenu(New MealsMenuControl())
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterMenu(txtSearch.Text)
    End Sub

End Class