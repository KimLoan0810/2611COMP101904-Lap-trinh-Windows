using QuanLySinhVienMVP.Models;

namespace QuanLySinhVienMVP.Views
{
    /// <summary>Ô nhập liệu bị lỗi, để View đưa con trỏ tới đúng chỗ.</summary>
    public enum InputField
    {
        None,
        StudentCode,
        FullName,
        ClassName,
        Score,
        Keyword
    }

    /// <summary>
    /// VIEW INTERFACE - mọi thứ Presenter được phép "nói chuyện" với Form.
    /// Presenter chỉ thấy các thuộc tính chuỗi và phương thức này,
    /// không bao giờ thấy TextBox hay DataGridView.
    /// </summary>
    public interface IStudentView
    {
        // ---- Dữ liệu người dùng nhập (dạng chuỗi, Presenter tự kiểm tra) ----
        string StudentCode { get; set; }
        string FullName { get; set; }
        string ClassName { get; set; }
        string ScoreText { get; set; }
        string Keyword { get; set; }

        // ---- Presenter yêu cầu View hiển thị ----
        void ShowStudents(List<Student> students);
        void ShowStatistics(int total, double average, int passed);
        void ShowMessage(string message);
        void ShowError(string message, InputField field);
        void ShowStatus(string text, bool isError);
        bool Confirm(string message);
        void ClearInput();
        void SelectStudentRow(string studentCode);
    }
}