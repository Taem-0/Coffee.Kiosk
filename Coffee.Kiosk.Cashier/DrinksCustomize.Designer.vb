<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrinksCustomize
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        btnClose = New Button()
        lblDrinkName = New Label()
        grpTemp = New GroupBox()
        rbIce = New RadioButton()
        rbHot = New RadioButton()
        grpBeans = New GroupBox()
        rbBoss = New RadioButton()
        rbLydia = New RadioButton()
        grpSize = New GroupBox()
        rbLarge = New RadioButton()
        rbMedium = New RadioButton()
        rbSmall = New RadioButton()
        grpSugarLevel = New GroupBox()
        rb100 = New RadioButton()
        rb50 = New RadioButton()
        rb75 = New RadioButton()
        rb25 = New RadioButton()
        rb0 = New RadioButton()
        rbNoSugar = New RadioButton()
        rbStandard = New RadioButton()
        rbMuscavado = New RadioButton()
        rbCane = New RadioButton()
        grpSugarType = New GroupBox()
        grpIceLevel = New GroupBox()
        rbNoIce = New RadioButton()
        rbLess = New RadioButton()
        rbNormal = New RadioButton()
        grpMilk = New GroupBox()
        rbNonDairy = New RadioButton()
        rbDairy = New RadioButton()
        grpToppings = New GroupBox()
        rbSeasaltCreme = New RadioButton()
        rbButterCreme = New RadioButton()
        rbCoffeeJelly = New RadioButton()
        rbJellyStrips = New RadioButton()
        rbVelvet = New RadioButton()
        rbNoToppings = New RadioButton()
        grpWhippedCream = New GroupBox()
        rbWhipped = New RadioButton()
        rbNoWhipped = New RadioButton()
        grpSyrup = New GroupBox()
        rbFrenchVanilla = New RadioButton()
        rbSaltedCaramel = New RadioButton()
        lblQty = New Label()
        nudQty = New NumericUpDown()
        btnAddOrder = New Button()
        btnCancel = New Button()
        lblBasePrice = New Label()
        lblTotal = New Label()
        grpTemp.SuspendLayout()
        grpBeans.SuspendLayout()
        grpSize.SuspendLayout()
        grpSugarLevel.SuspendLayout()
        grpSugarType.SuspendLayout()
        grpIceLevel.SuspendLayout()
        grpMilk.SuspendLayout()
        grpToppings.SuspendLayout()
        grpWhippedCream.SuspendLayout()
        grpSyrup.SuspendLayout()
        CType(nudQty, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.LightCoral
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.Location = New Point(927, 12)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(34, 34)
        btnClose.TabIndex = 0
        btnClose.Text = "X"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' lblDrinkName
        ' 
        lblDrinkName.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDrinkName.Location = New Point(324, 12)
        lblDrinkName.Name = "lblDrinkName"
        lblDrinkName.Size = New Size(307, 41)
        lblDrinkName.TabIndex = 1
        lblDrinkName.Text = "Drink Name"
        lblDrinkName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' grpTemp
        ' 
        grpTemp.Controls.Add(rbIce)
        grpTemp.Controls.Add(rbHot)
        grpTemp.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpTemp.Location = New Point(22, 92)
        grpTemp.Name = "grpTemp"
        grpTemp.Size = New Size(198, 54)
        grpTemp.TabIndex = 2
        grpTemp.TabStop = False
        grpTemp.Text = "Temperature"
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
        ' grpBeans
        ' 
        grpBeans.Controls.Add(rbBoss)
        grpBeans.Controls.Add(rbLydia)
        grpBeans.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpBeans.Location = New Point(289, 92)
        grpBeans.Name = "grpBeans"
        grpBeans.Size = New Size(213, 54)
        grpBeans.TabIndex = 3
        grpBeans.TabStop = False
        grpBeans.Text = "Beans"
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
        ' grpSize
        ' 
        grpSize.Controls.Add(rbLarge)
        grpSize.Controls.Add(rbMedium)
        grpSize.Controls.Add(rbSmall)
        grpSize.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSize.Location = New Point(564, 92)
        grpSize.Name = "grpSize"
        grpSize.Size = New Size(364, 54)
        grpSize.TabIndex = 4
        grpSize.TabStop = False
        grpSize.Text = "Size"
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
        ' grpSugarLevel
        ' 
        grpSugarLevel.Controls.Add(rb100)
        grpSugarLevel.Controls.Add(rb50)
        grpSugarLevel.Controls.Add(rb75)
        grpSugarLevel.Controls.Add(rb25)
        grpSugarLevel.Controls.Add(rb0)
        grpSugarLevel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSugarLevel.Location = New Point(22, 181)
        grpSugarLevel.Name = "grpSugarLevel"
        grpSugarLevel.Size = New Size(387, 54)
        grpSugarLevel.TabIndex = 5
        grpSugarLevel.TabStop = False
        grpSugarLevel.Text = "Sugar Level"
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
        ' grpSugarType
        ' 
        grpSugarType.Controls.Add(rbCane)
        grpSugarType.Controls.Add(rbMuscavado)
        grpSugarType.Controls.Add(rbStandard)
        grpSugarType.Controls.Add(rbNoSugar)
        grpSugarType.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSugarType.Location = New Point(435, 181)
        grpSugarType.Name = "grpSugarType"
        grpSugarType.Size = New Size(454, 54)
        grpSugarType.TabIndex = 6
        grpSugarType.TabStop = False
        grpSugarType.Text = "Sugar Type"
        ' 
        ' grpIceLevel
        ' 
        grpIceLevel.Controls.Add(rbNoIce)
        grpIceLevel.Controls.Add(rbLess)
        grpIceLevel.Controls.Add(rbNormal)
        grpIceLevel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpIceLevel.Location = New Point(22, 270)
        grpIceLevel.Name = "grpIceLevel"
        grpIceLevel.Size = New Size(331, 54)
        grpIceLevel.TabIndex = 7
        grpIceLevel.TabStop = False
        grpIceLevel.Text = "Ice Level"
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
        ' grpMilk
        ' 
        grpMilk.Controls.Add(rbNonDairy)
        grpMilk.Controls.Add(rbDairy)
        grpMilk.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpMilk.Location = New Point(405, 270)
        grpMilk.Name = "grpMilk"
        grpMilk.Size = New Size(279, 54)
        grpMilk.TabIndex = 8
        grpMilk.TabStop = False
        grpMilk.Text = "Milk"
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
        ' grpToppings
        ' 
        grpToppings.Controls.Add(rbSeasaltCreme)
        grpToppings.Controls.Add(rbButterCreme)
        grpToppings.Controls.Add(rbCoffeeJelly)
        grpToppings.Controls.Add(rbJellyStrips)
        grpToppings.Controls.Add(rbVelvet)
        grpToppings.Controls.Add(rbNoToppings)
        grpToppings.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpToppings.Location = New Point(22, 371)
        grpToppings.Name = "grpToppings"
        grpToppings.Size = New Size(845, 54)
        grpToppings.TabIndex = 9
        grpToppings.TabStop = False
        grpToppings.Text = "Toppings (+25)"
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
        ' grpWhippedCream
        ' 
        grpWhippedCream.Controls.Add(rbWhipped)
        grpWhippedCream.Controls.Add(rbNoWhipped)
        grpWhippedCream.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpWhippedCream.Location = New Point(501, 463)
        grpWhippedCream.Name = "grpWhippedCream"
        grpWhippedCream.Size = New Size(427, 54)
        grpWhippedCream.TabIndex = 10
        grpWhippedCream.TabStop = False
        grpWhippedCream.Text = "Whipped Cream"
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
        ' grpSyrup
        ' 
        grpSyrup.Controls.Add(rbFrenchVanilla)
        grpSyrup.Controls.Add(rbSaltedCaramel)
        grpSyrup.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSyrup.Location = New Point(22, 463)
        grpSyrup.Name = "grpSyrup"
        grpSyrup.Size = New Size(406, 54)
        grpSyrup.TabIndex = 11
        grpSyrup.TabStop = False
        grpSyrup.Text = "Syrup (+20)"
        ' 
        ' rbFrenchVanilla
        ' 
        rbFrenchVanilla.AutoSize = True
        rbFrenchVanilla.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbFrenchVanilla.Location = New Point(232, 22)
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
        rbSaltedCaramel.Location = New Point(56, 22)
        rbSaltedCaramel.Name = "rbSaltedCaramel"
        rbSaltedCaramel.Size = New Size(134, 24)
        rbSaltedCaramel.TabIndex = 0
        rbSaltedCaramel.TabStop = True
        rbSaltedCaramel.Text = "Salted Caramel"
        rbSaltedCaramel.UseVisualStyleBackColor = True
        ' 
        ' lblQty
        ' 
        lblQty.AutoSize = True
        lblQty.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQty.Location = New Point(28, 556)
        lblQty.Name = "lblQty"
        lblQty.Size = New Size(85, 23)
        lblQty.TabIndex = 12
        lblQty.Text = "Quantity:"
        ' 
        ' nudQty
        ' 
        nudQty.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        nudQty.Location = New Point(118, 553)
        nudQty.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        nudQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudQty.Name = "nudQty"
        nudQty.Size = New Size(150, 30)
        nudQty.TabIndex = 13
        nudQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' btnAddOrder
        ' 
        btnAddOrder.BackColor = Color.Wheat
        btnAddOrder.FlatStyle = FlatStyle.Popup
        btnAddOrder.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddOrder.Location = New Point(22, 622)
        btnAddOrder.Name = "btnAddOrder"
        btnAddOrder.Size = New Size(190, 45)
        btnAddOrder.TabIndex = 14
        btnAddOrder.Text = "Add Order"
        btnAddOrder.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Wheat
        btnCancel.FlatStyle = FlatStyle.Popup
        btnCancel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.Location = New Point(759, 622)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(190, 45)
        btnCancel.TabIndex = 15
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' lblBasePrice
        ' 
        lblBasePrice.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        lblBasePrice.Location = New Point(690, 533)
        lblBasePrice.Name = "lblBasePrice"
        lblBasePrice.Size = New Size(236, 25)
        lblBasePrice.TabIndex = 16
        lblBasePrice.Text = "Starting Price:"
        ' 
        ' lblTotal
        ' 
        lblTotal.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        lblTotal.Location = New Point(692, 582)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(234, 23)
        lblTotal.TabIndex = 17
        lblTotal.Text = "Total: "
        ' 
        ' DrinksCustomize
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.OldLace
        ClientSize = New Size(974, 689)
        ControlBox = False
        Controls.Add(lblTotal)
        Controls.Add(lblBasePrice)
        Controls.Add(btnCancel)
        Controls.Add(btnAddOrder)
        Controls.Add(nudQty)
        Controls.Add(lblQty)
        Controls.Add(grpSyrup)
        Controls.Add(grpWhippedCream)
        Controls.Add(grpToppings)
        Controls.Add(grpMilk)
        Controls.Add(grpIceLevel)
        Controls.Add(grpSugarType)
        Controls.Add(grpSugarLevel)
        Controls.Add(grpSize)
        Controls.Add(grpBeans)
        Controls.Add(grpTemp)
        Controls.Add(lblDrinkName)
        Controls.Add(btnClose)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "DrinksCustomize"
        grpTemp.ResumeLayout(False)
        grpTemp.PerformLayout()
        grpBeans.ResumeLayout(False)
        grpBeans.PerformLayout()
        grpSize.ResumeLayout(False)
        grpSize.PerformLayout()
        grpSugarLevel.ResumeLayout(False)
        grpSugarLevel.PerformLayout()
        grpSugarType.ResumeLayout(False)
        grpSugarType.PerformLayout()
        grpIceLevel.ResumeLayout(False)
        grpIceLevel.PerformLayout()
        grpMilk.ResumeLayout(False)
        grpMilk.PerformLayout()
        grpToppings.ResumeLayout(False)
        grpToppings.PerformLayout()
        grpWhippedCream.ResumeLayout(False)
        grpWhippedCream.PerformLayout()
        grpSyrup.ResumeLayout(False)
        grpSyrup.PerformLayout()
        CType(nudQty, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents lblDrinkName As Label
    Friend WithEvents grpTemp As GroupBox
    Friend WithEvents rbIce As RadioButton
    Friend WithEvents rbHot As RadioButton
    Friend WithEvents grpBeans As GroupBox
    Friend WithEvents rbBoss As RadioButton
    Friend WithEvents rbLydia As RadioButton
    Friend WithEvents grpSize As GroupBox
    Friend WithEvents rbLarge As RadioButton
    Friend WithEvents rbMedium As RadioButton
    Friend WithEvents rbSmall As RadioButton
    Friend WithEvents grpSugarLevel As GroupBox
    Friend WithEvents rb75 As RadioButton
    Friend WithEvents rb25 As RadioButton
    Friend WithEvents rb0 As RadioButton
    Friend WithEvents rb100 As RadioButton
    Friend WithEvents rb50 As RadioButton
    Friend WithEvents rbNoSugar As RadioButton
    Friend WithEvents rbStandard As RadioButton
    Friend WithEvents rbMuscavado As RadioButton
    Friend WithEvents rbCane As RadioButton
    Friend WithEvents grpSugarType As GroupBox
    Friend WithEvents grpIceLevel As GroupBox
    Friend WithEvents rbNoIce As RadioButton
    Friend WithEvents rbLess As RadioButton
    Friend WithEvents rbNormal As RadioButton
    Friend WithEvents grpMilk As GroupBox
    Friend WithEvents rbNonDairy As RadioButton
    Friend WithEvents rbDairy As RadioButton
    Friend WithEvents grpToppings As GroupBox
    Friend WithEvents rbCoffeeJelly As RadioButton
    Friend WithEvents rbJellyStrips As RadioButton
    Friend WithEvents rbVelvet As RadioButton
    Friend WithEvents rbNoToppings As RadioButton
    Friend WithEvents rbSeasaltCreme As RadioButton
    Friend WithEvents rbButterCreme As RadioButton
    Friend WithEvents grpWhippedCream As GroupBox
    Friend WithEvents rbWhipped As RadioButton
    Friend WithEvents rbNoWhipped As RadioButton
    Friend WithEvents grpSyrup As GroupBox
    Friend WithEvents rbFrenchVanilla As RadioButton
    Friend WithEvents rbSaltedCaramel As RadioButton
    Friend WithEvents lblQty As Label
    Friend WithEvents nudQty As NumericUpDown
    Friend WithEvents btnAddOrder As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblBasePrice As Label
    Friend WithEvents lblTotal As Label
End Class
