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
            tabPage2 = new TabPage();
            AdminHamburgerIcons = new ImageList(components);
            tabPage1 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            AdminFormHamburger.SuspendLayout();
            SuspendLayout();
            // 
            // AdminFormHamburger
            // 
            AdminFormHamburger.Controls.Add(DashBoard);
            AdminFormHamburger.Controls.Add(tabPage2);
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
            DashBoard.Location = new Point(4, 39);
            DashBoard.Name = "DashBoard";
            DashBoard.Padding = new Padding(3);
            DashBoard.Size = new Size(886, 490);
            DashBoard.TabIndex = 0;
            DashBoard.Text = "Admin";
            DashBoard.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(886, 490);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "MockUp";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // AdminHamburgerIcons
            // 
            AdminHamburgerIcons.ColorDepth = ColorDepth.Depth32Bit;
            AdminHamburgerIcons.ImageStream = (ImageListStreamer)resources.GetObject("AdminHamburgerIcons.ImageStream");
            AdminHamburgerIcons.TransparentColor = Color.Transparent;
            AdminHamburgerIcons.Images.SetKeyName(0, "Icon_Admin.png");
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(886, 490);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "MockUp";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 39);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(886, 490);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "MockUp";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 39);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(886, 490);
            tabPage4.TabIndex = 4;
            tabPage4.Text = "MockUp";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 39);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(886, 490);
            tabPage5.TabIndex = 5;
            tabPage5.Text = "MockUp";
            tabPage5.UseVisualStyleBackColor = true;
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
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl AdminFormHamburger;
        private TabPage DashBoard;
        private TabPage tabPage2;
        private ImageList AdminHamburgerIcons;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
    }
}
