using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms; 

namespace Coffee.Kiosk.CMS.Helpers
{
    internal static class UIhelp
    {

        public static void CallControl(UserControl control, Panel panel)
        {
            panel.SuspendLayout(); 
            panel.Controls.Clear();

            control.Dock = DockStyle.Fill;
            panel.Controls.Add(control);

            control.BringToFront();

            panel.ResumeLayout(true); 
            panel.PerformLayout();    
        }


        public static class EnumDisplayHelper
        {
            public static string FormatEnum(string value)
            {
                return System.Globalization.CultureInfo.CurrentCulture.TextInfo
                    .ToTitleCase(value.Replace("_", " ").ToLower());
            }
        }

        internal enum boxOrCircle
        {
            box,
            circle
        }

        [Flags]
        internal enum borderSide
        {
            None = 0,
            Top = 1,
            Bottom = 2,
            Left = 3,
            Right = 4,
            All = Top | Bottom | Left | Right
        }

        internal static void darkenOnHover(PaintEventArgs e, Rectangle stuffToHover, boxOrCircle shape)
        {
            using var brush = new SolidBrush(Color.FromArgb(67, Color.Black));
            if (shape == boxOrCircle.box)
            {
                e.Graphics.FillRectangle(brush, stuffToHover);
            }else
            {
                e.Graphics.FillEllipse(brush, stuffToHover);
            }
        }

        internal static void drawBorder(PaintEventArgs e, Rectangle rect, boxOrCircle shape, Color color, int thickness = 2)
        {
            using var pen = new Pen(color, thickness)
            {
                Alignment = System.Drawing.Drawing2D.PenAlignment.Inset
            };

            if (shape == boxOrCircle.box)
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
            else
            {
                e.Graphics.DrawEllipse(pen, rect);
            }
        }

        internal static void drawBorderSides(PaintEventArgs e, Rectangle rect, borderSide sides , Color color, int thickness = 2)
        {
            using var pen = new Pen(color, thickness)
            {
                Alignment = System.Drawing.Drawing2D.PenAlignment.Inset
            };
            if (sides.HasFlag(borderSide.Top)) e.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
            if (sides.HasFlag(borderSide.Bottom)) e.Graphics.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
            if (sides.HasFlag(borderSide.Left)) e.Graphics.DrawLine(pen, rect.Left, rect.Top, rect.Left, rect.Bottom);
            if (sides.HasFlag(borderSide.Right)) e.Graphics.DrawLine(pen, rect.Right, rect.Top, rect.Right, rect.Bottom);
        }

        // -------------------------------------------------------------------
        internal static void centerPanel(Panel outerPanel, Panel innerPanel, int heightDivideBy = 2, int widthDivideBy = 2, bool alignTop = false, bool alignBottom = false)
        {
            innerPanel.Left = alignBottom ? 0 : (outerPanel.ClientSize.Width - innerPanel.Width) / widthDivideBy;
            innerPanel.Top = alignTop ? 0 : (outerPanel.ClientSize.Height - innerPanel.Height) / heightDivideBy;
        }

        internal static void centerPanel(Panel outerPanel, Label innerPanel, int heightDivideBy = 2, int widthDivideBy = 2, bool alignTop = false, bool alignBottom = false)
        {
            innerPanel.Left = alignBottom ? 0 : (outerPanel.ClientSize.Width - innerPanel.Width) / widthDivideBy;
            innerPanel.Top = alignTop ? 0 : (outerPanel.ClientSize.Height - innerPanel.Height) / heightDivideBy;
        }

        internal static void centerPanel(Form outerPanel, Panel innerPanel, int heightDivideBy = 2, int widthDivideBy = 2, bool alignTop = false, bool alignBottom = false)
        {
            innerPanel.Left = alignBottom ? 0 : (outerPanel.ClientSize.Width - innerPanel.Width) / widthDivideBy;
            innerPanel.Top = alignTop ? 0 : (outerPanel.ClientSize.Height - innerPanel.Height) / heightDivideBy;
        }

        internal static void centerPanel(UserControl outerPanel, Panel innerPanel, int heightDivideBy = 2, int widthDivideBy = 2, bool alignTop = false, bool alignBottom = false)
        {
            innerPanel.Left = alignBottom ? 0 : (outerPanel.ClientSize.Width - innerPanel.Width) / widthDivideBy;
            innerPanel.Top = alignTop ? 0 : (outerPanel.ClientSize.Height - innerPanel.Height) / heightDivideBy;
        }

        internal static void centerPanel(Panel outerPanel, PictureBox innerPanel, int heightDivideBy = 2, int widthDivideBy = 2, bool alignTop = false, bool alignBottom = false)
        {
            innerPanel.Left = alignBottom ? 0 : (outerPanel.ClientSize.Width - innerPanel.Width) / widthDivideBy;
            innerPanel.Top = alignTop ? 0 : (outerPanel.ClientSize.Height - innerPanel.Height) / heightDivideBy;
        }

        internal static void centerPanel(UserControl outerPanel, PictureBox innerPanel, int heightDivideBy = 2, int widthDivideBy = 2, bool alignTop = false, bool alignBottom = false)
        {
            innerPanel.Left = alignBottom ? 0 : (outerPanel.ClientSize.Width - innerPanel.Width) / widthDivideBy;
            innerPanel.Top = alignTop ? 0 : (outerPanel.ClientSize.Height - innerPanel.Height) / heightDivideBy;
        }
        // -------------------------------------------------------------------

        internal static Image loadImageFromFile(string path) 
        { 
            return File.Exists(path) ? Image.FromFile(path) : Properties.Resources.default_icon; 
        }
    }
}
