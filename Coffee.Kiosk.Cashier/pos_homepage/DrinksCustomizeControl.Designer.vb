<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrinksCustomizeControl
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
        lblTotal = New Label()
        rbNonDairy = New RadioButton()
        rbDairy = New RadioButton()
        rbSeasaltCreme = New RadioButton()
        rbButterCreme = New RadioButton()
        rbCoffeeJelly = New RadioButton()
        rbJellyStrips = New RadioButton()
        rbVelvet = New RadioButton()
        rbNoToppings = New RadioButton()
        rbWhipped = New RadioButton()
        lblBasePrice = New Label()
        grpSyrup = New GroupBox()
        rbNoSyrup = New RadioButton()
        rbFrenchVanilla = New RadioButton()
        rbSaltedCaramel = New RadioButton()
        grpMilk = New GroupBox()
        btnCancel = New Button()
        btnAddOrder = New Button()
        nudQty = New NumericUpDown()
        lblQty = New Label()
        grpToppings = New GroupBox()
        rbNoWhipped = New RadioButton()
        grpWhippedCream = New GroupBox()
        rbNoIce = New RadioButton()
        grpSugarType = New GroupBox()
        rbCane = New RadioButton()
        rbMuscavado = New RadioButton()
        rbStandard = New RadioButton()
        rbNoSugar = New RadioButton()
        rbIce = New RadioButton()
        rbHot = New RadioButton()
        rbBoss = New RadioButton()
        rbLydia = New RadioButton()
        rbLarge = New RadioButton()
        rbMedium = New RadioButton()
        rbSmall = New RadioButton()
        grpIceLevel = New GroupBox()
        rbLess = New RadioButton()
        rbNormal = New RadioButton()
        rb100 = New RadioButton()
        grpSugarLevel = New GroupBox()
        rb50 = New RadioButton()
        rb75 = New RadioButton()
        rb25 = New RadioButton()
        rb0 = New RadioButton()
        grpSize = New GroupBox()
        grpBeans = New GroupBox()
        grpTemp = New GroupBox()
        lblDrinkName = New Label()
        btnClose = New Button()
        grpSyrup.SuspendLayout()
        grpMilk.SuspendLayout()
        CType(nudQty, ComponentModel.ISupportInitialize).BeginInit()
        grpToppings.SuspendLayout()
        grpWhippedCream.SuspendLayout()
        grpSugarType.SuspendLayout()
        grpIceLevel.SuspendLayout()
        grpSugarLevel.SuspendLayout()
        grpSize.SuspendLayout()
        grpBeans.SuspendLayout()
        grpTemp.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTotal
        ' 
        lblTotal.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        lblTotal.Location = New Point(635, 599)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(234, 23)
        lblTotal.TabIndex = 35
        lblTotal.Text = "Total: "
        ' 
        ' rbNonDairy
        ' 
        rbNonDairy.AutoSize = True
        rbNonDairy.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNonDairy.Location = New Point(153, 22)
        rbNonDairy.Name = "rbNonDairy"
        rbNonDairy.Size = New Size(104, 24)
        rbNonDairy.TabIndex = 1
        rbNonDairy.TabStop = True
        rbNonDairy.Text = "Non-Dairy"
        rbNonDairy.UseVisualStyleBackColor = True
        ' 
        ' rbDairy
        ' 
        rbDairy.AutoSize = True
        rbDairy.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbDairy.Location = New Point(29, 22)
        rbDairy.Name = "rbDairy"
        rbDairy.Size = New Size(102, 24)
        rbDairy.TabIndex = 0
        rbDairy.TabStop = True
        rbDairy.Text = "Dairy Milk"
        rbDairy.UseVisualStyleBackColor = True
        ' 
        ' rbSeasaltCreme
        ' 
        rbSeasaltCreme.AutoSize = True
        rbSeasaltCreme.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbSeasaltCreme.Location = New Point(691, 22)
        rbSeasaltCreme.Name = "rbSeasaltCreme"
        rbSeasaltCreme.Size = New Size(128, 24)
        rbSeasaltCreme.TabIndex = 10
        rbSeasaltCreme.TabStop = True
        rbSeasaltCreme.Text = "Seasalt Creme"
        rbSeasaltCreme.UseVisualStyleBackColor = True
        ' 
        ' rbButterCreme
        ' 
        rbButterCreme.AutoSize = True
        rbButterCreme.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbButterCreme.Location = New Point(535, 22)
        rbButterCreme.Name = "rbButterCreme"
        rbButterCreme.Size = New Size(124, 24)
        rbButterCreme.TabIndex = 4
        rbButterCreme.TabStop = True
        rbButterCreme.Text = "Butter Creme"
        rbButterCreme.UseVisualStyleBackColor = True
        ' 
        ' rbCoffeeJelly
        ' 
        rbCoffeeJelly.AutoSize = True
        rbCoffeeJelly.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbCoffeeJelly.Location = New Point(295, 22)
        rbCoffeeJelly.Name = "rbCoffeeJelly"
        rbCoffeeJelly.Size = New Size(111, 24)
        rbCoffeeJelly.TabIndex = 3
        rbCoffeeJelly.TabStop = True
        rbCoffeeJelly.Text = "Coffee Jelly"
        rbCoffeeJelly.UseVisualStyleBackColor = True
        ' 
        ' rbJellyStrips
        ' 
        rbJellyStrips.AutoSize = True
        rbJellyStrips.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbJellyStrips.Location = New Point(413, 22)
        rbJellyStrips.Name = "rbJellyStrips"
        rbJellyStrips.Size = New Size(105, 24)
        rbJellyStrips.TabIndex = 2
        rbJellyStrips.TabStop = True
        rbJellyStrips.Text = "Jelly Strips"
        rbJellyStrips.UseVisualStyleBackColor = True
        ' 
        ' rbVelvet
        ' 
        rbVelvet.AutoSize = True
        rbVelvet.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbVelvet.Location = New Point(159, 22)
        rbVelvet.Name = "rbVelvet"
        rbVelvet.Size = New Size(122, 24)
        rbVelvet.TabIndex = 1
        rbVelvet.TabStop = True
        rbVelvet.Text = "Velvet Creme"
        rbVelvet.UseVisualStyleBackColor = True
        ' 
        ' rbNoToppings
        ' 
        rbNoToppings.AutoSize = True
        rbNoToppings.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNoToppings.Location = New Point(29, 22)
        rbNoToppings.Name = "rbNoToppings"
        rbNoToppings.Size = New Size(119, 24)
        rbNoToppings.TabIndex = 0
        rbNoToppings.TabStop = True
        rbNoToppings.Text = "No Toppings"
        rbNoToppings.UseVisualStyleBackColor = True
        ' 
        ' rbWhipped
        ' 
        rbWhipped.AutoSize = True
        rbWhipped.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbWhipped.Location = New Point(232, 22)
        rbWhipped.Name = "rbWhipped"
        rbWhipped.Size = New Size(175, 24)
        rbWhipped.TabIndex = 1
        rbWhipped.TabStop = True
        rbWhipped.Text = "Add Whipped Cream"
        rbWhipped.UseVisualStyleBackColor = True
        ' 
        ' lblBasePrice
        ' 
        lblBasePrice.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        lblBasePrice.Location = New Point(633, 550)
        lblBasePrice.Name = "lblBasePrice"
        lblBasePrice.Size = New Size(236, 25)
        lblBasePrice.TabIndex = 34
        lblBasePrice.Text = "Starting Price:"
        ' 
        ' grpSyrup
        ' 
        grpSyrup.Controls.Add(rbNoSyrup)
        grpSyrup.Controls.Add(rbFrenchVanilla)
        grpSyrup.Controls.Add(rbSaltedCaramel)
        grpSyrup.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSyrup.Location = New Point(25, 434)
        grpSyrup.Name = "grpSyrup"
        grpSyrup.Size = New Size(457, 54)
        grpSyrup.TabIndex = 29
        grpSyrup.TabStop = False
        grpSyrup.Text = "Syrup (+20)"
        ' 
        ' rbNoSyrup
        ' 
        rbNoSyrup.AutoSize = True
        rbNoSyrup.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNoSyrup.Location = New Point(41, 22)
        rbNoSyrup.Name = "rbNoSyrup"
        rbNoSyrup.Size = New Size(95, 24)
        rbNoSyrup.TabIndex = 2
        rbNoSyrup.TabStop = True
        rbNoSyrup.Text = "No Syrup"
        rbNoSyrup.UseVisualStyleBackColor = True
        ' 
        ' rbFrenchVanilla
        ' 
        rbFrenchVanilla.AutoSize = True
        rbFrenchVanilla.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbFrenchVanilla.Location = New Point(311, 22)
        rbFrenchVanilla.Name = "rbFrenchVanilla"
        rbFrenchVanilla.Size = New Size(127, 24)
        rbFrenchVanilla.TabIndex = 1
        rbFrenchVanilla.TabStop = True
        rbFrenchVanilla.Text = "French Vanilla"
        rbFrenchVanilla.UseVisualStyleBackColor = True
        ' 
        ' rbSaltedCaramel
        ' 
        rbSaltedCaramel.AutoSize = True
        rbSaltedCaramel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbSaltedCaramel.Location = New Point(148, 22)
        rbSaltedCaramel.Name = "rbSaltedCaramel"
        rbSaltedCaramel.Size = New Size(134, 24)
        rbSaltedCaramel.TabIndex = 0
        rbSaltedCaramel.TabStop = True
        rbSaltedCaramel.Text = "Salted Caramel"
        rbSaltedCaramel.UseVisualStyleBackColor = True
        ' 
        ' grpMilk
        ' 
        grpMilk.Controls.Add(rbNonDairy)
        grpMilk.Controls.Add(rbDairy)
        grpMilk.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpMilk.Location = New Point(448, 273)
        grpMilk.Name = "grpMilk"
        grpMilk.Size = New Size(279, 54)
        grpMilk.TabIndex = 26
        grpMilk.TabStop = False
        grpMilk.Text = "Milk"
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Wheat
        btnCancel.FlatStyle = FlatStyle.Popup
        btnCancel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.Location = New Point(712, 653)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(190, 45)
        btnCancel.TabIndex = 33
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnAddOrder
        ' 
        btnAddOrder.BackColor = Color.Wheat
        btnAddOrder.FlatStyle = FlatStyle.Popup
        btnAddOrder.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddOrder.Location = New Point(24, 652)
        btnAddOrder.Name = "btnAddOrder"
        btnAddOrder.Size = New Size(190, 45)
        btnAddOrder.TabIndex = 32
        btnAddOrder.Text = "Add Order"
        btnAddOrder.UseVisualStyleBackColor = False
        ' 
        ' nudQty
        ' 
        nudQty.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        nudQty.Location = New Point(115, 597)
        nudQty.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        nudQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudQty.Name = "nudQty"
        nudQty.Size = New Size(150, 30)
        nudQty.TabIndex = 31
        nudQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblQty
        ' 
        lblQty.AutoSize = True
        lblQty.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQty.Location = New Point(25, 600)
        lblQty.Name = "lblQty"
        lblQty.Size = New Size(85, 23)
        lblQty.TabIndex = 30
        lblQty.Text = "Quantity:"
        ' 
        ' grpToppings
        ' 
        grpToppings.Controls.Add(rbSeasaltCreme)
        grpToppings.Controls.Add(rbButterCreme)
        grpToppings.Controls.Add(rbCoffeeJelly)
        grpToppings.Controls.Add(rbJellyStrips)
        grpToppings.Controls.Add(rbVelvet)
        grpToppings.Controls.Add(rbNoToppings)
        grpToppings.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpToppings.Location = New Point(24, 357)
        grpToppings.Name = "grpToppings"
        grpToppings.Size = New Size(845, 54)
        grpToppings.TabIndex = 27
        grpToppings.TabStop = False
        grpToppings.Text = "Toppings (+25)"
        ' 
        ' rbNoWhipped
        ' 
        rbNoWhipped.AutoSize = True
        rbNoWhipped.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNoWhipped.Location = New Point(29, 22)
        rbNoWhipped.Name = "rbNoWhipped"
        rbNoWhipped.Size = New Size(167, 24)
        rbNoWhipped.TabIndex = 0
        rbNoWhipped.TabStop = True
        rbNoWhipped.Text = "No Whipped Cream"
        rbNoWhipped.UseVisualStyleBackColor = True
        ' 
        ' grpWhippedCream
        ' 
        grpWhippedCream.Controls.Add(rbWhipped)
        grpWhippedCream.Controls.Add(rbNoWhipped)
        grpWhippedCream.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpWhippedCream.Location = New Point(25, 511)
        grpWhippedCream.Name = "grpWhippedCream"
        grpWhippedCream.Size = New Size(427, 54)
        grpWhippedCream.TabIndex = 28
        grpWhippedCream.TabStop = False
        grpWhippedCream.Text = "Whipped Cream (+20)"
        ' 
        ' rbNoIce
        ' 
        rbNoIce.AutoSize = True
        rbNoIce.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNoIce.Location = New Point(235, 22)
        rbNoIce.Name = "rbNoIce"
        rbNoIce.Size = New Size(75, 24)
        rbNoIce.TabIndex = 2
        rbNoIce.TabStop = True
        rbNoIce.Text = "No Ice"
        rbNoIce.UseVisualStyleBackColor = True
        ' 
        ' grpSugarType
        ' 
        grpSugarType.Controls.Add(rbCane)
        grpSugarType.Controls.Add(rbMuscavado)
        grpSugarType.Controls.Add(rbStandard)
        grpSugarType.Controls.Add(rbNoSugar)
        grpSugarType.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSugarType.Location = New Point(448, 182)
        grpSugarType.Name = "grpSugarType"
        grpSugarType.Size = New Size(454, 54)
        grpSugarType.TabIndex = 24
        grpSugarType.TabStop = False
        grpSugarType.Text = "Sugar Type"
        ' 
        ' rbCane
        ' 
        rbCane.AutoSize = True
        rbCane.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbCane.Location = New Point(244, 22)
        rbCane.Name = "rbCane"
        rbCane.Size = New Size(64, 24)
        rbCane.TabIndex = 3
        rbCane.TabStop = True
        rbCane.Text = "Cane"
        rbCane.UseVisualStyleBackColor = True
        ' 
        ' rbMuscavado
        ' 
        rbMuscavado.AutoSize = True
        rbMuscavado.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbMuscavado.Location = New Point(322, 22)
        rbMuscavado.Name = "rbMuscavado"
        rbMuscavado.Size = New Size(110, 24)
        rbMuscavado.TabIndex = 2
        rbMuscavado.TabStop = True
        rbMuscavado.Text = "Muscovado"
        rbMuscavado.UseVisualStyleBackColor = True
        ' 
        ' rbStandard
        ' 
        rbStandard.AutoSize = True
        rbStandard.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbStandard.Location = New Point(138, 22)
        rbStandard.Name = "rbStandard"
        rbStandard.Size = New Size(93, 24)
        rbStandard.TabIndex = 1
        rbStandard.TabStop = True
        rbStandard.Text = "Standard"
        rbStandard.UseVisualStyleBackColor = True
        ' 
        ' rbNoSugar
        ' 
        rbNoSugar.AutoSize = True
        rbNoSugar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNoSugar.Location = New Point(29, 22)
        rbNoSugar.Name = "rbNoSugar"
        rbNoSugar.Size = New Size(95, 24)
        rbNoSugar.TabIndex = 0
        rbNoSugar.TabStop = True
        rbNoSugar.Text = "No Sugar"
        rbNoSugar.UseVisualStyleBackColor = True
        ' 
        ' rbIce
        ' 
        rbIce.AutoSize = True
        rbIce.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbIce.Location = New Point(116, 22)
        rbIce.Name = "rbIce"
        rbIce.Size = New Size(50, 24)
        rbIce.TabIndex = 1
        rbIce.TabStop = True
        rbIce.Text = "Ice"
        rbIce.UseVisualStyleBackColor = True
        ' 
        ' rbHot
        ' 
        rbHot.AutoSize = True
        rbHot.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbHot.Location = New Point(29, 22)
        rbHot.Name = "rbHot"
        rbHot.Size = New Size(56, 24)
        rbHot.TabIndex = 0
        rbHot.TabStop = True
        rbHot.Text = "Hot"
        rbHot.UseVisualStyleBackColor = True
        ' 
        ' rbBoss
        ' 
        rbBoss.AutoSize = True
        rbBoss.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbBoss.Location = New Point(116, 22)
        rbBoss.Name = "rbBoss"
        rbBoss.Size = New Size(63, 24)
        rbBoss.TabIndex = 1
        rbBoss.TabStop = True
        rbBoss.Text = "Boss"
        rbBoss.UseVisualStyleBackColor = True
        ' 
        ' rbLydia
        ' 
        rbLydia.AutoSize = True
        rbLydia.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbLydia.Location = New Point(29, 22)
        rbLydia.Name = "rbLydia"
        rbLydia.Size = New Size(66, 24)
        rbLydia.TabIndex = 0
        rbLydia.TabStop = True
        rbLydia.Text = "Lydia"
        rbLydia.UseVisualStyleBackColor = True
        ' 
        ' rbLarge
        ' 
        rbLarge.AutoSize = True
        rbLarge.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbLarge.Location = New Point(235, 22)
        rbLarge.Name = "rbLarge"
        rbLarge.Size = New Size(109, 24)
        rbLarge.TabIndex = 2
        rbLarge.TabStop = True
        rbLarge.Text = "20oz (+20)"
        rbLarge.UseVisualStyleBackColor = True
        ' 
        ' rbMedium
        ' 
        rbMedium.AutoSize = True
        rbMedium.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbMedium.Location = New Point(116, 22)
        rbMedium.Name = "rbMedium"
        rbMedium.Size = New Size(109, 24)
        rbMedium.TabIndex = 1
        rbMedium.TabStop = True
        rbMedium.Text = "16oz (+10)"
        rbMedium.UseVisualStyleBackColor = True
        ' 
        ' rbSmall
        ' 
        rbSmall.AutoSize = True
        rbSmall.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbSmall.Location = New Point(29, 22)
        rbSmall.Name = "rbSmall"
        rbSmall.Size = New Size(64, 24)
        rbSmall.TabIndex = 0
        rbSmall.TabStop = True
        rbSmall.Text = "12oz"
        rbSmall.UseVisualStyleBackColor = True
        ' 
        ' grpIceLevel
        ' 
        grpIceLevel.Controls.Add(rbNoIce)
        grpIceLevel.Controls.Add(rbLess)
        grpIceLevel.Controls.Add(rbNormal)
        grpIceLevel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpIceLevel.Location = New Point(24, 273)
        grpIceLevel.Name = "grpIceLevel"
        grpIceLevel.Size = New Size(331, 54)
        grpIceLevel.TabIndex = 25
        grpIceLevel.TabStop = False
        grpIceLevel.Text = "Ice Level"
        ' 
        ' rbLess
        ' 
        rbLess.AutoSize = True
        rbLess.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbLess.Location = New Point(130, 22)
        rbLess.Name = "rbLess"
        rbLess.Size = New Size(84, 24)
        rbLess.TabIndex = 1
        rbLess.TabStop = True
        rbLess.Text = "Less Ice"
        rbLess.UseVisualStyleBackColor = True
        ' 
        ' rbNormal
        ' 
        rbNormal.AutoSize = True
        rbNormal.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNormal.Location = New Point(29, 22)
        rbNormal.Name = "rbNormal"
        rbNormal.Size = New Size(83, 24)
        rbNormal.TabIndex = 0
        rbNormal.TabStop = True
        rbNormal.Text = "Normal"
        rbNormal.UseVisualStyleBackColor = True
        ' 
        ' rb100
        ' 
        rb100.AutoSize = True
        rb100.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rb100.Location = New Point(302, 22)
        rb100.Name = "rb100"
        rb100.Size = New Size(70, 24)
        rb100.TabIndex = 6
        rb100.TabStop = True
        rb100.Text = "100%"
        rb100.UseVisualStyleBackColor = True
        ' 
        ' grpSugarLevel
        ' 
        grpSugarLevel.Controls.Add(rb100)
        grpSugarLevel.Controls.Add(rb50)
        grpSugarLevel.Controls.Add(rb75)
        grpSugarLevel.Controls.Add(rb25)
        grpSugarLevel.Controls.Add(rb0)
        grpSugarLevel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSugarLevel.Location = New Point(25, 182)
        grpSugarLevel.Name = "grpSugarLevel"
        grpSugarLevel.Size = New Size(387, 54)
        grpSugarLevel.TabIndex = 23
        grpSugarLevel.TabStop = False
        grpSugarLevel.Text = "Sugar Level"
        ' 
        ' rb50
        ' 
        rb50.AutoSize = True
        rb50.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rb50.Location = New Point(160, 22)
        rb50.Name = "rb50"
        rb50.Size = New Size(61, 24)
        rb50.TabIndex = 3
        rb50.TabStop = True
        rb50.Text = "50%"
        rb50.UseVisualStyleBackColor = True
        ' 
        ' rb75
        ' 
        rb75.AutoSize = True
        rb75.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rb75.Location = New Point(235, 22)
        rb75.Name = "rb75"
        rb75.Size = New Size(61, 24)
        rb75.TabIndex = 2
        rb75.TabStop = True
        rb75.Text = "75%"
        rb75.UseVisualStyleBackColor = True
        ' 
        ' rb25
        ' 
        rb25.AutoSize = True
        rb25.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rb25.Location = New Point(93, 22)
        rb25.Name = "rb25"
        rb25.Size = New Size(61, 24)
        rb25.TabIndex = 1
        rb25.TabStop = True
        rb25.Text = "25%"
        rb25.UseVisualStyleBackColor = True
        ' 
        ' rb0
        ' 
        rb0.AutoSize = True
        rb0.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rb0.Location = New Point(29, 22)
        rb0.Name = "rb0"
        rb0.Size = New Size(52, 24)
        rb0.TabIndex = 0
        rb0.TabStop = True
        rb0.Text = "0%"
        rb0.UseVisualStyleBackColor = True
        ' 
        ' grpSize
        ' 
        grpSize.Controls.Add(rbLarge)
        grpSize.Controls.Add(rbMedium)
        grpSize.Controls.Add(rbSmall)
        grpSize.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSize.Location = New Point(540, 95)
        grpSize.Name = "grpSize"
        grpSize.Size = New Size(364, 54)
        grpSize.TabIndex = 22
        grpSize.TabStop = False
        grpSize.Text = "Size"
        ' 
        ' grpBeans
        ' 
        grpBeans.Controls.Add(rbBoss)
        grpBeans.Controls.Add(rbLydia)
        grpBeans.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpBeans.Location = New Point(275, 95)
        grpBeans.Name = "grpBeans"
        grpBeans.Size = New Size(213, 54)
        grpBeans.TabIndex = 21
        grpBeans.TabStop = False
        grpBeans.Text = "Beans"
        ' 
        ' grpTemp
        ' 
        grpTemp.Controls.Add(rbIce)
        grpTemp.Controls.Add(rbHot)
        grpTemp.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpTemp.Location = New Point(24, 95)
        grpTemp.Name = "grpTemp"
        grpTemp.Size = New Size(198, 54)
        grpTemp.TabIndex = 20
        grpTemp.TabStop = False
        grpTemp.Text = "Temperature"
        ' 
        ' lblDrinkName
        ' 
        lblDrinkName.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDrinkName.Location = New Point(310, 18)
        lblDrinkName.Name = "lblDrinkName"
        lblDrinkName.Size = New Size(307, 41)
        lblDrinkName.TabIndex = 19
        lblDrinkName.Text = "Drink Name"
        lblDrinkName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.LightCoral
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.Location = New Point(874, 15)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(34, 34)
        btnClose.TabIndex = 18
        btnClose.Text = "X"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' DrinksCustomizeControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(lblTotal)
        Controls.Add(lblBasePrice)
        Controls.Add(grpSyrup)
        Controls.Add(grpMilk)
        Controls.Add(btnCancel)
        Controls.Add(btnAddOrder)
        Controls.Add(nudQty)
        Controls.Add(lblQty)
        Controls.Add(grpToppings)
        Controls.Add(grpWhippedCream)
        Controls.Add(grpSugarType)
        Controls.Add(grpIceLevel)
        Controls.Add(grpSugarLevel)
        Controls.Add(grpSize)
        Controls.Add(grpBeans)
        Controls.Add(grpTemp)
        Controls.Add(lblDrinkName)
        Controls.Add(btnClose)
        Name = "DrinksCustomizeControl"
        Size = New Size(921, 724)
        grpSyrup.ResumeLayout(False)
        grpSyrup.PerformLayout()
        grpMilk.ResumeLayout(False)
        grpMilk.PerformLayout()
        CType(nudQty, ComponentModel.ISupportInitialize).EndInit()
        grpToppings.ResumeLayout(False)
        grpToppings.PerformLayout()
        grpWhippedCream.ResumeLayout(False)
        grpWhippedCream.PerformLayout()
        grpSugarType.ResumeLayout(False)
        grpSugarType.PerformLayout()
        grpIceLevel.ResumeLayout(False)
        grpIceLevel.PerformLayout()
        grpSugarLevel.ResumeLayout(False)
        grpSugarLevel.PerformLayout()
        grpSize.ResumeLayout(False)
        grpSize.PerformLayout()
        grpBeans.ResumeLayout(False)
        grpBeans.PerformLayout()
        grpTemp.ResumeLayout(False)
        grpTemp.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTotal As Label
    Friend WithEvents rbNonDairy As RadioButton
    Friend WithEvents rbDairy As RadioButton
    Friend WithEvents rbSeasaltCreme As RadioButton
    Friend WithEvents rbButterCreme As RadioButton
    Friend WithEvents rbCoffeeJelly As RadioButton
    Friend WithEvents rbJellyStrips As RadioButton
    Friend WithEvents rbVelvet As RadioButton
    Friend WithEvents rbNoToppings As RadioButton
    Friend WithEvents rbWhipped As RadioButton
    Friend WithEvents lblBasePrice As Label
    Friend WithEvents grpSyrup As GroupBox
    Friend WithEvents rbNoSyrup As RadioButton
    Friend WithEvents rbFrenchVanilla As RadioButton
    Friend WithEvents rbSaltedCaramel As RadioButton
    Friend WithEvents grpMilk As GroupBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAddOrder As Button
    Friend WithEvents nudQty As NumericUpDown
    Friend WithEvents lblQty As Label
    Friend WithEvents grpToppings As GroupBox
    Friend WithEvents rbNoWhipped As RadioButton
    Friend WithEvents grpWhippedCream As GroupBox
    Friend WithEvents rbNoIce As RadioButton
    Friend WithEvents grpSugarType As GroupBox
    Friend WithEvents rbCane As RadioButton
    Friend WithEvents rbMuscavado As RadioButton
    Friend WithEvents rbStandard As RadioButton
    Friend WithEvents rbNoSugar As RadioButton
    Friend WithEvents rbIce As RadioButton
    Friend WithEvents rbHot As RadioButton
    Friend WithEvents rbBoss As RadioButton
    Friend WithEvents rbLydia As RadioButton
    Friend WithEvents rbLarge As RadioButton
    Friend WithEvents rbMedium As RadioButton
    Friend WithEvents rbSmall As RadioButton
    Friend WithEvents grpIceLevel As GroupBox
    Friend WithEvents rbLess As RadioButton
    Friend WithEvents rbNormal As RadioButton
    Friend WithEvents rb100 As RadioButton
    Friend WithEvents grpSugarLevel As GroupBox
    Friend WithEvents rb50 As RadioButton
    Friend WithEvents rb75 As RadioButton
    Friend WithEvents rb25 As RadioButton
    Friend WithEvents rb0 As RadioButton
    Friend WithEvents grpSize As GroupBox
    Friend WithEvents grpBeans As GroupBox
    Friend WithEvents grpTemp As GroupBox
    Friend WithEvents lblDrinkName As Label
    Friend WithEvents btnClose As Button

End Class
