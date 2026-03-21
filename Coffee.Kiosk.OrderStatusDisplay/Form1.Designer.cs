namespace Coffee.Kiosk.OrderStatusDisplay
{
    partial class Form1
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
            pnlHeader = new Panel();
            lblClock = new Label();
            pictureBox1 = new PictureBox();
            lblCafeFil = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlPay = new Panel();
            flpPay = new FlowLayoutPanel();
            pnlPayHeader = new Panel();
            lblProceed = new Label();
            lblPay = new Label();
            lblIcon = new Label();
            pnlPrep = new Panel();
            flpPrep = new FlowLayoutPanel();
            pnlPrepHeader = new Panel();
            lblPrepared = new Label();
            lblPreparing = new Label();
            lblIcon1 = new Label();
            pnlPickup = new Panel();
            flpPickup = new FlowLayoutPanel();
            pnlPickupHeader = new Panel();
            label1 = new Label();
            lblPickUp = new Label();
            lblIcon2 = new Label();
            tmrClock = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            pnlPay.SuspendLayout();
            pnlPayHeader.SuspendLayout();
            pnlPrep.SuspendLayout();
            pnlPrepHeader.SuspendLayout();
            pnlPickup.SuspendLayout();
            pnlPickupHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Tan;
            pnlHeader.Controls.Add(lblClock);
            pnlHeader.Controls.Add(pictureBox1);
            pnlHeader.Controls.Add(lblCafeFil);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1904, 111);
            pnlHeader.TabIndex = 0;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClock.Location = new Point(1735, 42);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(93, 37);
            lblClock.TabIndex = 2;
            lblClock.Text = "Time";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Tan;
            pictureBox1.Image = Properties.Resources.Untitled_design__7_;
            pictureBox1.Location = new Point(13, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(98, 93);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblCafeFil
            // 
            lblCafeFil.AutoSize = true;
            lblCafeFil.Font = new Font("Candara", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCafeFil.Location = new Point(119, 37);
            lblCafeFil.Name = "lblCafeFil";
            lblCafeFil.Size = new Size(215, 39);
            lblCafeFil.TabIndex = 0;
            lblCafeFil.Text = "CAFE FILIPINO";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(pnlPay, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlPrep, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlPickup, 2, 0);
            tableLayoutPanel1.Location = new Point(27, 129);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1848, 911);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlPay
            // 
            pnlPay.BackColor = Color.Tan;
            pnlPay.Controls.Add(flpPay);
            pnlPay.Controls.Add(pnlPayHeader);
            pnlPay.Dock = DockStyle.Left;
            pnlPay.Location = new Point(3, 3);
            pnlPay.Name = "pnlPay";
            pnlPay.Size = new Size(609, 905);
            pnlPay.TabIndex = 0;
            // 
            // flpPay
            // 
            flpPay.FlowDirection = FlowDirection.TopDown;
            flpPay.Location = new Point(0, 196);
            flpPay.Name = "flpPay";
            flpPay.Size = new Size(609, 709);
            flpPay.TabIndex = 1;
            flpPay.WrapContents = false;
            // 
            // pnlPayHeader
            // 
            pnlPayHeader.BackColor = Color.SeaShell;
            pnlPayHeader.Controls.Add(lblProceed);
            pnlPayHeader.Controls.Add(lblPay);
            pnlPayHeader.Controls.Add(lblIcon);
            pnlPayHeader.Location = new Point(16, 18);
            pnlPayHeader.Name = "pnlPayHeader";
            pnlPayHeader.Size = new Size(579, 159);
            pnlPayHeader.TabIndex = 0;
            // 
            // lblProceed
            // 
            lblProceed.AutoSize = true;
            lblProceed.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblProceed.Location = new Point(214, 119);
            lblProceed.Name = "lblProceed";
            lblProceed.Size = new Size(162, 18);
            lblProceed.TabIndex = 2;
            lblProceed.Text = "Proceed to Cashier";
            // 
            // lblPay
            // 
            lblPay.AutoSize = true;
            lblPay.Font = new Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPay.Location = new Point(187, 74);
            lblPay.Name = "lblPay";
            lblPay.Size = new Size(234, 40);
            lblPay.TabIndex = 1;
            lblPay.Text = "PLEASE PAY";
            // 
            // lblIcon
            // 
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIcon.Location = new Point(256, 5);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(94, 65);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "💳";
            // 
            // pnlPrep
            // 
            pnlPrep.BackColor = Color.Tan;
            pnlPrep.Controls.Add(flpPrep);
            pnlPrep.Controls.Add(pnlPrepHeader);
            pnlPrep.Dock = DockStyle.Fill;
            pnlPrep.Location = new Point(618, 3);
            pnlPrep.Name = "pnlPrep";
            pnlPrep.Size = new Size(609, 905);
            pnlPrep.TabIndex = 1;
            // 
            // flpPrep
            // 
            flpPrep.FlowDirection = FlowDirection.TopDown;
            flpPrep.Location = new Point(0, 196);
            flpPrep.Name = "flpPrep";
            flpPrep.Size = new Size(609, 709);
            flpPrep.TabIndex = 1;
            flpPrep.WrapContents = false;
            // 
            // pnlPrepHeader
            // 
            pnlPrepHeader.BackColor = Color.SeaShell;
            pnlPrepHeader.Controls.Add(lblPrepared);
            pnlPrepHeader.Controls.Add(lblPreparing);
            pnlPrepHeader.Controls.Add(lblIcon1);
            pnlPrepHeader.Location = new Point(12, 18);
            pnlPrepHeader.Name = "pnlPrepHeader";
            pnlPrepHeader.Size = new Size(579, 159);
            pnlPrepHeader.TabIndex = 0;
            // 
            // lblPrepared
            // 
            lblPrepared.AutoSize = true;
            lblPrepared.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPrepared.Location = new Point(199, 119);
            lblPrepared.Name = "lblPrepared";
            lblPrepared.Size = new Size(203, 18);
            lblPrepared.TabIndex = 2;
            lblPrepared.Text = "We're making your order";
            // 
            // lblPreparing
            // 
            lblPreparing.AutoSize = true;
            lblPreparing.Font = new Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPreparing.Location = new Point(138, 74);
            lblPreparing.Name = "lblPreparing";
            lblPreparing.Size = new Size(333, 40);
            lblPreparing.TabIndex = 1;
            lblPreparing.Text = "BEING PREPARED";
            // 
            // lblIcon1
            // 
            lblIcon1.AutoSize = true;
            lblIcon1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIcon1.Location = new Point(261, 14);
            lblIcon1.Name = "lblIcon1";
            lblIcon1.Size = new Size(94, 65);
            lblIcon1.TabIndex = 0;
            lblIcon1.Text = "☕";
            // 
            // pnlPickup
            // 
            pnlPickup.BackColor = Color.Tan;
            pnlPickup.Controls.Add(flpPickup);
            pnlPickup.Controls.Add(pnlPickupHeader);
            pnlPickup.Dock = DockStyle.Right;
            pnlPickup.Location = new Point(1233, 3);
            pnlPickup.Name = "pnlPickup";
            pnlPickup.Size = new Size(612, 905);
            pnlPickup.TabIndex = 2;
            // 
            // flpPickup
            // 
            flpPickup.FlowDirection = FlowDirection.TopDown;
            flpPickup.Location = new Point(0, 196);
            flpPickup.Name = "flpPickup";
            flpPickup.Size = new Size(612, 709);
            flpPickup.TabIndex = 1;
            flpPickup.WrapContents = false;
            // 
            // pnlPickupHeader
            // 
            pnlPickupHeader.BackColor = Color.SeaShell;
            pnlPickupHeader.Controls.Add(label1);
            pnlPickupHeader.Controls.Add(lblPickUp);
            pnlPickupHeader.Controls.Add(lblIcon2);
            pnlPickupHeader.Location = new Point(21, 18);
            pnlPickupHeader.Name = "pnlPickupHeader";
            pnlPickupHeader.Size = new Size(579, 159);
            pnlPickupHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(201, 119);
            label1.Name = "label1";
            label1.Size = new Size(208, 18);
            label1.TabIndex = 2;
            label1.Text = "Please collect your order";
            // 
            // lblPickUp
            // 
            lblPickUp.AutoSize = true;
            lblPickUp.Font = new Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPickUp.Location = new Point(122, 75);
            lblPickUp.Name = "lblPickUp";
            lblPickUp.Size = new Size(378, 40);
            lblPickUp.TabIndex = 1;
            lblPickUp.Text = "READY FOR PICK-UP";
            // 
            // lblIcon2
            // 
            lblIcon2.AutoSize = true;
            lblIcon2.Font = new Font("Segoe UI", 32.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIcon2.Location = new Point(274, 19);
            lblIcon2.Name = "lblIcon2";
            lblIcon2.Size = new Size(85, 59);
            lblIcon2.TabIndex = 0;
            lblIcon2.Text = "✅";
            // 
            // tmrClock
            // 
            tmrClock.Enabled = true;
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1052);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlHeader);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            pnlPay.ResumeLayout(false);
            pnlPayHeader.ResumeLayout(false);
            pnlPayHeader.PerformLayout();
            pnlPrep.ResumeLayout(false);
            pnlPrepHeader.ResumeLayout(false);
            pnlPrepHeader.PerformLayout();
            pnlPickup.ResumeLayout(false);
            pnlPickupHeader.ResumeLayout(false);
            pnlPickupHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlPay;
        private Panel pnlPrep;
        private Panel pnlPickup;
        private Panel pnlPayHeader;
        private Panel pnlPrepHeader;
        private Panel pnlPickupHeader;
        private FlowLayoutPanel flpPay;
        private Label lblPay;
        private Label lblIcon;
        private Label lblProceed;
        private FlowLayoutPanel flpPrep;
        private FlowLayoutPanel flpPickup;
        private Label lblPreparing;
        private Label lblIcon1;
        private Label lblPrepared;
        private Label lblIcon2;
        private Label label1;
        private Label lblPickUp;
        private Label lblCafeFil;
        private PictureBox pictureBox1;
        private Label lblClock;
        private System.Windows.Forms.Timer tmrClock;
    }
}
