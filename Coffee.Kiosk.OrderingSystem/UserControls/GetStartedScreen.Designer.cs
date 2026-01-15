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
            getStartedButton = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            panelButtonGetStarted = new Panel();
            button1 = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            panelButtonGetStarted.SuspendLayout();
            SuspendLayout();
            // 
            // getStartedButton
            // 
            getStartedButton.AutoSize = false;
            getStartedButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            getStartedButton.BackColor = Color.Gray;
            getStartedButton.BackgroundImageLayout = ImageLayout.Stretch;
            getStartedButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            getStartedButton.Depth = 0;
            getStartedButton.Font = new Font("Segoe UI", 17F);
            getStartedButton.ForeColor = Color.Transparent;
            getStartedButton.HighEmphasis = true;
            getStartedButton.Icon = null;
            getStartedButton.Location = new Point(4, 6);
            getStartedButton.Margin = new Padding(4, 6, 4, 6);
            getStartedButton.MouseState = MaterialSkin.MouseState.HOVER;
            getStartedButton.Name = "getStartedButton";
            getStartedButton.NoAccentTextColor = Color.Empty;
            getStartedButton.Size = new Size(290, 59);
            getStartedButton.TabIndex = 0;
            getStartedButton.Text = "Get Started";
            getStartedButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            getStartedButton.UseAccentColor = false;
            getStartedButton.UseVisualStyleBackColor = false;
            getStartedButton.Click += getStartedButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panelButtonGetStarted);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 469);
            panel1.Name = "panel1";
            panel1.Size = new Size(771, 276);
            panel1.TabIndex = 1;
            // 
            // panelButtonGetStarted
            // 
            panelButtonGetStarted.BackColor = Color.Transparent;
            panelButtonGetStarted.Controls.Add(button1);
            panelButtonGetStarted.Controls.Add(getStartedButton);
            panelButtonGetStarted.Location = new Point(242, 46);
            panelButtonGetStarted.Name = "panelButtonGetStarted";
            panelButtonGetStarted.Size = new Size(300, 151);
            panelButtonGetStarted.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 20F);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(4, 74);
            button1.Name = "button1";
            button1.Size = new Size(290, 60);
            button1.TabIndex = 2;
            button1.Text = "Get Started";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(338, 18);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 2;
            label1.Text = "idk which one";
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
            panel1.PerformLayout();
            panelButtonGetStarted.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton getStartedButton;
        private Panel panel1;
        private Panel panelButtonGetStarted;
        private Button button1;
        private Label label1;
    }
}
