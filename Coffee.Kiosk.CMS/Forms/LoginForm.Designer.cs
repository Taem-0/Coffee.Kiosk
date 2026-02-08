namespace Coffee.Kiosk.CMS.Forms
{
    partial class LoginForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            loginPanel = new Guna.UI2.WinForms.Guna2Panel();
            guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.None;
            loginPanel.BackColor = SystemColors.ButtonFace;
            loginPanel.CustomizableEdges = customizableEdges1;
            loginPanel.FillColor = Color.Transparent;
            loginPanel.Location = new Point(271, 285);
            loginPanel.Name = "loginPanel";
            loginPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            loginPanel.Size = new Size(900, 600);
            loginPanel.TabIndex = 0;
            // 
            // guna2ContainerControl1
            // 
            guna2ContainerControl1.Anchor = AnchorStyles.None;
            guna2ContainerControl1.BackColor = SystemColors.ButtonFace;
            guna2ContainerControl1.BorderRadius = 10;
            guna2ContainerControl1.CustomizableEdges = customizableEdges3;
            guna2ContainerControl1.Location = new Point(261, 275);
            guna2ContainerControl1.Name = "guna2ContainerControl1";
            guna2ContainerControl1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ContainerControl1.Size = new Size(920, 620);
            guna2ContainerControl1.TabIndex = 1;
            guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1443, 1170);
            Controls.Add(loginPanel);
            Controls.Add(guna2ContainerControl1);
            Name = "LoginForm";
            WindowState = FormWindowState.Maximized;
            Load += LoginForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel loginPanel;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
    }
}