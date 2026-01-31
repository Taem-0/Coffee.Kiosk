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
            ModifierGroupName = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(20, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(530, 58);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.ControlAdded += flowLayoutPanel1_ControlAdded;
            // 
            // ModifierGroupName
            // 
            ModifierGroupName.Dock = DockStyle.Top;
            ModifierGroupName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ModifierGroupName.Location = new Point(20, 0);
            ModifierGroupName.Name = "ModifierGroupName";
            ModifierGroupName.Size = new Size(530, 25);
            ModifierGroupName.TabIndex = 0;
            ModifierGroupName.Text = "Modifier_Group_Name";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(20, 83);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(530, 0);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // ModalModifierGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(ModifierGroupName);
            Name = "ModalModifierGroup";
            Padding = new Padding(20, 0, 0, 0);
            Size = new Size(550, 83);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label ModifierGroupName;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
