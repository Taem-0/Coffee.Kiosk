namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab.UserControls
{
    partial class CategoryItem
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            CategoryName = new Label();
            CategoryIdLabel = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            EditName = new ToolStripMenuItem();
            ChangeImage = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            Cancel = new ToolStripMenuItem();
            materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.default_icon;
            pictureBox1.Location = new Point(47, 7);
            pictureBox1.Margin = new Padding(15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += pictureBox1_MouseLeave;
            // 
            // CategoryName
            // 
            CategoryName.AutoSize = true;
            CategoryName.Font = new Font("Impact", 16.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CategoryName.Location = new Point(165, 7);
            CategoryName.Name = "CategoryName";
            CategoryName.Size = new Size(218, 36);
            CategoryName.TabIndex = 1;
            CategoryName.Text = "category_name";
            CategoryName.Click += CategoryName_Click;
            CategoryName.Paint += CategoryName_Paint;
            CategoryName.MouseEnter += CategoryName_MouseEnter;
            CategoryName.MouseLeave += CategoryName_MouseLeave;
            // 
            // CategoryIdLabel
            // 
            CategoryIdLabel.AutoSize = true;
            CategoryIdLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CategoryIdLabel.Location = new Point(3, 43);
            CategoryIdLabel.Name = "CategoryIdLabel";
            CategoryIdLabel.Size = new Size(29, 28);
            CategoryIdLabel.TabIndex = 2;
            CategoryIdLabel.Text = "0.";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { EditName, ChangeImage, deleteToolStripMenuItem, Cancel });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(175, 100);
            // 
            // EditName
            // 
            EditName.Name = "EditName";
            EditName.Size = new Size(174, 24);
            EditName.Text = "Edit Name";
            EditName.Click += EditName_Click;
            // 
            // ChangeImage
            // 
            ChangeImage.Name = "ChangeImage";
            ChangeImage.Size = new Size(174, 24);
            ChangeImage.Text = "Change Image";
            ChangeImage.Click += ChangeImage_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(174, 24);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // Cancel
            // 
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(174, 24);
            Cancel.Text = "Cancel";
            // 
            // materialSwitch1
            // 
            materialSwitch1.AutoSize = true;
            materialSwitch1.CheckAlign = ContentAlignment.MiddleRight;
            materialSwitch1.Depth = 0;
            materialSwitch1.Location = new Point(162, 70);
            materialSwitch1.Margin = new Padding(0);
            materialSwitch1.MouseLocation = new Point(-1, -1);
            materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch1.Name = "materialSwitch1";
            materialSwitch1.Ripple = true;
            materialSwitch1.Size = new Size(107, 37);
            materialSwitch1.TabIndex = 3;
            materialSwitch1.Text = "Shown";
            materialSwitch1.UseVisualStyleBackColor = true;
            materialSwitch1.Click += materialSwitch1_Click;
            // 
            // CategoryItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(materialSwitch1);
            Controls.Add(CategoryName);
            Controls.Add(pictureBox1);
            Controls.Add(CategoryIdLabel);
            Name = "CategoryItem";
            Size = new Size(482, 115);
            Paint += CategoryItem_Paint;
            DoubleClick += CategoryItem_DoubleClick;
            KeyDown += CategoryItem_KeyDown;
            MouseEnter += CategoryItem_MouseEnter;
            MouseLeave += CategoryItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label CategoryName;
        private Label CategoryIdLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem EditName;
        private ToolStripMenuItem ChangeImage;
        private ToolStripMenuItem Cancel;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
    }
}
