using Coffee.Kiosk.CMS.Controllers;
using Coffee.Kiosk.CMS.Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Helpers
{
    internal static class UIhelp
    {

        public class UITheme
        {
            public Color DarkPrimary { get; }
            public Color Primary { get; }
            public Color Secondary { get; }
            public Color Background { get; }
            public Color Accent { get; }

            public UITheme(Theme theme)
            {
                DarkPrimary = ColorTranslator.FromHtml(theme.DarkPrimaryColor);
                Primary = ColorTranslator.FromHtml(theme.PrimaryColor);
                Secondary = ColorTranslator.FromHtml(theme.SecondaryColor);
                Background = ColorTranslator.FromHtml(theme.Background);
                Accent = ColorTranslator.FromHtml(theme.Accent);
            }
        }

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
            Left = 4,      // Fixed: Changed from 3 to 4
            Right = 8,     // Fixed: Changed from 4 to 8
            All = Top | Bottom | Left | Right
        }

        internal static void darkenOnHover(PaintEventArgs e, Rectangle stuffToHover, boxOrCircle shape)
        {
            using var brush = new SolidBrush(Color.FromArgb(67, Color.Black));
            if (shape == boxOrCircle.box)
            {
                e.Graphics.FillRectangle(brush, stuffToHover);
            }
            else
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

        internal static void drawBorderSides(PaintEventArgs e, Rectangle rect, borderSide sides, Color color, int thickness = 2)
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


        //Delete later, new "Universal" theme manager is set. Only for settingsView thoughhh
        public static class ThemeColors
        {
            public static Color DarkBrown = ColorTranslator.FromHtml("#3d211a");
            public static Color MediumBrown = ColorTranslator.FromHtml("#6f4d38");
            public static Color LightBrown = ColorTranslator.FromHtml("#a07856");
            public static Color Beige = ColorTranslator.FromHtml("#cbb799");
            public static Color Background = ColorTranslator.FromHtml("#f5f5dc");

            public static Color TextColor = DarkBrown;
            public static Color ButtonColor = MediumBrown;
            public static Color ButtonHover = LightBrown;
            public static Color BorderColor = MediumBrown;
            public static Color PanelColor = Beige;
            public static Color GridHeaderColor = MediumBrown;
            public static Color GridAlternateRow = Beige;

            // Common control states
            public static Color DisabledColor = Color.FromArgb(200, 200, 200);
            public static Color ErrorColor = Color.FromArgb(220, 80, 80);
            public static Color SuccessColor = Color.FromArgb(80, 180, 80);
        }

        public static class ThemeManager
        {
            public static void ApplyTheme(Control root, UITheme theme)
            {
                if (theme == null) return;

                var darkPrimary = theme.DarkPrimary;
                var primary = theme.Primary;
                var secondary = theme.Secondary;
                var background = theme.Background;
                var accent = theme.Accent;

                root.BackColor = background;
                root.ForeColor = darkPrimary;

                ApplyRecursive(root, darkPrimary, primary, secondary, background, accent);
            }

            public static UITheme BuildUITheme(ThemeController controller, bool useCustom)
            {
                if (controller == null)
                    throw new ArgumentNullException(nameof(controller));

                var theme = controller.GetTheme(useCustom);
                return new UITheme(theme);
            }

            private static void ApplyRecursive(
                Control parent,
                Color darkPrimary,
                Color primary,
                Color secondary,
                Color background,
                Color accent)
            {
                foreach (Control control in parent.Controls)
                {
                    ApplyToSingleControl(control, darkPrimary, primary, secondary, background, accent);

                    if (control.HasChildren)
                        ApplyRecursive(control, darkPrimary, primary, secondary, background, accent);
                }
            }

            private static void ApplyToSingleControl(
                Control control,
                Color darkPrimary,
                Color primary,
                Color secondary,
                Color background,
                Color accent)
            {
                switch (control)
                {
                    case Guna2Panel panel:
                        panel.FillColor = background;
                        panel.BorderColor = primary;
                        break;

                    case Guna2Button button:
                        button.FillColor = primary;
                        button.ForeColor = Color.White;
                        button.BorderColor = darkPrimary;
                        button.BorderThickness = 1;
                        button.BorderRadius = 6;

                        button.HoverState.FillColor = secondary;
                        button.HoverState.BorderColor = darkPrimary;
                        button.PressedColor = darkPrimary;
                        break;

                    case Guna2VScrollBar scroll:
                        scroll.ThumbColor = primary;
                        scroll.FillColor = background;
                        break;

                    case Guna2TabControl tab:
                        tab.TabButtonHoverState.FillColor = secondary;
                        tab.TabButtonHoverState.ForeColor = Color.White;
                        tab.TabButtonHoverState.InnerColor = secondary;

                        tab.TabButtonIdleState.FillColor = primary;
                        tab.TabButtonIdleState.ForeColor = Color.White;
                        tab.TabButtonIdleState.InnerColor = primary;

                        tab.TabButtonSelectedState.FillColor = darkPrimary;
                        tab.TabButtonSelectedState.ForeColor = Color.White;
                        tab.TabButtonSelectedState.InnerColor = darkPrimary;

                        tab.TabMenuBackColor = primary;
                        break;

                    case Label label:
                        label.ForeColor = darkPrimary;
                        label.BackColor = Color.Transparent;
                        break;

                    case Panel panel2:
                        panel2.BackColor = background;
                        break;

                    default:
                        control.BackColor = background;
                        control.ForeColor = darkPrimary;
                        break;
                }
            }
        } 

    }
}