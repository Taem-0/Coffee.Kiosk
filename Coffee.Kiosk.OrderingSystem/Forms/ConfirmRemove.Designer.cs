namespace Coffee.Kiosk.OrderingSystem.Forms
{
    partial class ConfirmRemove
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            NoBtn = new Guna.UI2.WinForms.Guna2Button();
            YesBtn = new Guna.UI2.WinForms.Guna2Button();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(94, 47);
            label1.Name = "label1";
            label1.Size = new Size(215, 41);
            label1.TabIndex = 0;
            label1.Text = "Remove item?";
            // 
            // NoBtn
            // 
            NoBtn.BorderColor = Color.FromArgb(60, 60, 60);
            NoBtn.BorderRadius = 17;
            NoBtn.BorderThickness = 2;
            NoBtn.CustomizableEdges = customizableEdges1;
            NoBtn.DisabledState.BorderColor = Color.DarkGray;
            NoBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            NoBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            NoBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            NoBtn.FillColor = Color.FromArgb(85, 118, 81);
            NoBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            NoBtn.ForeColor = Color.White;
            NoBtn.Location = new Point(12, 132);
            NoBtn.Name = "NoBtn";
            NoBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            NoBtn.Size = new Size(180, 45);
            NoBtn.TabIndex = 1;
            NoBtn.Text = "No";
            NoBtn.Click += NoBtn_Click;
            // 
            // YesBtn
            // 
            YesBtn.BorderColor = Color.FromArgb(60, 60, 60);
            YesBtn.BorderRadius = 17;
            YesBtn.BorderThickness = 2;
            YesBtn.CustomizableEdges = customizableEdges3;
            YesBtn.DisabledState.BorderColor = Color.DarkGray;
            YesBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            YesBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            YesBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            YesBtn.FillColor = Color.FromArgb(111, 111, 111);
            YesBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            YesBtn.ForeColor = Color.White;
            YesBtn.Location = new Point(208, 132);
            YesBtn.Name = "YesBtn";
            YesBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            YesBtn.Size = new Size(180, 45);
            YesBtn.TabIndex = 2;
            YesBtn.Text = "Yes";
            YesBtn.Click += YesBtn_Click;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ConfirmRemove
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(YesBtn);
            Controls.Add(NoBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(400, 200);
            MinimumSize = new Size(400, 200);
            Name = "ConfirmRemove";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ConfirmRemove";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button YesBtn;
        private Guna.UI2.WinForms.Guna2Button NoBtn;
        private Label label1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}