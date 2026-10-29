using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduManager.Models
{
    /// <summary>
    /// Entity ánh xạ tới bảng MONHOC trong SQL Server.
    /// Mỗi thuộc tính = một cột; mỗi đối tượng MonHoc = một dòng.
    /// </summary>
    [Table("MONHOC")]
    public class MonHoc
    {
        /// <summary>Mã môn học - khóa chính, nvarchar(10).</summary>
        [Key]
        [StringLength(10)]
        public string MaMonHoc { get; set; }

        /// <summary>Tên môn học - bắt buộc, nvarchar(100).</summary>
        [Required]
        [StringLength(100)]
        public string TenMonHoc { get; set; }

        /// <summary>Số tín chỉ từ 1 đến 6 (database có CHECK, BLL kiểm tra lại).</summary>
        [Range(1, 6)]
        public int SoTinChi { get; set; }

        /// <summary>true = còn sử dụng, false = ngừng sử dụng.</summary>
        public bool TrangThai { get; set; } = true;
    }
}