namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class DineInvsTakeout
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
            dineInCount = new Label();
            dineInPercentage = new Label();
            takeOutPercentage = new Label();
            takeOutCount = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 26);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 0;
            label1.Text = "Dine In:";
            // 
            // dineInCount
            // 
            dineInCount.AutoSize = true;
            dineInCount.Location = new Point(62, 74);
            dineInCount.Name = "dineInCount";
            dineInCount.Size = new Size(60, 25);
            dineInCount.TabIndex = 1;
            dineInCount.Text = "Count";
            // 
            // dineInPercentage
            // 
            dineInPercentage.AutoSize = true;
            dineInPercentage.Location = new Point(62, 117);
            dineInPercentage.Name = "dineInPercentage";
            dineInPercentage.Size = new Size(98, 25);
            dineInPercentage.TabIndex = 2;
            dineInPercentage.Text = "Percentage";
            // 
            // takeOutPercentage
            // 
            takeOutPercentage.AutoSize = true;
            takeOutPercentage.Location = new Point(589, 117);
            takeOutPercentage.Name = "takeOutPercentage";
            takeOutPercentage.Size = new Size(98, 25);
            takeOutPercentage.TabIndex = 5;
            takeOutPercentage.Text = "Percentage";
            // 
            // takeOutCount
            // 
            takeOutCount.AutoSize = true;
            takeOutCount.Location = new Point(589, 74);
            takeOutCount.Name = "takeOutCount";
            takeOutCount.Size = new Size(60, 25);
            takeOutCount.TabIndex = 4;
            takeOutCount.Text = "Count";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(589, 26);
            label6.Name = "label6";
            label6.Size = new Size(85, 25);
            label6.TabIndex = 3;
            label6.Text = "Take Out:";
            // 
            // DineInvsTakeout
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(takeOutPercentage);
            Controls.Add(takeOutCount);
            Controls.Add(label6);
            Controls.Add(dineInPercentage);
            Controls.Add(dineInCount);
            Controls.Add(label1);
            Name = "DineInvsTakeout";
            Size = new Size(850, 170);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label dineInCount;
        private Label dineInPercentage;
        private Label takeOutPercentage;
        private Label takeOutCount;
        private Label label6;
    }
}
