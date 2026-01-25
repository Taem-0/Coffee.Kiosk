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
        btnHistory = New Button()
        btnMenu = New Button()
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
        Panel1.Controls.Add(btnHistory)
        Panel1.Controls.Add(btnMenu)
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
        btnSettings.Location = New Point(81, 473)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(87, 80)
        btnSettings.TabIndex = 4
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnHistory
        ' 
        btnHistory.BackColor = Color.Transparent
        btnHistory.BackgroundImage = CType(resources.GetObject("btnHistory.BackgroundImage"), Image)
        btnHistory.BackgroundImageLayout = ImageLayout.Zoom
        btnHistory.FlatStyle = FlatStyle.Flat
        btnHistory.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnHistory.Location = New Point(80, 356)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(87, 80)
        btnHistory.TabIndex = 3
        btnHistory.UseVisualStyleBackColor = False
        ' 
        ' btnMenu
        ' 
        btnMenu.BackColor = Color.Transparent
        btnMenu.BackgroundImage = CType(resources.GetObject("btnMenu.BackgroundImage"), Image)
        btnMenu.BackgroundImageLayout = ImageLayout.Zoom
        btnMenu.FlatStyle = FlatStyle.Flat
        btnMenu.ForeColor = Color.FromArgb(CByte(111), CByte(77), CByte(56))
        btnMenu.Location = New Point(81, 244)
        btnMenu.Name = "btnMenu"
        btnMenu.Size = New Size(87, 80)
        btnMenu.TabIndex = 2
        btnMenu.UseVisualStyleBackColor = False
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
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnHistory As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents HomeScreenPanel As Panel
End Class
