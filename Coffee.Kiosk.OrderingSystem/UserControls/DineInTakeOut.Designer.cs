namespace Coffee.Kiosk.OrderingSystem
{
    partial class DineInTakeOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DineInTakeOut));
            DineInTakeOutLogo = new PictureBox();
            panel1 = new Panel();
            BackButton = new MaterialSkin.Controls.MaterialFloatingActionButton();
            panel2 = new Panel();
            panel3 = new Panel();
            TakeOut_Button = new PictureBox();
            panel4 = new Panel();
            DineIn_Button = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)DineInTakeOutLogo).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TakeOut_Button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DineIn_Button).BeginInit();
            SuspendLayout();
            // 
            // DineInTakeOutLogo
            // 
            DineInTakeOutLogo.Image = Properties.Resources.Tux;
            DineInTakeOutLogo.Location = new Point(158, 46);
            DineInTakeOutLogo.Margin = new Padding(0);
            DineInTakeOutLogo.Name = "DineInTakeOutLogo";
            DineInTakeOutLogo.Size = new Size(247, 178);
            DineInTakeOutLogo.SizeMode = PictureBoxSizeMode.Zoom;
            DineInTakeOutLogo.TabIndex = 1;
            DineInTakeOutLogo.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(DineInTakeOutLogo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 282);
            panel1.TabIndex = 2;
            // 
            // BackButton
            // 
            BackButton.AnimateShowHideButton = true;
            BackButton.Depth = 0;
            BackButton.DrawShadows = false;
            BackButton.Icon = (Image)resources.GetObject("BackButton.Icon");
            BackButton.Location = new Point(19, 20);
            BackButton.Margin = new Padding(0);
            BackButton.MouseState = MaterialSkin.MouseState.HOVER;
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(59, 61);
            BackButton.TabIndex = 2;
            BackButton.Text = "materialFloatingActionButton1";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            BackButton.Paint += BackButton_Paint;
            BackButton.MouseEnter += BackButton_MouseEnter;
            BackButton.MouseLeave += BackButton_MouseLeave;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 280);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(788, 340);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(TakeOut_Button);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(DineIn_Button);
            panel3.Location = new Point(176, 61);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(440, 217);
            panel3.TabIndex = 0;
            // 
            // TakeOut_Button
            // 
            TakeOut_Button.Dock = DockStyle.Left;
            TakeOut_Button.Image = Properties.Resources.TakeOut;
            TakeOut_Button.Location = new Point(238, 0);
            TakeOut_Button.Margin = new Padding(0);
            TakeOut_Button.Name = "TakeOut_Button";
            TakeOut_Button.Size = new Size(200, 217);
            TakeOut_Button.SizeMode = PictureBoxSizeMode.StretchImage;
            TakeOut_Button.TabIndex = 4;
            TakeOut_Button.TabStop = false;
            TakeOut_Button.Paint += TakeOut_Button_Paint;
            TakeOut_Button.MouseEnter += TakeOut_Button_MouseEnter;
            TakeOut_Button.MouseLeave += TakeOut_Button_MouseLeave;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(200, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(38, 217);
            panel4.TabIndex = 3;
            // 
            // DineIn_Button
            // 
            DineIn_Button.Dock = DockStyle.Left;
            DineIn_Button.Image = Properties.Resources.DineIn;
            DineIn_Button.Location = new Point(0, 0);
            DineIn_Button.Margin = new Padding(0);
            DineIn_Button.Name = "DineIn_Button";
            DineIn_Button.Size = new Size(200, 217);
            DineIn_Button.SizeMode = PictureBoxSizeMode.StretchImage;
            DineIn_Button.TabIndex = 2;
            DineIn_Button.TabStop = false;
            DineIn_Button.Paint += DineIn_Button_Paint;
            DineIn_Button.MouseEnter += DineIn_Button_MouseEnter;
            DineIn_Button.MouseLeave += DineIn_Button_MouseLeave;
            // 
            // DineInTakeOut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "DineInTakeOut";
            Size = new Size(788, 620);
            Load += DineInTakeOut_Load;
            Resize += DineInTakeOut_Resize;
            ((System.ComponentModel.ISupportInitialize)DineInTakeOutLogo).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TakeOut_Button).EndInit();
            ((System.ComponentModel.ISupportInitialize)DineIn_Button).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox DineInTakeOutLogo;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox TakeOut_Button;
        private Panel panel4;
        private PictureBox DineIn_Button;
        private MaterialSkin.Controls.MaterialFloatingActionButton BackButton;
    }
}
