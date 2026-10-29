using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu (Data Access Layer) cho chức năng nhập điểm.
    /// Mọi thao tác với database đều đi qua stored procedure + SqlParameter.
    /// </summary>
    public class KetQuaDAL
    {
        // ------------------------------------------------------------------
        // Hàm dùng chung: gọi stored procedure trả về bảng
        // ------------------------------------------------------------------
        private DataTable ExecuteProcedure(string procedureName, params SqlParameter[] parameters)
        {
            using SqlConnection conn = Database.GetConnection();
            using SqlCommand cmd = new SqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);

            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /// <summary>sp_Lop_GetAll: danh sách lớp (MaLop, TenLop).</summary>
        public DataTable GetLop()
        {
            return ExecuteProcedure("sp_Lop_GetAll");
        }

        /// <summary>sp_MonHoc_GetAll: danh sách môn học (MaMon, TenMon, SoTinChi).</summary>
        public DataTable GetMonHoc()
        {
            return ExecuteProcedure("sp_MonHoc_GetAll");
        }

        /// <summary>
        /// sp_KetQua_GetByLopMon: sinh viên của lớp kèm điểm môn học.
        /// Cột trả về: MaSV, HoTen, Diem (NULL nếu chưa có), GhiChu.
        /// </summary>
        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            return ExecuteProcedure("sp_KetQua_GetByLopMon",
                new SqlParameter("@MaLop", SqlDbType.NVarChar, 20) { Value = maLop },
                new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon });
        }

        /// <summary>
        /// Lưu điểm của TẤT CẢ dòng trong bảng bằng MỘT transaction.
        /// - Mọi dòng thành công  -> Commit, trả về số dòng đã lưu.
        /// - Một dòng bị lỗi      -> Rollback toàn bộ, ném lỗi ra cho Form xử lý.
        /// </summary>
        public int SaveAll(string maMon, DataTable table)
        {
            using SqlConnection conn = Database.GetConnection();
            conn.Open();

            using SqlTransaction trans = conn.BeginTransaction();
            try
            {
                int count = 0;

                foreach (DataRow row in table.Rows)
                {
                    string maSV = row["MaSV"].ToString();
                    object diem = row["Diem"];                       // double hoặc DBNull
                    string ghiChu = row["GhiChu"]?.ToString()?.Trim();

                    // Command phải gắn với transaction (tham số thứ 3)
                    using SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MaSV", SqlDbType.NVarChar, 20) { Value = maSV });
                    cmd.Parameters.Add(new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon });
                    cmd.Parameters.Add(new SqlParameter("@Diem", SqlDbType.Float) { Value = diem ?? DBNull.Value });
                    cmd.Parameters.Add(new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255)
                    {
                        Value = string.IsNullOrEmpty(ghiChu) ? DBNull.Value : ghiChu
                    });

                    cmd.ExecuteNonQuery();
                    count++;
                }

                trans.Commit();     // chỉ commit SAU KHI tất cả dòng đều thành công
                return count;
            }
            catch
            {
                try
                {
                    trans.Rollback();   // hủy mọi dòng đã lưu trong transaction này
                }
                catch
                {
                    // Transaction có thể đã bị SQL Server tự hủy; bỏ qua lỗi rollback
                }
                throw;                  // ném lỗi gốc lên Form để thông báo
            }
        }
    }
}