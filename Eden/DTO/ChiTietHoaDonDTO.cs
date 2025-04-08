using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden.DTO
{
    public class ChiTietHoaDonDTO
    {
        public int idHoaDon { get; set; } // Lấy từ bảng HOADON
        public int idSanPham { get; set; } // Lấy từ bảng SANPHAM
        public string MaHoaDon { get; set; } // Lấy từ bảng HOADON
        public string MaSanPham { get; set; } // Lấy từ bảng SANPHAM
        public string TenSanPham { get; set; } // Lấy từ bảng SANPHAM
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
