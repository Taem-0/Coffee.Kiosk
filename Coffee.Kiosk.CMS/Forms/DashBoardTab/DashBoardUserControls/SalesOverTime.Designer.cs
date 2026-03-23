namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class SalesOverTime
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
            salesOTplot = new ScottPlot.WinForms.FormsPlot();
            SuspendLayout();
            // 
            // salesOTplot
            // 
            salesOTplot.DisplayScale = 1.5F;
            salesOTplot.Dock = DockStyle.Fill;
            salesOTplot.Location = new Point(0, 0);
            salesOTplot.Name = "salesOTplot";
            salesOTplot.Size = new Size(940, 270);
            salesOTplot.TabIndex = 6;
            salesOTplot.Load += salesOTplot_Load;
            // 
            // SalesOverTime
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(salesOTplot);
            Name = "SalesOverTime";
            Size = new Size(940, 270);
            Load += SalesOverTime_Load;
            ResumeLayout(false);
        }

        #endregion
        private ScottPlot.WinForms.FormsPlot salesOTplot;
    }
}
