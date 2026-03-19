using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee.Kiosk.Cashier
{
    public partial class OrderCustomizer : Form
    {
        public OrderItemModel? Result { get; private set; }

        private readonly MenuItemModel _item;
        private decimal _basePrice = 0;
        private decimal _addOnsTotal = 0;
        private int _qty = 1;

        private string _serveAs = "";
        private string _size = "";
        private string _beans = "";
        private string _milk = "";
        private string _iceLevel = "";
        private string _sugarLevel = "";
        private string _servedWith = "";

        private readonly List<string> _selectedAddOns = new();
        private readonly List<decimal> _selectedAddOnPrices = new();

        private Label _lblQty = new();
        private TextBox _txtNotes = new();

        public OrderCustomizer(MenuItemModel item, Point location)
        {
            InitializeComponent();

            _item = item;
            _basePrice = item.Price;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

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
            pnlBody.PerformLayout();
            this.PerformLayout();

            int w = pnlBody.ClientSize.Width - 8;
            int y = 4;

            if (CustomizerConfig.ShowServeAs(_item.Category))
            {
                _serveAs = "Hot";
                AddSectionLabel("Serve as", ref y);
                AddPillGroup(new[] { "Hot", "Iced" },
                    "Hot", ref y, v => _serveAs = v);
            }

            var sizes = CustomizerConfig.GetSizes(_item);
            var firstSize = sizes.First();
            _size = firstSize.Key;
            _basePrice = firstSize.Value;

            if (sizes.Count > 1)
            {
                AddSectionLabel("Size", ref y);
                AddPillGroupWithPrice(sizes, firstSize.Key, ref y,
                    (k, v) => { _size = k; _basePrice = v; UpdateTotal(); });
            }

            if (CustomizerConfig.ShowBreakfastOptions(_item.Category))
            {
                var opts = CustomizerConfig.GetBreakfastOptions(_item.Price);
                var firstOpt = opts.First();
                _servedWith = firstOpt.Key;
                _basePrice = firstOpt.Value;
                AddSectionLabel("Served with", ref y);
                AddPillGroupWithPrice(opts, firstOpt.Key, ref y,
                    (k, v) => { _servedWith = k; _basePrice = v; UpdateTotal(); });
            }

            if (CustomizerConfig.ShowBeans(_item.Category))
            {
                _beans = "House blend";
                AddSectionLabel("Beans", ref y);
                AddPillGroup(new[] { "House blend", "Single origin", "Decaf" },
                    "House blend", ref y, v => _beans = v);
            }

            if (CustomizerConfig.ShowMilk(_item.Category))
            {
                _milk = "Regular milk";
                AddSectionLabel("Milk", ref y);
                AddPillGroup(new[] { "Regular milk", "Oat milk +₱49", "No milk" },
                    "Regular milk", ref y, v =>
                    {
                        _milk = v;
                        if (v == "Oat milk +₱49")
                        {
                            if (!_selectedAddOns.Contains("Oat milk"))
                            {
                                _selectedAddOns.Add("Oat milk");
                                _selectedAddOnPrices.Add(49);
                            }
                        }
                        else
                        {
                            _selectedAddOns.Remove("Oat milk");
                            _selectedAddOnPrices.RemoveAll(p => p == 49);
                        }
                        _addOnsTotal = _selectedAddOnPrices.Sum();
                        UpdateTotal();
                    });
            }

            if (CustomizerConfig.ShowIceLevel(_item.Category))
            {
                _iceLevel = "Standard";
                AddSectionLabel("Ice level", ref y);
                AddPillGroup(new[] { "No ice", "Less ice", "Standard", "Extra ice" },
                    "Standard", ref y, v => _iceLevel = v);
            }

            if (CustomizerConfig.ShowSugarLevel(_item.Category))
            {
                _sugarLevel = "Standard";
                AddSectionLabel("Sugar level", ref y);
                AddPillGroup(new[] { "No sugar", "Less sweet", "Standard", "Extra sweet" },
                    "Standard", ref y, v => _sugarLevel = v);
            }

            if (CustomizerConfig.ShowDrinkAddOns(_item.Category))
            {
                AddSectionLabel("Add-ons (optional)", ref y);
                foreach (var ao in CustomizerConfig.GetDrinkAddOns())
                    AddAddonRow(ao.Key, ao.Value, ref y);
            }

            if (CustomizerConfig.ShowFoodAddOns(_item.Category))
            {
                AddSectionLabel("Add-ons (optional)", ref y);
                foreach (var ao in CustomizerConfig.GetFoodAddOns())
                    AddAddonRow(ao.Key, ao.Value, ref y);
            }

            AddSectionLabel("Quantity", ref y);
            AddQtyRow(ref y);

            AddSectionLabel("Special instructions (optional)", ref y);
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

        private void AddSectionLabel(string text, ref int y)
        {
            int w = pnlBody.ClientSize.Width - 8;
            pnlBody.Controls.Add(new Label
            {
                Text = text.ToUpper(),
                Font = new Font("Segoe UI", 7f, FontStyle.Bold),
                ForeColor = Color.FromArgb(166, 124, 91),
                AutoSize = false,
                Width = w,
                Height = 18,
                Location = new Point(0, y),
                BackColor = Color.Transparent
            });
            y += 22;
        }

        private void AddPillGroup(string[] options, string defaultVal,
            ref int y, Action<string> onSelect)
        {
            int w = pnlBody.ClientSize.Width - 8;
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

            foreach (var opt in options)
            {
                string captured = opt;
                bool isDefault = opt == defaultVal;
                int btnW = Math.Max(90, opt.Length * 9 + 20);

                var btn = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = opt,
                    AutoSize = false,
                    Size = new Size(btnW, 32),
                    BorderRadius = 16,
                    FillColor = isDefault ? Color.FromArgb(107, 79, 58) : Color.White,
                    ForeColor = isDefault ? Color.White : Color.FromArgb(107, 79, 58),
                    BorderColor = Color.FromArgb(107, 79, 58),
                    Font = new Font("Segoe UI", 8f),
                    Margin = new Padding(0, 0, 6, 6),
                    Tag = opt
                };

                btn.Click += (s, e) =>
                {
                    foreach (var p in pills)
                    {
                        bool active = p.Tag?.ToString() == captured;
                        p.FillColor = active ? Color.FromArgb(107, 79, 58) : Color.White;
                        p.ForeColor = active ? Color.White : Color.FromArgb(107, 79, 58);
                    }
                    onSelect(captured);
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

        private void AddPillGroupWithPrice(Dictionary<string, decimal> options,
            string defaultKey, ref int y, Action<string, decimal> onSelect)
        {
            int w = pnlBody.ClientSize.Width - 8;
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

            foreach (var opt in options)
            {
                string capturedKey = opt.Key;
                decimal capturedVal = opt.Value;
                string label = $"{opt.Key} — ₱{opt.Value:N0}";
                bool isDefault = opt.Key == defaultKey;
                int btnW = Math.Max(120, label.Length * 8 + 20);

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
                    Tag = opt.Key
                };

                btn.Click += (s, e) =>
                {
                    foreach (var p in pills)
                    {
                        bool active = p.Tag?.ToString() == capturedKey;
                        p.FillColor = active ? Color.FromArgb(107, 79, 58) : Color.White;
                        p.ForeColor = active ? Color.White : Color.FromArgb(107, 79, 58);
                    }
                    onSelect(capturedKey, capturedVal);
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

        private void AddAddonRow(string name, decimal price, ref int y)
        {
            int w = pnlBody.ClientSize.Width - 8;
            var row = new Panel
            {
                Height = 36,
                Width = w,
                Location = new Point(0, y),
                BackColor = Color.FromArgb(250, 246, 243)
            };

            row.Controls.Add(new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(44, 34, 24),
                AutoSize = false,
                Width = w - 100,
                Height = 36,
                Location = new Point(8, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            });
            row.Controls.Add(new Label
            {
                Text = $"+₱{price:N0}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(166, 124, 91),
                AutoSize = false,
                Width = 60,
                Height = 36,
                Location = new Point(w - 90, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            });

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
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (isOn)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(107, 79, 58)), 0, 0, 22, 22);
                    var pen = new Pen(Color.White, 2.5f)
                    {
                        StartCap = System.Drawing.Drawing2D.LineCap.Round,
                        EndCap = System.Drawing.Drawing2D.LineCap.Round
                    };
                    g.DrawLines(pen,
                        new[] { new Point(4, 11), new Point(9, 16), new Point(18, 6) });
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(212, 184, 150)), 0, 0, 21, 21);
                }
            };
            chk.Click += (s, e) =>
            {
                isOn = !isOn;
                chk.Invalidate();
                if (isOn) { _selectedAddOns.Add(name); _selectedAddOnPrices.Add(price); }
                else { _selectedAddOns.Remove(name); _selectedAddOnPrices.Remove(price); }
                _addOnsTotal = _selectedAddOnPrices.Sum();
                UpdateTotal();
            };

            row.Controls.Add(chk);
            pnlBody.Controls.Add(row);
            y += 42;
        }

        private void AddQtyRow(ref int y)
        {
            var row = new Panel
            {
                Height = 44,
                Width = pnlBody.ClientSize.Width - 8,
                Location = new Point(0, y),
                BackColor = Color.Transparent
            };

            // ── USE REGULAR WINFORMS BUTTON — always visible, no Guna issues ──
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
            {
                if (_qty > 1) { _qty--; _lblQty.Text = _qty.ToString(); UpdateTotal(); }
            };
            btnPlus.Click += (s, e) =>
            {
                _qty++; _lblQty.Text = _qty.ToString(); UpdateTotal();
            };

            row.Controls.AddRange(new Control[] { btnMinus, _lblQty, btnPlus });
            pnlBody.Controls.Add(row);
            y += 52;
        }

        private void UpdateTotal()
        {
            lblTotalPrice.Text = $"₱{(_basePrice + _addOnsTotal) * _qty:N2}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
                    ServeAs = _serveAs,
                    Size = _size,
                    Beans = _beans,
                    Milk = _milk,
                    IceLevel = _iceLevel,
                    SugarLevel = _sugarLevel,
                    ServedWith = _servedWith,
                    Notes = _txtNotes?.Text.Trim() ?? "",
                    AddOns = new List<string>(_selectedAddOns),
                    AddOnsTotal = _addOnsTotal
                }
            };
            this.DialogResult = DialogResult.OK;
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