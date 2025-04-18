﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden.DTO
{
    public class KhachHangDTO
    {
        public int id { get; set; } // ID của khách hàng
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        // Thêm các thuộc tính khác nếu cần
    }
}
