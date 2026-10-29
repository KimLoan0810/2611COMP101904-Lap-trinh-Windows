using QuanLySinhVienMVP.Models;

namespace QuanLySinhVienMVP.Repositories
{
    /// <summary>
    /// Hợp đồng lưu trữ sinh viên. Presenter chỉ biết interface này,
    /// nên sau này đổi từ List sang SQL Server chỉ cần viết lớp mới.
    /// </summary>
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetByCode(string maSV);
        bool Exists(string maSV);
        List<Student> Search(string keyword);
        void Add(Student student);
        bool Delete(string maSV);
    }
}