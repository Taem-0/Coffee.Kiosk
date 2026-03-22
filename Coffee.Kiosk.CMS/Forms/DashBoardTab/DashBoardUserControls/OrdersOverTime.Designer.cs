namespace Coffee.Kiosk.CMS.Forms.DashBoardTab.DashBoardUserControls
{
    partial class OrdersOverTime
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
            ordersOTplot = new ScottPlot.WinForms.FormsPlot();
            SuspendLayout();
            // 
            // ordersOTplot
            // 
            ordersOTplot.DisplayScale = 1.5F;
            ordersOTplot.Dock = DockStyle.Fill;
            ordersOTplot.Location = new Point(0, 0);
            ordersOTplot.Name = "ordersOTplot";
            ordersOTplot.Size = new Size(940, 270);
            ordersOTplot.TabIndex = 7;
            ordersOTplot.Load += ordersOTplot_Load;
            // 
            // OrdersOverTime
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ordersOTplot);
            Name = "OrdersOverTime";
            Size = new Size(940, 270);
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot ordersOTplot;
    }
}
