using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;

namespace StudentCard
{
    public partial class FrmStudentCard : Form
    {
        // Kích thước "bản vẽ chuẩn" của thẻ (tỉ lệ ~ thẻ ISO ID-1: 85,6 x 54 mm)
        private const float CardW = 520f;
        private const float CardH = 328f;

        // Kích thước thẻ thật (mm) và lề trang in (mm)
        private const float CardMmW = 85.6f;
        private const float CardMmH = 54f;
        private const float PageMarginMm = 10f;

        /// <summary>Gói dữ liệu cần in lên thẻ.</summary>
        private record CardData(
            string StudentId,
            string FullName,
            string BirthDate,
            string Gender,
            string ClassName,
            string Faculty,
            string Course);

        public FrmStudentCard()
        {
            InitializeComponent();
            InitControls();
            SetDefaultValues();
        }

        // =====================================================
        // KHỞI TẠO
        // =====================================================

        private void InitControls()
        {
            // Dọn mục rỗng/trùng do lỡ xuống dòng thừa khi nhập Items
            CleanComboItems(cboClass);
            CleanComboItems(cboFaculty);
            CleanComboItems(cboCourse);
            CleanComboItems(cboGender);

            // Chỉ cho chọn trong danh sách, không gõ tự do
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;

            // DateTimePicker ngày sinh: MinDate, MaxDate TRƯỚC, Value SAU
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.MinDate = new DateTime(1900, 1, 1);
            dtpBirthDate.MaxDate = DateTime.Today;

            // Ảnh đại diện: giữ đúng tỉ lệ, không méo
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;

            // Bộ lọc file ảnh
            ofdAvatar.Title = "Chọn ảnh đại diện";
            ofdAvatar.Filter =
                "Ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            ofdAvatar.Multiselect = false;
            ofdAvatar.CheckFileExists = true;

            // ----- Preview thẻ -----
            EnableDoubleBuffer(pnlCard);          // chống nháy khi vẽ lại
            pnlCard.Paint += pnlCard_Paint;       // vẽ thẻ

            // Dữ liệu đổi -> vẽ lại thẻ
            txtStudentId.TextChanged += RefreshPreview;
            txtFullName.TextChanged += RefreshPreview;
            cboClass.SelectedIndexChanged += RefreshPreview;
            cboFaculty.SelectedIndexChanged += RefreshPreview;
            cboCourse.SelectedIndexChanged += RefreshPreview;
            cboGender.SelectedIndexChanged += RefreshPreview;
            dtpBirthDate.ValueChanged += RefreshPreview;

            // ----- In ấn -----
            ppdCard.Document = pdCard;
            pdlgCard.Document = pdCard;
            pdCard.DocumentName = "The sinh vien";

            // "-=" trước "+=" để dù Designer đã gắn sẵn thì cũng chỉ còn MỘT lần
            pdCard.PrintPage -= pdCard_PrintPage;
            pdCard.PrintPage += pdCard_PrintPage;

            btnPreviewPrint.Click -= btnPreviewPrint_Click;
            btnPreviewPrint.Click += btnPreviewPrint_Click;

            btnPrint.Click -= btnPrint_Click;
            btnPrint.Click += btnPrint_Click;

            // ----- Làm mới / Thoát -----
            btnReset.Click -= btnReset_Click;
            btnReset.Click += btnReset_Click;

            btnExit.Click -= btnExit_Click;
            btnExit.Click += btnExit_Click;
        }

        private void SetDefaultValues()
        {
            txtStudentId.Clear();
            txtFullName.Clear();

            SelectFirstItem(cboClass);
            SelectFirstItem(cboFaculty);
            SelectFirstItem(cboCourse);
            SelectFirstItem(cboGender);

            dtpBirthDate.Value = new DateTime(2004, 1, 1);

            ClearAvatar();

            txtStudentId.Focus();
        }

        private static void SelectFirstItem(ComboBox cbo)
        {
            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Xóa mục rỗng/trùng trong ComboBox (do lỡ xuống dòng thừa khi nhập Items).
        /// </summary>
        private static void CleanComboItems(ComboBox cbo)
        {
            var valid = cbo.Items.Cast<object>()
                .Select(i => i?.ToString()?.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct()
                .Cast<object>()
                .ToArray();

            cbo.Items.Clear();
            cbo.Items.AddRange(valid);
        }

        /// <summary>
        /// Panel mặc định không bật DoubleBuffered (thuộc tính protected),
        /// nên bật bằng Reflection để thẻ không bị nhấp nháy.
        /// </summary>
        private static void EnableDoubleBuffer(Control control)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(control, true);
        }

        // =====================================================
        // XỬ LÝ ẢNH ĐẠI DIỆN
        // =====================================================

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            if (ofdAvatar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            LoadAvatar(ofdAvatar.FileName);
        }

        /// <summary>Nạp ảnh từ đường dẫn mà KHÔNG khóa file gốc.</summary>
        private void LoadAvatar(string path)
        {
            try
            {
                Bitmap newImage;
                using (var temp = Image.FromFile(path))
                {
                    newImage = new Bitmap(temp);
                }

                Image? oldImage = picAvatar.Image;
                picAvatar.Image = newImage;
                oldImage?.Dispose();

                pnlCard.Invalidate(); // vẽ lại thẻ với ảnh mới
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show(
                    "File được chọn không phải ảnh hợp lệ hoặc đã bị hỏng.",
                    "Lỗi ảnh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở ảnh: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearAvatar()
        {
            Image? oldImage = picAvatar.Image;
            picAvatar.Image = null;
            oldImage?.Dispose();

            pnlCard.Invalidate();
        }

        // =====================================================
        // VALIDATION
        // =====================================================

        /// <summary>
        /// F3: Kiểm tra dữ liệu bắt buộc (Mã SV, Họ tên, Ảnh).
        /// Trả về true nếu hợp lệ. Nếu sai: báo lỗi và đưa con trỏ về đúng ô.
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                ShowValidationError("Vui lòng nhập Mã sinh viên.", txtStudentId);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                ShowValidationError("Vui lòng nhập Họ tên.", txtFullName);
                return false;
            }

            if (picAvatar.Image == null)
            {
                ShowValidationError("Vui lòng chọn ảnh đại diện.", btnChooseImage);
                return false;
            }

            return true;
        }

        /// <summary>Hiện thông báo lỗi rồi đưa con trỏ về control bị thiếu.</summary>
        private void ShowValidationError(string message, Control target)
        {
            MessageBox.Show(
                message,
                "Thiếu thông tin",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            target.Focus();

            // Nếu là ô nhập chữ thì bôi đen nội dung cho dễ sửa
            if (target is TextBox tb)
            {
                tb.SelectAll();
            }
        }

        // =====================================================
        // IN ẤN (PrintDocument)
        // =====================================================

        /// <summary>Đổi mm sang đơn vị 1/100 inch (đơn vị của PrintPage).</summary>
        private static float MmToHundredthInch(float mm) => mm / 25.4f * 100f;

        /// <summary>F4: Mở cửa sổ xem trước khi in.</summary>
        private void btnPreviewPrint_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; // thiếu dữ liệu -> không cho xem trước in
            }

            try
            {
                ppdCard.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở xem trước in: " + ex.Message,
                    "Lỗi in ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>F5: Chọn máy in rồi in thẻ.</summary>
        private void btnPrint_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return; // thiếu dữ liệu -> không cho in
            }

            try
            {
                if (pdlgCard.ShowDialog(this) == DialogResult.OK)
                {
                    pdCard.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể in: " + ex.Message,
                    "Lỗi in ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// PrintPage: vẽ thẻ 85,6 x 54 mm ở góc trên trái trang (cách lề 10 mm).
        /// Dùng lại đúng hàm DrawCard nên bản in giống hệt preview.
        /// </summary>
        private void pdCard_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;

            float margin = MmToHundredthInch(PageMarginMm);
            float w = MmToHundredthInch(CardMmW);
            float h = MmToHundredthInch(CardMmH);

            var cardBounds = new Rectangle(
                (int)Math.Round(margin), (int)Math.Round(margin),
                (int)Math.Round(w), (int)Math.Round(h));

            DrawCard(g, cardBounds, GetCardData(), picAvatar.Image);

            // Đường viền mảnh quanh thẻ để dễ cắt
            using (var cutPen = new Pen(Color.Gray, 0.5f))
            {
                g.DrawRectangle(cutPen, cardBounds);
            }

            e.HasMorePages = false; // chỉ một trang
        }

        // =====================================================
        // LÀM MỚI / THOÁT
        // =====================================================

        /// <summary>F6: Xóa dữ liệu, xóa ảnh, đưa Form về trạng thái ban đầu.</summary>
        private void btnReset_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ dữ liệu đã nhập và ảnh đã chọn?",
                "Xác nhận làm mới",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2); // mặc định chọn "No" cho an toàn

            if (result != DialogResult.Yes)
            {
                return;
            }

            SetDefaultValues();
        }

        /// <summary>Thoát ứng dụng (có hỏi xác nhận).</summary>
        private void btnExit_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>Giải phóng ảnh trong bộ nhớ khi Form đóng.</summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            picAvatar.Image?.Dispose();
            picAvatar.Image = null;
            base.OnFormClosed(e);
        }

        // =====================================================
        // PREVIEW THẺ (GDI+)
        // =====================================================

        /// <summary>Bất kỳ dữ liệu nào đổi -> yêu cầu vẽ lại thẻ.</summary>
        private void RefreshPreview(object? sender, EventArgs e)
        {
            pnlCard.Invalidate();
        }

        /// <summary>Paint event của pnlCard: gọi hàm vẽ thẻ.</summary>
        private void pnlCard_Paint(object? sender, PaintEventArgs e)
        {
            var bounds = new Rectangle(0, 0,
                pnlCard.ClientSize.Width, pnlCard.ClientSize.Height);

            DrawCard(e.Graphics, bounds, GetCardData(), picAvatar.Image);
        }

        /// <summary>Đọc dữ liệu hiện tại từ các control.</summary>
        private CardData GetCardData()
        {
            return new CardData(
                StudentId: txtStudentId.Text.Trim(),
                FullName: txtFullName.Text.Trim(),
                BirthDate: dtpBirthDate.Value.ToString("dd/MM/yyyy"),
                Gender: cboGender.Text,
                ClassName: cboClass.Text,
                Faculty: cboFaculty.Text,
                Course: cboCourse.Text);
        }

        /// <summary>
        /// Tạo font tính bằng PIXEL trong "bản vẽ chuẩn" 520x328.
        /// Nhờ vậy cỡ chữ luôn tỉ lệ đúng với thẻ, dù vẽ lên màn hình
        /// hay lên trang in (đơn vị 1/100 inch). Nhập cỡ theo point như cũ.
        /// </summary>
        private static Font MakeFont(float sizePt, FontStyle style)
        {
            return new Font("Segoe UI", sizePt * 96f / 72f, style, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Vẽ thẻ sinh viên vào vùng 'bounds' của Graphics 'g'.
        /// Dùng chung cho preview và in ấn.
        /// </summary>
        private void DrawCard(Graphics g, Rectangle bounds, CardData data, Image? photo)
        {
            var savedState = g.Save();

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Co giãn bản vẽ chuẩn 520x328 vào 'bounds', giữ đúng tỉ lệ, căn giữa
            float scale = Math.Min(bounds.Width / CardW, bounds.Height / CardH);
            float offsetX = bounds.X + (bounds.Width - CardW * scale) / 2f;
            float offsetY = bounds.Y + (bounds.Height - CardH * scale) / 2f;
            g.TranslateTransform(offsetX, offsetY);
            g.ScaleTransform(scale, scale);

            // Mọi thứ vẽ chỉ nằm trong thẻ, góc bo tròn (quan trọng khi in)
            var cardRect = new RectangleF(0, 0, CardW, CardH);
            using (var clipPath = RoundedRect(cardRect, 16))
            {
                g.SetClip(clipPath);
            }

            // ---- Bảng màu ----
            Color navy = Color.FromArgb(10, 56, 120);
            Color blue = Color.FromArgb(30, 110, 190);
            Color teal = Color.FromArgb(0, 150, 170);
            Color gold = Color.FromArgb(240, 190, 60);
            Color ink = Color.FromArgb(30, 40, 60);
            Color muted = Color.FromArgb(120, 130, 145);

            // ---- Kiểu căn chữ dùng chung ----
            using var leftFmt = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap
            };
            using var centerFmt = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoWrap
            };

            // ---- Nền thẻ: gradient chéo trắng -> xanh nhạt ----
            using (var bg = new LinearGradientBrush(cardRect,
                Color.White, Color.FromArgb(205, 224, 248), 45f))
            {
                g.FillRectangle(bg, cardRect);
            }

            // ---- Hoa văn chấm bi mờ ----
            using (var dot = new SolidBrush(Color.FromArgb(28, navy)))
            {
                for (float dx = 300; dx < 515; dx += 12)
                {
                    for (float dy = 150; dy < 300; dy += 12)
                    {
                        g.FillEllipse(dot, dx, dy, 3f, 3f);
                    }
                }
            }

            // ---- Hình tròn mờ làm watermark ----
            using (var wm1 = new SolidBrush(Color.FromArgb(18, navy)))
            using (var wm2 = new SolidBrush(Color.FromArgb(14, teal)))
            {
                g.FillEllipse(wm1, 330, 120, 280, 280);
                g.FillEllipse(wm2, -60, 200, 220, 220);
            }

            // ---- Header: gradient 3 màu, viền dưới dạng sóng ----
            var headRect = new RectangleF(0, 0, CardW, 100);
            using (var headPath = new GraphicsPath())
            {
                headPath.AddLine(0, 0, CardW, 0);
                headPath.AddLine(CardW, 0, CardW, 70);
                headPath.AddBezier(CardW, 70, CardW * 0.70f, 96,
                    CardW * 0.35f, 48, 0, 78);
                headPath.CloseFigure();

                using (var headBrush = new LinearGradientBrush(
                    headRect, navy, teal, LinearGradientMode.Horizontal))
                {
                    headBrush.InterpolationColors = new ColorBlend
                    {
                        Colors = new[] { navy, blue, teal },
                        Positions = new[] { 0f, 0.6f, 1f }
                    };
                    g.FillPath(headBrush, headPath);
                }
            }

            // Đường sóng vàng dưới header
            using (var goldWave = new Pen(gold, 3f))
            {
                g.DrawBezier(goldWave,
                    CardW, 75, CardW * 0.70f, 101,
                    CardW * 0.35f, 53, 0, 83);
            }

            // Vòng tròn trang trí mờ trên header
            using (var deco = new SolidBrush(Color.FromArgb(30, Color.White)))
            {
                g.FillEllipse(deco, 410, -60, 180, 180);
                g.FillEllipse(deco, 350, 14, 80, 80);
            }

            // ---- Logo tròn "SP" viền vàng đôi ----
            var logoRect = new RectangleF(20, 12, 54, 54);
            using (var white = new SolidBrush(Color.White))
            using (var ring = new Pen(gold, 3f))
            using (var ringOuter = new Pen(Color.FromArgb(120, gold), 1.5f))
            using (var logoFont = MakeFont(16f, FontStyle.Bold))
            using (var logoBrush = new SolidBrush(navy))
            {
                g.FillEllipse(white, logoRect);
                g.DrawEllipse(ring, logoRect);
                g.DrawEllipse(ringOuter, RectangleF.Inflate(logoRect, 4, 4));
                g.DrawString("SP", logoFont, logoBrush, logoRect, centerFmt);
            }

            // ---- Chữ trên header ----
            using (var schoolFont = MakeFont(9.5f, FontStyle.Bold))
            using (var titleFont = MakeFont(20f, FontStyle.Bold))
            using (var whiteBrush = new SolidBrush(Color.White))
            using (var goldBrush = new SolidBrush(gold))
            {
                g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH",
                    schoolFont, whiteBrush, new RectangleF(90, 10, 430, 24), leftFmt);

                g.DrawString("THẺ SINH VIÊN",
                    titleFont, goldBrush, new RectangleF(90, 32, 430, 38), leftFmt);
            }

            // ---- Ảnh sinh viên: bóng đổ + khung gradient bo góc ----
            var photoRect = new RectangleF(28, 102, 120, 160); // tỉ lệ 3x4
            var frameRect = RectangleF.Inflate(photoRect, 5, 5);

            using (var shadowBrush = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
            using (var shadowPath = RoundedRect(
                new RectangleF(frameRect.X + 3, frameRect.Y + 4,
                    frameRect.Width, frameRect.Height), 10))
            {
                g.FillPath(shadowBrush, shadowPath);
            }

            using (var framePath = RoundedRect(frameRect, 10))
            using (var frameFill = new SolidBrush(Color.White))
            using (var frameBrush = new LinearGradientBrush(
                frameRect, navy, gold, 60f))
            using (var framePen = new Pen(frameBrush, 3f))
            {
                g.FillPath(frameFill, framePath);

                if (photo != null)
                {
                    DrawImageFit(g, photo, photoRect);
                }
                else
                {
                    using var hintFont = MakeFont(10f, FontStyle.Italic);
                    using var hintBrush = new SolidBrush(Color.Gray);
                    g.DrawString("Ảnh 3x4", hintFont, hintBrush, photoRect, centerFmt);
                }

                g.DrawPath(framePen, framePath);
            }

            // ---- Nhãn khóa học dạng viên thuốc vàng dưới ảnh ----
            var pillRect = new RectangleF(28, 275, 120, 20);
            using (var pillPath = RoundedRect(pillRect, 10))
            using (var pillBrush = new LinearGradientBrush(
                pillRect, Color.FromArgb(250, 210, 90), Color.FromArgb(225, 165, 30), 0f))
            using (var pillFont = MakeFont(9f, FontStyle.Bold))
            using (var pillText = new SolidBrush(navy))
            {
                g.FillPath(pillBrush, pillPath);
                g.DrawString("KHÓA " + data.Course.ToUpper(),
                    pillFont, pillText, pillRect, centerFmt);
            }

            // ---- Họ tên (to, nổi bật) ----
            bool noName = string.IsNullOrEmpty(data.FullName);
            using (var nameFont = MakeFont(16f, FontStyle.Bold))
            using (var nameBrush = new SolidBrush(
                noName ? Color.FromArgb(170, 180, 195) : navy))
            {
                string nameText = noName ? "HỌ VÀ TÊN" : data.FullName.ToUpper();

                g.DrawString(nameText, nameFont, nameBrush,
                    new RectangleF(172, 100, 336, 34), leftFmt);
            }

            // ---- Đường phân cách: đoạn vàng + đoạn xám nhạt ----
            using (var goldBrush = new SolidBrush(gold))
            using (var lightPen = new Pen(Color.FromArgb(190, 205, 225), 1.5f))
            {
                g.FillRectangle(goldBrush, 172, 135, 60, 3);
                g.DrawLine(lightPen, 236, 136.5f, 504, 136.5f);
            }

            // ---- Các dòng thông tin (mỗi thông tin một dòng ngang) ----
            var rows = new (string Label, string Value)[]
            {
                ("Mã SV",     data.StudentId),
                ("Ngày sinh", data.BirthDate),
                ("Giới tính", data.Gender),
                ("Lớp",       data.ClassName),
                ("Khoa",      data.Faculty),
            };

            using (var labelFont = MakeFont(9f, FontStyle.Regular))
            using (var valueFont = MakeFont(10.5f, FontStyle.Bold))
            using (var labelBrush = new SolidBrush(muted))
            using (var valueBrush = new SolidBrush(ink))
            using (var linePen = new Pen(Color.FromArgb(150, 190, 205, 225), 1f))
            {
                float y = 146f;
                const float rowH = 28f;

                foreach (var row in rows)
                {
                    // Nhãn (cột trái)
                    g.DrawString(row.Label, labelFont, labelBrush,
                        new RectangleF(172, y, 72, rowH), leftFmt);

                    // Giá trị (cột phải)
                    string shown = string.IsNullOrWhiteSpace(row.Value) ? "—" : row.Value;
                    g.DrawString(shown, valueFont, valueBrush,
                        new RectangleF(246, y, 180, rowH), leftFmt);

                    // Đường kẻ mảnh phân cách dòng (ngắn lại để chừa chỗ cho QR)
                    g.DrawLine(linePen, 172, y + rowH, 430, y + rowH);

                    y += rowH + 1f;
                }
            }

            // ---- Mã QR giả lập (góc dưới phải, đổi theo Mã SV) ----
            DrawFakeQr(g, 440, 200, 62, data.StudentId, navy);

            // ---- Footer ----
            var footRect = new RectangleF(0, 305, CardW, 23);
            using (var footBrush = new LinearGradientBrush(
                footRect, teal, navy, LinearGradientMode.Horizontal))
            using (var goldBrush = new SolidBrush(gold))
            using (var footFont = MakeFont(7.5f, FontStyle.Italic))
            using (var footText = new SolidBrush(Color.White))
            {
                g.FillRectangle(goldBrush, 0, 302, CardW, 3);
                g.FillRectangle(footBrush, footRect);
                g.DrawString("Thẻ chỉ có giá trị khi sử dụng bởi chính chủ",
                    footFont, footText, footRect, centerFmt);
            }

            // ---- Khung ngoài bo góc ----
            using (var outerPath = RoundedRect(
                new RectangleF(1.5f, 1.5f, CardW - 3f, CardH - 3f), 15))
            using (var outer = new Pen(navy, 3f))
            {
                g.DrawPath(outer, outerPath);
            }

            g.Restore(savedState);
        }

        /// <summary>
        /// Vẽ mã QR giả lập: lưới ô vuông sinh ra từ chuỗi 'seed'.
        /// Cùng Mã SV thì luôn ra cùng một hình.
        /// </summary>
        private static void DrawFakeQr(Graphics g, float x, float y, float size,
            string seed, Color dark)
        {
            const int n = 11;

            // Nền trắng bo góc + viền
            var box = new RectangleF(x, y, size, size);
            using (var boxPath = RoundedRect(box, 5))
            using (var white = new SolidBrush(Color.White))
            using (var border = new Pen(Color.FromArgb(150, dark), 1f))
            {
                g.FillPath(white, boxPath);
                g.DrawPath(border, boxPath);
            }

            // Tạo dãy bit giả ngẫu nhiên cố định theo 'seed'
            uint h = 2166136261;
            unchecked
            {
                foreach (char ch in seed ?? string.Empty)
                {
                    h = (h ^ ch) * 16777619;
                }
            }

            float pad = 5f;
            float cell = (size - pad * 2f) / n;

            using (var darkBrush = new SolidBrush(dark))
            using (var whiteBrush = new SolidBrush(Color.White))
            {
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        // 3 góc dành cho "ô định vị"
                        bool inFinder =
                            (r < 3 && c < 3) ||
                            (r < 3 && c >= n - 3) ||
                            (r >= n - 3 && c < 3);
                        if (inFinder) continue;

                        unchecked { h = h * 1664525u + 1013904223u; }
                        if (((h >> 16) & 1) == 1)
                        {
                            g.FillRectangle(darkBrush,
                                x + pad + c * cell, y + pad + r * cell,
                                cell + 0.4f, cell + 0.4f);
                        }
                    }
                }

                // Vẽ 3 ô định vị: khối đậm 3x3 có lõi trắng 1x1
                void Finder(int r0, int c0)
                {
                    float fx = x + pad + c0 * cell;
                    float fy = y + pad + r0 * cell;
                    g.FillRectangle(darkBrush, fx, fy, cell * 3f, cell * 3f);
                    g.FillRectangle(whiteBrush, fx + cell, fy + cell, cell, cell);
                }

                Finder(0, 0);
                Finder(0, n - 3);
                Finder(n - 3, 0);
            }
        }

        /// <summary>Tạo hình chữ nhật bo góc.</summary>
        private static GraphicsPath RoundedRect(RectangleF r, float radius)
        {
            float d = radius * 2f;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Vẽ ảnh vừa khít trong 'rect', GIỮ ĐÚNG TỈ LỆ (không méo), căn giữa.
        /// </summary>
        private static void DrawImageFit(Graphics g, Image img, RectangleF rect)
        {
            float ratio = Math.Min(rect.Width / img.Width, rect.Height / img.Height);
            float w = img.Width * ratio;
            float h = img.Height * ratio;
            float x = rect.X + (rect.Width - w) / 2f;
            float y = rect.Y + (rect.Height - h) / 2f;

            g.DrawImage(img, x, y, w, h);
        }

        private void FrmStudentCard_Load(object sender, EventArgs e)
        {

        }
    }
}