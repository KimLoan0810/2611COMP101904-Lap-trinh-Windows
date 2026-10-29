using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Cấu hình kết nối tới SQL Server, đặt ở một chỗ duy nhất.
    /// </summary>
    public static class Database
    {
        public static readonly string ConnectionString =
            @"Data Source=.;Initial Catalog=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}