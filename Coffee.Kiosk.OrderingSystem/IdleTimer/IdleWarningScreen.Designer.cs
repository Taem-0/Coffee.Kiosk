namespace Coffee.Kiosk.OrderingSystem.IdleTimer
{
    partial class IdleWarningScreen
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(86, 36);
            label1.Name = "label1";
            label1.Size = new Size(229, 32);
            label1.TabIndex = 0;
            label1.Text = "Are you still there?";
            label1.Click += label1_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 17;
            guna2Button1.BorderThickness = 1;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(115, 115, 115);
            guna2Button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(12, 136);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(376, 52);
            guna2Button1.TabIndex = 1;
            guna2Button1.Text = "Tap anywhere to continue";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(166, 87);
            label2.Name = "label2";
            label2.Size = new Size(63, 32);
            label2.TabIndex = 2;
            label2.Text = "0:00";
            // 
            // IdleWarningScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(label2);
            Controls.Add(guna2Button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "IdleWarningScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IdleWarningScreen";
            TopMost = true;
            Load += IdleWarningScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Label label2;
    }
}