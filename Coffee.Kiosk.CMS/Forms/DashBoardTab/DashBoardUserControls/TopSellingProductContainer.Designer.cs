namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class TopSellingProductContainer
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
            productRankNo = new Label();
            productName = new Label();
            productQt = new Label();
            SuspendLayout();
            // 
            // productRankNo
            // 
            productRankNo.AutoSize = true;
            productRankNo.Location = new Point(224, 34);
            productRankNo.Name = "productRankNo";
            productRankNo.Size = new Size(104, 25);
            productRankNo.TabIndex = 0;
            productRankNo.Text = "produ.Num";
            // 
            // productName
            // 
            productName.AutoSize = true;
            productName.Location = new Point(458, 34);
            productName.Name = "productName";
            productName.Size = new Size(59, 25);
            productName.TabIndex = 1;
            productName.Text = "Name";
            // 
            // productQt
            // 
            productQt.AutoSize = true;
            productQt.Location = new Point(672, 34);
            productQt.Name = "productQt";
            productQt.Size = new Size(41, 25);
            productQt.TabIndex = 2;
            productQt.Text = "Qty";
            // 
            // TopSellingProductContainer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(productQt);
            Controls.Add(productName);
            Controls.Add(productRankNo);
            Name = "TopSellingProductContainer";
            Size = new Size(822, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label productRankNo;
        private Label productName;
        private Label productQt;
    }
}
