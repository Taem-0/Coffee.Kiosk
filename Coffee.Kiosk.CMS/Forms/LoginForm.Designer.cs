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
            loginPanel = new Guna.UI2.WinForms.Guna2Panel();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loginPanel.CustomizableEdges = customizableEdges1;
            loginPanel.Location = new Point(271, 285);
            loginPanel.Name = "loginPanel";
            loginPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            loginPanel.Size = new Size(900, 600);
            loginPanel.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1443, 1170);
            Controls.Add(loginPanel);
            Name = "LoginForm";
            Text = "LoginForm";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel loginPanel;
    }
}