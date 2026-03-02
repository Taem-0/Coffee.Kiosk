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
            flowMainGroup = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel1 = new Panel();
            ModifierGroupName = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowMainGroup
            // 
            flowMainGroup.AutoSize = true;
            flowMainGroup.Dock = DockStyle.Fill;
            flowMainGroup.Location = new Point(17, 34);
            flowMainGroup.Name = "flowMainGroup";
            flowMainGroup.Size = new Size(623, 97);
            flowMainGroup.TabIndex = 2;
            flowMainGroup.ControlAdded += flowMainGroup_ControlAdded;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(17, 131);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(623, 0);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(ModifierGroupName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(17, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(623, 34);
            panel1.TabIndex = 3;
            // 
            // ModifierGroupName
            // 
            ModifierGroupName.BackColor = Color.Transparent;
            ModifierGroupName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ModifierGroupName.Location = new Point(3, -1);
            ModifierGroupName.Name = "ModifierGroupName";
            ModifierGroupName.Size = new Size(444, 35);
            ModifierGroupName.TabIndex = 0;
            ModifierGroupName.Text = "Modifier_Group_Name";
            // 
            // ModifierGroup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowMainGroup);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel1);
            MinimumSize = new Size(600, 131);
            Name = "ModifierGroup";
            Padding = new Padding(17, 0, 0, 0);
            Size = new Size(640, 131);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowMainGroup;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel1;
        private Label ModifierGroupName;
    }
}
