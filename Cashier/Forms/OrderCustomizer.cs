using Coffee.Kiosk.Cashier.CashierDBHelper;
using Coffee.Kiosk.Cashier.ModelClassHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class OrderCustomizer : Form
    {
        public OrderItemModel? Result { get; private set; }

        private readonly MenuItemModel _item;
        private decimal _basePrice = 0;
        private decimal _modifiersTotal = 0;
        private int _qty = 1;
        private List<ModifierGroupModel> _groups = new();

        private Dictionary<int, List<(int Id, string Name, decimal Price)>> _selected = new();

        private Label _lblQty = new();
        private TextBox _txtNotes = new();

        public OrderCustomizer(MenuItemModel item, Point location)
        {
            InitializeComponent();

            _item = item;
            _basePrice = item.Price;

            this.StartPosition = FormStartPosition.CenterParent;
            this.TopMost = false;
            this.ShowInTaskbar = false;

            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            };

            this.Shown += (s, e) => BuildUI();
        }

        private void BuildUI()
        {
            lblName.Text = _item.ItemName;
            lblCat.Text = _item.Category;
            lblTotalPrice.Text = $"₱{_basePrice:N2}";

            pnlBody.Controls.Clear();
            pnlBody.AutoScroll = true;
            pnlBody.Padding = new Padding(12, 8, 12, 8);
            pnlBody.PerformLayout();

            int w = pnlBody.ClientSize.Width - pnlBody.Padding.Horizontal - 4;
            int y = 4;

            try
            {
                _groups = KioskOrderDbManager.GetProductModifiers(_item.ItemID);
            }
            catch
            {
                _groups = new List<ModifierGroupModel>();
            }

            foreach (var group in _groups)
            {
                _selected[group.GroupId] = new List<(int, string, decimal)>();

                string label = group.Required
                    ? $"{group.Name}  *required"
                    : group.Name;

                AddSectionLabel(label, ref y, w, group.Required);

                if (group.SelectionType == "Single")
                    AddSingleSelectGroup(group, ref y, w);
                else
                    AddMultiSelectGroup(group, ref y, w);
            }

            AddSectionLabel("Quantity", ref y, w, false);
            AddQtyRow(ref y, w);

            AddSectionLabel("Special instructions (optional)", ref y, w, false);
            _txtNotes = new TextBox
            {
                Multiline = true,
                Height = 52,
                Width = w,
                Location = new Point(0, y),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(250, 246, 243),
                ForeColor = Color.FromArgb(44, 34, 24),
                Font = new Font("Segoe UI", 9f),
                PlaceholderText = "e.g. extra hot, less foam, allergies..."
            };
            pnlBody.Controls.Add(_txtNotes);
            y += 64;

            pnlBody.AutoScrollMinSize = new Size(0, y + 20);
            UpdateTotal();
        }

        private void AddSectionLabel(string text, ref int y, int w, bool required)
        {
            pnlBody.Controls.Add(new Label
            {
                Text = text.ToUpper(),
                Font = new Font("Segoe UI", 7f, FontStyle.Bold),
                ForeColor = required
                    ? Color.FromArgb(192, 80, 80)
                    : Color.FromArgb(166, 124, 91),
                AutoSize = false,
                Width = w,
                Height = 18,
                Location = new Point(0, y),
                BackColor = Color.Transparent
            });
            y += 22;
        }

        private void AddSingleSelectGroup(ModifierGroupModel group, ref int y, int w)
        {
            if (group.Options.Count == 0) return;

            var pills = new List<Guna.UI2.WinForms.Guna2Button>();
            var flp = new FlowLayoutPanel
            {
                AutoSize = false,
                Location = new Point(0, y),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = Color.Transparent,
                Width = w,
                Height = 80
            };

            if (group.Required && group.Options.Count > 0)
            {
                var first = group.Options[0];
                _selected[group.GroupId].Add((first.OptionId, first.Name, first.PriceDelta));
            }

            foreach (var opt in group.Options)
            {
                var capturedOpt = opt;
                bool isDefault = group.Required && opt == group.Options[0];
                string label = opt.PriceDelta > 0
                    ? $"{opt.Name}  +₱{opt.PriceDelta:N0}"
                    : opt.Name;
                int btnW = Math.Max(90, label.Length * 8 + 20);

                var btn = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = label,
                    AutoSize = false,
                    Size = new Size(btnW, 32),
                    BorderRadius = 16,
                    FillColor = isDefault ? Color.FromArgb(107, 79, 58) : Color.White,
                    ForeColor = isDefault ? Color.White : Color.FromArgb(107, 79, 58),
                    BorderColor = Color.FromArgb(107, 79, 58),
                    Font = new Font("Segoe UI", 8f),
                    Margin = new Padding(0, 0, 6, 6),
                    Tag = capturedOpt.OptionId
                };

                btn.Click += (s, e) =>
                {
                    _selected[group.GroupId].Clear();
                    _selected[group.GroupId].Add((capturedOpt.OptionId, capturedOpt.Name, capturedOpt.PriceDelta));

                    foreach (var p in pills)
                    {
                        bool active = (int)(p.Tag ?? -1) == capturedOpt.OptionId;
                        p.FillColor = active ? Color.FromArgb(107, 79, 58) : Color.White;
                        p.ForeColor = active ? Color.White : Color.FromArgb(107, 79, 58);
                    }
                    UpdateTotal();
                };

                pills.Add(btn);
                flp.Controls.Add(btn);
            }

            pnlBody.Controls.Add(flp);
            flp.PerformLayout();

            int rows = 1, rowW = 0;
            foreach (Guna.UI2.WinForms.Guna2Button b in flp.Controls)
            {
                rowW += b.Width + 6;
                if (rowW > w) { rows++; rowW = b.Width + 6; }
            }
            flp.Height = rows * 38 + 4;
            y += flp.Height + 8;
        }

        private void AddMultiSelectGroup(ModifierGroupModel group, ref int y, int w)
        {
            foreach (var opt in group.Options)
            {
                var capturedOpt = opt;
                var row = new Panel
                {
                    Height = 36,
                    Width = w,
                    Location = new Point(0, y),
                    BackColor = Color.FromArgb(250, 246, 243)
                };

                row.Controls.Add(new Label
                {
                    Text = opt.Name,
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = Color.FromArgb(44, 34, 24),
                    AutoSize = false,
                    Width = w - 100,
                    Height = 36,
                    Location = new Point(8, 0),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent
                });

                if (opt.PriceDelta > 0)
                {
                    row.Controls.Add(new Label
                    {
                        Text = $"+₱{opt.PriceDelta:N0}",
                        Font = new Font("Segoe UI", 9f),
                        ForeColor = Color.FromArgb(166, 124, 91),
                        AutoSize = false,
                        Width = 60,
                        Height = 36,
                        Location = new Point(w - 90, 0),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    });
                }

                bool isOn = false;
                var chk = new Panel
                {
                    Size = new Size(22, 22),
                    Location = new Point(w - 28, 7),
                    BackColor = Color.White,
                    Cursor = Cursors.Hand
                };
                chk.Paint += (s, e) =>
                {
                    var g2 = e.Graphics;
                    g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    if (isOn)
                    {
                        g2.FillRectangle(new SolidBrush(Color.FromArgb(107, 79, 58)), 0, 0, 22, 22);
                        var pen = new Pen(Color.White, 2.5f)
                        {
                            StartCap = System.Drawing.Drawing2D.LineCap.Round,
                            EndCap = System.Drawing.Drawing2D.LineCap.Round
                        };
                        g2.DrawLines(pen, new[] { new Point(4, 11), new Point(9, 16), new Point(18, 6) });
                    }
                    else
                    {
                        g2.DrawRectangle(new Pen(Color.FromArgb(212, 184, 150)), 0, 0, 21, 21);
                    }
                };
                chk.Click += (s, e) =>
                {
                    isOn = !isOn;
                    chk.Invalidate();
                    if (isOn)
                        _selected[group.GroupId].Add((capturedOpt.OptionId, capturedOpt.Name, capturedOpt.PriceDelta));
                    else
                        _selected[group.GroupId].RemoveAll(x => x.Id == capturedOpt.OptionId);
                    UpdateTotal();
                };

                row.Controls.Add(chk);
                pnlBody.Controls.Add(row);
                y += 42;
            }
        }

        private void AddQtyRow(ref int y, int w)
        {
            var row = new Panel
            {
                Height = 44,
                Width = w,
                Location = new Point(0, y),
                BackColor = Color.Transparent
            };

            var btnMinus = new Button
            {
                Text = "−",
                Size = new Size(34, 34),
                Location = new Point(0, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(240, 225, 210),
                ForeColor = Color.FromArgb(107, 79, 58),
                Font = new Font("Arial", 14f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnMinus.FlatAppearance.BorderColor = Color.FromArgb(107, 79, 58);
            btnMinus.FlatAppearance.BorderSize = 1;

            _lblQty = new Label
            {
                Text = "1",
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(59, 35, 20),
                AutoSize = false,
                Width = 36,
                Height = 34,
                Location = new Point(40, 5),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            var btnPlus = new Button
            {
                Text = "+",
                Size = new Size(34, 34),
                Location = new Point(82, 5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(107, 79, 58),
                ForeColor = Color.White,
                Font = new Font("Arial", 14f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnPlus.FlatAppearance.BorderColor = Color.FromArgb(107, 79, 58);
            btnPlus.FlatAppearance.BorderSize = 1;

            btnMinus.Click += (s, e) =>
            { if (_qty > 1) { _qty--; _lblQty.Text = _qty.ToString(); UpdateTotal(); } };
            btnPlus.Click += (s, e) =>
            { _qty++; _lblQty.Text = _qty.ToString(); UpdateTotal(); };

            row.Controls.AddRange(new Control[] { btnMinus, _lblQty, btnPlus });
            pnlBody.Controls.Add(row);
            y += 52;
        }

        private void UpdateTotal()
        {
            _modifiersTotal = _selected.Values
                .SelectMany(v => v)
                .Sum(x => x.Price);

            lblTotalPrice.Text = $"₱{(_basePrice + _modifiersTotal) * _qty:N2}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var group in _groups.Where(g => g.Required))
            {
                if (!_selected.ContainsKey(group.GroupId) || _selected[group.GroupId].Count == 0)
                {
                    MessageBox.Show($"Please select an option for: {group.Name}",
                        "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var modifierParts = _selected.Values
                .SelectMany(v => v)
                .Select(x => x.Name)
                .ToList();

            Result = new OrderItemModel
            {
                Item = new MenuItemModel
                {
                    ItemID = _item.ItemID,
                    ItemName = _item.ItemName,
                    Category = _item.Category,
                    Price = _basePrice
                },
                Quantity = _qty,
                Customization = new OrderCustomization
                {
                    Notes = _txtNotes?.Text.Trim() ?? "",
                    AddOns = modifierParts,
                    AddOnsTotal = _modifiersTotal
                }
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }
        private void pnlFooter_Paint(object sender, PaintEventArgs e) { }
        private void pnlBody_Paint(object sender, PaintEventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
        private void lblCat_Click(object sender, EventArgs e) { }
        private void lblTotalPrice_Click(object sender, EventArgs e) { }
    }
}