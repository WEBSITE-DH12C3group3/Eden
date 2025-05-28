using System;

namespace Eden.DTO
{
    public class ThongTinNhanVienDTO
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNguoiDung { get; set; } // Lấy từ NGUOIDUNG
        public decimal LuongCoDinh { get; set; }
        public DateTime NgayBatDauLam { get; set; }
        public string TrangThai { get; set; }
    }
}