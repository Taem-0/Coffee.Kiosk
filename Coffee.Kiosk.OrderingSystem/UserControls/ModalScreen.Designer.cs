namespace Coffee.Kiosk.OrderingSystem.UserControls
{
    partial class ModalScreen
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
            mainModalScreen = new Panel();
            SuspendLayout();
            // 
            // mainModalScreen
            // 
            mainModalScreen.Dock = DockStyle.Fill;
            mainModalScreen.Location = new Point(0, 0);
            mainModalScreen.Name = "mainModalScreen";
            mainModalScreen.Size = new Size(598, 597);
            mainModalScreen.TabIndex = 1;
            // 
            // ModalScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainModalScreen);
            Name = "ModalScreen";
            Size = new Size(598, 597);
            ResumeLayout(false);
        }

        #endregion
        private Panel mainModalScreen;
    }
}
