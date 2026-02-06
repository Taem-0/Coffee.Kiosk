<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomePageControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomePageControl))
        lblUsername = New Label()
        ProfileBox = New PictureBox()
        txtSearch = New TextBox()
        txtKioskOrder = New TextBox()
        btnCash = New Button()
        btnGcash = New Button()
        btnMaya = New Button()
        btnDrinks = New Button()
        btnPastry = New Button()
        btnSnacks = New Button()
        btnMeals = New Button()
        MenuPanel = New Panel()
        lblTotal = New Label()
        btnRemoveOrder = New Button()
        OrderList = New RichTextBox()
        CType(ProfileBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblUsername
        ' 
        lblUsername.BackColor = Color.Transparent
        lblUsername.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        lblUsername.Location = New Point(1238, 50)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(317, 36)
        lblUsername.TabIndex = 1
        lblUsername.Text = "Staff Name " & vbCrLf
        lblUsername.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ProfileBox
        ' 
        ProfileBox.BackgroundImage = CType(resources.GetObject("ProfileBox.BackgroundImage"), Image)
        ProfileBox.BackgroundImageLayout = ImageLayout.Zoom
        ProfileBox.Location = New Point(1561, 20)
        ProfileBox.Name = "ProfileBox"
        ProfileBox.Size = New Size(84, 78)
        ProfileBox.TabIndex = 2
        ProfileBox.TabStop = False
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.FixedSingle
        txtSearch.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(65, 50)
        txtSearch.Name = "txtSearch"
        txtSearch.PlaceholderText = " 🔍 Search"
        txtSearch.Size = New Size(1087, 38)
        txtSearch.TabIndex = 3
        ' 
        ' txtKioskOrder
        ' 
        txtKioskOrder.BackColor = Color.White
        txtKioskOrder.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtKioskOrder.ForeColor = Color.Black
        txtKioskOrder.Location = New Point(41, 1007)
        txtKioskOrder.Name = "txtKioskOrder"
        txtKioskOrder.PlaceholderText = " Enter Code:"
        txtKioskOrder.Size = New Size(395, 43)
        txtKioskOrder.TabIndex = 4
        ' 
        ' btnCash
        ' 
        btnCash.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnCash.FlatStyle = FlatStyle.Popup
        btnCash.ForeColor = Color.White
        btnCash.Location = New Point(1031, 1007)
        btnCash.Name = "btnCash"
        btnCash.Size = New Size(187, 42)
        btnCash.TabIndex = 6
        btnCash.Text = "Pay with Cash"
        btnCash.UseVisualStyleBackColor = False
        ' 
        ' btnGcash
        ' 
        btnGcash.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnGcash.FlatStyle = FlatStyle.Popup
        btnGcash.ForeColor = Color.White
        btnGcash.Location = New Point(1238, 1007)
        btnGcash.Name = "btnGcash"
        btnGcash.Size = New Size(187, 42)
        btnGcash.TabIndex = 7
        btnGcash.Text = "Gcash"
        btnGcash.UseVisualStyleBackColor = False
        ' 
        ' btnMaya
        ' 
        btnMaya.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnMaya.FlatStyle = FlatStyle.Popup
        btnMaya.ForeColor = Color.White
        btnMaya.Location = New Point(1438, 1007)
        btnMaya.Name = "btnMaya"
        btnMaya.Size = New Size(187, 42)
        btnMaya.TabIndex = 8
        btnMaya.Text = "Maya"
        btnMaya.UseVisualStyleBackColor = False
        ' 
        ' btnDrinks
        ' 
        btnDrinks.Anchor = AnchorStyles.None
        btnDrinks.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnDrinks.FlatStyle = FlatStyle.Popup
        btnDrinks.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDrinks.ForeColor = Color.White
        btnDrinks.Location = New Point(65, 147)
        btnDrinks.Name = "btnDrinks"
        btnDrinks.Size = New Size(160, 48)
        btnDrinks.TabIndex = 9
        btnDrinks.Text = "Drinks"
        btnDrinks.UseVisualStyleBackColor = False
        ' 
        ' btnPastry
        ' 
        btnPastry.Anchor = AnchorStyles.None
        btnPastry.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnPastry.FlatStyle = FlatStyle.Popup
        btnPastry.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPastry.ForeColor = Color.White
        btnPastry.Location = New Point(312, 147)
        btnPastry.Name = "btnPastry"
        btnPastry.Size = New Size(160, 48)
        btnPastry.TabIndex = 10
        btnPastry.Text = "Pastry"
        btnPastry.UseVisualStyleBackColor = False
        ' 
        ' btnSnacks
        ' 
        btnSnacks.Anchor = AnchorStyles.None
        btnSnacks.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSnacks.FlatStyle = FlatStyle.Popup
        btnSnacks.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSnacks.ForeColor = Color.White
        btnSnacks.Location = New Point(560, 147)
        btnSnacks.Name = "btnSnacks"
        btnSnacks.Size = New Size(160, 48)
        btnSnacks.TabIndex = 11
        btnSnacks.Text = "Snacks"
        btnSnacks.UseVisualStyleBackColor = False
        ' 
        ' btnMeals
        ' 
        btnMeals.Anchor = AnchorStyles.None
        btnMeals.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnMeals.FlatStyle = FlatStyle.Popup
        btnMeals.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMeals.ForeColor = Color.White
        btnMeals.Location = New Point(812, 147)
        btnMeals.Name = "btnMeals"
        btnMeals.Size = New Size(160, 48)
        btnMeals.TabIndex = 12
        btnMeals.Text = "Meals"
        btnMeals.UseVisualStyleBackColor = False
        ' 
        ' MenuPanel
        ' 
        MenuPanel.Location = New Point(65, 236)
        MenuPanel.Name = "MenuPanel"
        MenuPanel.Size = New Size(921, 724)
        MenuPanel.TabIndex = 13
        ' 
        ' lblTotal
        ' 
        lblTotal.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.Location = New Point(1436, 144)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(187, 33)
        lblTotal.TabIndex = 14
        lblTotal.Text = "Total:"
        ' 
        ' btnRemoveOrder
        ' 
        btnRemoveOrder.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnRemoveOrder.FlatStyle = FlatStyle.Flat
        btnRemoveOrder.ForeColor = Color.White
        btnRemoveOrder.Location = New Point(1020, 155)
        btnRemoveOrder.Name = "btnRemoveOrder"
        btnRemoveOrder.Size = New Size(197, 29)
        btnRemoveOrder.TabIndex = 16
        btnRemoveOrder.Text = "Remove Selected"
        btnRemoveOrder.UseVisualStyleBackColor = False
        ' 
        ' OrderList
        ' 
        OrderList.BorderStyle = BorderStyle.None
        OrderList.Location = New Point(1020, 216)
        OrderList.Name = "OrderList"
        OrderList.Size = New Size(625, 744)
        OrderList.TabIndex = 17
        OrderList.Text = ""
        ' 
        ' HomePageControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(OrderList)
        Controls.Add(btnRemoveOrder)
        Controls.Add(lblTotal)
        Controls.Add(MenuPanel)
        Controls.Add(btnMeals)
        Controls.Add(btnSnacks)
        Controls.Add(btnPastry)
        Controls.Add(btnDrinks)
        Controls.Add(btnMaya)
        Controls.Add(btnGcash)
        Controls.Add(btnCash)
        Controls.Add(txtKioskOrder)
        Controls.Add(txtSearch)
        Controls.Add(ProfileBox)
        Controls.Add(lblUsername)
        Name = "HomePageControl"
        Size = New Size(1669, 1082)
        CType(ProfileBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblUsername As Label
    Friend WithEvents ProfileBox As PictureBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents txtKioskOrder As TextBox
    Friend WithEvents btnCash As Button
    Friend WithEvents btnGcash As Button
    Friend WithEvents btnMaya As Button
    Friend WithEvents btnDrinks As Button
    Friend WithEvents btnPastry As Button
    Friend WithEvents btnSnacks As Button
    Friend WithEvents btnMeals As Button
    Friend WithEvents MenuPanel As Panel
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnRemoveOrder As Button
    Friend WithEvents OrderList As RichTextBox

End Class
