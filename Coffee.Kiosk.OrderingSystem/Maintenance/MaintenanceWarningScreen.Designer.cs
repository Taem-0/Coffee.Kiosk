namespace Coffee.Kiosk.OrderingSystem.Maintenance
{
    partial class MaintenanceWarningScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(144, 169);
            label2.Name = "label2";
            label2.Size = new Size(63, 32);
            label2.TabIndex = 5;
            label2.Text = "0:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 31);
            label1.Name = "label1";
            label1.Size = new Size(289, 128);
            label1.TabIndex = 3;
            label1.Text = "Sorry for inconvenience\r\nUnder Maintenance\r\n:(\r\nResetting in\r\n";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // MaintenanceWarningScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 210);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MaintenanceWarningScreen";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "MaintenanceWarningScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
    }
}