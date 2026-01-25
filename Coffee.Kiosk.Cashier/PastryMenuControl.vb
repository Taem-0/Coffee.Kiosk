Public Class PastryMenuControl

    Private Sub PastryMenuControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlpMenu.Controls.Clear()

        LoadBreadAndCroissants()
        LoadCakes()
        LoadCookiesAndBars()
        LoadWaffles()
    End Sub

    Private Sub LoadBreadAndCroissants()
        AddPastry("Butter Croissant", 79)
        AddPastry("Chocolate Croissant", 89)
        AddPastry("Almond Croissant", 99)
        AddPastry("Cheese Danish", 89)
        AddPastry("Cinnamon Roll", 95)
        AddPastry("Garlic Bread", 69)
        AddPastry("Cheese Bread", 79)
        AddPastry("Banana Bread", 85)
    End Sub

    Private Sub LoadCakes()
        AddPastry("Chocolate Cake Slice", 129)
        AddPastry("Red Velvet Cake Slice", 139)
        AddPastry("Carrot Cake Slice", 129)
        AddPastry("Cheesecake Slice", 149)
        AddPastry("Oreo Cheesecake Slice", 159)
        AddPastry("Blueberry Cheesecake Slice", 159)
        AddPastry("Mocha Cake Slice", 139)
        AddPastry("Strawberry Cake Slice", 139)
    End Sub

    Private Sub LoadCookiesAndBars()
        AddPastry("Chocolate Chip Cookie", 49)
        AddPastry("Double Chocolate Cookie", 59)
        AddPastry("Oatmeal Cookie", 49)
        AddPastry("Brownie", 79)
        AddPastry("Fudge Brownie", 89)
        AddPastry("Revel Bar", 79)
        AddPastry("Blondie Bar", 79)
    End Sub

    Private Sub LoadWaffles()
        AddPastry("Classic Waffle", 89)
        AddPastry("Strawberry Waffle", 99)
        AddPastry("Chocolate Waffle", 99)
        AddPastry("Caramel Biscotti Waffle", 109)
        AddPastry("Oreo Waffle", 109)
        AddPastry("Banana Nutella Waffle", 119)
    End Sub

    Private Sub AddPastry(name As String, price As Decimal)
        Dim item As New MenuItemControl()
        item.SetData(name, price)
        FlpMenu.Controls.Add(item)
    End Sub

End Class
