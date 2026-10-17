using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    public class FrmPaint : Form
    {
        private readonly DrawSurface canvas = new DrawSurface();
        private readonly ComboBox cboMode = new ComboBox();
        private readonly NumericUpDown nudWidth = new NumericUpDown();

        // Các nút bấm với tên tiếng Việt
        private readonly Button btnColor = new Button();
        private readonly Button btnUndo = new Button();
        private readonly Button btnClear = new Button();
        private readonly Button btnSave = new Button();
        private readonly Button btnOpenBg = new Button();
        private readonly Button btnBgColor = new Button();

        private readonly StatusStrip statusStrip = new StatusStrip();
        private readonly ToolStripStatusLabel lblStatus = new ToolStripStatusLabel();

        private readonly List<DrawItem> items = new List<DrawItem>();
        private DrawItem currentItem;
        private bool isDrawing = false;
        private Color currentColor = Color.FromArgb(30, 30, 30);
        private Image backgroundImage = null;

        public FrmPaint()
        {
            Text = "COMP1019 - Modern Paint Studio";
            Width = 1200;
            Height = 720;
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            KeyPreview = true;

            BuildUserInterface();
            RegisterEvents();
        }

        private void BuildUserInterface()
        {
            // Thanh công cụ phía trên với màu nền rõ ràng, nổi bật
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(215, 230, 245), // Màu nền thanh công cụ rõ nét
                Padding = new Padding(10)
            };

            FlowLayoutPanel flowTools = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent
            };

            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.AddRange(new object[] { "Pen", "Line", "Rectangle", "Ellipse", "FilledRectangle", "FilledEllipse" });
            cboMode.SelectedIndex = 0;
            cboMode.Width = 140;
            cboMode.Height = 30;
            cboMode.Margin = new Padding(5, 8, 15, 0);

            nudWidth.Minimum = 1;
            nudWidth.Maximum = 20;
            nudWidth.Value = 3;
            nudWidth.Width = 65;
            nudWidth.Height = 30;
            nudWidth.Margin = new Padding(5, 8, 20, 0);

            // Đổi nhãn nút bấm sang tiếng Việt
            CreateStyledButton(btnColor, "🎨 Màu vẽ", 95, currentColor);
            CreateStyledButton(btnUndo, "↩ Hoàn tác", 100, Color.White);
            CreateStyledButton(btnClear, "🗑 Xóa hết", 85, Color.White);
            CreateStyledButton(btnSave, "💾 Lưu PNG", 95, Color.White);
            CreateStyledButton(btnOpenBg, "📁 Mở ảnh nền", 110, Color.White);
            CreateStyledButton(btnBgColor, "🖼 Màu nền", 100, Color.White);

            Label lblMode = new Label { Text = "Chế độ:", AutoSize = true, Margin = new Padding(5, 12, 0, 0) };
            Label lblWidth = new Label { Text = "Độ dày:", AutoSize = true, Margin = new Padding(5, 12, 0, 0) };

            flowTools.Controls.Add(lblMode);
            flowTools.Controls.Add(cboMode);
            flowTools.Controls.Add(lblWidth);
            flowTools.Controls.Add(nudWidth);
            flowTools.Controls.Add(CreateSeparator());
            flowTools.Controls.Add(btnColor);
            flowTools.Controls.Add(btnUndo);
            flowTools.Controls.Add(btnClear);
            flowTools.Controls.Add(CreateSeparator());
            flowTools.Controls.Add(btnSave);
            flowTools.Controls.Add(btnOpenBg);
            flowTools.Controls.Add(btnBgColor);

            topPanel.Controls.Add(flowTools);

            statusStrip.Items.Add(lblStatus);
            lblStatus.Text = "Sẵn sàng — Chọn công cụ và bắt đầu vẽ!";
            statusStrip.BackColor = Color.FromArgb(240, 243, 246);

            Controls.Add(canvas);
            Controls.Add(statusStrip);
            Controls.Add(topPanel);
        }

        private void CreateStyledButton(Button btn, string text, int width, Color backColor)
        {
            btn.Text = text;
            btn.Width = width;
            btn.Height = 35;
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = backColor;
            btn.ForeColor = Color.FromArgb(40, 40, 40);
            btn.FlatAppearance.BorderColor = Color.FromArgb(180, 200, 220);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 240, 255);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 220, 245);
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(4, 5, 4, 0);
        }

        private Panel CreateSeparator()
        {
            return new Panel
            {
                Width = 1,
                Height = 35,
                BackColor = Color.FromArgb(190, 210, 230),
                Margin = new Padding(8, 5, 8, 0)
            };
        }

        private void RegisterEvents()
        {
            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;

            btnColor.Click += BtnColor_Click;
            btnUndo.Click += BtnUndo_Click;
            btnClear.Click += BtnClear_Click;
            btnSave.Click += BtnSave_Click;
            btnOpenBg.Click += BtnOpenBg_Click;
            btnBgColor.Click += BtnBgColor_Click;

            this.KeyDown += FrmPaint_KeyDown;
        }

        private DrawMode CurrentMode
        {
            get
            {
                string mode = cboMode.SelectedItem.ToString();
                return (DrawMode)Enum.Parse(typeof(DrawMode), mode);
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using ColorDialog dialog = new ColorDialog();
            dialog.Color = currentColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = dialog.Color;
                btnColor.BackColor = currentColor;
                btnColor.ForeColor = (currentColor.GetBrightness() < 0.5) ? Color.White : Color.Black;
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) return;
            items.RemoveAt(items.Count - 1);
            canvas.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ vùng vẽ và ảnh nền?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                items.Clear();
                backgroundImage = null;
                canvas.BackColor = Color.White;
                canvas.Invalidate();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|Bitmap Image|*.bmp|All Files|*.*";
            sfd.Title = "Lưu bản vẽ thành file ảnh";
            sfd.FileName = "ModernPaint_Artwork.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using Bitmap bmp = new Bitmap(canvas.Width, canvas.Height);
                canvas.DrawToBitmap(bmp, new Rectangle(0, 0, canvas.Width, canvas.Height));
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show("Lưu file ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnOpenBg_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            ofd.Title = "Chọn ảnh nền cho canvas";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    backgroundImage = Image.FromFile(ofd.FileName);
                    canvas.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở file ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnBgColor_Click(object sender, EventArgs e)
        {
            using ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                canvas.BackColor = dialog.Color;
            }
        }

        private void FrmPaint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                BtnUndo_Click(sender, e);
                e.Handled = true;
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            isDrawing = true;
            currentItem = new DrawItem
            {
                Mode = CurrentMode,
                Start = e.Location,
                End = e.Location,
                Color = currentColor,
                Width = (float)nudWidth.Value
            };

            if (currentItem.Mode == DrawMode.Pen)
            {
                currentItem.Points.Add(e.Location);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"Tọa độ: X = {e.X}, Y = {e.Y}  |  Tổng số đối tượng: {items.Count}";

            if (!isDrawing || currentItem == null) return;
            currentItem.End = e.Location;

            if (currentItem.Mode == DrawMode.Pen)
            {
                currentItem.Points.Add(e.Location);
            }

            canvas.Invalidate();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing || currentItem == null) return;
            currentItem.End = e.Location;
            items.Add(currentItem);
            currentItem = null;
            isDrawing = false;
            canvas.Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (backgroundImage != null)
            {
                e.Graphics.DrawImage(backgroundImage, 0, 0, canvas.Width, canvas.Height);
            }

            foreach (DrawItem item in items)
            {
                DrawOneItem(e.Graphics, item);
            }

            if (currentItem != null)
            {
                DrawOneItem(e.Graphics, currentItem);
            }
        }

        private void DrawOneItem(Graphics g, DrawItem item)
        {
            Rectangle rect = GetRectangle(item.Start, item.End);

            switch (item.Mode)
            {
                case DrawMode.Pen:
                    {
                        using Pen pen = new Pen(item.Color, item.Width);
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        pen.LineJoin = LineJoin.Round;
                        DrawFreePen(g, pen, item.Points);
                    }
                    break;
                case DrawMode.Line:
                    {
                        using Pen pen = new Pen(item.Color, item.Width);
                        g.DrawLine(pen, item.Start, item.End);
                    }
                    break;
                case DrawMode.Rectangle:
                    {
                        using Pen pen = new Pen(item.Color, item.Width);
                        g.DrawRectangle(pen, rect);
                    }
                    break;
                case DrawMode.Ellipse:
                    {
                        using Pen pen = new Pen(item.Color, item.Width);
                        g.DrawEllipse(pen, rect);
                    }
                    break;
                case DrawMode.FilledRectangle:
                    {
                        using SolidBrush brush = new SolidBrush(item.Color);
                        g.FillRectangle(brush, rect);
                    }
                    break;
                case DrawMode.FilledEllipse:
                    {
                        using SolidBrush brush = new SolidBrush(item.Color);
                        g.FillEllipse(brush, rect);
                    }
                    break;
            }
        }

        private void DrawFreePen(Graphics g, Pen pen, List<Point> points)
        {
            if (points.Count < 2) return;
            for (int i = 1; i < points.Count; i++)
            {
                g.DrawLine(pen, points[i - 1], points[i]);
            }
        }

        private Rectangle GetRectangle(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(start.X - end.X);
            int height = Math.Abs(start.Y - end.Y);
            return new Rectangle(x, y, width, height);
        }
    }
}