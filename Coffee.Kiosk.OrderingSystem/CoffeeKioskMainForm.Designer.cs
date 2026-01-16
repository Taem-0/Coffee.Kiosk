namespace Coffee.Kiosk.OrderingSystem
{
    partial class CoffeeKioskMainForm
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
            mainPanel = new Panel();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(3, 24);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(767, 873);
            mainPanel.TabIndex = 0;
            // 
            // CoffeeKioskMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(203, 183, 153);
            ClientSize = new Size(773, 900);
            Controls.Add(mainPanel);
            FormStyle = FormStyles.ActionBar_None;
            MinimumSize = new Size(0, 900);
            Name = "CoffeeKioskMainForm";
            Padding = new Padding(3, 24, 3, 3);
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KIOSK";
            Load += CoffeeKiosk_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
    }
}
