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
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(228, 196);
            label5.Name = "label5";
            label5.Size = new Size(74, 25);
            label5.TabIndex = 11;
            label5.Text = "number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 196);
            label6.Name = "label6";
            label6.Size = new Size(176, 25);
            label6.TabIndex = 10;
            label6.Text = "This month's Orders:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(216, 112);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 9;
            label3.Text = "number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 112);
            label4.Name = "label4";
            label4.Size = new Size(159, 25);
            label4.TabIndex = 8;
            label4.Text = "This weeks Orders:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 24);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 7;
            label2.Text = "number";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 24);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 6;
            label1.Text = "Todays Orders:";
            // 
            // OrdersOverTime
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OrdersOverTime";
            Size = new Size(550, 270);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
    }
}
