namespace Coffee.Kiosk.CMS.Forms.OrderingSystemTab
{
    partial class OrderingSystemMainControl
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
            MainScreen = new Panel();
            SuspendLayout();
            // 
            // MainScreen
            // 
            MainScreen.Dock = DockStyle.Fill;
            MainScreen.Location = new Point(0, 0);
            MainScreen.Name = "MainScreen";
            MainScreen.Size = new Size(1008, 657);
            MainScreen.TabIndex = 2;
            // 
            // OrderingSystemMainControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MainScreen);
            Name = "OrderingSystemMainControl";
            Size = new Size(1008, 657);
            Load += OrderingSystemMainControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel MainScreen;
    }
}
