namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls.Modifiers
{
    partial class ModifierChildGroup
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
            flowMainGroup = new FlowLayoutPanel();
            flowChildGroup = new FlowLayoutPanel();
            panel1 = new Panel();
            ModifierGroupName = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowMainGroup
            // 
            flowMainGroup.AutoSize = true;
            flowMainGroup.Dock = DockStyle.Fill;
            flowMainGroup.Location = new Point(0, 32);
            flowMainGroup.Name = "flowMainGroup";
            flowMainGroup.Size = new Size(729, 42);
            flowMainGroup.TabIndex = 2;
            // 
            // flowChildGroup
            // 
            flowChildGroup.AutoSize = true;
            flowChildGroup.Dock = DockStyle.Bottom;
            flowChildGroup.Location = new Point(0, 74);
            flowChildGroup.Name = "flowChildGroup";
            flowChildGroup.Size = new Size(729, 0);
            flowChildGroup.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(ModifierGroupName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(729, 32);
            panel1.TabIndex = 3;
            // 
            // ModifierGroupName
            // 
            ModifierGroupName.BackColor = Color.Transparent;
            ModifierGroupName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ModifierGroupName.Location = new Point(3, -1);
            ModifierGroupName.Name = "ModifierGroupName";
            ModifierGroupName.Size = new Size(444, 25);
            ModifierGroupName.TabIndex = 0;
            ModifierGroupName.Text = "Modifier_Group_Name";
            // 
            // ModifierChildGroup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowMainGroup);
            Controls.Add(flowChildGroup);
            Controls.Add(panel1);
            Name = "ModifierChildGroup";
            Size = new Size(729, 74);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowMainGroup;
        private FlowLayoutPanel flowChildGroup;
        private Panel panel1;
        private Label ModifierGroupName;
    }
}
