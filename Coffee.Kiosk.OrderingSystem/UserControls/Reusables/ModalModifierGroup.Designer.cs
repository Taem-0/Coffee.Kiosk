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
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(550, 58);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.ControlAdded += flowLayoutPanel1_ControlAdded;
            // 
            // ModifierGroupName
            // 
            ModifierGroupName.Dock = DockStyle.Top;
            ModifierGroupName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ModifierGroupName.Location = new Point(0, 0);
            ModifierGroupName.Name = "ModifierGroupName";
            ModifierGroupName.Padding = new Padding(20, 0, 0, 0);
            ModifierGroupName.Size = new Size(550, 25);
            ModifierGroupName.TabIndex = 0;
            ModifierGroupName.Text = "Modifier_Group_Name";
            // 
            // ModalModifierGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(ModifierGroupName);
            Name = "ModalModifierGroup";
            Size = new Size(550, 83);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label ModifierGroupName;
    }
}
