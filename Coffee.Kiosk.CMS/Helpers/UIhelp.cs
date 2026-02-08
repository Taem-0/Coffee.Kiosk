using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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

        // ===================================================================
        // THEME SYSTEM - ADDED HERE
        // ===================================================================

        /// <summary>
        /// Contains all the theme colors you specified
        /// </summary>
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

        /// <summary>
        /// Applies theme to forms and controls automatically
        /// </summary>
        public static class ThemeApplier
        {
            /// <summary>
            /// Applies theme to a form and all its child controls - ONE LINER!
            /// </summary>
            public static void ApplyThemeToForm(Form form, bool applyToChildren = true)
            {
                form.BackColor = ThemeColors.Background;
                form.ForeColor = ThemeColors.TextColor;

                if (applyToChildren)
                {
                    ApplyThemeToControl(form, form.Controls);
                }
            }

            /// <summary>
            /// Applies theme to a UserControl and all its child controls - ONE LINER!
            /// </summary>
            public static void ApplyThemeToUserControl(UserControl userControl)
            {
                userControl.BackColor = ThemeColors.Background;
                ApplyThemeToControl(userControl, userControl.Controls);
            }

            /// <summary>
            /// Applies theme to a specific control and its children
            /// </summary>
            public static void ApplyThemeToControl(Control parentControl, Control.ControlCollection controls)
            {
                foreach (Control control in controls)
                {
                    try
                    {
                        ApplyThemeToSingleControl(control);

                        // Recursively apply to child controls
                        if (control.HasChildren)
                        {
                            ApplyThemeToControl(control, control.Controls);
                        }
                    }
                    catch
                    {
                        // Silent fail
                    }
                }
            }

            /// <summary>
            /// Applies theme to a single control based on its type
            /// </summary>
            private static void ApplyThemeToSingleControl(Control control)
            {
                // Handle specific controls first
                if (control is Guna2DataGridView dataGridView)
                {
                    ApplyThemeToDataGridView(dataGridView);
                }
                else if (control is Guna2Panel guna2Panel)
                {
                    guna2Panel.FillColor = ThemeColors.PanelColor;
                    guna2Panel.BorderColor = ThemeColors.BorderColor;
                }
                else if (control is Guna2CustomGradientPanel gradientPanel)
                {
                    gradientPanel.FillColor = ThemeColors.PanelColor;
                    gradientPanel.FillColor2 = ThemeColors.Beige;
                    gradientPanel.FillColor3 = ThemeColors.Beige;
                    gradientPanel.FillColor4 = ThemeColors.PanelColor;
                    gradientPanel.BorderColor = ThemeColors.BorderColor;
                }
                else if (control is Guna2Button guna2Button)
                {
                    guna2Button.FillColor = ThemeColors.ButtonColor;
                    guna2Button.ForeColor = Color.White;
                    guna2Button.BorderColor = ThemeColors.BorderColor;
                }
                else if (control is Guna2TextBox guna2TextBox)
                {
                    // FIXED: Simplified Guna2TextBox theming - only set colors, don't mess with effects
                    guna2TextBox.FillColor = ThemeColors.Background;
                    guna2TextBox.ForeColor = ThemeColors.TextColor;
                    guna2TextBox.BorderColor = ThemeColors.BorderColor;
                    guna2TextBox.FocusedState.BorderColor = ThemeColors.LightBrown;

                    // Clear any shadow effects that might be causing weird borders
                    guna2TextBox.ShadowDecoration.Enabled = false;

                    // Make sure placeholder text is visible
                    guna2TextBox.PlaceholderForeColor = Color.Gray;
                }
                else if (control is Guna2ComboBox guna2ComboBox)
                {
                    guna2ComboBox.FillColor = ThemeColors.Background;
                    guna2ComboBox.ForeColor = ThemeColors.TextColor;
                    guna2ComboBox.BorderColor = ThemeColors.BorderColor;
                }
                // Then handle base controls
                else
                {
                    switch (control)
                    {
                        case Label label:
                            label.ForeColor = ThemeColors.TextColor;
                            break;

                        case Button button:
                            button.BackColor = ThemeColors.ButtonColor;
                            button.ForeColor = Color.White;
                            button.FlatAppearance.BorderColor = ThemeColors.BorderColor;
                            break;

                        case Panel panel:
                            panel.BackColor = ThemeColors.PanelColor;
                            break;

                        case DataGridView dgv:
                            ApplyThemeToWinFormsDataGrid(dgv);
                            break;

                        case TextBox textBox:
                            textBox.BackColor = ThemeColors.Background;
                            textBox.ForeColor = ThemeColors.TextColor;
                            textBox.BorderStyle = BorderStyle.FixedSingle;
                            break;

                        case ComboBox comboBox:
                            comboBox.BackColor = ThemeColors.Background;
                            comboBox.ForeColor = ThemeColors.TextColor;
                            break;

                        case ListBox listBox:
                            listBox.BackColor = ThemeColors.Background;
                            listBox.ForeColor = ThemeColors.TextColor;
                            break;

                        case CheckBox checkBox:
                            checkBox.ForeColor = ThemeColors.TextColor;
                            break;

                        case RadioButton radioButton:
                            radioButton.ForeColor = ThemeColors.TextColor;
                            break;

                        case GroupBox groupBox:
                            groupBox.ForeColor = ThemeColors.TextColor;
                            break;

                        case TabControl tabControl:
                            tabControl.BackColor = ThemeColors.Background;
                            tabControl.ForeColor = ThemeColors.TextColor;
                            break;


                    }
                }
            }

            /// <summary>
            /// Applies theme to Guna2DataGridView
            /// </summary>
            private static void ApplyThemeToDataGridView(Guna2DataGridView dataGridView)
            {
                // Header
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeColors.GridHeaderColor;
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

                // Rows
                dataGridView.DefaultCellStyle.BackColor = ThemeColors.Background;
                dataGridView.DefaultCellStyle.ForeColor = ThemeColors.TextColor;
                dataGridView.DefaultCellStyle.SelectionBackColor = ThemeColors.LightBrown;
                dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

                // Alternating rows
                dataGridView.AlternatingRowsDefaultCellStyle.BackColor = ThemeColors.GridAlternateRow;
                dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = ThemeColors.TextColor;

                // Grid color
                dataGridView.GridColor = ThemeColors.BorderColor;

                // Theme style
                try
                {
                    dataGridView.ThemeStyle.HeaderStyle.BackColor = ThemeColors.GridHeaderColor;
                    dataGridView.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    dataGridView.ThemeStyle.HeaderStyle.ForeColor = Color.White;
                    dataGridView.ThemeStyle.BackColor = ThemeColors.Background;
                    dataGridView.ThemeStyle.GridColor = ThemeColors.BorderColor;
                    dataGridView.ThemeStyle.RowsStyle.BackColor = ThemeColors.Background;
                    dataGridView.ThemeStyle.RowsStyle.ForeColor = ThemeColors.TextColor;
                    dataGridView.ThemeStyle.RowsStyle.SelectionBackColor = ThemeColors.LightBrown;
                    dataGridView.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
                    dataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = ThemeColors.GridAlternateRow;
                    dataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = ThemeColors.TextColor;
                }
                catch { }
            }

            /// <summary>
            /// Applies theme to standard WinForms DataGridView
            /// </summary>
            private static void ApplyThemeToWinFormsDataGrid(DataGridView dataGridView)
            {
                dataGridView.BackgroundColor = ThemeColors.Background;
                dataGridView.BorderStyle = BorderStyle.FixedSingle;
                dataGridView.GridColor = ThemeColors.BorderColor;

                // Header
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ThemeColors.GridHeaderColor;
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dataGridView.EnableHeadersVisualStyles = false;

                // Rows
                dataGridView.DefaultCellStyle.BackColor = ThemeColors.Background;
                dataGridView.DefaultCellStyle.ForeColor = ThemeColors.TextColor;
                dataGridView.DefaultCellStyle.SelectionBackColor = ThemeColors.LightBrown;
                dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

                // Alternating rows
                dataGridView.AlternatingRowsDefaultCellStyle.BackColor = ThemeColors.GridAlternateRow;
                dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = ThemeColors.TextColor;

                // Row headers
                dataGridView.RowHeadersDefaultCellStyle.BackColor = ThemeColors.GridHeaderColor;
                dataGridView.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            }

            /// <summary>
            /// Quick method to apply theme to all open forms
            /// </summary>
            public static void ApplyGlobalTheme()
            {
                foreach (Form form in Application.OpenForms)
                {
                    ApplyThemeToForm(form);
                }
            }

            /// <summary>
            /// Creates a pre-styled themed button
            /// </summary>
            public static Guna2Button CreateThemedButton(string text, int width = 150, int height = 45)
            {
                return new Guna2Button
                {
                    Text = text,
                    Width = width,
                    Height = height,
                    FillColor = ThemeColors.ButtonColor,
                    ForeColor = Color.White,
                    BorderColor = ThemeColors.BorderColor,
                    BorderThickness = 2,
                    BorderRadius = 8,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Animated = true,
                    Cursor = Cursors.Hand
                };
            }

            /// <summary>
            /// Creates a pre-styled themed panel
            /// </summary>
            public static Guna2Panel CreateThemedPanel()
            {
                var panel = new Guna2Panel
                {
                    FillColor = ThemeColors.PanelColor,
                    BorderColor = ThemeColors.BorderColor,
                    BorderThickness = 1,
                    BorderRadius = 10,
                };

                return panel;
            }
        }
        // ===================================================================
        // END THEME SYSTEM
        // ===================================================================
    }
}