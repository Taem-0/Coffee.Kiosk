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
            materialListView1 = new MaterialSkin.Controls.MaterialListView();
            addEmpButton = new Button();
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
            AdminFormHamburger.Location = new Point(3, 64);
            AdminFormHamburger.MouseState = MaterialSkin.MouseState.HOVER;
            AdminFormHamburger.Multiline = true;
            AdminFormHamburger.Name = "AdminFormHamburger";
            AdminFormHamburger.SelectedIndex = 0;
            AdminFormHamburger.Size = new Size(894, 533);
            AdminFormHamburger.TabIndex = 0;
            // 
            // DashBoard
            // 
            DashBoard.ImageKey = "Icon_Admin.png";
            DashBoard.Location = new Point(4, 41);
            DashBoard.Name = "DashBoard";
            DashBoard.Padding = new Padding(3);
            DashBoard.Size = new Size(886, 488);
            DashBoard.TabIndex = 0;
            DashBoard.Text = "Admin";
            DashBoard.UseVisualStyleBackColor = true;
            // 
            // tabAccounts
            // 
            tabAccounts.Controls.Add(materialListView1);
            tabAccounts.Controls.Add(addEmpButton);
            tabAccounts.ImageKey = "user-management-svgrepo-com.png";
            tabAccounts.Location = new Point(4, 41);
            tabAccounts.Name = "tabAccounts";
            tabAccounts.Padding = new Padding(3);
            tabAccounts.Size = new Size(886, 488);
            tabAccounts.TabIndex = 1;
            tabAccounts.Text = "Accounts";
            tabAccounts.UseVisualStyleBackColor = true;
            // 
            // materialListView1
            // 
            materialListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialListView1.AutoSizeTable = false;
            materialListView1.BackColor = Color.FromArgb(255, 255, 255);
            materialListView1.BorderStyle = BorderStyle.None;
            materialListView1.Depth = 0;
            materialListView1.FullRowSelect = true;
            materialListView1.Location = new Point(6, 55);
            materialListView1.MinimumSize = new Size(200, 100);
            materialListView1.MouseLocation = new Point(-1, -1);
            materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            materialListView1.Name = "materialListView1";
            materialListView1.OwnerDraw = true;
            materialListView1.Size = new Size(872, 427);
            materialListView1.TabIndex = 1;
            materialListView1.UseCompatibleStateImageBehavior = false;
            materialListView1.View = View.Details;
            materialListView1.SelectedIndexChanged += materialListView1_SelectedIndexChanged;
            // 
            // addEmpButton
            // 
            addEmpButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addEmpButton.Location = new Point(720, 14);
            addEmpButton.Name = "addEmpButton";
            addEmpButton.Size = new Size(158, 35);
            addEmpButton.TabIndex = 0;
            addEmpButton.Text = "+ Add Employee";
            addEmpButton.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 41);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(886, 488);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "MockUp";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 41);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(886, 488);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "MockUp";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 41);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(886, 488);
            tabPage4.TabIndex = 4;
            tabPage4.Text = "MockUp";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 41);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(886, 488);
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
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(AdminFormHamburger);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = AdminFormHamburger;
            Name = "AdminControlForm";
            Text = "Form1";
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
        private Button addEmpButton;
        private MaterialSkin.Controls.MaterialListView materialListView1;
    }
}
