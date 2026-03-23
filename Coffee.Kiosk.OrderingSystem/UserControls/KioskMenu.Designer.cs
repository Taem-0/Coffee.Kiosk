namespace Coffee.Kiosk.OrderingSystem
{
    partial class KioskMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _adTimer?.Stop();
                _adTimer?.Dispose();
                components?.Dispose();
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KioskMenu));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowCategories = new FlowLayoutPanel();
            BottomPanel = new Panel();
            panel1 = new Panel();
            checkOutBtn = new Guna.UI2.WinForms.Guna2Button();
            panel2 = new Panel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cartCounterButton = new Guna.UI2.WinForms.Guna2CircleButton();
            CartPicture = new PictureBox();
            StartOverBtn = new Guna.UI2.WinForms.Guna2Button();
            AdPanel = new Panel();
            TopBanner = new PictureBox();
            ContentPanel = new Guna.UI2.WinForms.Guna2Panel();
            BottomPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CartPicture).BeginInit();
            AdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TopBanner).BeginInit();
            SuspendLayout();
            // 
            // flowCategories
            // 
            flowCategories.AutoScroll = true;
            flowCategories.BackColor = Color.SeaShell;
            flowCategories.Dock = DockStyle.Left;
            flowCategories.FlowDirection = FlowDirection.TopDown;
            flowCategories.Location = new Point(0, 159);
            flowCategories.Name = "flowCategories";
            flowCategories.Size = new Size(220, 358);
            flowCategories.TabIndex = 0;
            flowCategories.WrapContents = false;
            // 
            // BottomPanel
            // 
            BottomPanel.BackColor = Color.SeaShell;
            BottomPanel.Controls.Add(panel1);
            BottomPanel.Controls.Add(panel2);
            BottomPanel.Controls.Add(cartCounterButton);
            BottomPanel.Controls.Add(CartPicture);
            BottomPanel.Controls.Add(StartOverBtn);
            BottomPanel.Dock = DockStyle.Bottom;
            BottomPanel.Location = new Point(0, 517);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new Size(673, 167);
            BottomPanel.TabIndex = 1;
            BottomPanel.Paint += BottomPanel_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkOutBtn);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(397, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 167);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // checkOutBtn
            // 
            checkOutBtn.Animated = true;
            checkOutBtn.BorderRadius = 17;
            checkOutBtn.CustomizableEdges = customizableEdges8;
            checkOutBtn.DisabledState.BorderColor = Color.DarkGray;
            checkOutBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            checkOutBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            checkOutBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            checkOutBtn.Enabled = false;
            checkOutBtn.FillColor = Color.Red;
            checkOutBtn.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);
            checkOutBtn.ForeColor = Color.White;
            checkOutBtn.Location = new Point(9, 61);
            checkOutBtn.Margin = new Padding(50);
            checkOutBtn.Name = "checkOutBtn";
            checkOutBtn.ShadowDecoration.CustomizableEdges = customizableEdges9;
            checkOutBtn.Size = new Size(250, 56);
            checkOutBtn.TabIndex = 4;
            checkOutBtn.Text = "Proceed to Checkout";
            checkOutBtn.Click += checkOutBtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2HtmlLabel1);
            panel2.Location = new Point(125, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(228, 130);
            panel2.TabIndex = 6;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.AutoSize = false;
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Dock = DockStyle.Fill;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(0, 0);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(228, 130);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "<b><font size='12'>Order summary</font></b>\r\n<br>\r\n<b>Items:</b> 67\r\n<br>\r\n<b>Dine in</b>\r\n<br>\r\n<b>Total:</b> ₱67.67";
            // 
            // cartCounterButton
            // 
            cartCounterButton.BackColor = Color.Transparent;
            cartCounterButton.DisabledState.BorderColor = Color.DarkGray;
            cartCounterButton.DisabledState.CustomBorderColor = Color.DarkGray;
            cartCounterButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            cartCounterButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            cartCounterButton.FillColor = Color.Red;
            cartCounterButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cartCounterButton.ForeColor = Color.White;
            cartCounterButton.Location = new Point(84, 6);
            cartCounterButton.Margin = new Padding(0);
            cartCounterButton.Name = "cartCounterButton";
            cartCounterButton.ShadowDecoration.CustomizableEdges = customizableEdges10;
            cartCounterButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            cartCounterButton.Size = new Size(35, 35);
            cartCounterButton.TabIndex = 3;
            cartCounterButton.Text = "0";
            cartCounterButton.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            cartCounterButton.UseTransparentBackground = true;
            cartCounterButton.Visible = false;
            cartCounterButton.Click += cartCounterButton_Click;
            // 
            // CartPicture
            // 
            CartPicture.Image = Properties.Resources.CART__1__1_;
            CartPicture.Location = new Point(37, 6);
            CartPicture.Name = "CartPicture";
            CartPicture.Size = new Size(82, 85);
            CartPicture.SizeMode = PictureBoxSizeMode.Zoom;
            CartPicture.TabIndex = 1;
            CartPicture.TabStop = false;
            CartPicture.Click += CartPicture_Click;
            // 
            // StartOverBtn
            // 
            StartOverBtn.BackColor = Color.Transparent;
            StartOverBtn.BorderColor = Color.Transparent;
            StartOverBtn.BorderRadius = 15;
            StartOverBtn.BorderThickness = 1;
            StartOverBtn.CustomizableEdges = customizableEdges11;
            StartOverBtn.DisabledState.BorderColor = Color.DarkGray;
            StartOverBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            StartOverBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            StartOverBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            StartOverBtn.FillColor = Color.WhiteSmoke;
            StartOverBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartOverBtn.ForeColor = Color.Black;
            StartOverBtn.HoverState.BorderColor = Color.Black;
            StartOverBtn.HoverState.FillColor = Color.Transparent;
            StartOverBtn.Location = new Point(0, 135);
            StartOverBtn.Name = "StartOverBtn";
            StartOverBtn.ShadowDecoration.BorderRadius = 17;
            StartOverBtn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            StartOverBtn.ShadowDecoration.Depth = 7;
            StartOverBtn.ShadowDecoration.Enabled = true;
            StartOverBtn.Size = new Size(116, 29);
            StartOverBtn.TabIndex = 2;
            StartOverBtn.Text = "< Start over";
            StartOverBtn.Click += guna2Button1_Click;
            // 
            // AdPanel
            // 
            AdPanel.Controls.Add(TopBanner);
            AdPanel.Dock = DockStyle.Top;
            AdPanel.Location = new Point(0, 0);
            AdPanel.Name = "AdPanel";
            AdPanel.Size = new Size(673, 159);
            AdPanel.TabIndex = 2;
            // 
            // TopBanner
            // 
            TopBanner.BackColor = Color.Sienna;
            TopBanner.Dock = DockStyle.Fill;
            TopBanner.Image = (Image)resources.GetObject("TopBanner.Image");
            TopBanner.Location = new Point(0, 0);
            TopBanner.Margin = new Padding(0);
            TopBanner.Name = "TopBanner";
            TopBanner.Size = new Size(673, 159);
            TopBanner.SizeMode = PictureBoxSizeMode.StretchImage;
            TopBanner.TabIndex = 1;
            TopBanner.TabStop = false;
            // 
            // ContentPanel
            // 
            ContentPanel.AutoScroll = true;
            ContentPanel.BackColor = Color.SeaShell;
            ContentPanel.CustomizableEdges = customizableEdges13;
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(220, 159);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Padding = new Padding(3, 3, 3, 10);
            ContentPanel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            ContentPanel.Size = new Size(453, 358);
            ContentPanel.TabIndex = 3;
            // 
            // KioskMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ContentPanel);
            Controls.Add(flowCategories);
            Controls.Add(BottomPanel);
            Controls.Add(AdPanel);
            Margin = new Padding(0);
            Name = "KioskMenu";
            Size = new Size(673, 684);
            BottomPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CartPicture).EndInit();
            AdPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TopBanner).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowCategories;
        private Panel BottomPanel;
        //private Label StartOver_Button;
        private Panel AdPanel;
        private PictureBox TopBanner;
        private PictureBox CartPicture;
        private Guna.UI2.WinForms.Guna2Panel ContentPanel;
        private Guna.UI2.WinForms.Guna2Button StartOverBtn;
        private Guna.UI2.WinForms.Guna2CircleButton cartCounterButton;
        private Guna.UI2.WinForms.Guna2Button checkOutBtn;
        private Panel panel1;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
