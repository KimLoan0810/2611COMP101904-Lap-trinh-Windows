/* =====================================================================
   COMP1019 - LAB 14 - Entity Framework và mô hình ba lớp
   File   : Lab14_MONHOC.sql
   Nội dung: Tạo database EduManagerDB (nếu chưa có) và bảng MONHOC
             đúng cấu trúc đề Lab 14, kèm dữ liệu mẫu.
   Chạy   : mở trong SSMS, bấm F5. Chạy lại nhiều lần được.

   LƯU Ý: Database EduManagerDB của Lab 10 đã có bảng MONHOC kiểu cũ
   (cột MaMH, TenMH) và bảng KETQUA đang tham chiếu tới nó.
   Script KHÔNG xóa bảng cũ mà đổi tên thành MONHOC_Lab10 để giữ dữ liệu
   Lab 10, rồi tạo bảng MONHOC mới cho Lab 14.
   ===================================================================== */

USE master;
GO

-- 1. Tạo database nếu chưa có
IF DB_ID(N'EduManagerDB') IS NULL
    CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

-- 2. Nếu MONHOC đang là bảng kiểu Lab 10 (có cột MaMH) -> đổi tên để giữ lại
IF OBJECT_ID(N'dbo.MONHOC', N'U') IS NOT NULL
   AND COL_LENGTH(N'dbo.MONHOC', N'MaMH') IS NOT NULL
BEGIN
    EXEC sp_rename N'dbo.MONHOC', N'MONHOC_Lab10';
    PRINT N'Đã đổi tên bảng MONHOC (Lab 10) thành MONHOC_Lab10.';
END
GO

-- 3. Nếu MONHOC kiểu Lab 14 đã có (chạy lại script) -> xóa để tạo lại
IF OBJECT_ID(N'dbo.MONHOC', N'U') IS NOT NULL
    DROP TABLE dbo.MONHOC;
GO

-- 4. Tạo bảng MONHOC theo đề Lab 14
--    (tên ràng buộc khác Lab 10 để không trùng với bảng MONHOC_Lab10)
CREATE TABLE dbo.MONHOC (
    MaMonHoc   NVARCHAR(10)  NOT NULL,
    TenMonHoc  NVARCHAR(100) NOT NULL,
    SoTinChi   INT           NOT NULL,
    TrangThai  BIT           NOT NULL
        CONSTRAINT DF_MONHOC_TrangThai DEFAULT 1,
    CONSTRAINT PK_MONHOC_MaMonHoc PRIMARY KEY (MaMonHoc),
    CONSTRAINT CK_MONHOC_SoTinChi_1_6 CHECK (SoTinChi BETWEEN 1 AND 6)
);
GO

-- 5. Dữ liệu mẫu (TrangThai: 1 = còn sử dụng, 0 = ngừng sử dụng)
INSERT INTO dbo.MONHOC (MaMonHoc, TenMonHoc, SoTinChi, TrangThai) VALUES
(N'COMP1017', N'Lập trình cơ bản',              3, 1),
(N'COMP1019', N'Lập trình trên Windows',        3, 1),
(N'COMP1020', N'Cơ sở dữ liệu',                 3, 1),
(N'COMP1044', N'Nhập môn Công nghệ phần mềm',   3, 1),
(N'COMP1301', N'Mạng máy tính',                 3, 1),
(N'COMP1820', N'Thiết kế khóa học trực tuyến',  2, 1),
(N'MATH1001', N'Giải tích 1',                   4, 1),
(N'COMP1001', N'Tin học đại cương (chương trình cũ)', 2, 0);
GO

-- 6. Kiểm tra
SELECT MaMonHoc, TenMonHoc, SoTinChi, TrangThai
FROM dbo.MONHOC
ORDER BY MaMonHoc;
GO