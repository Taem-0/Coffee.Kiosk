using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Kiosk.OrderingSystem
{
    internal class UI_Handling
    {
        internal static void loadUserControl(Panel mainScreen, UserControl userControl)
        {

            for (int i = 0; i < mainScreen.Controls.Count; i++) { mainScreen.Controls[i].Dispose(); }

            mainScreen.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            mainScreen.Controls.Add(userControl);
        }

        internal static void centerPanel(Panel outerPanel, Panel innerPanel)
        {
            innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) / 2;
            innerPanel.Top = (outerPanel.ClientSize.Height - innerPanel.Height) / 2;
        }

        internal static void centerPanel(Form outerPanel, Panel innerPanel)
        {
            innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) / 2;
            innerPanel.Top = (outerPanel.ClientSize.Height - innerPanel.Height) / 2;
        }

        internal static void centerPanel(UserControl outerPanel, Panel innerPanel)
        {
            innerPanel.Left = (outerPanel.ClientSize.Width - innerPanel.Width) / 2;
            innerPanel.Top = (outerPanel.ClientSize.Height - innerPanel.Height) / 2;
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


}
