namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.FormDialog
{
    partial class EditName
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
            txtName = new TextBox();
            SaveButton = new MaterialSkin.Controls.MaterialButton();
            CancelBtn = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(12, 23);
            txtName.Name = "txtName";
            txtName.Size = new Size(255, 34);
            txtName.TabIndex = 1;
            // 
            // SaveButton
            // 
            SaveButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            SaveButton.Depth = 0;
            SaveButton.HighEmphasis = true;
            SaveButton.Icon = null;
            SaveButton.Location = new Point(203, 87);
            SaveButton.Margin = new Padding(4, 6, 4, 6);
            SaveButton.MouseState = MaterialSkin.MouseState.HOVER;
            SaveButton.Name = "SaveButton";
            SaveButton.NoAccentTextColor = Color.Empty;
            SaveButton.Size = new Size(64, 36);
            SaveButton.TabIndex = 2;
            SaveButton.Text = "Save";
            SaveButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            SaveButton.UseAccentColor = false;
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(132, 87);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(64, 36);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelButton_Click;
            // 
            // EditName
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 138);
            Controls.Add(CancelBtn);
            Controls.Add(SaveButton);
            Controls.Add(txtName);
            MaximumSize = new Size(300, 185);
            MinimumSize = new Size(300, 185);
            Name = "EditName";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EditName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private MaterialSkin.Controls.MaterialButton SaveButton;
        private Button CancelBtn;
    }
}