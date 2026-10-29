namespace QuanLySinhVienMVP.Models
{
    /// <summary>
    /// MODEL - dữ liệu một sinh viên. Không biết gì về giao diện hay nơi lưu trữ.
    /// </summary>
    public class Student
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string Lop { get; set; }
        public double Diem { get; set; }

        /// <summary>Chỉ đọc: Đạt nếu điểm từ 5 trở lên.</summary>
        public string KetQua
        {
            get { return Diem >= 5 ? "Đạt" : "Không đạt"; }
        }
    }
}