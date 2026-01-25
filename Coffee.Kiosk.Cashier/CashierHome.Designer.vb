<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashierHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CashierHome))
        Panel1 = New Panel()
        btnSettings = New Button()
        btnCustomers = New Button()
        btnHisory = New Button()
        btnMenu = New Button()
        btnHome = New Button()
        btnSignOut = New Button()
        LogoBox = New PictureBox()
        HomeScreenPanel = New Panel()
        Panel1.SuspendLayout()
        CType(LogoBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        Panel1.Controls.Add(btnSettings)
        Panel1.Controls.Add(btnCustomers)
        Panel1.Controls.Add(btnHisory)
        Panel1.Controls.Add(btnMenu)
        Panel1.Controls.Add(btnHome)
        Panel1.Controls.Add(btnSignOut)
        Panel1.Controls.Add(LogoBox)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(250, 1082)
        Panel1.TabIndex = 0
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.Transparent
        btnSettings.BackgroundImage = CType(resources.GetObject("btnSettings.BackgroundImage"), Image)
        btnSettings.BackgroundImageLayout = ImageLayout.Zoom
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSettings.Location = New Point(81, 649)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(87, 80)
        btnSettings.TabIndex = 4
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnCustomers
        ' 
        btnCustomers.BackColor = Color.Transparent
        btnCustomers.BackgroundImage = CType(resources.GetObject("btnCustomers.BackgroundImage"), Image)
        btnCustomers.BackgroundImageLayout = ImageLayout.Zoom
        btnCustomers.FlatStyle = FlatStyle.Flat
        btnCustomers.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnCustomers.Location = New Point(81, 543)
        btnCustomers.Name = "btnCustomers"
        btnCustomers.Size = New Size(87, 80)
        btnCustomers.TabIndex = 2
        btnCustomers.UseVisualStyleBackColor = False
        ' 
        ' btnHisory
        ' 
        btnHisory.BackColor = Color.Transparent
        btnHisory.BackgroundImage = CType(resources.GetObject("btnHisory.BackgroundImage"), Image)
        btnHisory.BackgroundImageLayout = ImageLayout.Zoom
        btnHisory.FlatStyle = FlatStyle.Flat
        btnHisory.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnHisory.Location = New Point(81, 444)
        btnHisory.Name = "btnHisory"
        btnHisory.Size = New Size(87, 80)
        btnHisory.TabIndex = 3
        btnHisory.UseVisualStyleBackColor = False
        ' 
        ' btnMenu
        ' 
        btnMenu.BackColor = Color.Transparent
        btnMenu.BackgroundImage = CType(resources.GetObject("btnMenu.BackgroundImage"), Image)
        btnMenu.BackgroundImageLayout = ImageLayout.Zoom
        btnMenu.FlatStyle = FlatStyle.Flat
        btnMenu.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnMenu.Location = New Point(81, 347)
        btnMenu.Name = "btnMenu"
        btnMenu.Size = New Size(87, 80)
        btnMenu.TabIndex = 2
        btnMenu.UseVisualStyleBackColor = False
        ' 
        ' btnHome
        ' 
        btnHome.BackColor = Color.Transparent
        btnHome.BackgroundImage = CType(resources.GetObject("btnHome.BackgroundImage"), Image)
        btnHome.BackgroundImageLayout = ImageLayout.Zoom
        btnHome.FlatStyle = FlatStyle.Flat
        btnHome.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnHome.Location = New Point(81, 258)
        btnHome.Name = "btnHome"
        btnHome.Size = New Size(87, 80)
        btnHome.TabIndex = 1
        btnHome.UseVisualStyleBackColor = False
        ' 
        ' btnSignOut
        ' 
        btnSignOut.BackColor = Color.Transparent
        btnSignOut.BackgroundImage = CType(resources.GetObject("btnSignOut.BackgroundImage"), Image)
        btnSignOut.BackgroundImageLayout = ImageLayout.Zoom
        btnSignOut.FlatStyle = FlatStyle.Flat
        btnSignOut.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSignOut.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnSignOut.Location = New Point(0, 1021)
        btnSignOut.Name = "btnSignOut"
        btnSignOut.Size = New Size(250, 49)
        btnSignOut.TabIndex = 1
        btnSignOut.UseVisualStyleBackColor = False
        ' 
        ' LogoBox
        ' 
        LogoBox.BackgroundImage = CType(resources.GetObject("LogoBox.BackgroundImage"), Image)
        LogoBox.BackgroundImageLayout = ImageLayout.Stretch
        LogoBox.Location = New Point(38, 39)
        LogoBox.Name = "LogoBox"
        LogoBox.Size = New Size(174, 171)
        LogoBox.TabIndex = 1
        LogoBox.TabStop = False
        ' 
        ' HomeScreenPanel
        ' 
        HomeScreenPanel.Location = New Point(250, 0)
        HomeScreenPanel.Name = "HomeScreenPanel"
        HomeScreenPanel.Size = New Size(1669, 1082)
        HomeScreenPanel.TabIndex = 1
        ' 
        ' CashierHome
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Beige
        ClientSize = New Size(1920, 1080)
        ControlBox = False
        Controls.Add(HomeScreenPanel)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "CashierHome"
        StartPosition = FormStartPosition.CenterScreen
        Panel1.ResumeLayout(False)
        CType(LogoBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents LogoBox As PictureBox
    Friend WithEvents btnSignOut As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnCustomers As Button
    Friend WithEvents btnHisory As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents HomeScreenPanel As Panel
End Class
