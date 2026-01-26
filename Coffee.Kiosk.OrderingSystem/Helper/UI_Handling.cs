using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.OrderingSystem.Helper
{
    internal class UI_Handling
    {
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
            Left = 4,
            Right = 8,
            All = Top | Bottom | Left | Right
        }

        internal static void loadUserControl(Panel mainScreen, UserControl userControl)
        {
                mainScreen.Controls.Clear();
                userControl.Dock = DockStyle.Fill;
                mainScreen.Controls.Add(userControl);
        }

        internal static void fixVisualShifts(UserControl e)
        {
            e.AutoScaleMode = AutoScaleMode.None;
            e.Font = SystemFonts.MessageBoxFont;
        }

        internal static void materialDrawer(MaterialForm e, MaterialTabControl materialControl, bool shown)
        {
            materialControl.Visible = shown;
            e.FormStyle = shown ? MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_40 : MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None; 
            e.DrawerIsOpen = false;
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

        internal static void centerPanelfix(UserControl outerPanel, Panel innerPanel)
        {
            innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) / 2;
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
    }

    internal class UI_ColorScheme
    {

        private static MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        internal static void initializeMaterialSkinThemes()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                ColorTranslator.FromHtml("#6F4D38"),
                ColorTranslator.FromHtml("#3D211A"),
                ColorTranslator.FromHtml("#6F4D38"),
                ColorTranslator.FromHtml("#CBB799"),
                TextShade.WHITE
            );
        }

        internal static Color Primary => MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
        internal static Color DarkPrimary => MaterialSkinManager.Instance.ColorScheme.DarkPrimaryColor;
        internal static Color LightPrimary => MaterialSkinManager.Instance.ColorScheme.LightPrimaryColor;
        internal static Color Accent => MaterialSkinManager.Instance.ColorScheme.AccentColor;
        internal static Color Text => MaterialSkinManager.Instance.ColorScheme.TextColor;
    }

    internal class UI_Images
    {
        // !!IMPORTANT!! CHANGE LATER FOR DATABASE 
        private static string logoPath = "C:/Images/Logo.png";
        internal static Image logoImage = Properties.Resources.default_icon;

        internal static void loadLogoImage()
        {
            if (File.Exists(logoPath))
                logoImage = Image.FromFile(logoPath);
            else
                logoImage = Properties.Resources.default_icon;
        }
        internal static Image loadImageFromFile(string path) 
        { 
            return File.Exists(path) ? Image.FromFile(path) : Properties.Resources.default_icon; 
        }

    }
}
