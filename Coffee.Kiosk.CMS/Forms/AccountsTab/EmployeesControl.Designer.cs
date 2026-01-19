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
            EmployeeListView = new MaterialSkin.Controls.MaterialListView();
            addEmpButton = new Button();
            SuspendLayout();
            // 
            // EmployeeListView
            // 
            EmployeeListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EmployeeListView.AutoSizeTable = false;
            EmployeeListView.BackColor = Color.FromArgb(255, 255, 255);
            EmployeeListView.BorderStyle = BorderStyle.None;
            EmployeeListView.Depth = 0;
            EmployeeListView.FullRowSelect = true;
            EmployeeListView.Location = new Point(0, 55);
            EmployeeListView.MinimumSize = new Size(200, 100);
            EmployeeListView.MouseLocation = new Point(-1, -1);
            EmployeeListView.MouseState = MaterialSkin.MouseState.OUT;
            EmployeeListView.Name = "EmployeeListView";
            EmployeeListView.OwnerDraw = true;
            EmployeeListView.Size = new Size(880, 427);
            EmployeeListView.TabIndex = 3;
            EmployeeListView.UseCompatibleStateImageBehavior = false;
            EmployeeListView.View = View.Details;
            EmployeeListView.SelectedIndexChanged += EmployeeListView_SelectedIndexChanged;
            EmployeeListView.Resize += EmployeeListView_Resize;
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
            Controls.Add(EmployeeListView);
            Controls.Add(addEmpButton);
            Name = "EmployeesControl";
            Size = new Size(880, 482);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialListView EmployeeListView;
        private Button addEmpButton;
    }
}
