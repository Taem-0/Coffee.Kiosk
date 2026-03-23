namespace Coffee.Kiosk.CMS.Forms.SettingsTab.SettingsUserControls
{
    partial class JobTitleList
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
            guna2vScrollBar4 = new Guna.UI2.WinForms.Guna2VScrollBar();
            flowLayoutPanel1 = new FlowLayoutPanel();
            jobTitleCard1 = new JobTitleCard();
            guna2vScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2vScrollBar4
            // 
            guna2vScrollBar4.BindingContainer = this;
            guna2vScrollBar4.BorderRadius = 6;
            guna2vScrollBar4.FillOffset = new Padding(10, 10, 0, 10);
            guna2vScrollBar4.InUpdate = false;
            guna2vScrollBar4.LargeChange = 10;
            guna2vScrollBar4.Location = new Point(836, 22);
            guna2vScrollBar4.Name = "guna2vScrollBar4";
            guna2vScrollBar4.Padding = new Padding(10, 10, 0, 10);
            guna2vScrollBar4.ScrollbarSize = 16;
            guna2vScrollBar4.Size = new Size(26, 400);
            guna2vScrollBar4.TabIndex = 8;
            guna2vScrollBar4.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(jobTitleCard1);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(837, 400);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // jobTitleCard1
            // 
            jobTitleCard1.Location = new Point(3, 3);
            jobTitleCard1.Name = "jobTitleCard1";
            jobTitleCard1.Size = new Size(802, 58);
            jobTitleCard1.TabIndex = 0;
            // 
            // guna2vScrollBar1
            // 
            guna2vScrollBar1.BindingContainer = flowLayoutPanel1;
            guna2vScrollBar1.BorderRadius = 6;
            guna2vScrollBar1.FillOffset = new Padding(10, 10, 0, 10);
            guna2vScrollBar1.InUpdate = false;
            guna2vScrollBar1.LargeChange = 10;
            guna2vScrollBar1.Location = new Point(811, 0);
            guna2vScrollBar1.Name = "guna2vScrollBar1";
            guna2vScrollBar1.Padding = new Padding(10, 10, 0, 10);
            guna2vScrollBar1.ScrollbarSize = 16;
            guna2vScrollBar1.Size = new Size(26, 397);
            guna2vScrollBar1.TabIndex = 8;
            // 
            // JobTitleList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(guna2vScrollBar1);
            Controls.Add(flowLayoutPanel1);
            Name = "JobTitleList";
            Size = new Size(840, 400);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2VScrollBar guna2vScrollBar4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2vScrollBar1;
        private JobTitleCard jobTitleCard1;
    }
}
