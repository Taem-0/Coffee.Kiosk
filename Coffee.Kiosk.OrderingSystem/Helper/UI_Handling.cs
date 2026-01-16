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

        internal static void loadUserControl(Panel mainScreen, UserControl userControl, bool clearUserControls = false)
        {

            if (clearUserControls)
            {
                for (int i = 0; i < mainScreen.Controls.Count; i++) { mainScreen.Controls[i].Dispose(); }
            }
                mainScreen.Controls.Clear();
                userControl.Dock = DockStyle.Fill;
                mainScreen.Controls.Add(userControl);
        }

        internal static void centerPanel(Panel outerPanel, Panel innerPanel, int heightDivideBy = 2, int widthDivideBy = 2, bool alignTop = false, bool alignBottom = false)
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
        private static string logoPathFallback = "../../../Resources/Tux.png";

        internal static string logoImage()
        {
            //if (File.Exists(logoPath))
            //{
            //    return logoPath;
            //}
            //return logoPathFallback;

            return File.Exists(logoPath) ? logoPath : logoPathFallback; 
        }
    }
}
