using QuanLySinhVienMVP.Models;

namespace QuanLySinhVienMVP.Repositories
{
    /// <summary>
    /// REPOSITORY - lưu sinh viên trong bộ nhớ bằng List&lt;Student&gt;.
    /// Có sẵn 8 sinh viên mẫu để kiểm tra ngay khi chạy.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> students;

        public StudentRepository()
        {
            students = new List<Student>
            {
                new Student { MaSV = "SV001", HoTen = "Nguyễn Văn An",   Lop = "CTK47A", Diem = 8.5 },
                new Student { MaSV = "SV002", HoTen = "Trần Thị Bình",   Lop = "CTK47A", Diem = 7.0 },
                new Student { MaSV = "SV003", HoTen = "Lê Minh Cường",   Lop = "CTK47A", Diem = 4.5 },
                new Student { MaSV = "SV004", HoTen = "Phạm Thanh Dung", Lop = "CTK47B", Diem = 9.0 },
                new Student { MaSV = "SV005", HoTen = "Hoàng Gia Huy",   Lop = "CTK47B", Diem = 6.5 },
                new Student { MaSV = "SV006", HoTen = "Võ Thị Hồng",     Lop = "CTK47B", Diem = 3.5 },
                new Student { MaSV = "SV007", HoTen = "Đặng Minh Khôi",  Lop = "CTK48A", Diem = 5.0 },
                new Student { MaSV = "SV008", HoTen = "Bùi Ngọc Lan",    Lop = "CTK48A", Diem = 7.5 },
            };
        }

        public List<Student> GetAll()
        {
            return students.OrderBy(s => s.MaSV).ToList();
        }

        public Student GetByCode(string maSV)
        {
            return students.FirstOrDefault(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        public bool Exists(string maSV)
        {
            return students.Any(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Tìm theo một phần mã hoặc họ tên, không phân biệt hoa thường.</summary>
        public List<Student> Search(string keyword)
        {
            return students
                .Where(s => s.MaSV.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                         || s.HoTen.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s.MaSV)
                .ToList();
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public bool Delete(string maSV)
        {
            Student sv = GetByCode(maSV);
            if (sv == null) return false;

            students.Remove(sv);
            return true;
        }
    }
}