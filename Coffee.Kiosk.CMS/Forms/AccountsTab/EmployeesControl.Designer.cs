namespace Coffee.Kiosk.CMS
{
    partial class EmployeesControl
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
            materialListView1 = new MaterialSkin.Controls.MaterialListView();
            addEmpButton = new Button();
            SuspendLayout();
            // 
            // materialListView1
            // 
            materialListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialListView1.AutoSizeTable = false;
            materialListView1.BackColor = Color.FromArgb(255, 255, 255);
            materialListView1.BorderStyle = BorderStyle.None;
            materialListView1.Depth = 0;
            materialListView1.FullRowSelect = true;
            materialListView1.Location = new Point(4, 48);
            materialListView1.MinimumSize = new Size(200, 100);
            materialListView1.MouseLocation = new Point(-1, -1);
            materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            materialListView1.Name = "materialListView1";
            materialListView1.OwnerDraw = true;
            materialListView1.Size = new Size(872, 427);
            materialListView1.TabIndex = 3;
            materialListView1.UseCompatibleStateImageBehavior = false;
            materialListView1.View = View.Details;
            // 
            // addEmpButton
            // 
            addEmpButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addEmpButton.Location = new Point(718, 7);
            addEmpButton.Name = "addEmpButton";
            addEmpButton.Size = new Size(158, 35);
            addEmpButton.TabIndex = 2;
            addEmpButton.Text = "+ Add Employee";
            addEmpButton.UseVisualStyleBackColor = true;
            addEmpButton.Click += addEmpButton_Click;
            // 
            // EmployeesControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialListView1);
            Controls.Add(addEmpButton);
            Name = "EmployeesControl";
            Size = new Size(880, 482);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialListView materialListView1;
        private Button addEmpButton;
    }
}
