<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentDialog
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
        lblTitle = New Label()
        LeftPanel = New Panel()
        grpOrderSummary = New GroupBox()
        rtbOrderSummary = New RichTextBox()
        grpReceiptPreview = New GroupBox()
        rtbReceiptPreview = New RichTextBox()
        RightPanel = New Panel()
        grpPaymentDetails = New GroupBox()
        pnlDigitalPayment = New Panel()
        lblDigitalAmount = New Label()
        lblDigitalAmountLabel = New Label()
        txtReference = New TextBox()
        lblReference = New Label()
        Label4 = New Label()
        pnlCashPayment = New Panel()
        lblChange = New Label()
        lblChangeLabel = New Label()
        txtAmountPaid = New TextBox()
        lblAmountPaid = New Label()
        lblCashPayment = New Label()
        rbMaya = New RadioButton()
        rbGcash = New RadioButton()
        rbCash = New RadioButton()
        lblPaymentMethod = New Label()
        lblTotalAmount = New Label()
        lblTotalLabel = New Label()
        btnConfirm = New Button()
        btnCancel = New Button()
        LeftPanel.SuspendLayout()
        grpOrderSummary.SuspendLayout()
        grpReceiptPreview.SuspendLayout()
        RightPanel.SuspendLayout()
        grpPaymentDetails.SuspendLayout()
        pnlDigitalPayment.SuspendLayout()
        pnlCashPayment.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(319, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(401, 41)
        lblTitle.TabIndex = 0
        lblTitle.Text = "PAYMENT CONFIRMATION"
        lblTitle.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LeftPanel
        ' 
        LeftPanel.Controls.Add(grpOrderSummary)
        LeftPanel.Location = New Point(35, 83)
        LeftPanel.Name = "LeftPanel"
        LeftPanel.Size = New Size(462, 404)
        LeftPanel.TabIndex = 1
        ' 
        ' grpOrderSummary
        ' 
        grpOrderSummary.Controls.Add(rtbOrderSummary)
        grpOrderSummary.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpOrderSummary.Location = New Point(30, 21)
        grpOrderSummary.Name = "grpOrderSummary"
        grpOrderSummary.Size = New Size(400, 350)
        grpOrderSummary.TabIndex = 0
        grpOrderSummary.TabStop = False
        grpOrderSummary.Text = "Order Summary"
        ' 
        ' rtbOrderSummary
        ' 
        rtbOrderSummary.BackColor = Color.White
        rtbOrderSummary.Location = New Point(17, 27)
        rtbOrderSummary.Name = "rtbOrderSummary"
        rtbOrderSummary.ReadOnly = True
        rtbOrderSummary.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbOrderSummary.Size = New Size(365, 300)
        rtbOrderSummary.TabIndex = 0
        rtbOrderSummary.Text = ""
        ' 
        ' grpReceiptPreview
        ' 
        grpReceiptPreview.Controls.Add(rtbReceiptPreview)
        grpReceiptPreview.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpReceiptPreview.Location = New Point(30, 21)
        grpReceiptPreview.Name = "grpReceiptPreview"
        grpReceiptPreview.Size = New Size(400, 350)
        grpReceiptPreview.TabIndex = 0
        grpReceiptPreview.TabStop = False
        grpReceiptPreview.Text = "Receipt Preview"
        ' 
        ' rtbReceiptPreview
        ' 
        rtbReceiptPreview.BackColor = Color.White
        rtbReceiptPreview.Location = New Point(17, 27)
        rtbReceiptPreview.Name = "rtbReceiptPreview"
        rtbReceiptPreview.ReadOnly = True
        rtbReceiptPreview.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbReceiptPreview.Size = New Size(365, 300)
        rtbReceiptPreview.TabIndex = 0
        rtbReceiptPreview.Text = ""
        ' 
        ' RightPanel
        ' 
        RightPanel.Controls.Add(grpReceiptPreview)
        RightPanel.Location = New Point(528, 83)
        RightPanel.Name = "RightPanel"
        RightPanel.Size = New Size(462, 404)
        RightPanel.TabIndex = 2
        ' 
        ' grpPaymentDetails
        ' 
        grpPaymentDetails.Controls.Add(pnlDigitalPayment)
        grpPaymentDetails.Controls.Add(pnlCashPayment)
        grpPaymentDetails.Controls.Add(rbMaya)
        grpPaymentDetails.Controls.Add(rbGcash)
        grpPaymentDetails.Controls.Add(rbCash)
        grpPaymentDetails.Controls.Add(lblPaymentMethod)
        grpPaymentDetails.Controls.Add(lblTotalAmount)
        grpPaymentDetails.Controls.Add(lblTotalLabel)
        grpPaymentDetails.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpPaymentDetails.Location = New Point(97, 509)
        grpPaymentDetails.Name = "grpPaymentDetails"
        grpPaymentDetails.Size = New Size(820, 230)
        grpPaymentDetails.TabIndex = 3
        grpPaymentDetails.TabStop = False
        grpPaymentDetails.Text = "Payment Details"
        ' 
        ' pnlDigitalPayment
        ' 
        pnlDigitalPayment.BackColor = Color.LightYellow
        pnlDigitalPayment.Controls.Add(lblDigitalAmount)
        pnlDigitalPayment.Controls.Add(lblDigitalAmountLabel)
        pnlDigitalPayment.Controls.Add(txtReference)
        pnlDigitalPayment.Controls.Add(lblReference)
        pnlDigitalPayment.Controls.Add(Label4)
        pnlDigitalPayment.Location = New Point(421, 112)
        pnlDigitalPayment.Name = "pnlDigitalPayment"
        pnlDigitalPayment.Size = New Size(383, 95)
        pnlDigitalPayment.TabIndex = 7
        pnlDigitalPayment.Visible = False
        ' 
        ' lblDigitalAmount
        ' 
        lblDigitalAmount.AutoSize = True
        lblDigitalAmount.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDigitalAmount.Location = New Point(135, 59)
        lblDigitalAmount.Name = "lblDigitalAmount"
        lblDigitalAmount.Size = New Size(61, 23)
        lblDigitalAmount.TabIndex = 4
        lblDigitalAmount.Text = "₱ 0.00"
        ' 
        ' lblDigitalAmountLabel
        ' 
        lblDigitalAmountLabel.AutoSize = True
        lblDigitalAmountLabel.Location = New Point(24, 61)
        lblDigitalAmountLabel.Name = "lblDigitalAmountLabel"
        lblDigitalAmountLabel.Size = New Size(105, 20)
        lblDigitalAmountLabel.TabIndex = 3
        lblDigitalAmountLabel.Text = "Amount Paid:"
        ' 
        ' txtReference
        ' 
        txtReference.BorderStyle = BorderStyle.None
        txtReference.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtReference.Location = New Point(140, 26)
        txtReference.Name = "txtReference"
        txtReference.Size = New Size(224, 20)
        txtReference.TabIndex = 2
        ' 
        ' lblReference
        ' 
        lblReference.AutoSize = True
        lblReference.Location = New Point(21, 27)
        lblReference.Name = "lblReference"
        lblReference.Size = New Size(115, 20)
        lblReference.TabIndex = 1
        lblReference.Text = "Referrence no.:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(4, 4)
        Label4.Name = "Label4"
        Label4.Size = New Size(182, 23)
        Label4.TabIndex = 0
        Label4.Text = "Gcash/Maya Payment"
        ' 
        ' pnlCashPayment
        ' 
        pnlCashPayment.BackColor = Color.LightYellow
        pnlCashPayment.Controls.Add(lblChange)
        pnlCashPayment.Controls.Add(lblChangeLabel)
        pnlCashPayment.Controls.Add(txtAmountPaid)
        pnlCashPayment.Controls.Add(lblAmountPaid)
        pnlCashPayment.Controls.Add(lblCashPayment)
        pnlCashPayment.Location = New Point(17, 112)
        pnlCashPayment.Name = "pnlCashPayment"
        pnlCashPayment.Size = New Size(383, 95)
        pnlCashPayment.TabIndex = 6
        ' 
        ' lblChange
        ' 
        lblChange.AutoSize = True
        lblChange.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblChange.Location = New Point(135, 59)
        lblChange.Name = "lblChange"
        lblChange.Size = New Size(61, 23)
        lblChange.TabIndex = 4
        lblChange.Text = "₱ 0.00"
        ' 
        ' lblChangeLabel
        ' 
        lblChangeLabel.AutoSize = True
        lblChangeLabel.Location = New Point(24, 61)
        lblChangeLabel.Name = "lblChangeLabel"
        lblChangeLabel.Size = New Size(65, 20)
        lblChangeLabel.TabIndex = 3
        lblChangeLabel.Text = "Change:"
        ' 
        ' txtAmountPaid
        ' 
        txtAmountPaid.BorderStyle = BorderStyle.None
        txtAmountPaid.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtAmountPaid.Location = New Point(135, 25)
        txtAmountPaid.Name = "txtAmountPaid"
        txtAmountPaid.Size = New Size(224, 20)
        txtAmountPaid.TabIndex = 2
        ' 
        ' lblAmountPaid
        ' 
        lblAmountPaid.AutoSize = True
        lblAmountPaid.Location = New Point(21, 27)
        lblAmountPaid.Name = "lblAmountPaid"
        lblAmountPaid.Size = New Size(105, 20)
        lblAmountPaid.TabIndex = 1
        lblAmountPaid.Text = "Amount Paid:"
        ' 
        ' lblCashPayment
        ' 
        lblCashPayment.AutoSize = True
        lblCashPayment.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCashPayment.Location = New Point(4, 4)
        lblCashPayment.Name = "lblCashPayment"
        lblCashPayment.Size = New Size(122, 23)
        lblCashPayment.TabIndex = 0
        lblCashPayment.Text = "Cash Payment"
        ' 
        ' rbMaya
        ' 
        rbMaya.AutoSize = True
        rbMaya.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbMaya.Location = New Point(361, 69)
        rbMaya.Name = "rbMaya"
        rbMaya.Size = New Size(74, 27)
        rbMaya.TabIndex = 5
        rbMaya.Text = "Maya"
        rbMaya.UseVisualStyleBackColor = True
        ' 
        ' rbGcash
        ' 
        rbGcash.AutoSize = True
        rbGcash.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbGcash.Location = New Point(264, 69)
        rbGcash.Name = "rbGcash"
        rbGcash.Size = New Size(80, 27)
        rbGcash.TabIndex = 4
        rbGcash.Text = "GCash"
        rbGcash.UseVisualStyleBackColor = True
        ' 
        ' rbCash
        ' 
        rbCash.AutoSize = True
        rbCash.Checked = True
        rbCash.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        rbCash.Location = New Point(176, 69)
        rbCash.Name = "rbCash"
        rbCash.Size = New Size(68, 27)
        rbCash.TabIndex = 3
        rbCash.TabStop = True
        rbCash.Text = "Cash"
        rbCash.UseVisualStyleBackColor = True
        ' 
        ' lblPaymentMethod
        ' 
        lblPaymentMethod.AutoSize = True
        lblPaymentMethod.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPaymentMethod.Location = New Point(17, 69)
        lblPaymentMethod.Name = "lblPaymentMethod"
        lblPaymentMethod.Size = New Size(153, 23)
        lblPaymentMethod.TabIndex = 2
        lblPaymentMethod.Text = "Payment Method:"
        ' 
        ' lblTotalAmount
        ' 
        lblTotalAmount.AutoSize = True
        lblTotalAmount.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalAmount.Location = New Point(152, 31)
        lblTotalAmount.Name = "lblTotalAmount"
        lblTotalAmount.Size = New Size(72, 28)
        lblTotalAmount.TabIndex = 1
        lblTotalAmount.Text = "₱ 0.00"
        ' 
        ' lblTotalLabel
        ' 
        lblTotalLabel.AutoSize = True
        lblTotalLabel.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalLabel.Location = New Point(17, 36)
        lblTotalLabel.Name = "lblTotalLabel"
        lblTotalLabel.Size = New Size(129, 23)
        lblTotalLabel.TabIndex = 0
        lblTotalLabel.Text = "Total Amount: "
        ' 
        ' btnConfirm
        ' 
        btnConfirm.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnConfirm.FlatStyle = FlatStyle.Popup
        btnConfirm.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfirm.ForeColor = Color.White
        btnConfirm.Location = New Point(35, 755)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(205, 37)
        btnConfirm.TabIndex = 4
        btnConfirm.Text = "CONFIRM"
        btnConfirm.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnCancel.FlatStyle = FlatStyle.Popup
        btnCancel.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(773, 755)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(205, 37)
        btnCancel.TabIndex = 5
        btnCancel.Text = "CANCEL"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' PaymentDialog
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        ClientSize = New Size(1024, 813)
        Controls.Add(btnCancel)
        Controls.Add(btnConfirm)
        Controls.Add(grpPaymentDetails)
        Controls.Add(RightPanel)
        Controls.Add(LeftPanel)
        Controls.Add(lblTitle)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "PaymentDialog"
        StartPosition = FormStartPosition.CenterScreen
        Text = "PaymentDialog"
        LeftPanel.ResumeLayout(False)
        grpOrderSummary.ResumeLayout(False)
        grpReceiptPreview.ResumeLayout(False)
        RightPanel.ResumeLayout(False)
        grpPaymentDetails.ResumeLayout(False)
        grpPaymentDetails.PerformLayout()
        pnlDigitalPayment.ResumeLayout(False)
        pnlDigitalPayment.PerformLayout()
        pnlCashPayment.ResumeLayout(False)
        pnlCashPayment.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents LeftPanel As Panel
    Friend WithEvents grpOrderSummary As GroupBox
    Friend WithEvents rtbOrderSummary As RichTextBox
    Friend WithEvents grpReceiptPreview As GroupBox
    Friend WithEvents rtbReceiptPreview As RichTextBox
    Friend WithEvents RightPanel As Panel
    Friend WithEvents grpPaymentDetails As GroupBox
    Friend WithEvents lblTotalLabel As Label
    Friend WithEvents rbCash As RadioButton
    Friend WithEvents lblPaymentMethod As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents pnlCashPayment As Panel
    Friend WithEvents rbMaya As RadioButton
    Friend WithEvents rbGcash As RadioButton
    Friend WithEvents lblChangeLabel As Label
    Friend WithEvents txtAmountPaid As TextBox
    Friend WithEvents lblAmountPaid As Label
    Friend WithEvents lblCashPayment As Label
    Friend WithEvents pnlDigitalPayment As Panel
    Friend WithEvents lblDigitalAmount As Label
    Friend WithEvents lblDigitalAmountLabel As Label
    Friend WithEvents txtReference As TextBox
    Friend WithEvents lblReference As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCancel As Button
End Class
