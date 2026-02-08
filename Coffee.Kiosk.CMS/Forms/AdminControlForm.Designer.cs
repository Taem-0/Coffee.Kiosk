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
            Customizations = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            AdminHamburgerIcons = new ImageList(components);
            AdminFormHamburger.SuspendLayout();
            DashBoard.SuspendLayout();
            tabAccounts.SuspendLayout();
            Kiosk.SuspendLayout();
            SuspendLayout();
            // 
            // AdminFormHamburger
            // 
            AdminFormHamburger.Controls.Add(DashBoard);
            AdminFormHamburger.Controls.Add(tabAccounts);
            AdminFormHamburger.Controls.Add(Kiosk);
            AdminFormHamburger.Controls.Add(Customizations);
            AdminFormHamburger.Controls.Add(tabPage4);
            AdminFormHamburger.Controls.Add(tabPage5);
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
            // Customizations
            // 
            Customizations.Location = new Point(4, 41);
            Customizations.Margin = new Padding(2);
            Customizations.Name = "Customizations";
            Customizations.Size = new Size(888, 489);
            Customizations.TabIndex = 3;
            Customizations.Text = "Customizations";
            Customizations.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 41);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(888, 489);
            tabPage4.TabIndex = 4;
            tabPage4.Text = "MockUp";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 41);
            tabPage5.Margin = new Padding(2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(888, 489);
            tabPage5.TabIndex = 5;
            tabPage5.Text = "MockUp";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // AdminHamburgerIcons
            // 
            AdminHamburgerIcons.ColorDepth = ColorDepth.Depth32Bit;
            AdminHamburgerIcons.ImageStream = (ImageListStreamer)resources.GetObject("AdminHamburgerIcons.ImageStream");
            AdminHamburgerIcons.TransparentColor = Color.Transparent;
            AdminHamburgerIcons.Images.SetKeyName(0, "Icon_Admin.png");
            AdminHamburgerIcons.Images.SetKeyName(1, "user-management-svgrepo-com.png");
            AdminHamburgerIcons.Images.SetKeyName(2, "CART (1)(1).png");
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
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl AdminFormHamburger;
        private TabPage DashBoard;
        private TabPage tabAccounts;
        private ImageList AdminHamburgerIcons;
        private TabPage Kiosk;
        private TabPage Customizations;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private CMS.Forms.OrderingSystemTab.OrderingSystemMainControl orderingSystem1;
        private Panel AdminContentPanel;
        private Panel AccountsContentPanel;
        private CMS.Forms.AccountsTab.NewEmployeeView newEmployeeView1;
    }
}
