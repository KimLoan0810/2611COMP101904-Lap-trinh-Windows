USE EduManagerDB; 
GO

-- ======================================
-- PHẦN A: TRUY VẤN CƠ BẢN 
-- ======================================

-- Câu 1. Liệt kê toàn bộ sinh viên
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN
ORDER BY MaSV;

-- Câu 2. Sinh viên kèm tên lớp và tên khoa
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa
ORDER BY sv.MaSV;

-- Câu 3. Tìm sinh viên theo một phần họ tên
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen ASC;

-- Câu 4. Sinh viên theo mã lớp
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';

-- ======================================
-- PHẦN B: UPDATE VÀ DELETE
-- ======================================

-- Câu 5. Cập nhật họ tên hoặc lớp
-- 5a. Xem trước
SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV IN ('SV001', 'SV006');

-- 5b. Sửa họ tên SV001
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (đã cập nhật)'
WHERE MaSV = 'SV001';

-- 5c. Chuyển SV006 từ SPTIN01 sang CNTT01
UPDATE SINHVIEN
SET MaLop = 'CNTT01'
WHERE MaSV = 'SV006';

-- 5d. Xem lại

-- Câu 6. Xóa sinh viên chưa có điểm
-- 6a. SV007 có điểm không? (phải ra 0 dòng)
SELECT * FROM KETQUA WHERE MaSV = 'SV007';

-- 6b. Xóa, chỉ khi chưa có điểm
DELETE FROM SINHVIEN
WHERE MaSV = 'SV007'
  AND NOT EXISTS (SELECT 1 FROM KETQUA kq WHERE kq.MaSV = SINHVIEN.MaSV);

-- 6c. Kiểm tra đã mất
SELECT * FROM SINHVIEN WHERE MaSV = 'SV007';

-- ======================================
-- PHẦN C: JOIN VÀ THỐNG KÊ
-- ======================================

-- Câu 7. Điểm của từng sinh viên theo từng môn
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC  mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;

-- Câu 8. Điểm trung bình từng sinh viên
SELECT sv.MaSV, sv.HoTen,
       CAST(AVG(kq.Diem) AS DECIMAL(4,2)) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen
ORDER BY DiemTrungBinh DESC;

-- Câu 9. Số sinh viên theo từng lớp
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;

-- Câu 10. Lớp có từ 2 sinh viên trở lên
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2
ORDER BY l.MaLop;

-- ======================================
-- PHẦN D: KIỂM THỬ RÀNG BUỘC
-- ======================================

-- Câu 11. Thêm sinh viên vào lớp không tồn tại
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');

-- Câu 12. Nhập điểm ngoài khoảng 0–10
-- 12a. Điểm > 10
INSERT INTO KETQUA (MaSV, MaMH, Diem)
VALUES ('SV003', 'COMP1020', 12);

-- 12b. Điểm âm
INSERT INTO KETQUA (MaSV, MaMH, Diem)
VALUES ('SV004', 'COMP1020', -1);

-- Câu 13–15 (bổ sung, để được điểm tối đa phần kiểm thử)
-- 13. Giới tính sai
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV998', N'Sinh viên giới tính lỗi', '2005-01-01', N'Khác', 'CNTT01');

-- 14. Trùng mã sinh viên
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT01');

-- 15. Số tín chỉ = 0
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi)
VALUES ('COMP9999', N'Môn lỗi', 0);

