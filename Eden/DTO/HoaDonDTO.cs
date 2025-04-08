using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden.DTO
{
    public class HoaDonDTO
    {


        public int idHoaDon { get; set; }
    public int idKhachHang { get; set; }
    public string MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; } // Thêm tên khách hàng
        public int idNguoiDung { get; set; }
        public string TenNguoiDung { get; set; } // Thêm tên người dùng
        public decimal TongTien { get; set; }
    }
}
