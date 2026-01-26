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
            panelButtonGetStarted.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 543);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(675, 16);
            panel1.TabIndex = 1;
            // 
            // panelButtonGetStarted
            // 
            panelButtonGetStarted.BackColor = Color.Transparent;
            panelButtonGetStarted.Controls.Add(button1);
            panelButtonGetStarted.Location = new Point(203, 433);
            panelButtonGetStarted.Margin = new Padding(3, 2, 3, 2);
            panelButtonGetStarted.Name = "panelButtonGetStarted";
            panelButtonGetStarted.Size = new Size(262, 50);
            panelButtonGetStarted.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Impact", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(0, 2);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(254, 45);
            button1.TabIndex = 2;
            button1.Text = "Get Started";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // GetStartedScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Café_Gelado___Lune_Graphic;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(panel1);
            Controls.Add(panelButtonGetStarted);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GetStartedScreen";
            Size = new Size(675, 559);
            Load += GetStartedScreen_Load;
            Resize += GetStartedScreen_Resize;
            panelButtonGetStarted.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panelButtonGetStarted;
        private Button button1;
    }
}
