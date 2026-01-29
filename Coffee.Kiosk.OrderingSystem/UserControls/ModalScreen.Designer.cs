namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    partial class ModalScreen
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            panel1 = new Panel();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            BackButton = new Guna.UI2.WinForms.Guna2Button();
            mainModalScreen = new Panel();
            guna2Panel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderColor = Color.Gray;
            guna2Panel1.BorderRadius = 17;
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(panel1);
            guna2Panel1.Controls.Add(BackButton);
            guna2Panel1.CustomBorderColor = Color.Gray;
            guna2Panel1.CustomBorderThickness = new Padding(0, 1, 0, 0);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Dock = DockStyle.Bottom;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(0, 512);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.ShadowDecoration.Enabled = true;
            guna2Panel1.ShadowDecoration.Shadow = new Padding(0, 5, 0, 0);
            guna2Panel1.Size = new Size(598, 85);
            guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 67);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // panel1
            // 
            panel1.Controls.Add(guna2Button2);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(454, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(144, 85);
            panel1.TabIndex = 1;
            // 
            // guna2Button2
            // 
            guna2Button2.BorderColor = Color.DimGray;
            guna2Button2.BorderRadius = 7;
            guna2Button2.BorderThickness = 1;
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(17, 150, 0);
            guna2Button2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(0, 23);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.Size = new Size(124, 41);
            guna2Button2.TabIndex = 1;
            guna2Button2.Text = "Add to cart";
            // 
            // BackButton
            // 
            BackButton.BorderColor = Color.DimGray;
            BackButton.BorderRadius = 7;
            BackButton.BorderThickness = 1;
            BackButton.CustomizableEdges = customizableEdges3;
            BackButton.DisabledState.BorderColor = Color.DarkGray;
            BackButton.DisabledState.CustomBorderColor = Color.DarkGray;
            BackButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BackButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BackButton.FillColor = Color.FromArgb(129, 105, 91);
            BackButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BackButton.ForeColor = Color.White;
            BackButton.Location = new Point(26, 23);
            BackButton.Name = "BackButton";
            BackButton.ShadowDecoration.CustomizableEdges = customizableEdges4;
            BackButton.Size = new Size(124, 41);
            BackButton.TabIndex = 0;
            BackButton.Text = "Back";
            BackButton.Click += BackButton_Click;
            // 
            // mainModalScreen
            // 
            mainModalScreen.Dock = DockStyle.Fill;
            mainModalScreen.Location = new Point(0, 0);
            mainModalScreen.Name = "mainModalScreen";
            mainModalScreen.Size = new Size(598, 512);
            mainModalScreen.TabIndex = 1;
            // 
            // ModalScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainModalScreen);
            Controls.Add(guna2Panel1);
            Name = "ModalScreen";
            Size = new Size(598, 597);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button BackButton;
        private Panel mainModalScreen;
        private Label label1;
    }
}
