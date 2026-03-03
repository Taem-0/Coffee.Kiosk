namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls.Modifiers
{
    partial class ModifierGroup
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
            flowMainGroup = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel1 = new Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ModifierGroupName = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowMainGroup
            // 
            flowMainGroup.AutoSize = true;
            flowMainGroup.Dock = DockStyle.Fill;
            flowMainGroup.Location = new Point(0, 34);
            flowMainGroup.Name = "flowMainGroup";
            flowMainGroup.Size = new Size(674, 66);
            flowMainGroup.TabIndex = 2;
            flowMainGroup.ControlAdded += flowMainGroup_ControlAdded;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 100);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(674, 0);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(guna2Button1);
            panel1.Controls.Add(ModifierGroupName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(674, 34);
            panel1.TabIndex = 3;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Gainsboro;
            guna2Button1.BorderRadius = 7;
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.Transparent;
            guna2Button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Image = Properties.Resources._3_dots;
            guna2Button1.ImageSize = new Size(30, 30);
            guna2Button1.Location = new Point(637, 0);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(34, 36);
            guna2Button1.TabIndex = 5;
            guna2Button1.Tile = true;
            // 
            // ModifierGroupName
            // 
            ModifierGroupName.BackColor = Color.Gainsboro;
            ModifierGroupName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ModifierGroupName.Location = new Point(3, -1);
            ModifierGroupName.Name = "ModifierGroupName";
            ModifierGroupName.Size = new Size(672, 35);
            ModifierGroupName.TabIndex = 0;
            ModifierGroupName.Text = "Modifier_Group_Name";
            // 
            // ModifierGroup
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(flowMainGroup);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel1);
            MinimumSize = new Size(674, 100);
            Name = "ModifierGroup";
            Size = new Size(674, 100);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowMainGroup;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel1;
        private Label ModifierGroupName;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
