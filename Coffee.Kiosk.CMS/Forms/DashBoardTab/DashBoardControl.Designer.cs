using Coffee.Kiosk.CMS.Helpers;

namespace Coffee.Kiosk.CMS.Forms.DashBoardTab
{
    partial class DashBoardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                UIhelp.ThemeManager.ThemeChanged -= OnThemeChanged;
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoardControl));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            label5 = new Label();
            totalQTYNum = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            transactionsNum = new Label();
            label2 = new Label();
            guna2ContainerControl4 = new Guna.UI2.WinForms.Guna2ContainerControl();
            guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            label8 = new Label();
            totalProfitNum = new Label();
            guna2ContainerControl3 = new Guna.UI2.WinForms.Guna2ContainerControl();
            guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            label6 = new Label();
            totalRevenueNum = new Label();
            ordersOverTime1 = new Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls.OrdersOverTime();
            label10 = new Label();
            label11 = new Label();
            salesOverTime1 = new Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls.SalesOverTime();
            dineInvsTakeout1 = new Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls.DineInvsTakeout();
            topSellingProducts1 = new Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls.TopSellingProducts();
            peakHours1 = new Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls.PeakHours();
            TimeLineDropDown = new Guna.UI2.WinForms.Guna2ComboBox();
            TimeLineLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            guna2ContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            guna2ContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox4).BeginInit();
            guna2ContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(14, 13);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 41);
            label1.TabIndex = 1;
            label1.Text = "Dashboard\r\n";
            label1.Click += label1_Click;
            // 
            // guna2ContainerControl1
            // 
            guna2ContainerControl1.BackColor = SystemColors.Control;
            guna2ContainerControl1.BorderRadius = 25;
            guna2ContainerControl1.Controls.Add(guna2PictureBox2);
            guna2ContainerControl1.Controls.Add(label5);
            guna2ContainerControl1.Controls.Add(totalQTYNum);
            guna2ContainerControl1.CustomizableEdges = customizableEdges3;
            guna2ContainerControl1.Dock = DockStyle.Fill;
            guna2ContainerControl1.Location = new Point(479, 2);
            guna2ContainerControl1.Margin = new Padding(2);
            guna2ContainerControl1.Name = "guna2ContainerControl1";
            guna2ContainerControl1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ContainerControl1.Size = new Size(436, 166);
            guna2ContainerControl1.TabIndex = 5;
            guna2ContainerControl1.Text = "DataContainer01";
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.BackColor = Color.Transparent;
            guna2PictureBox2.CustomizableEdges = customizableEdges1;
            guna2PictureBox2.Image = (Image)resources.GetObject("guna2PictureBox2.Image");
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.Location = new Point(24, 34);
            guna2PictureBox2.Margin = new Padding(2);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox2.Size = new Size(96, 96);
            guna2PictureBox2.TabIndex = 5;
            guna2PictureBox2.TabStop = false;
            guna2PictureBox2.UseTransparentBackground = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(125, 19);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(180, 30);
            label5.TabIndex = 3;
            label5.Text = "TOTAL QTY SOLD";
            // 
            // totalQTYNum
            // 
            totalQTYNum.AutoSize = true;
            totalQTYNum.BackColor = Color.White;
            totalQTYNum.Font = new Font("Segoe UI", 20F);
            totalQTYNum.Location = new Point(125, 78);
            totalQTYNum.Margin = new Padding(2, 0, 2, 0);
            totalQTYNum.Name = "totalQTYNum";
            totalQTYNum.Size = new Size(38, 46);
            totalQTYNum.TabIndex = 4;
            totalQTYNum.Text = "0";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel3.ColumnCount = 7;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.5F));
            tableLayoutPanel3.Controls.Add(guna2ContainerControl2, 0, 0);
            tableLayoutPanel3.Controls.Add(guna2ContainerControl4, 6, 0);
            tableLayoutPanel3.Controls.Add(guna2ContainerControl3, 4, 0);
            tableLayoutPanel3.Controls.Add(guna2ContainerControl1, 2, 0);
            tableLayoutPanel3.Location = new Point(14, 91);
            tableLayoutPanel3.Margin = new Padding(2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1873, 170);
            tableLayoutPanel3.TabIndex = 11;
            tableLayoutPanel3.Paint += tableLayoutPanel3_Paint_1;
            // 
            // guna2ContainerControl2
            // 
            guna2ContainerControl2.BackColor = SystemColors.Control;
            guna2ContainerControl2.BorderRadius = 25;
            guna2ContainerControl2.Controls.Add(guna2PictureBox1);
            guna2ContainerControl2.Controls.Add(transactionsNum);
            guna2ContainerControl2.Controls.Add(label2);
            guna2ContainerControl2.CustomizableEdges = customizableEdges7;
            guna2ContainerControl2.Dock = DockStyle.Fill;
            guna2ContainerControl2.Location = new Point(2, 2);
            guna2ContainerControl2.Margin = new Padding(2);
            guna2ContainerControl2.Name = "guna2ContainerControl2";
            guna2ContainerControl2.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2ContainerControl2.Size = new Size(436, 166);
            guna2ContainerControl2.TabIndex = 6;
            guna2ContainerControl2.Text = "DataContainer01";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.CustomizableEdges = customizableEdges5;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(20, 34);
            guna2PictureBox1.Margin = new Padding(2);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.Size = new Size(96, 96);
            guna2PictureBox1.TabIndex = 2;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.UseTransparentBackground = true;
            // 
            // transactionsNum
            // 
            transactionsNum.AutoSize = true;
            transactionsNum.BackColor = Color.White;
            transactionsNum.Font = new Font("Segoe UI", 20F);
            transactionsNum.Location = new Point(124, 78);
            transactionsNum.Margin = new Padding(2, 0, 2, 0);
            transactionsNum.Name = "transactionsNum";
            transactionsNum.Size = new Size(38, 46);
            transactionsNum.TabIndex = 1;
            transactionsNum.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(121, 19);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 0;
            label2.Text = "TRANSACTIONS";
            // 
            // guna2ContainerControl4
            // 
            guna2ContainerControl4.BackColor = SystemColors.Control;
            guna2ContainerControl4.BorderRadius = 25;
            guna2ContainerControl4.Controls.Add(guna2PictureBox4);
            guna2ContainerControl4.Controls.Add(label8);
            guna2ContainerControl4.Controls.Add(totalProfitNum);
            guna2ContainerControl4.CustomizableEdges = customizableEdges11;
            guna2ContainerControl4.Dock = DockStyle.Fill;
            guna2ContainerControl4.Location = new Point(1433, 2);
            guna2ContainerControl4.Margin = new Padding(2);
            guna2ContainerControl4.Name = "guna2ContainerControl4";
            guna2ContainerControl4.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2ContainerControl4.Size = new Size(438, 166);
            guna2ContainerControl4.TabIndex = 8;
            guna2ContainerControl4.Text = "DataContainer01";
            guna2ContainerControl4.Click += guna2ContainerControl4_Click;
            // 
            // guna2PictureBox4
            // 
            guna2PictureBox4.BackColor = Color.Transparent;
            guna2PictureBox4.CustomizableEdges = customizableEdges9;
            guna2PictureBox4.Image = (Image)resources.GetObject("guna2PictureBox4.Image");
            guna2PictureBox4.ImageRotate = 0F;
            guna2PictureBox4.Location = new Point(28, 34);
            guna2PictureBox4.Margin = new Padding(2);
            guna2PictureBox4.Name = "guna2PictureBox4";
            guna2PictureBox4.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2PictureBox4.Size = new Size(96, 96);
            guna2PictureBox4.TabIndex = 11;
            guna2PictureBox4.TabStop = false;
            guna2PictureBox4.UseTransparentBackground = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI", 13F);
            label8.Location = new Point(129, 19);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(151, 30);
            label8.TabIndex = 9;
            label8.Text = "TOTAL PROFIT";
            // 
            // totalProfitNum
            // 
            totalProfitNum.AutoSize = true;
            totalProfitNum.BackColor = Color.White;
            totalProfitNum.Font = new Font("Segoe UI", 20F);
            totalProfitNum.Location = new Point(129, 78);
            totalProfitNum.Margin = new Padding(2, 0, 2, 0);
            totalProfitNum.Name = "totalProfitNum";
            totalProfitNum.Size = new Size(38, 46);
            totalProfitNum.TabIndex = 10;
            totalProfitNum.Text = "0";
            // 
            // guna2ContainerControl3
            // 
            guna2ContainerControl3.BackColor = SystemColors.Control;
            guna2ContainerControl3.BorderRadius = 25;
            guna2ContainerControl3.Controls.Add(guna2PictureBox3);
            guna2ContainerControl3.Controls.Add(label6);
            guna2ContainerControl3.Controls.Add(totalRevenueNum);
            guna2ContainerControl3.CustomizableEdges = customizableEdges15;
            guna2ContainerControl3.Dock = DockStyle.Fill;
            guna2ContainerControl3.Location = new Point(956, 2);
            guna2ContainerControl3.Margin = new Padding(2);
            guna2ContainerControl3.Name = "guna2ContainerControl3";
            guna2ContainerControl3.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2ContainerControl3.Size = new Size(436, 166);
            guna2ContainerControl3.TabIndex = 7;
            guna2ContainerControl3.Text = "DataContainer01";
            // 
            // guna2PictureBox3
            // 
            guna2PictureBox3.CustomizableEdges = customizableEdges13;
            guna2PictureBox3.ImageRotate = 0F;
            guna2PictureBox3.Location = new Point(29, 34);
            guna2PictureBox3.Margin = new Padding(2);
            guna2PictureBox3.Name = "guna2PictureBox3";
            guna2PictureBox3.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2PictureBox3.Size = new Size(96, 96);
            guna2PictureBox3.TabIndex = 8;
            guna2PictureBox3.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 13F);
            label6.Location = new Point(130, 19);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(171, 30);
            label6.TabIndex = 6;
            label6.Text = "TOTAL REVENUE";
            // 
            // totalRevenueNum
            // 
            totalRevenueNum.AutoSize = true;
            totalRevenueNum.BackColor = Color.White;
            totalRevenueNum.Font = new Font("Segoe UI", 20F);
            totalRevenueNum.Location = new Point(130, 78);
            totalRevenueNum.Margin = new Padding(2, 0, 2, 0);
            totalRevenueNum.Name = "totalRevenueNum";
            totalRevenueNum.Size = new Size(38, 46);
            totalRevenueNum.TabIndex = 7;
            totalRevenueNum.Text = "0";
            // 
            // ordersOverTime1
            // 
            ordersOverTime1.Location = new Point(36, 696);
            ordersOverTime1.Margin = new Padding(2, 2, 2, 2);
            ordersOverTime1.Name = "ordersOverTime1";
            ordersOverTime1.Size = new Size(755, 315);
            ordersOverTime1.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label10.Location = new Point(36, 295);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(339, 35);
            label10.TabIndex = 14;
            label10.Text = "Key Performance Indicators";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label11.Location = new Point(999, 295);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(166, 35);
            label11.TabIndex = 15;
            label11.Text = "Performance";
            // 
            // salesOverTime1
            // 
            salesOverTime1.Location = new Point(36, 332);
            salesOverTime1.Margin = new Padding(2, 2, 2, 2);
            salesOverTime1.Name = "salesOverTime1";
            salesOverTime1.Size = new Size(755, 315);
            salesOverTime1.TabIndex = 12;
            // 
            // dineInvsTakeout1
            // 
            dineInvsTakeout1.BackColor = Color.FromArgb(245, 245, 220);
            dineInvsTakeout1.Location = new Point(970, 695);
            dineInvsTakeout1.Margin = new Padding(2, 2, 2, 2);
            dineInvsTakeout1.Name = "dineInvsTakeout1";
            dineInvsTakeout1.Size = new Size(315, 315);
            dineInvsTakeout1.TabIndex = 18;
            // 
            // topSellingProducts1
            // 
            topSellingProducts1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            topSellingProducts1.Location = new Point(999, 331);
            topSellingProducts1.Margin = new Padding(2);
            topSellingProducts1.Name = "topSellingProducts1";
            topSellingProducts1.Padding = new Padding(8);
            topSellingProducts1.Size = new Size(885, 360);
            topSellingProducts1.TabIndex = 19;
            // 
            // peakHours1
            // 
            peakHours1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            peakHours1.BackColor = Color.FromArgb(245, 245, 220);
            peakHours1.Location = new Point(1378, 695);
            peakHours1.Margin = new Padding(2, 2, 2, 2);
            peakHours1.Name = "peakHours1";
            peakHours1.Size = new Size(506, 315);
            peakHours1.TabIndex = 20;
            // 
            // TimeLineDropDown
            // 
            TimeLineDropDown.AutoRoundedCorners = true;
            TimeLineDropDown.BackColor = Color.Brown;
            TimeLineDropDown.BorderColor = Color.Brown;
            TimeLineDropDown.BorderRadius = 17;
            TimeLineDropDown.BorderThickness = 2;
            TimeLineDropDown.CustomizableEdges = customizableEdges17;
            TimeLineDropDown.DrawMode = DrawMode.OwnerDrawFixed;
            TimeLineDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            TimeLineDropDown.FillColor = Color.Brown;
            TimeLineDropDown.FocusedColor = Color.FromArgb(94, 148, 255);
            TimeLineDropDown.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TimeLineDropDown.FocusedState.FillColor = Color.Transparent;
            TimeLineDropDown.Font = new Font("Segoe UI", 10F);
            TimeLineDropDown.ForeColor = Color.White;
            TimeLineDropDown.HoverState.BorderColor = Color.Transparent;
            TimeLineDropDown.HoverState.FillColor = Color.Transparent;
            TimeLineDropDown.ItemHeight = 30;
            TimeLineDropDown.Items.AddRange(new object[] { "This day", "This month", "This year" });
            TimeLineDropDown.ItemsAppearance.SelectedFont = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TimeLineDropDown.Location = new Point(214, 18);
            TimeLineDropDown.Margin = new Padding(2);
            TimeLineDropDown.Name = "TimeLineDropDown";
            TimeLineDropDown.ShadowDecoration.CustomizableEdges = customizableEdges18;
            TimeLineDropDown.Size = new Size(161, 36);
            TimeLineDropDown.StartIndex = 0;
            TimeLineDropDown.TabIndex = 2;
            TimeLineDropDown.TextOffset = new Point(10, 0);
            TimeLineDropDown.SelectedIndexChanged += TimeLineDropDown_SelectedIndexChanged;
            // 
            // TimeLineLabel
            // 
            TimeLineLabel.BackColor = Color.Brown;
            TimeLineLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TimeLineLabel.ForeColor = Color.White;
            TimeLineLabel.Location = new Point(19, 9);
            TimeLineLabel.Name = "TimeLineLabel";
            TimeLineLabel.Size = new Size(45, 22);
            TimeLineLabel.TabIndex = 3;
            TimeLineLabel.Text = "Show:";
            // 
            // DashBoardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TimeLineDropDown);
            Controls.Add(peakHours1);
            Controls.Add(topSellingProducts1);
            Controls.Add(dineInvsTakeout1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(ordersOverTime1);
            Controls.Add(salesOverTime1);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "DashBoardControl";
            Size = new Size(1920, 1080);
            Load += DashBoardControl_Load;
            guna2ContainerControl1.ResumeLayout(false);
            guna2ContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            guna2ContainerControl2.ResumeLayout(false);
            guna2ContainerControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            guna2ContainerControl4.ResumeLayout(false);
            guna2ContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox4).EndInit();
            guna2ContainerControl3.ResumeLayout(false);
            guna2ContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl3;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label transactionsNum;
        private Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Label label5;
        private Label totalQTYNum;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Label label6;
        private Label totalRevenueNum;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private Label label8;
        private Label totalProfitNum;
        private DashBoardUserControls.OrdersOverTime ordersOverTime1;
        private Label label10;
        private Label label11;
        private DashBoardUserControls.SalesOverTime salesOverTime1;
        private DashBoardUserControls.DineInvsTakeout dineInvsTakeout1;
        private DashBoardUserControls.TopSellingProducts topSellingProducts1;
        private DashBoardUserControls.PeakHours peakHours1;
        private Guna.UI2.WinForms.Guna2ComboBox TimeLineDropDown;
        private Guna.UI2.WinForms.Guna2HtmlLabel TimeLineLabel;
    }
}
