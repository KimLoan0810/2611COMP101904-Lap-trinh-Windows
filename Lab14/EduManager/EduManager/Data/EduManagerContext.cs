using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.Data
{
    /// <summary>
    /// DbContext: cầu nối giữa code C# và database EduManagerDB.
    /// Mỗi DbSet tương ứng một bảng.
    /// </summary>
    public class EduManagerContext : DbContext
    {
        // Máy cá nhân: SQL Server mặc định, Windows Authentication.
        // SQL Express: Data Source=.\SQLEXPRESS ; LocalDB: Data Source=(localdb)\MSSQLLocalDB
        public const string ConnectionString =
            @"Data Source=.;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";

        /// <summary>Bảng MONHOC.</summary>
        public DbSet<MonHoc> MonHocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ghi rõ cấu hình bảng MONHOC (bổ sung cho các attribute trong MonHoc.cs)
            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.ToTable("MONHOC");
                entity.HasKey(m => m.MaMonHoc);
                entity.Property(m => m.MaMonHoc).HasMaxLength(10).IsRequired();
                entity.Property(m => m.TenMonHoc).HasMaxLength(100).IsRequired();
                entity.Property(m => m.SoTinChi).IsRequired();
                // Không dùng HasDefaultValue(true) cho TrangThai: với kiểu bool,
                // EF Core sẽ bỏ qua giá trị false khi thêm mới và để database
                // tự điền 1 -> môn "ngừng sử dụng" bị lưu thành "đang sử dụng".
            });
        }
    }
}