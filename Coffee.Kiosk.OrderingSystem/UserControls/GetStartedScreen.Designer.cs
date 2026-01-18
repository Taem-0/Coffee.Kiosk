namespace Coffee.Kiosk.OrderingSystem
{
    partial class GetStartedScreen
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
            panel1 = new Panel();
            panelButtonGetStarted = new Panel();
            button1 = new Button();
            panel1.SuspendLayout();
            panelButtonGetStarted.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panelButtonGetStarted);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 386);
            panel1.Name = "panel1";
            panel1.Size = new Size(771, 359);
            panel1.TabIndex = 1;
            // 
            // panelButtonGetStarted
            // 
            panelButtonGetStarted.BackColor = Color.Transparent;
            panelButtonGetStarted.Controls.Add(button1);
            panelButtonGetStarted.Location = new Point(241, 3);
            panelButtonGetStarted.Name = "panelButtonGetStarted";
            panelButtonGetStarted.Size = new Size(300, 66);
            panelButtonGetStarted.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 20F);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(290, 60);
            button1.TabIndex = 2;
            button1.Text = "Get Started";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GetStartedScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "GetStartedScreen";
            Size = new Size(771, 745);
            Load += GetStartedScreen_Load;
            Resize += GetStartedScreen_Resize;
            panel1.ResumeLayout(false);
            panelButtonGetStarted.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panelButtonGetStarted;
        private Button button1;
    }
}
