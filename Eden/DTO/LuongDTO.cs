using System;

namespace Eden.DTO
{
    public class LuongDTO
    {
        public int Id { get; set; }
        public string MaLuong { get; set; }
        public string TenNguoiDung { get; set; } // Lấy từ NGUOIDUNG qua THONGTINNHANVIEN
        public string ThangNam { get; set; }
        public decimal LuongCoDinh { get; set; }
        public decimal TongDoanhSo { get; set; }
        public decimal PhatDiMuon { get; set; }
        public decimal PhatNghiBuoi { get; set; }
        public decimal TroCap { get; set; }
        public decimal Thuong { get; set; }
        public decimal TongLuong { get; set; }
        public DateTime NgayTinhLuong { get; set; }
        public string GhiChu { get; set; }
    }
}