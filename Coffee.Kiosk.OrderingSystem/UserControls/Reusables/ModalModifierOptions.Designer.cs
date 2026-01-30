namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    partial class ModalModifierOptions
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderColor = Color.DimGray;
            guna2Button1.BorderRadius = 7;
            guna2Button1.BorderThickness = 1;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DefaultAutoSize = true;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.WhiteSmoke;
            guna2Button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Location = new Point(1, 3);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.Padding = new Padding(0, 5, 0, 5);
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(194, 40);
            guna2Button1.TabIndex = 0;
            guna2Button1.Text = "Modifier_Options_Name";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // ModalModifierOptions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(guna2Button1);
            Name = "ModalModifierOptions";
            Size = new Size(198, 46);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
