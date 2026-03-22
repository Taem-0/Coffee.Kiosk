namespace Coffee.Kiosk.OrderStatusDisplay
{
    partial class OrderStatusUC
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
            lblOrderNum = new Label();
            lblItemName = new Label();
            lblBadge = new Label();
            SuspendLayout();
            // 
            // lblOrderNum
            // 
            lblOrderNum.AutoSize = true;
            lblOrderNum.Font = new Font("Arial Rounded MT Bold", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOrderNum.Location = new Point(48, 13);
            lblOrderNum.Name = "lblOrderNum";
            lblOrderNum.Size = new Size(174, 58);
            lblOrderNum.TabIndex = 0;
            lblOrderNum.Text = "label1";
            lblOrderNum.Click += lblOrderNum_Click;
            // 
            // lblItemName
            // 
            lblItemName.AutoSize = true;
            lblItemName.Dock = DockStyle.Bottom;
            lblItemName.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblItemName.Location = new Point(14, 79);
            lblItemName.Name = "lblItemName";
            lblItemName.Size = new Size(69, 23);
            lblItemName.TabIndex = 1;
            lblItemName.Text = "label2";
            lblItemName.Click += lblItemName_Click;
            // 
            // lblBadge
            // 
            lblBadge.AutoSize = true;
            lblBadge.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBadge.Location = new Point(509, 49);
            lblBadge.Name = "lblBadge";
            lblBadge.Size = new Size(93, 32);
            lblBadge.TabIndex = 2;
            lblBadge.Text = "label3";
            lblBadge.Click += lblBadge_Click;
            // 
            // OrderStatusUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblBadge);
            Controls.Add(lblItemName);
            Controls.Add(lblOrderNum);
            Margin = new Padding(3, 4, 3, 4);
            Name = "OrderStatusUC";
            Padding = new Padding(14, 9, 14, 9);
            Size = new Size(662, 111);
            Load += OrderStatusUC_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderNum;
        private Label lblItemName;
        private Label lblBadge;
    }
}
