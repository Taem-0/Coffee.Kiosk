namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    partial class ConfirmDelete
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            DeleteBtn = new Guna.UI2.WinForms.Guna2Button();
            CancelBtn = new Guna.UI2.WinForms.Guna2Button();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(53, 53, 53);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(340, 92);
            label1.TabIndex = 0;
            label1.Text = "Are you sure you want to delete this ?";
            // 
            // DeleteBtn
            // 
            DeleteBtn.BorderRadius = 10;
            DeleteBtn.CustomizableEdges = customizableEdges1;
            DeleteBtn.DisabledState.BorderColor = Color.DarkGray;
            DeleteBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            DeleteBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            DeleteBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            DeleteBtn.FillColor = Color.Brown;
            DeleteBtn.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteBtn.ForeColor = Color.LightGray;
            DeleteBtn.Location = new Point(230, 126);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            DeleteBtn.Size = new Size(122, 47);
            DeleteBtn.TabIndex = 6;
            DeleteBtn.Text = "Delete";
            DeleteBtn.Click += guna2Button1_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Transparent;
            CancelBtn.BorderColor = Color.DimGray;
            CancelBtn.BorderRadius = 10;
            CancelBtn.BorderThickness = 1;
            CancelBtn.CustomizableEdges = customizableEdges3;
            CancelBtn.DisabledState.BorderColor = Color.DarkGray;
            CancelBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            CancelBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            CancelBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            CancelBtn.FillColor = Color.White;
            CancelBtn.Font = new Font("Verdana", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CancelBtn.ForeColor = Color.DimGray;
            CancelBtn.Location = new Point(100, 126);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            CancelBtn.ShadowDecoration.Depth = 15;
            CancelBtn.ShadowDecoration.Enabled = true;
            CancelBtn.Size = new Size(124, 47);
            CancelBtn.TabIndex = 7;
            CancelBtn.Text = "Cancel";
            CancelBtn.Click += guna2Button1_Click_1;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 30;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockForm = false;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ConfirmDelete
            // 
            AcceptButton = DeleteBtn;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(364, 185);
            Controls.Add(CancelBtn);
            Controls.Add(DeleteBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(300, 185);
            Name = "ConfirmDelete";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Delete?";
            Load += ConfirmDelete_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button DeleteBtn;
        private Guna.UI2.WinForms.Guna2Button CancelBtn;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}