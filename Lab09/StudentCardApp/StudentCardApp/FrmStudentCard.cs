using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace StudentCardApp
{
    public partial class FrmStudentCard : Form
    {
        private Image? _avatar;   // ảnh đại diện hiện tại (nằm trong bộ nhớ)

        public FrmStudentCard()
        {
            InitializeComponent();
            LoadSampleData();
            SetupButtons();
            SetupCardPanel();
            WireEvents();
        }

        // =====================================================
        // KHỞI TẠO
        // =====================================================

        // Ép kích thước 5 nút hàng dưới cho đủ chữ
        private void SetupButtons()
        {
            Button[] buttons = { btnReset, btnSavePng, btnPrintPreview, btnPrint, btnExit };
            string[] texts = { "Làm mới", "Lưu PNG", "Xem trước in", "In thẻ", "Thoát" };

            int x = 470;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].AutoSize = false;
                buttons[i].Size = new Size(130, 44);
                buttons[i].Location = new Point(x, 618);
                buttons[i].Text = texts[i];
                x += 140;
            }
        }

        // Bật DoubleBuffered cho Panel để vẽ không bị nhấp nháy
        private void SetupCardPanel()
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, pnlCard, new object[] { true });
        }

        // Gắn sự kiện bằng code. "-=" trước "+=" để không bị gắn trùng.
        private void WireEvents()
        {
            btnChooseImage.Click -= btnChooseImage_Click;
            btnChooseImage.Click += btnChooseImage_Click;

            btnRemoveImage.Click -= btnRemoveImage_Click;
            btnRemoveImage.Click += btnRemoveImage_Click;

            btnPrintPreview.Click -= btnPrintPreview_Click;
            btnPrintPreview.Click += btnPrintPreview_Click;

            btnPrint.Click -= btnPrint_Click;
            btnPrint.Click += btnPrint_Click;

            btnExit.Click -= btnExit_Click;
            btnExit.Click += btnExit_Click;

            btnCardColor.Click -= btnCardColor_Click;
            btnCardColor.Click += btnCardColor_Click;

            // Vẽ thẻ trên Panel
            pnlCard.Paint -= pnlCard_Paint;
            pnlCard.Paint += pnlCard_Paint;

            // Khi gõ chữ: xóa dấu lỗi + vẽ lại thẻ
            txtStudentId.TextChanged -= ClearError_TextChanged;
            txtStudentId.TextChanged += ClearError_TextChanged;
            txtFullName.TextChanged -= ClearError_TextChanged;
            txtFullName.TextChanged += ClearError_TextChanged;

            // Mọi thay đổi dữ liệu đều vẽ lại thẻ
            txtStudentId.TextChanged -= RefreshCard;
            txtStudentId.TextChanged += RefreshCard;
            txtFullName.TextChanged -= RefreshCard;
            txtFullName.TextChanged += RefreshCard;

            cboClass.TextChanged -= RefreshCard;
            cboClass.TextChanged += RefreshCard;
            cboFaculty.TextChanged -= RefreshCard;
            cboFaculty.TextChanged += RefreshCard;
            cboCourse.SelectedIndexChanged -= RefreshCard;
            cboCourse.SelectedIndexChanged += RefreshCard;
            cboGender.SelectedIndexChanged -= RefreshCard;
            cboGender.SelectedIndexChanged += RefreshCard;
            dtpBirthDate.ValueChanged -= RefreshCard;
            dtpBirthDate.ValueChanged += RefreshCard;
            chkShowQR.CheckedChanged -= RefreshCard;
            chkShowQR.CheckedChanged += RefreshCard;
        }

        private void LoadSampleData()
        {
            if (cboClass.Items.Count == 0)
                cboClass.Items.AddRange(new object[]
                { "49.01.CNTT.A", "49.01.CNTT.B", "50.01.CNTT.A", "50.01.CNTT.B", "51.01.CNTT.A" });

            if (cboFaculty.Items.Count == 0)
                cboFaculty.Items.AddRange(new object[]
                { "Công nghệ thông tin", "Toán - Tin học", "Vật lý", "Hóa học", "Ngữ văn", "Tiếng Anh" });

            if (cboCourse.Items.Count == 0)
                cboCourse.Items.AddRange(new object[] { "K49", "K50", "K51", "K52" });

            if (cboGender.Items.Count == 0)
                cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            cboClass.SelectedIndex = 0;
            cboFaculty.SelectedIndex = 0;
            cboCourse.SelectedIndex = 0;
            cboGender.SelectedIndex = 0;

            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.Value = new DateTime(2004, 1, 1);
        }

        // Vẽ lại Panel thẻ
        private void RefreshCard(object? sender, EventArgs e)
        {
            pnlCard.Invalidate();
        }

        // =====================================================
        // F1: CHỌN ẢNH
        // =====================================================
        private void btnChooseImage_Click(object? sender, EventArgs e)
        {
            if (ofdAvatar.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                // Đọc file vào bộ nhớ rồi đóng file ngay => không khóa file
                byte[] data = File.ReadAllBytes(ofdAvatar.FileName);
                using var ms = new MemoryStream(data);
                using var temp = Image.FromStream(ms);
                Image newImage = new Bitmap(temp);   // bản sao độc lập với stream

                SetAvatar(newImage);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể mở file ảnh này. Vui lòng chọn file ảnh hợp lệ.",
                                "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveImage_Click(object? sender, EventArgs e)
        {
            SetAvatar(null);
        }

        // Gán ảnh mới, giải phóng ảnh cũ
        private void SetAvatar(Image? newImage)
        {
            var old = _avatar;
            _avatar = newImage;
            picAvatar.Image = _avatar;
            old?.Dispose();

            if (_avatar != null)
                errProvider.SetError(btnChooseImage, "");

            pnlCard.Invalidate();   // vẽ lại thẻ với ảnh mới
        }

        // =====================================================
        // CHỌN MÀU THẺ
        // =====================================================
        private void btnCardColor_Click(object? sender, EventArgs e)
        {
            colorDialog.Color = pnlColorSample.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlColorSample.BackColor = colorDialog.Color;
                pnlCard.Invalidate();
            }
        }

        // =====================================================
        // F2: VẼ THẺ BẰNG GDI+
        // =====================================================

        // Sự kiện Paint của Panel: gọi hàm vẽ dùng chung
        private void pnlCard_Paint(object? sender, PaintEventArgs e)
        {
            DrawCard(e.Graphics, new Rectangle(0, 0, pnlCard.Width, pnlCard.Height));
        }

        // Hàm vẽ thẻ DÙNG CHUNG cho Panel (preview) và PrintDocument (Bước 6).
        // bounds = vùng chữ nhật mà thẻ được vẽ vào.
        // Mọi kích thước đều tính theo bounds nên thẻ co giãn đúng tỉ lệ.
        private void DrawCard(Graphics g, Rectangle bounds)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Hệ số co giãn: thiết kế gốc là 540 x 340
            float s = bounds.Width / 540f;
            Func<float, float> S = v => v * s;

            Color baseColor = pnlColorSample.BackColor;
            Color darkColor = Darken(baseColor, 0.45f);
            Color lightColor = Lighten(baseColor, 0.80f);

            // ---------- Nền thẻ: tô màu chuyển sắc ----------
            var cardRect = new RectangleF(bounds.X + S(8), bounds.Y + S(8),
                                          bounds.Width - S(16), bounds.Height - S(16));
            float radius = S(18);

            using (var path = RoundedRect(cardRect, radius))
            {
                using (var bg = new LinearGradientBrush(cardRect, Color.White, lightColor, 90f))
                    g.FillPath(bg, path);

                // ---------- Thanh tiêu đề phía trên ----------
                var headerRect = new RectangleF(cardRect.X, cardRect.Y, cardRect.Width, S(72));
                var oldClip = g.Clip;
                g.SetClip(path, CombineMode.Intersect);
                using (var hb = new LinearGradientBrush(headerRect, darkColor, baseColor, 0f))
                    g.FillRectangle(hb, headerRect);
                g.Clip = oldClip;
            }

            // ---------- Tiêu đề ----------
            using (var fSchool = new Font("Segoe UI", S(9.5f), FontStyle.Bold))
            using (var fTitle = new Font("Segoe UI", S(15f), FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                var r1 = new RectangleF(cardRect.X, cardRect.Y + S(6), cardRect.Width, S(30));
                var r2 = new RectangleF(cardRect.X, cardRect.Y + S(34), cardRect.Width, S(34));
                g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", fSchool, Brushes.White, r1, sf);
                g.DrawString("THẺ SINH VIÊN", fTitle, Brushes.White, r2, sf);
            }

            // ---------- Ảnh sinh viên (bên trái) ----------
            var photoRect = new RectangleF(cardRect.X + S(22), cardRect.Y + S(88), S(120), S(160));
            DrawPhoto(g, photoRect, S(1));

            // ---------- Thông tin sinh viên (bên phải) ----------
            float infoX = photoRect.Right + S(22);
            float infoW = cardRect.Right - infoX - S(20);
            float y = photoRect.Y;
            float rowH = S(26);

            string id = txtStudentId.Text.Trim();
            string name = txtFullName.Text.Trim().ToUpper();
            string cls = cboClass.Text.Trim();
            string faculty = cboFaculty.Text.Trim();
            string course = cboCourse.Text.Trim();
            string birth = dtpBirthDate.Value.ToString("dd/MM/yyyy");
            string gender = cboGender.Text.Trim();

            using (var fLabel = new Font("Segoe UI", S(8.5f), FontStyle.Regular))
            using (var fValue = new Font("Segoe UI", S(10f), FontStyle.Bold))
            using (var fName = new Font("Segoe UI", S(13f), FontStyle.Bold))
            using (var labelBrush = new SolidBrush(Color.FromArgb(90, 90, 90)))
            using (var valueBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
            using (var nameBrush = new SolidBrush(darkColor))
            using (var sfLeft = new StringFormat { Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap })
            {
                // Họ tên (to, nổi bật)
                g.DrawString(name.Length == 0 ? "HỌ VÀ TÊN" : name, fName, nameBrush,
                             new RectangleF(infoX, y, infoW, S(28)), sfLeft);
                y += S(34);

                // Đường kẻ dưới tên
                using (var pen = new Pen(darkColor, S(1.5f)))
                    g.DrawLine(pen, infoX, y - S(3), infoX + infoW, y - S(3));

                DrawRow(g, "Mã SV:", id.Length == 0 ? "..." : id, infoX, ref y, infoW, rowH, fLabel, fValue, labelBrush, valueBrush, sfLeft, s);
                DrawRow(g, "Lớp:", cls, infoX, ref y, infoW, rowH, fLabel, fValue, labelBrush, valueBrush, sfLeft, s);
                DrawRow(g, "Khoa:", faculty, infoX, ref y, infoW, rowH, fLabel, fValue, labelBrush, valueBrush, sfLeft, s);
                DrawRow(g, "Khóa:", course, infoX, ref y, infoW, rowH, fLabel, fValue, labelBrush, valueBrush, sfLeft, s);
                DrawRow(g, "Ngày sinh:", birth, infoX, ref y, infoW, rowH, fLabel, fValue, labelBrush, valueBrush, sfLeft, s);
                DrawRow(g, "Giới tính:", gender, infoX, ref y, infoW, rowH, fLabel, fValue, labelBrush, valueBrush, sfLeft, s);
            }

            // ---------- Thanh chân thẻ ----------
            var footerRect = new RectangleF(cardRect.X, cardRect.Bottom - S(16), cardRect.Width, S(16));
            using (var path = RoundedRect(cardRect, radius))
            {
                var oldClip = g.Clip;
                g.SetClip(path, CombineMode.Intersect);
                using (var fb = new SolidBrush(darkColor))
                    g.FillRectangle(fb, footerRect);
                g.Clip = oldClip;
            }

            // ---------- Khung ngoài ----------
            using (var path = RoundedRect(cardRect, radius))
            using (var pen = new Pen(darkColor, S(2.5f)))
                g.DrawPath(pen, path);
        }

        // Vẽ một dòng "Nhãn: Giá trị"
        private void DrawRow(Graphics g, string label, string value, float x, ref float y,
                             float w, float rowH, Font fLabel, Font fValue,
                             Brush labelBrush, Brush valueBrush, StringFormat sf, float s)
        {
            float labelW = 84f * s;
            g.DrawString(label, fLabel, labelBrush, new RectangleF(x, y + 2f * s, labelW, rowH), sf);
            g.DrawString(value, fValue, valueBrush, new RectangleF(x + labelW, y, w - labelW, rowH), sf);
            y += rowH;
        }

        // Vẽ ảnh vào khung, GIỮ TỈ LỆ, cắt phần thừa ở giữa (không méo)
        private void DrawPhoto(Graphics g, RectangleF frame, float s)
        {
            Color darkColor = Darken(pnlColorSample.BackColor, 0.45f);

            // Nền khung ảnh
            g.FillRectangle(Brushes.White, frame);

            if (_avatar != null)
            {
                // Tính vùng cắt của ảnh gốc sao cho cùng tỉ lệ với khung
                float imgRatio = (float)_avatar.Width / _avatar.Height;
                float frameRatio = frame.Width / frame.Height;

                RectangleF src;
                if (imgRatio > frameRatio)
                {
                    // Ảnh rộng hơn khung: cắt hai bên
                    float w = _avatar.Height * frameRatio;
                    src = new RectangleF((_avatar.Width - w) / 2f, 0, w, _avatar.Height);
                }
                else
                {
                    // Ảnh cao hơn khung: cắt trên dưới
                    float h = _avatar.Width / frameRatio;
                    src = new RectangleF(0, (_avatar.Height - h) / 2f, _avatar.Width, h);
                }

                g.DrawImage(_avatar, frame, src, GraphicsUnit.Pixel);
            }
            else
            {
                // Chưa có ảnh: vẽ chữ nhắc
                using (var f = new Font("Segoe UI", 9f * frame.Width / 120f, FontStyle.Italic))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    g.DrawString("Ảnh 3x4", f, Brushes.Gray, frame, sf);
            }

            using (var pen = new Pen(darkColor, 2f * frame.Width / 120f))
                g.DrawRectangle(pen, frame.X, frame.Y, frame.Width, frame.Height);
        }

        // ----- Hàm hỗ trợ vẽ -----

        // Hình chữ nhật bo góc
        private static GraphicsPath RoundedRect(RectangleF r, float radius)
        {
            float d = radius * 2;
            var p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        // Làm đậm màu (amount 0..1)
        private static Color Darken(Color c, float amount)
        {
            return Color.FromArgb(
                (int)(c.R * (1 - amount)),
                (int)(c.G * (1 - amount)),
                (int)(c.B * (1 - amount)));
        }

        // Làm nhạt màu (amount 0..1)
        private static Color Lighten(Color c, float amount)
        {
            return Color.FromArgb(
                (int)(c.R + (255 - c.R) * amount),
                (int)(c.G + (255 - c.G) * amount),
                (int)(c.B + (255 - c.B) * amount));
        }

        // =====================================================
        // F3: VALIDATION
        // =====================================================
        private bool ValidateInput()
        {
            errProvider.Clear();

            string studentId = txtStudentId.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            if (studentId.Length == 0)
            {
                errProvider.SetError(txtStudentId, "Mã sinh viên không được để trống");
                MessageBox.Show("Vui lòng nhập Mã sinh viên.", "Thiếu dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return false;
            }

            if (fullName.Length == 0)
            {
                errProvider.SetError(txtFullName, "Họ tên không được để trống");
                MessageBox.Show("Vui lòng nhập Họ và tên.", "Thiếu dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (_avatar == null)
            {
                errProvider.SetError(btnChooseImage, "Chưa chọn ảnh đại diện");
                MessageBox.Show("Vui lòng chọn ảnh đại diện.", "Thiếu dữ liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnChooseImage.Focus();
                return false;
            }

            return true;
        }

        private void ClearError_TextChanged(object? sender, EventArgs e)
        {
            if (sender is Control c)
                errProvider.SetError(c, "");
        }

        // =====================================================
        // NÚT XEM TRƯỚC IN / IN / THOÁT (in thật làm ở Bước 6)
        // =====================================================
        private void btnPrintPreview_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            MessageBox.Show("Dữ liệu hợp lệ! (Phần xem trước in sẽ làm ở Bước 6)",
                            "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrint_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            MessageBox.Show("Dữ liệu hợp lệ! (Phần in sẽ làm ở Bước 6)",
                            "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // =====================================================
        // CÁC HÀM DESIGNER ĐÃ GẮN SẴN (làm nội dung ở Bước 7)
        // =====================================================
        private void btnReset_Click(object? sender, EventArgs e)
        {
            // Làm ở Bước 7
        }

        private void btnSavePng_Click(object? sender, EventArgs e)
        {
            // Làm ở Bước 7
        }

        private void FrmStudentCard_Load(object? sender, EventArgs e)
        {
        }
    }
}