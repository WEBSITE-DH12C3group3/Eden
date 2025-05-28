-- Xóa database cũ nếu có
DROP DATABASE IF EXISTS QLBanHoa;
GO

-- Tạo database mới
CREATE DATABASE QLBanHoa;
GO

USE QLBanHoa;
GO

-- Bảng Nhóm Người Dùng (Quản lý nhóm quyền)
CREATE TABLE NHOMNGUOIDUNG (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaNhomNguoiDung AS CAST('NND' + RIGHT('000' + CAST(id AS VARCHAR(5)), 3) AS CHAR(6)) PERSISTED,
    TenNhomNguoiDung NVARCHAR(255) NOT NULL
);
GO

-- Bảng Chức Năng (Các quyền trong hệ thống)
CREATE TABLE CHUCNANG (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaChucNang AS CAST('CN' + RIGHT('000' + CAST(id AS VARCHAR(3)), 3) AS CHAR(5)) PERSISTED,
    TenChucNang NVARCHAR(255) NOT NULL,
    TenManHinh NVARCHAR(255) NOT NULL
);
GO

-- Bảng Phân Quyền
CREATE TABLE PHANQUYEN (
    idNhomNguoiDung INT FOREIGN KEY REFERENCES NHOMNGUOIDUNG(id) ON DELETE CASCADE,
    idChucNang INT FOREIGN KEY REFERENCES CHUCNANG(id) ON DELETE CASCADE,
    PRIMARY KEY (idNhomNguoiDung, idChucNang)
);
GO

-- Bảng Người Dùng
CREATE TABLE NGUOIDUNG (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung AS CAST('ND' + RIGHT('000000' + CAST(id AS VARCHAR(4)), 4) AS CHAR(6)) PERSISTED,
    TenNguoiDung NVARCHAR(255) NOT NULL,
    TenDangNhap VARCHAR(100) UNIQUE NOT NULL,
    MatKhau VARCHAR(255) NOT NULL,
    idNhomNguoiDung INT REFERENCES NHOMNGUOIDUNG(id) ON DELETE CASCADE NOT NULL,
    CaLamViec NVARCHAR(50),
    MaNhanVien AS CAST('NV' + RIGHT('0000' + CAST(id AS VARCHAR(4)), 4) AS CHAR(6)) PERSISTED,
    LuongCoDinh DECIMAL(10,2),
    NgayBatDauLam DATETIME,
    TrangThai NVARCHAR(50) DEFAULT N'Đang làm'
);
GO

-- Bảng Loại Sản Phẩm
CREATE TABLE LOAISANPHAM (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaLoaiSanPham AS ('LSP' + RIGHT('000' + CAST(id AS VARCHAR(3)), 3)) PERSISTED,
    TenLoaiSanPham NVARCHAR(255) NOT NULL
);
GO

-- Bảng Nhà Cung Cấp
CREATE TABLE NHACUNGCAP (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaNhaCungCap AS ('NCC' + RIGHT('000' + CAST(id AS VARCHAR(3)), 3)) PERSISTED,
    TenNhaCungCap NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(MAX),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(255)
);
GO

-- Bảng Sản Phẩm (Hoa)
CREATE TABLE SANPHAM (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaSanPham AS ('SP' + RIGHT('000' + CAST(id AS VARCHAR(3)), 3)) PERSISTED,
    TenSanPham NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(MAX),
    Gia DECIMAL(10,2) NOT NULL,
    SoLuong INT NOT NULL,
    DaBan INT DEFAULT 0, -- Số lượng đã bán
    MauSac NVARCHAR(50),
    AnhChiTiet NVARCHAR(255),
    idNhaCungCap INT REFERENCES NHACUNGCAP(id) ON DELETE CASCADE,
    idLoaiSanPham INT REFERENCES LOAISANPHAM(id) ON DELETE CASCADE NOT NULL
);
GO

-- Bảng Khách Hàng
CREATE TABLE KHACHHANG (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang AS CAST('KH' + RIGHT('0000' + CAST(id AS VARCHAR(10)), 4) AS CHAR(6)) PERSISTED,
    TenKhachHang NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(MAX),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(255)
);
GO

-- Bảng Hóa Đơn
CREATE TABLE HOADON (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon AS CAST('HD' + RIGHT('0000' + CAST(id AS VARCHAR(10)), 4) AS CHAR(6)) PERSISTED,
    NgayLap DATETIME NOT NULL,
    idKhachHang INT REFERENCES KHACHHANG(id) ON DELETE CASCADE, 
    idNguoiDung INT REFERENCES NGUOIDUNG(id) ON DELETE CASCADE, -- Người lập hóa đơn
    TongTien DECIMAL(10,2) NOT NULL
);
GO

-- Bảng Chi Tiết Hóa Đơn
CREATE TABLE CHITIETHOADON (
    idHoaDon INT REFERENCES HOADON(id) ON DELETE CASCADE,
    idSanPham INT REFERENCES SANPHAM(id) ON DELETE CASCADE,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(10,2) NOT NULL,
    ThanhTien DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (idHoaDon, idSanPham)
);
GO

-- Bảng Nhập Hàng
CREATE TABLE PHIEUNHAP (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap AS CAST('PN' + RIGHT('0000' + CAST(id AS VARCHAR(10)), 4) AS CHAR(6)) PERSISTED,
    NgayNhap DATETIME NOT NULL,
    idNhaCungCap INT REFERENCES NHACUNGCAP(id) ON DELETE CASCADE,
    idNguoiDung INT REFERENCES NGUOIDUNG(id) ON DELETE CASCADE,
    TongTien DECIMAL(10,2) NOT NULL
);
GO

-- Bảng Chi Tiết Phiếu Nhập
CREATE TABLE CHITIETPHIEUNHAP (
    idPhieuNhap INT REFERENCES PHIEUNHAP(id) ON DELETE NO ACTION,
    idSanPham INT REFERENCES SANPHAM(id) ON DELETE NO ACTION,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(10,2) NOT NULL,
    ThanhTien DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (idPhieuNhap, idSanPham)
);
GO

-- Bảng Chấm Công
CREATE TABLE CHAMCONG (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaChamCong AS CAST('CC' + RIGHT('0000' + CAST(id AS VARCHAR(4)), 4) AS CHAR(6)) PERSISTED,
    idNguoiDung INT FOREIGN KEY REFERENCES NGUOIDUNG(id) ON DELETE CASCADE NOT NULL,
    NgayChamCong DATE NOT NULL,
    GioDangNhap TIME,
    GioDangXuat TIME,
    CaLamViec NVARCHAR(50),
    TrangThai NVARCHAR(50) DEFAULT N'Đi làm'
);
GO

-- Bảng Lương
CREATE TABLE LUONG (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaLuong AS CAST('L' + RIGHT('0000' + CAST(id AS VARCHAR(4)), 4) AS CHAR(6)) PERSISTED,
    idNguoiDung INT FOREIGN KEY REFERENCES NGUOIDUNG(id) ON DELETE CASCADE NOT NULL,
    ThangNam VARCHAR(6) NOT NULL,
    LuongCoDinh DECIMAL(10,2) NOT NULL,
    TongDoanhSo DECIMAL(12,2) NOT NULL,
    PhatDiMuon DECIMAL(10,2) DEFAULT 0,
    PhatNghiBuoi DECIMAL(10,2) DEFAULT 0,
    TroCap DECIMAL(10,2) DEFAULT 0,
    Thuong DECIMAL(10,2) DEFAULT 0,
    TongLuong DECIMAL(10,2) NOT NULL,
    NgayTinhLuong DATETIME NOT NULL,
    GhiChu NVARCHAR(MAX)
);
GO

-- Bảng Tham Số (Cấu hình hệ thống)
CREATE TABLE THAMSO (
    id INT IDENTITY(1,1) PRIMARY KEY,
    SoLuongTonToiThieu INT NOT NULL, -- Số lượng tối thiểu trong kho
    MucGiamGia DECIMAL(5,2) DEFAULT 0, -- Mức giảm giá mặc định
    ThoiGianBaoHanh INT DEFAULT 0 -- Thời gian bảo hành nếu có
);
GO

-- Thêm dữ liệu vào bảng NHOMNGUOIDUNG
INSERT INTO NHOMNGUOIDUNG (TenNhomNguoiDung)
VALUES 
    (N'Quản trị viên'),
    (N'Nhân viên bán hàng'),
    (N'Quản lý kho');
GO

-- Thêm dữ liệu vào bảng CHUCNANG
INSERT INTO CHUCNANG (TenManHinh, TenChucNang)
VALUES 
    (N'Quản lý người dùng', N'QLND'),
    (N'Quản lý sản phẩm', N'QLSP'),
    (N'Quản lý hóa đơn', N'QLHD'),
    (N'Quản lý nhập hàng', N'QLNH'),
    (N'Quản lý khách hàng', N'QLKH'),
    (N'Báo cáo thống kê', N'BCTK'),
    (N'Thay đổi quy định', N'TDQD');
GO

-- Thêm dữ liệu vào bảng PHANQUYEN
INSERT INTO PHANQUYEN (idNhomNguoiDung, idChucNang)
VALUES 
    (1, 1), -- Quản trị viên có quyền quản lý người dùng
    (1, 2), -- Quản trị viên có quyền quản lý sản phẩm
    (1, 3), -- Quản trị viên có quyền quản lý hóa đơn
    (1, 4), -- Quản trị viên có quyền quản lý nhập hàng
    (1, 5), -- Quản trị viên có quyền quản lý khách hàng
    (1, 6),
    (1, 7),
    (2, 2), -- Nhân viên bán hàng có quyền quản lý sản phẩm
    (2, 3), -- Nhân viên bán hàng có quyền quản lý hóa đơn
    (2, 5), -- Nhân viên bán hàng có quyền quản lý khách hàng
    (3, 4), -- Quản lý kho có quyền quản lý nhập hàng
    (3, 6);
GO

-- Thêm dữ liệu vào bảng NGUOIDUNG
INSERT INTO NGUOIDUNG (TenNguoiDung, TenDangNhap, MatKhau, idNhomNguoiDung, CaLamViec, LuongCoDinh, NgayBatDauLam, TrangThai)
VALUES 
    (N'Admin', 'admin', '123456', 1, 'Ca 1: 7h-12h', 5000000, '2023-01-01', N'Đang làm'),
    (N'Nhân viên 1', 'nvien', '1', 2, 'Ca 1: 7h-12h', 3500000, '2023-02-01', N'Đang làm'),
    (N'Quản lý kho 1', 'ql', '1', 3, 'Ca 2: 12h-17h', 5000000, '2023-03-01', N'Đang làm');
GO

-- Thêm dữ liệu vào bảng LOAISANPHAM
INSERT INTO LOAISANPHAM (TenLoaiSanPham)
VALUES 
    (N'Hoa hồng'),
    (N'Hoa cúc'),
    (N'Hoa ly'),
    (N'Hoa tulip');
GO

-- Thêm dữ liệu vào bảng NHACUNGCAP
INSERT INTO NHACUNGCAP (TenNhaCungCap, DiaChi, SoDienThoai, Email)
VALUES 
    (N'Nhà cung cấp A', N'Hà Nội', '0123456789', 'nccA@gmail.com'),
    (N'Nhà cung cấp B', N'Hồ Chí Minh', '0987654321', 'nccB@gmail.com'),
    (N'Nhà cung cấp C', N'Đà Nẵng', '0369852147', 'nccC@gmail.com');
GO

-- Thêm dữ liệu vào bảng SANPHAM
INSERT INTO SANPHAM (TenSanPham, MoTa, Gia, SoLuong, MauSac, AnhChiTiet, idNhaCungCap, idLoaiSanPham)
VALUES 
    (N'Hoa hồng đỏ', N'Hoa hồng đỏ tươi', 50000, 100, N'Đỏ', 'hoahongdo.jpg', 1, 1),
    (N'Hoa cúc trắng', N'Hoa cúc trắng tinh khiết', 30000, 150, N'Trắng', 'hoacuctrang.jpg', 2, 2),
    (N'Hoa ly vàng', N'Hoa ly vàng rực rỡ', 70000, 80, N'Vàng', 'hoalyvang.jpg', 3, 3),
    (N'Hoa tulip hồng', N'Hoa tulip hồng nhẹ nhàng', 60000, 120, N'Hồng', 'hoatuliphong.jpg', 1, 4);
GO

-- Thêm dữ liệu vào bảng KHACHHANG
INSERT INTO KHACHHANG (TenKhachHang, DiaChi, SoDienThoai, Email)
VALUES 
    (N'Khách hàng A', N'Hà Nội', '0123456789', 'khachhangA@gmail.com'),
    (N'Khách hàng B', N'Hồ Chí Minh', '0987654321', 'khachhangB@gmail.com'),
    (N'Khách hàng C', N'Đà Nẵng', '0369852147', 'khachhangC@gmail.com');
GO

-- Thêm dữ liệu vào bảng HOADON
INSERT INTO HOADON (NgayLap, idKhachHang, idNguoiDung, TongTien)
VALUES 
    ('2025-04-05', 1, 1, 100000),
    ('2025-04-06', 2, 1, 200000),
    ('2025-04-07', 3, 1, 300000),
    ('2025-04-01', 1, 2, 50000),
    ('2025-04-08', 2, 2, 100000),
    ('2025-04-09', 3, 2, 200000),
    ('2025-04-10', 1, 2, 300000),
    ('2025-04-11', 2, 2, 400000),
    ('2025-04-12', 3, 2, 500000),
    ('2025-04-13', 1, 2, 600000),
    ('2025-04-14', 2, 2, 700000),
    ('2025-04-15', 3, 2, 800000),
    ('2025-04-03', 1, 1, 100000),
    ('2025-04-02', 2, 1, 200000),
    ('2025-04-01', 3, 1, 300000),
    ('2025-04-05', 1, 2, 100000),
    ('2025-04-06', 2, 2, 200000),
    ('2025-04-07', 3, 2, 300000),
    ('2025-04-04', 1, 2, 100000),
    ('2025-04-03', 2, 2, 200000),
    ('2025-04-02', 3, 2, 300000),
    ('2025-04-01', 1, 2, 100000),
    ('2025-04-08', 2, 2, 200000),
    ('2025-04-09', 3, 2, 300000),
    ('2025-04-10', 1, 2, 400000),
    ('2025-04-11', 2, 2, 500000),
    ('2025-04-12', 3, 2, 600000),
    ('2025-04-13', 1, 2, 700000),
    ('2025-04-14', 2, 2, 800000),
    ('2025-04-15', 3, 2, 900000),
    ('2025-04-04', 1, 2, 150000),
    ('2025-04-03', 2, 2, 200000),
    ('2025-04-02', 3, 2, 250000);
GO

-- Thêm dữ liệu vào bảng CHITIETHOADON
INSERT INTO CHITIETHOADON (idHoaDon, idSanPham, SoLuong, DonGia, ThanhTien)
VALUES 
    (1, 1, 2, 50000, 100000),
    (1, 2, 1, 30000, 30000),
    (2, 3, 3, 70000, 210000),
    (3, 4, 4, 60000, 240000),
    (4, 1, 5, 50000, 250000),
    (5, 2, 6, 30000, 180000),
    (6, 3, 7, 70000, 490000),
    (7, 4, 8, 60000, 480000),
    (8, 1, 9, 50000, 450000),
    (9, 2, 10, 30000, 300000),
    (10, 3, 11, 70000, 770000),
    (11, 4, 12, 60000, 720000),
    (12, 1, 13, 50000, 650000),
    (13, 2, 14, 30000, 420000),
    (14, 3, 15, 70000, 1050000),
    (15, 4, 16, 60000, 960000);
GO

-- Thêm dữ liệu vào bảng PHIEUNHAP
INSERT INTO PHIEUNHAP (NgayNhap, idNhaCungCap, idNguoiDung, TongTien)
VALUES 
    ('2023-10-01', 1, 3, 500000),
    ('2023-10-02', 2, 3, 450000),
    ('2023-10-03', 3, 3, 600000);
GO

-- Thêm dữ liệu vào bảng CHITIETPHIEUNHAP
INSERT INTO CHITIETPHIEUNHAP (idPhieuNhap, idSanPham, SoLuong, DonGia, ThanhTien)
VALUES 
    (1, 1, 10, 50000, 500000),
    (2, 2, 15, 30000, 450000),
    (3, 3, 8, 70000, 560000),
    (3, 4, 10, 60000, 600000);
GO

-- Thêm dữ liệu vào bảng CHAMCONG
INSERT INTO CHAMCONG (idNguoiDung, NgayChamCong, GioDangNhap, GioDangXuat, CaLamViec, TrangThai)
VALUES 
    (1, '2025-05-26', '07:10', '12:00', 'Ca 1: 7h-12h', N'Đi muộn'),
    (1, '2025-05-27', '07:00', '12:00', 'Ca 1: 7h-12h', N'Đi làm'),
    (2, '2025-05-26', '07:15', '12:00', 'Ca 1: 7h-12h', N'Đi muộn'),
    (2, '2025-05-27', NULL, NULL, 'Ca 1: 7h-12h', N'Nghỉ phép');
GO

-- Thêm dữ liệu vào bảng LUONG
INSERT INTO LUONG (idNguoiDung, ThangNam, LuongCoDinh, TongDoanhSo, PhatDiMuon, PhatNghiBuoi, TroCap, Thuong, TongLuong, NgayTinhLuong, GhiChu)
VALUES 
    (1, '052025',
     (SELECT LuongCoDinh FROM NGUOIDUNG WHERE id = 1),
     (SELECT COALESCE(SUM(TongTien), 0) FROM HOADON WHERE idNguoiDung = 1 AND NgayLap BETWEEN '2025-05-01' AND '2025-05-27'),
     20,
     0,
     500000,
     (SELECT COALESCE(SUM(TongTien) * 0.01, 0) FROM HOADON WHERE idNguoiDung = 1 AND NgayLap BETWEEN '2025-05-01' AND '2025-05-27'),
     (SELECT LuongCoDinh - 20 + 500000 + COALESCE(SUM(TongTien) * 0.01, 0) FROM NGUOIDUNG nd LEFT JOIN HOADON hd ON hd.idNguoiDung = nd.id AND hd.NgayLap BETWEEN '2025-05-01' AND '2025-05-27' WHERE nd.id = 1 GROUP BY LuongCoDinh),
     '2025-05-27 14:49:00', N'Lương tháng 5/2025'),
    (2, '052025',
     (SELECT LuongCoDinh FROM NGUOIDUNG WHERE id = 2),
     (SELECT COALESCE(SUM(TongTien), 0) FROM HOADON WHERE idNguoiDung = 2 AND NgayLap BETWEEN '2025-05-01' AND '2025-05-27'),
     20,
     100,
     0,
     (SELECT COALESCE(SUM(TongTien) * 0.01, 0) FROM HOADON WHERE idNguoiDung = 2 AND NgayLap BETWEEN '2025-05-01' AND '2025-05-27'),
     (SELECT LuongCoDinh - 20 - 100 + COALESCE(SUM(TongTien) * 0.01, 0) FROM NGUOIDUNG nd LEFT JOIN HOADON hd ON hd.idNguoiDung = nd.id AND hd.NgayLap BETWEEN '2025-05-01' AND '2025-05-27' WHERE nd.id = 2 GROUP BY LuongCoDinh),
     '2025-05-27 14:49:00', N'Lương tháng 5/2025');
GO

-- Thêm dữ liệu vào bảng THAMSO
INSERT INTO THAMSO (SoLuongTonToiThieu, MucGiamGia, ThoiGianBaoHanh)
VALUES 
    (10, 5.00, 0);
GO
