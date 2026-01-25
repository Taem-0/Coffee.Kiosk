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
            label1 = new Label();
            CancelBtn = new Button();
            DeleteBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 67);
            label1.TabIndex = 0;
            label1.Text = "Are you sure you want to delete this category?";
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(135, 87);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(64, 36);
            CancelBtn.TabIndex = 5;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.Maroon;
            DeleteBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteBtn.ForeColor = Color.White;
            DeleteBtn.Location = new Point(205, 88);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(64, 35);
            DeleteBtn.TabIndex = 1;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // ConfirmDelete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 138);
            Controls.Add(DeleteBtn);
            Controls.Add(CancelBtn);
            Controls.Add(label1);
            MaximumSize = new Size(300, 185);
            MinimumSize = new Size(300, 185);
            Name = "ConfirmDelete";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Delete?";
            Load += ConfirmDelete_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button CancelBtn;
        private Button DeleteBtn;
    }
}