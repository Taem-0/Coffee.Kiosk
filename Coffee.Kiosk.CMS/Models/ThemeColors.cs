using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee.Kiosk.CMS.Helpers
{
    public static class ThemeColors
    {
        // Your provided colors
        public static Color DarkBrown = ColorTranslator.FromHtml("#3d211a");
        public static Color MediumBrown = ColorTranslator.FromHtml("#6f4d38");
        public static Color LightBrown = ColorTranslator.FromHtml("#a07856");
        public static Color Beige = ColorTranslator.FromHtml("#cbb799");
        public static Color Background = ColorTranslator.FromHtml("#f5f5dc");

        // Default colors (fallbacks)
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
}