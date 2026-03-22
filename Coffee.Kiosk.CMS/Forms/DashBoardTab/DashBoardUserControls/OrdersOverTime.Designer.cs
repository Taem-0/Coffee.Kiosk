namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class OrdersOverTime
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
            monthOrders = new Label();
            label6 = new Label();
            weekOrders = new Label();
            label4 = new Label();
            todayOrders = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // monthOrders
            // 
            monthOrders.AutoSize = true;
            monthOrders.Location = new Point(207, 200);
            monthOrders.Name = "monthOrders";
            monthOrders.Size = new Size(74, 25);
            monthOrders.TabIndex = 11;
            monthOrders.Text = "number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 200);
            label6.Name = "label6";
            label6.Size = new Size(176, 25);
            label6.TabIndex = 10;
            label6.Text = "This month's Orders:";
            // 
            // weekOrders
            // 
            weekOrders.AutoSize = true;
            weekOrders.Location = new Point(190, 115);
            weekOrders.Name = "weekOrders";
            weekOrders.Size = new Size(74, 25);
            weekOrders.TabIndex = 9;
            weekOrders.Text = "number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 115);
            label4.Name = "label4";
            label4.Size = new Size(159, 25);
            label4.TabIndex = 8;
            label4.Text = "This weeks Orders:";
            // 
            // todayOrders
            // 
            todayOrders.AutoSize = true;
            todayOrders.Location = new Point(161, 35);
            todayOrders.Name = "todayOrders";
            todayOrders.Size = new Size(74, 25);
            todayOrders.TabIndex = 7;
            todayOrders.Text = "number";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 35);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 6;
            label1.Text = "Todays Orders:";
            // 
            // OrdersOverTime
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(monthOrders);
            Controls.Add(label6);
            Controls.Add(weekOrders);
            Controls.Add(label4);
            Controls.Add(todayOrders);
            Controls.Add(label1);
            Name = "OrdersOverTime";
            Size = new Size(550, 270);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label monthOrders;
        private Label label6;
        private Label weekOrders;
        private Label label4;
        private Label todayOrders;
        private Label label1;
    }
}
