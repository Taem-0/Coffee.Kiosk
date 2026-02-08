<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MealsCustomizeControl
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
        btnCancel = New Button()
        btnAddOrder = New Button()
        nudQty = New NumericUpDown()
        lblQty = New Label()
        rbExtraRice = New RadioButton()
        lblBasePrice = New Label()
        rbRegularRice = New RadioButton()
        rbSalad = New RadioButton()
        rbFries = New RadioButton()
        rbNoSide = New RadioButton()
        lblTotal = New Label()
        grpRice = New GroupBox()
        btnClose = New Button()
        grpSide = New GroupBox()
        lblMealName = New Label()
        CType(nudQty, ComponentModel.ISupportInitialize).BeginInit()
        grpRice.SuspendLayout()
        grpSide.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Wheat
        btnCancel.FlatStyle = FlatStyle.Popup
        btnCancel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.Location = New Point(620, 621)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(190, 45)
        btnCancel.TabIndex = 51
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnAddOrder
        ' 
        btnAddOrder.BackColor = Color.Wheat
        btnAddOrder.FlatStyle = FlatStyle.Popup
        btnAddOrder.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddOrder.Location = New Point(113, 621)
        btnAddOrder.Name = "btnAddOrder"
        btnAddOrder.Size = New Size(190, 45)
        btnAddOrder.TabIndex = 50
        btnAddOrder.Text = "Add Order"
        btnAddOrder.UseVisualStyleBackColor = False
        ' 
        ' nudQty
        ' 
        nudQty.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        nudQty.Location = New Point(283, 285)
        nudQty.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        nudQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nudQty.Name = "nudQty"
        nudQty.Size = New Size(150, 30)
        nudQty.TabIndex = 49
        nudQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblQty
        ' 
        lblQty.AutoSize = True
        lblQty.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblQty.Location = New Point(193, 288)
        lblQty.Name = "lblQty"
        lblQty.Size = New Size(85, 23)
        lblQty.TabIndex = 48
        lblQty.Text = "Quantity:"
        ' 
        ' rbExtraRice
        ' 
        rbExtraRice.AutoSize = True
        rbExtraRice.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbExtraRice.Location = New Point(174, 30)
        rbExtraRice.Name = "rbExtraRice"
        rbExtraRice.Size = New Size(144, 24)
        rbExtraRice.TabIndex = 2
        rbExtraRice.TabStop = True
        rbExtraRice.Text = "Extra Rice (+10)"
        rbExtraRice.UseVisualStyleBackColor = True
        ' 
        ' lblBasePrice
        ' 
        lblBasePrice.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        lblBasePrice.Location = New Point(538, 260)
        lblBasePrice.Name = "lblBasePrice"
        lblBasePrice.Size = New Size(236, 25)
        lblBasePrice.TabIndex = 52
        lblBasePrice.Text = "Starting Price:"
        ' 
        ' rbRegularRice
        ' 
        rbRegularRice.AutoSize = True
        rbRegularRice.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbRegularRice.Location = New Point(29, 30)
        rbRegularRice.Name = "rbRegularRice"
        rbRegularRice.Size = New Size(117, 24)
        rbRegularRice.TabIndex = 0
        rbRegularRice.TabStop = True
        rbRegularRice.Text = "Regular Rice"
        rbRegularRice.UseVisualStyleBackColor = True
        ' 
        ' rbSalad
        ' 
        rbSalad.AutoSize = True
        rbSalad.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbSalad.Location = New Point(264, 32)
        rbSalad.Name = "rbSalad"
        rbSalad.Size = New Size(112, 24)
        rbSalad.TabIndex = 6
        rbSalad.TabStop = True
        rbSalad.Text = "Salad (+40)"
        rbSalad.UseVisualStyleBackColor = True
        ' 
        ' rbFries
        ' 
        rbFries.AutoSize = True
        rbFries.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbFries.Location = New Point(137, 32)
        rbFries.Name = "rbFries"
        rbFries.Size = New Size(108, 24)
        rbFries.TabIndex = 2
        rbFries.TabStop = True
        rbFries.Text = "Fries (+40)"
        rbFries.UseVisualStyleBackColor = True
        ' 
        ' rbNoSide
        ' 
        rbNoSide.AutoSize = True
        rbNoSide.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbNoSide.Location = New Point(29, 32)
        rbNoSide.Name = "rbNoSide"
        rbNoSide.Size = New Size(91, 24)
        rbNoSide.TabIndex = 0
        rbNoSide.TabStop = True
        rbNoSide.Text = "No Sides"
        rbNoSide.UseVisualStyleBackColor = True
        ' 
        ' lblTotal
        ' 
        lblTotal.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        lblTotal.Location = New Point(540, 309)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(234, 23)
        lblTotal.TabIndex = 53
        lblTotal.Text = "Total: "
        ' 
        ' grpRice
        ' 
        grpRice.Controls.Add(rbExtraRice)
        grpRice.Controls.Add(rbRegularRice)
        grpRice.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpRice.Location = New Point(56, 141)
        grpRice.Name = "grpRice"
        grpRice.Size = New Size(364, 70)
        grpRice.TabIndex = 40
        grpRice.TabStop = False
        grpRice.Text = "Rice "
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.LightCoral
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.Location = New Point(870, 64)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(34, 34)
        btnClose.TabIndex = 36
        btnClose.Text = "X"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' grpSide
        ' 
        grpSide.Controls.Add(rbSalad)
        grpSide.Controls.Add(rbFries)
        grpSide.Controls.Add(rbNoSide)
        grpSide.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpSide.Location = New Point(483, 138)
        grpSide.Name = "grpSide"
        grpSide.Size = New Size(387, 73)
        grpSide.TabIndex = 41
        grpSide.TabStop = False
        grpSide.Text = "Side Dish"
        ' 
        ' lblMealName
        ' 
        lblMealName.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMealName.Location = New Point(306, 67)
        lblMealName.Name = "lblMealName"
        lblMealName.Size = New Size(307, 41)
        lblMealName.TabIndex = 37
        lblMealName.Text = "Meals Name"
        lblMealName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' MealsCustomizeControl
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        Controls.Add(btnCancel)
        Controls.Add(btnAddOrder)
        Controls.Add(nudQty)
        Controls.Add(lblQty)
        Controls.Add(lblBasePrice)
        Controls.Add(lblTotal)
        Controls.Add(grpRice)
        Controls.Add(btnClose)
        Controls.Add(grpSide)
        Controls.Add(lblMealName)
        Name = "MealsCustomizeControl"
        Size = New Size(921, 724)
        CType(nudQty, ComponentModel.ISupportInitialize).EndInit()
        grpRice.ResumeLayout(False)
        grpRice.PerformLayout()
        grpSide.ResumeLayout(False)
        grpSide.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAddOrder As Button
    Friend WithEvents nudQty As NumericUpDown
    Friend WithEvents lblQty As Label
    Friend WithEvents rbExtraRice As RadioButton
    Friend WithEvents lblBasePrice As Label
    Friend WithEvents rbRegularRice As RadioButton
    Friend WithEvents rbSalad As RadioButton
    Friend WithEvents rb50 As RadioButton
    Friend WithEvents rbFries As RadioButton
    Friend WithEvents rb25 As RadioButton
    Friend WithEvents rbNoSide As RadioButton
    Friend WithEvents lblTotal As Label
    Friend WithEvents grpRice As GroupBox
    Friend WithEvents btnClose As Button
    Friend WithEvents grpSide As GroupBox
    Friend WithEvents lblMealName As Label

End Class
