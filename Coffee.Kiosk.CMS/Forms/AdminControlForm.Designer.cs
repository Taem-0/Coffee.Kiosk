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
            tabAccounts = new TabPage();
            AccountsContentPanel = new Panel();
            tabPage1 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            AdminHamburgerIcons = new ImageList(components);
            AdminFormHamburger.SuspendLayout();
            tabAccounts.SuspendLayout();
            SuspendLayout();
            // 
            // AdminFormHamburger
            // 
            AdminFormHamburger.Controls.Add(DashBoard);
            AdminFormHamburger.Controls.Add(tabAccounts);
            AdminFormHamburger.Controls.Add(tabPage1);
            AdminFormHamburger.Controls.Add(tabPage3);
            AdminFormHamburger.Controls.Add(tabPage4);
            AdminFormHamburger.Controls.Add(tabPage5);
            AdminFormHamburger.Depth = 0;
            AdminFormHamburger.Dock = DockStyle.Fill;
            AdminFormHamburger.ImageList = AdminHamburgerIcons;
            AdminFormHamburger.Location = new Point(2, 51);
            AdminFormHamburger.Margin = new Padding(2, 2, 2, 2);
            AdminFormHamburger.MouseState = MaterialSkin.MouseState.HOVER;
            AdminFormHamburger.Multiline = true;
            AdminFormHamburger.Name = "AdminFormHamburger";
            AdminFormHamburger.SelectedIndex = 0;
            AdminFormHamburger.Size = new Size(716, 427);
            AdminFormHamburger.TabIndex = 0;
            // 
            // DashBoard
            // 
            DashBoard.ImageKey = "Icon_Admin.png";
            DashBoard.Location = new Point(4, 41);
            DashBoard.Margin = new Padding(2, 2, 2, 2);
            DashBoard.Name = "DashBoard";
            DashBoard.Padding = new Padding(2, 2, 2, 2);
            DashBoard.Size = new Size(708, 382);
            DashBoard.TabIndex = 0;
            DashBoard.Text = "Admin";
            DashBoard.UseVisualStyleBackColor = true;
            // 
            // tabAccounts
            // 
            tabAccounts.Controls.Add(AccountsContentPanel);
            tabAccounts.ImageKey = "user-management-svgrepo-com.png";
            tabAccounts.Location = new Point(4, 41);
            tabAccounts.Margin = new Padding(2, 2, 2, 2);
            tabAccounts.Name = "tabAccounts";
            tabAccounts.Padding = new Padding(2, 2, 2, 2);
            tabAccounts.Size = new Size(708, 382);
            tabAccounts.TabIndex = 1;
            tabAccounts.Text = "Accounts";
            tabAccounts.UseVisualStyleBackColor = true;
            // 
            // AccountsContentPanel
            // 
            AccountsContentPanel.Dock = DockStyle.Fill;
            AccountsContentPanel.Location = new Point(2, 2);
            AccountsContentPanel.Margin = new Padding(2, 2, 2, 2);
            AccountsContentPanel.Name = "AccountsContentPanel";
            AccountsContentPanel.Size = new Size(704, 378);
            AccountsContentPanel.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 41);
            tabPage1.Margin = new Padding(2, 2, 2, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(708, 382);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "MockUp";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 41);
            tabPage3.Margin = new Padding(2, 2, 2, 2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(707, 381);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "MockUp";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 41);
            tabPage4.Margin = new Padding(2, 2, 2, 2);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(707, 381);
            tabPage4.TabIndex = 4;
            tabPage4.Text = "MockUp";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 41);
            tabPage5.Margin = new Padding(2, 2, 2, 2);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(707, 381);
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
            // 
            // AdminControlForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 480);
            Controls.Add(AdminFormHamburger);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = AdminFormHamburger;
            Margin = new Padding(2, 2, 2, 2);
            Name = "AdminControlForm";
            Padding = new Padding(2, 51, 2, 2);
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            AdminFormHamburger.ResumeLayout(false);
            tabAccounts.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl AdminFormHamburger;
        private TabPage DashBoard;
        private TabPage tabAccounts;
        private ImageList AdminHamburgerIcons;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Panel AccountsContentPanel;
    }
}
