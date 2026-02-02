namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    partial class CategoryItem
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
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2ShadowPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(guna2Button1);
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.EdgeWidth = 1;
            guna2ShadowPanel1.FillColor = Color.White;
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 5;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.ShadowDepth = 48;
            guna2ShadowPanel1.Size = new Size(170, 145);
            guna2ShadowPanel1.TabIndex = 2;
            // 
            // guna2Button1
            // 
            guna2Button1.Animated = true;
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 13;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.SeaShell;
            guna2Button1.FocusedColor = Color.Tan;
            guna2Button1.Font = new Font("Arial Rounded MT Bold", 14.8F);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.HoverState.BorderColor = Color.Black;
            guna2Button1.HoverState.FillColor = Color.BurlyWood;
            guna2Button1.Image = Properties.Resources.default_icon;
            guna2Button1.ImageOffset = new Point(0, 13);
            guna2Button1.ImageSize = new Size(107, 107);
            guna2Button1.Location = new Point(3, 3);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.PressedDepth = 0;
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(164, 139);
            guna2Button1.TabIndex = 3;
            guna2Button1.Text = "Name";
            guna2Button1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            guna2Button1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase;
            guna2Button1.Tile = true;
            guna2Button1.UseTransparentBackground = true;
            guna2Button1.Click += guna2Button1_Click;
            // 
            // CategoryItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2ShadowPanel1);
            Name = "CategoryItem";
            Size = new Size(170, 145);
            guna2ShadowPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
