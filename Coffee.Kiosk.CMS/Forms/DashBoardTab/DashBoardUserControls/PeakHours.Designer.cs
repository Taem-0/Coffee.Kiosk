namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class PeakHours
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
            peakHourNum = new Label();
            slowestHourNum = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 32);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 0;
            label1.Text = "Peak Hours:";
            // 
            // peakHourNum
            // 
            peakHourNum.AutoSize = true;
            peakHourNum.Location = new Point(164, 32);
            peakHourNum.Name = "peakHourNum";
            peakHourNum.Size = new Size(74, 25);
            peakHourNum.TabIndex = 1;
            peakHourNum.Text = "number";
            // 
            // slowestHourNum
            // 
            slowestHourNum.AutoSize = true;
            slowestHourNum.Location = new Point(703, 32);
            slowestHourNum.Name = "slowestHourNum";
            slowestHourNum.Size = new Size(74, 25);
            slowestHourNum.TabIndex = 3;
            slowestHourNum.Text = "number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(567, 32);
            label4.Name = "label4";
            label4.Size = new Size(130, 25);
            label4.TabIndex = 2;
            label4.Text = "Slowest Hours:";
            // 
            // PeakHours
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(slowestHourNum);
            Controls.Add(label4);
            Controls.Add(peakHourNum);
            Controls.Add(label1);
            Name = "PeakHours";
            Size = new Size(850, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label peakHourNum;
        private Label slowestHourNum;
        private Label label4;
    }
}
