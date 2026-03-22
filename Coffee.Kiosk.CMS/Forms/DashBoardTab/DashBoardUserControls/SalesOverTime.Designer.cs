namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class SalesOverTime
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
            todayRevenue = new Label();
            weekRevenue = new Label();
            label4 = new Label();
            monthRevenue = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 35);
            label1.Name = "label1";
            label1.Size = new Size(142, 25);
            label1.TabIndex = 0;
            label1.Text = "Todays Revenue:";
            label1.Click += label1_Click;
            // 
            // todayRevenue
            // 
            todayRevenue.AutoSize = true;
            todayRevenue.Location = new Point(175, 35);
            todayRevenue.Name = "todayRevenue";
            todayRevenue.Size = new Size(74, 25);
            todayRevenue.TabIndex = 1;
            todayRevenue.Text = "number";
            // 
            // weekRevenue
            // 
            weekRevenue.AutoSize = true;
            weekRevenue.Location = new Point(198, 115);
            weekRevenue.Name = "weekRevenue";
            weekRevenue.Size = new Size(74, 25);
            weekRevenue.TabIndex = 3;
            weekRevenue.Text = "number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 115);
            label4.Name = "label4";
            label4.Size = new Size(167, 25);
            label4.TabIndex = 2;
            label4.Text = "This weeks revenue:";
            // 
            // monthRevenue
            // 
            monthRevenue.AutoSize = true;
            monthRevenue.Location = new Point(215, 200);
            monthRevenue.Name = "monthRevenue";
            monthRevenue.Size = new Size(74, 25);
            monthRevenue.TabIndex = 5;
            monthRevenue.Text = "number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 200);
            label6.Name = "label6";
            label6.Size = new Size(184, 25);
            label6.TabIndex = 4;
            label6.Text = "This month's revenue:";
            // 
            // SalesOverTime
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(monthRevenue);
            Controls.Add(label6);
            Controls.Add(weekRevenue);
            Controls.Add(label4);
            Controls.Add(todayRevenue);
            Controls.Add(label1);
            Name = "SalesOverTime";
            Size = new Size(550, 270);
            Load += SalesOverTime_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label todayRevenue;
        private Label weekRevenue;
        private Label label4;
        private Label monthRevenue;
        private Label label6;
    }
}
