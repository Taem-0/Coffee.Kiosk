using Coffee.Kiosk.CMS.Controllers;

namespace Coffee.Kiosk
{
    partial class AdminControlForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminControlForm));
            AdminFormHamburger = new MaterialSkin.Controls.MaterialTabControl();
            DashBoard = new TabPage();
            AdminContentPanel = new Panel();
            tabAccounts = new TabPage();
            AccountsContentPanel = new Panel();
            Kiosk = new TabPage();
            orderingSystem1 = new Coffee.Kiosk.CMS.Forms.OrderingSystemTab.OrderingSystemMainControl();
            Settings = new TabPage();
            settingsContentPanel = new Panel();
            AdminHamburgerIcons = new ImageList(components);
            AdminFormHamburger.SuspendLayout();
            DashBoard.SuspendLayout();
            tabAccounts.SuspendLayout();
            Kiosk.SuspendLayout();
            Settings.SuspendLayout();
            SuspendLayout();
            // 
            // AdminFormHamburger
            // 
            AdminFormHamburger.Controls.Add(DashBoard);
            AdminFormHamburger.Controls.Add(tabAccounts);
            AdminFormHamburger.Controls.Add(Kiosk);
            AdminFormHamburger.Controls.Add(Settings);
            AdminFormHamburger.Depth = 0;
            AdminFormHamburger.Dock = DockStyle.Fill;
            AdminFormHamburger.ImageList = AdminHamburgerIcons;
            AdminFormHamburger.Location = new Point(2, 64);
            AdminFormHamburger.Margin = new Padding(2);
            AdminFormHamburger.MouseState = MaterialSkin.MouseState.HOVER;
            AdminFormHamburger.Multiline = true;
            AdminFormHamburger.Name = "AdminFormHamburger";
            AdminFormHamburger.SelectedIndex = 0;
            AdminFormHamburger.Size = new Size(896, 534);
            AdminFormHamburger.TabIndex = 0;
            // 
            // DashBoard
            // 
            DashBoard.Controls.Add(AdminContentPanel);
            DashBoard.ImageKey = "Icon_Admin.png";
            DashBoard.Location = new Point(4, 41);
            DashBoard.Margin = new Padding(2);
            DashBoard.Name = "DashBoard";
            DashBoard.Padding = new Padding(2);
            DashBoard.Size = new Size(888, 489);
            DashBoard.TabIndex = 0;
            DashBoard.Text = "Admin";
            DashBoard.UseVisualStyleBackColor = true;
            // 
            // AdminContentPanel
            // 
            AdminContentPanel.Dock = DockStyle.Fill;
            AdminContentPanel.Location = new Point(2, 2);
            AdminContentPanel.Name = "AdminContentPanel";
            AdminContentPanel.Size = new Size(884, 485);
            AdminContentPanel.TabIndex = 0;
            // 
            // tabAccounts
            // 
            tabAccounts.Controls.Add(AccountsContentPanel);
            tabAccounts.ImageKey = "user-management-svgrepo-com.png";
            tabAccounts.Location = new Point(4, 41);
            tabAccounts.Margin = new Padding(2);
            tabAccounts.Name = "tabAccounts";
            tabAccounts.Padding = new Padding(2);
            tabAccounts.Size = new Size(888, 489);
            tabAccounts.TabIndex = 1;
            tabAccounts.Text = "Accounts";
            tabAccounts.UseVisualStyleBackColor = true;
            // 
            // AccountsContentPanel
            // 
            AccountsContentPanel.Dock = DockStyle.Fill;
            AccountsContentPanel.Location = new Point(2, 2);
            AccountsContentPanel.Margin = new Padding(2);
            AccountsContentPanel.Name = "AccountsContentPanel";
            AccountsContentPanel.Size = new Size(884, 485);
            AccountsContentPanel.TabIndex = 1;
            // 
            // Kiosk
            // 
            Kiosk.Controls.Add(orderingSystem1);
            Kiosk.ImageKey = "CART (1)(1).png";
            Kiosk.Location = new Point(4, 41);
            Kiosk.Margin = new Padding(2);
            Kiosk.Name = "Kiosk";
            Kiosk.Size = new Size(888, 489);
            Kiosk.TabIndex = 2;
            Kiosk.Text = "Kiosk";
            Kiosk.UseVisualStyleBackColor = true;
            // 
            // orderingSystem1
            // 
            orderingSystem1.Dock = DockStyle.Fill;
            orderingSystem1.Location = new Point(0, 0);
            orderingSystem1.Margin = new Padding(5);
            orderingSystem1.Name = "orderingSystem1";
            orderingSystem1.Size = new Size(888, 489);
            orderingSystem1.TabIndex = 0;
            // 
            // Settings
            // 
            Settings.Controls.Add(settingsContentPanel);
            Settings.ImageKey = "settings-5670.png";
            Settings.Location = new Point(4, 41);
            Settings.Margin = new Padding(2);
            Settings.Name = "Settings";
            Settings.Size = new Size(888, 489);
            Settings.TabIndex = 3;
            Settings.Text = "Settings";
            Settings.UseVisualStyleBackColor = true;
            // 
            // settingsContentPanel
            // 
            settingsContentPanel.Dock = DockStyle.Fill;
            settingsContentPanel.Location = new Point(0, 0);
            settingsContentPanel.Margin = new Padding(2);
            settingsContentPanel.Name = "settingsContentPanel";
            settingsContentPanel.Size = new Size(888, 489);
            settingsContentPanel.TabIndex = 2;
            // 
            // AdminHamburgerIcons
            // 
            AdminHamburgerIcons.ColorDepth = ColorDepth.Depth32Bit;
            AdminHamburgerIcons.ImageStream = (ImageListStreamer)resources.GetObject("AdminHamburgerIcons.ImageStream");
            AdminHamburgerIcons.TransparentColor = Color.Transparent;
            AdminHamburgerIcons.Images.SetKeyName(0, "Icon_Admin.png");
            AdminHamburgerIcons.Images.SetKeyName(1, "user-management-svgrepo-com.png");
            AdminHamburgerIcons.Images.SetKeyName(2, "CART (1)(1).png");
            AdminHamburgerIcons.Images.SetKeyName(3, "settings-5670.png");
            // 
            // AdminControlForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(AdminFormHamburger);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = AdminFormHamburger;
            Margin = new Padding(2);
            Name = "AdminControlForm";
            Padding = new Padding(2, 64, 2, 2);
            Text = "CMS";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            AdminFormHamburger.ResumeLayout(false);
            DashBoard.ResumeLayout(false);
            tabAccounts.ResumeLayout(false);
            Kiosk.ResumeLayout(false);
            Settings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl AdminFormHamburger;
        private TabPage DashBoard;
        private TabPage tabAccounts;
        private ImageList AdminHamburgerIcons;
        private TabPage Kiosk;
        private TabPage Settings;
        private CMS.Forms.OrderingSystemTab.OrderingSystemMainControl orderingSystem1;
        private Panel AdminContentPanel;
        private Panel AccountsContentPanel;
        private CMS.Forms.AccountsTab.NewEmployeeView newEmployeeView1;
        private Panel settingsContentPanel;
    }
}
