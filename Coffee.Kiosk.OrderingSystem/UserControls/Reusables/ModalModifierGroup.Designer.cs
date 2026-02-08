namespace Coffee.Kiosk.OrderingSystem.UserControls.Reusables
{
    partial class ModalModifierGroup
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            ModifierGroupName = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(20, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(540, 69);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.ControlAdded += flowLayoutPanel1_ControlAdded;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(20, 93);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(540, 0);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // ModifierGroupName
            // 
            ModifierGroupName.BackColor = Color.Transparent;
            ModifierGroupName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ModifierGroupName.Location = new Point(3, -1);
            ModifierGroupName.Name = "ModifierGroupName";
            ModifierGroupName.Size = new Size(534, 25);
            ModifierGroupName.TabIndex = 0;
            ModifierGroupName.Text = "Modifier_Group_Name";
            ModifierGroupName.Click += ModifierGroupName_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ModifierGroupName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(20, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 24);
            panel1.TabIndex = 0;
            // 
            // ModalModifierGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 3, 3, 10);
            MinimumSize = new Size(560, 17);
            Name = "ModalModifierGroup";
            Padding = new Padding(20, 0, 0, 0);
            Size = new Size(560, 93);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label ModifierGroupName;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel1;
    }
}
