/* =====================================================================
   COMP1019 - LAB 12 - Data Binding, Stored Procedure và Transaction
   File   : QLSinhVienLab12.sql
   Nội dung: Tạo database QLSinhVienLab12, 4 bảng, dữ liệu mẫu,
             4 stored procedure bắt buộc.
   SV     : Huỳnh Thị Hồng Ân - MSSV 49.01.103.006 - Lớp 49.01.SPTIN.A
   Cách chạy: mở trong SSMS, bấm F5 chạy toàn bộ. Chạy lại được nhiều lần.
   ===================================================================== */

USE master;
GO

-- 1. Xóa database cũ (nếu có) để chạy lại từ đầu
IF DB_ID(N'QLSinhVienLab12') IS NOT NULL
BEGIN
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLSinhVienLab12;
END
GO

CREATE DATABASE QLSinhVienLab12;
GO

USE QLSinhVienLab12;
GO

/* =========================== 2. TẠO BẢNG =========================== */

-- LOP: khóa chính MaLop
CREATE TABLE LOP (
    MaLop   NVARCHAR(20)  NOT NULL,
    TenLop  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop)
);
GO

-- SINHVIEN: khóa chính MaSV, khóa ngoại MaLop -> LOP
CREATE TABLE SINHVIEN (
    MaSV      NVARCHAR(20)  NOT NULL,
    HoTen     NVARCHAR(100) NOT NULL,
    NgaySinh  DATE          NULL,
    MaLop     NVARCHAR(20)  NOT NULL,
    CONSTRAINT PK_SINHVIEN PRIMARY KEY (MaSV),
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- MONHOC: khóa chính MaMon, số tín chỉ > 0
CREATE TABLE MONHOC (
    MaMon     NVARCHAR(20)  NOT NULL,
    TenMon    NVARCHAR(100) NOT NULL,
    SoTinChi  INT           NOT NULL,
    CONSTRAINT PK_MONHOC PRIMARY KEY (MaMon),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

-- KETQUA: khóa chính ghép (MaSV, MaMon), điểm từ 0 đến 10
CREATE TABLE KETQUA (
    MaSV    NVARCHAR(20)  NOT NULL,
    MaMon   NVARCHAR(20)  NOT NULL,
    Diem    FLOAT         NOT NULL,
    GhiChu  NVARCHAR(255) NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMon),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem >= 0 AND Diem <= 10),
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV)  REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMon) REFERENCES MONHOC(MaMon)
);
GO

/* ========================= 3. DỮ LIỆU MẪU ========================= */

INSERT INTO LOP (MaLop, TenLop) VALUES
(N'CTK47A', N'Công nghệ thông tin K47A'),
(N'CTK47B', N'Công nghệ thông tin K47B');

INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES
(N'SV001', N'Nguyễn Văn An',     '2005-01-15', N'CTK47A'),
(N'SV002', N'Trần Thị Bình',     '2005-05-20', N'CTK47A'),
(N'SV003', N'Lê Minh Cường',     '2005-03-11', N'CTK47A'),
(N'SV004', N'Võ Thị Diễm',       '2005-09-02', N'CTK47A'),
(N'SV005', N'Hoàng Gia Huy',     '2005-11-23', N'CTK47A'),
(N'SV006', N'Phạm Thanh Dung',   '2005-07-09', N'CTK47B'),
(N'SV007', N'Đặng Quốc Khánh',   '2005-02-28', N'CTK47B'),
(N'SV008', N'Bùi Ngọc Lan',      '2005-06-14', N'CTK47B');

INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES
(N'COMP1019', N'Lập trình trên Windows', 3),
(N'COMP1017', N'Cơ sở lập trình',        3),
(N'COMP1020', N'Cơ sở dữ liệu',          3);

-- Một vài điểm có sẵn: SV001, SV002 đã có điểm COMP1019 (để thấy UPDATE),
-- các sinh viên còn lại chưa có điểm (để thấy INSERT).
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES
(N'SV001', N'COMP1019', 8.5, N'Nhập từ học kỳ trước'),
(N'SV002', N'COMP1019', 7.0, NULL),
(N'SV006', N'COMP1020', 9.0, NULL);
GO

/* ======================= 4. STORED PROCEDURE ======================= */

-- 4.1. Lấy danh sách lớp
CREATE OR ALTER PROCEDURE sp_Lop_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLop, TenLop
    FROM LOP
    ORDER BY TenLop;
END;
GO

-- 4.2. Lấy danh sách môn học
CREATE OR ALTER PROCEDURE sp_MonHoc_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMon, TenMon, SoTinChi
    FROM MONHOC
    ORDER BY TenMon;
END;
GO

-- 4.3. Lấy sinh viên của lớp kèm điểm môn học (nếu đã có)
--      LEFT JOIN: sinh viên chưa có điểm vẫn hiện, Diem = NULL (ô trống)
CREATE OR ALTER PROCEDURE sp_KetQua_GetByLopMon
    @MaLop NVARCHAR(20),
    @MaMon NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV,
           sv.HoTen,
           kq.Diem,                          -- NULL nếu chưa có điểm
           ISNULL(kq.GhiChu, N'') AS GhiChu
    FROM SINHVIEN sv
    LEFT JOIN KETQUA kq
           ON sv.MaSV = kq.MaSV
          AND kq.MaMon = @MaMon
    WHERE sv.MaLop = @MaLop
    ORDER BY sv.MaSV;
END;
GO

-- 4.4. Lưu điểm (upsert): đã có thì UPDATE, chưa có thì INSERT
CREATE OR ALTER PROCEDURE sp_KetQua_Save
    @MaSV   NVARCHAR(20),
    @MaMon  NVARCHAR(20),
    @Diem   FLOAT,
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = @MaSV AND MaMon = @MaMon)
    BEGIN
        UPDATE KETQUA
        SET Diem = @Diem,
            GhiChu = @GhiChu
        WHERE MaSV = @MaSV AND MaMon = @MaMon;
    END
    ELSE
    BEGIN
        INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu)
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
    END
END;
GO

/* ========================= 5. KIỂM TRA NHANH ========================= */

EXEC sp_Lop_GetAll;
EXEC sp_MonHoc_GetAll;
EXEC sp_KetQua_GetByLopMon @MaLop = N'CTK47A', @MaMon = N'COMP1019';
GO

/* Câu dùng để chụp "trước / sau khi lưu" trong SSMS:
SELECT kq.MaSV, sv.HoTen, kq.MaMon, kq.Diem, kq.GhiChu
FROM KETQUA kq JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
ORDER BY kq.MaMon, kq.MaSV;
*/