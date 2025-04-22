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
    idNhomNguoiDung INT REFERENCES NHOMNGUOIDUNG(id) ON DELETE CASCADE NOT NULL
);
GO

-- Bảng Loại Sản Phẩm
CREATE TABLE LOAISANPHAM (
    id INT IDENTITY(1,1) PRIMARY KEY,
    MaLoaiSanPham AS ('LSP' + RIGHT('000' + CAST(id AS VARCHAR(3)), 3)) PERSISTED,
    TenLoaiSanPham NVARCHAR(255) NOT NULL,
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
    MaSanPham AS ('SP' + RIGHT('000' + CAST(id AS VARCHAR(3)), 3)) PERSISTED;    
    TenSanPham NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(MAX),
    Gia DECIMAL(10,2) NOT NULL,
    SoLuong INT NOT NULL,
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

-- Bảng Tham Số (Cấu hình hệ thống)
CREATE TABLE THAMSO (
    id INT IDENTITY(1,1) PRIMARY KEY,
    SoLuongTonToiThieu INT NOT NULL, -- Số lượng tối thiểu trong kho
    MucGiamGia DECIMAL(5,2) DEFAULT 0, -- Mức giảm giá mặc định
    ThoiGianBaoHanh INT DEFAULT 0 -- Thời gian bảo hành nếu có
);
GO

USE QLBanHoa;
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
INSERT INTO NGUOIDUNG (TenNguoiDung, TenDangNhap, MatKhau, idNhomNguoiDung)
VALUES 
    (N'Admin', 'admin', '1', 1), -- Quản trị viên
    (N'Nhân viên 1', 'nvien', '1', 2), -- Nhân viên bán hàng
    (N'Quản lý kho 1', 'ql', '1', 3); -- Quản lý kho
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
    (N'Hoa hồng đỏ', N'Hoa hồng đỏ tươi', 50000, 100,  N'Đỏ', 'hoahongdo.jpg', 1, 1),
    (N'Hoa cúc trắng', N'Hoa cúc trắng tinh khiết', 30000, 150,  N'Trắng', 'hoacuctrang.jpg', 2, 2),
    (N'Hoa ly vàng', N'Hoa ly vàng rực rỡ', 70000, 80,  N'Vàng', 'hoalyvang.jpg', 3, 3),
    (N'Hoa tulip hồng', N'Hoa tulip hồng nhẹ nhàng', 60000, 120,  N'Hồng', 'hoatuliphong.jpg', 1, 4);
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
    ('2025-04-05', 1, 1, 100000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-06', 2, 1, 200000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-07', 3, 1, 300000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
    ('2025-04-01', 1, 2, 50000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 2
    ('2025-04-08', 2, 2, 100000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 2
    ('2025-04-09', 3, 2, 200000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 2
    ('2025-04-10', 1, 2, 300000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 2
    ('2025-04-11', 2, 2, 400000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 2
    ('2025-04-12', 3, 2, 500000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 2
    ('2025-04-13', 1, 2, 600000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 2
    ('2025-04-14', 2, 2, 700000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 2
    ('2025-04-15', 3, 2, 800000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 2
    ('2025-04-03', 1, 1, 100000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-02', 2, 1, 200000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-01', 3, 1, 300000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
    ('2025-04-05', 1, 2, 100000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-06', 2, 2, 200000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-07', 3, 2, 300000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
    ('2025-04-04', 1, 2, 100000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-03', 2, 2, 200000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-02', 3, 2, 300000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
    ('2025-04-01', 1, 2, 100000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-08', 2, 2, 200000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-09', 3, 2, 300000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
    ('2025-04-10', 1, 2, 400000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-11', 2, 2, 500000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-12', 3, 2, 600000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
    ('2025-04-13', 1, 2, 700000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-14', 2, 2, 800000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-15', 3, 2,900000), -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
    ('2025-04-04', 1, 2, 150000), -- Hóa đơn của khách hàng A, lập bởi nhân viên 1
    ('2025-04-03', 2, 2, 200000), -- Hóa đơn của khách hàng B, lập bởi nhân viên 1
    ('2025-04-02', 3, 2, 250000); -- Hóa đơn của khách hàng C, lập bởi nhân viên 1
GO

-- Thêm dữ liệu vào bảng CHITIETHOADON
INSERT INTO CHITIETHOADON (idHoaDon, idSanPham, SoLuong, DonGia, ThanhTien)
VALUES 
    (1, 1, 2, 50000, 100000), -- Hóa đơn 1, sản phẩm 1
    (1, 2, 1, 30000, 30000),  -- Hóa đơn 1, sản phẩm 2
    (2, 3, 3, 70000, 210000), -- Hóa đơn 2, sản phẩm 3
    (3, 4, 4, 60000, 240000), -- Hóa đơn 3, sản phẩm 4
    (4, 1, 5, 50000, 250000), -- Hóa đơn 4, sản phẩm 1
    (5, 2, 6, 30000, 180000), -- Hóa đơn 5, sản phẩm 2
    (6, 3, 7, 70000, 490000), -- Hóa đơn 6, sản phẩm 3
    (7, 4, 8, 60000, 480000), -- Hóa đơn 7, sản phẩm 4
    (8, 1, 9, 50000, 450000), -- Hóa đơn 8, sản phẩm 1
    (9, 2, 10, 30000, 300000), -- Hóa đơn 9, sản phẩm 2
    (10, 3, 11, 70000,770000), -- Hóa đơn10,sản phẩm3
    (11,4 ,12 ,60000 ,720000), -- Hóa đơn11,sản phẩm4
    (12 ,1 ,13 ,50000 ,650000), -- Hóa đơn12,sản phẩm1
    (13 ,2 ,14 ,30000 ,420000), -- Hóa đơn13,sản phẩm2
    (14 ,3 ,15 ,70000 ,1050000), -- Hóa đơn14,sản phẩm3
    (15 ,4 ,16 ,60000 ,960000); -- Hóa đơn15,sản phẩm4
GO

-- Thêm dữ liệu vào bảng PHIEUNHAP
INSERT INTO PHIEUNHAP (NgayNhap, idNhaCungCap, idNguoiDung, TongTien)
VALUES 
    ('2023-10-01', 1, 3, 500000), -- Phiếu nhập từ nhà cung cấp A, lập bởi quản lý kho 1
    ('2023-10-02', 2, 3, 450000), -- Phiếu nhập từ nhà cung cấp B, lập bởi quản lý kho 1
    ('2023-10-03', 3, 3, 600000); -- Phiếu nhập từ nhà cung cấp C, lập bởi quản lý kho 1
GO

-- Thêm dữ liệu vào bảng CHITIETPHIEUNHAP
INSERT INTO CHITIETPHIEUNHAP (idPhieuNhap, idSanPham, SoLuong, DonGia, ThanhTien)
VALUES 
    (1, 1, 10, 50000, 500000), -- Phiếu nhập 1, sản phẩm 1
    (2, 2, 15, 30000, 450000), -- Phiếu nhập 2, sản phẩm 2
    (3, 3, 8, 70000, 560000),  -- Phiếu nhập 3, sản phẩm 3
    (3, 4, 10, 60000, 600000); -- Phiếu nhập 3, sản phẩm 4
GO

-- Thêm dữ liệu vào bảng THAMSO
INSERT INTO THAMSO (SoLuongTonToiThieu, MucGiamGia, ThoiGianBaoHanh)
VALUES 
    (10, 5.00, 0); -- Số lượng tồn tối thiểu là 10, mức giảm giá 5%, không có bảo hành
GO