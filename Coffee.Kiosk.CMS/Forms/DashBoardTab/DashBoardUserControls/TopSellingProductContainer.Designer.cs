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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(224, 34);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 0;
            label1.Text = "produ.Num";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(458, 34);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(672, 34);
            label3.Name = "label3";
            label3.Size = new Size(41, 25);
            label3.TabIndex = 2;
            label3.Text = "Qty";
            // 
            // TopSellingProductContainer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TopSellingProductContainer";
            Size = new Size(822, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
    }
}
