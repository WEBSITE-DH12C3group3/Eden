using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class TINHLUONGDAL : IDisposable
    {
        private readonly QLBanHoaEntities db;

        public TINHLUONGDAL()
        {
            db = new QLBanHoaEntities();
        }

        // Lấy danh sách lương dưới dạng DTO
        public List<LuongDTO> GetAllDTO()
        {
            try
            {
                return db.LUONGs
                    .Include(l => l.NGUOIDUNG)
                    .Select(l => new LuongDTO
                    {
                        Id = l.id,
                        MaLuong = l.MaLuong,
                        IdNguoiDung = l.idNguoiDung,
                        TenNguoiDung = l.NGUOIDUNG.TenNguoiDung,
                        ThangNam = l.ThangNam,
                        LuongCoDinh = l.LuongCoDinh,
                        TongDoanhSo = l.TongDoanhSo,
                        PhatDiMuon = l.PhatDiMuon ?? 0,
                        PhatNghiBuoi = l.PhatNghiBuoi ?? 0,
                        TroCap = l.TroCap ?? 0,
                        Thuong = l.Thuong ?? 0,
                        TongLuong = l.TongLuong,
                        NgayTinhLuong = l.NgayTinhLuong,
                        GhiChu = l.GhiChu,
                        MaNhanVien = l.NGUOIDUNG.MaNhanVien
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lương DTO: " + ex.Message);
                throw;
            }
        }

        // Tính lương cho một nhân viên dựa trên tháng/năm và dữ liệu chấm công
        public LuongDTO CalculateSalary(int idNguoiDung, int thang, int nam)
        {
            try
            {
                // Lấy thông tin nhân viên từ NGUOIDUNG
                var nguoiDung = db.NGUOIDUNGs
                    .FirstOrDefault(n => n.id == idNguoiDung);
                if (nguoiDung == null)
                {
                    throw new Exception("Không tìm thấy thông tin người dùng.");
                }

                // Tính lương cố định (lấy từ NGUOIDUNG)
                decimal luongCoDinh = nguoiDung.LuongCoDinh ?? 0; // Sử dụng giá trị từ NGUOIDUNG, mặc định 0 nếu NULL

                // Tính tổng doanh số từ bảng HOADON
                decimal tongDoanhSo = db.HOADONs
                    .Where(h => h.idNguoiDung == idNguoiDung &&
                               h.NgayLap.Month == thang &&
                               h.NgayLap.Year == nam)
                    .Sum(h => (decimal?)h.TongTien) ?? 0;

                // Tính phạt đi muộn từ bảng CHAMCONG
                decimal phatDiMuon = db.CHAMCONGs
                    .Where(c => c.idNguoiDung == idNguoiDung &&
                               c.NgayChamCong.Month == thang &&
                               c.NgayChamCong.Year == nam &&
                               c.TrangThai == "Đi muộn")
                    .Count() * 50000; // Giả định phạt 50,000 VNĐ mỗi lần đi muộn

                // Tính phạt nghỉ buổi từ bảng CHAMCONG
                decimal phatNghiBuoi = db.CHAMCONGs
                    .Where(c => c.idNguoiDung == idNguoiDung &&
                               c.NgayChamCong.Month == thang &&
                               c.NgayChamCong.Year == nam &&
                               c.GioDangNhap == null && c.GioDangXuat == null)
                    .Count() * 100000; // Giả định phạt 100,000 VNĐ mỗi buổi nghỉ

                // Tính trợ cấp (giả định cố định, có thể lấy từ THAMSO nếu cần)
                decimal troCap = 500000; // Giá trị mặc định

                // Tính thưởng (giả định 1% doanh số)
                decimal thuong = tongDoanhSo * 0.01m;

                // Tính tổng lương
                decimal tongLuong = luongCoDinh + tongDoanhSo + troCap + thuong - (phatDiMuon + phatNghiBuoi);

                // Tạo mã lương (định dạng: "L" + id + thang + nam)
                string maLuong = $"L{idNguoiDung}{thang:D2}{nam}";

                // Tạo đối tượng LuongDTO
                var luongDTO = new LuongDTO
                {
                    Id = 0, // ID sẽ được tạo tự động khi lưu vào DB
                    MaLuong = maLuong,
                    IdNguoiDung = idNguoiDung,
                    TenNguoiDung = nguoiDung.TenNguoiDung,
                    ThangNam = $"{thang}/{nam}",
                    LuongCoDinh = luongCoDinh,
                    TongDoanhSo = tongDoanhSo,
                    PhatDiMuon = phatDiMuon,
                    PhatNghiBuoi = phatNghiBuoi,
                    TroCap = troCap,
                    Thuong = thuong,
                    TongLuong = tongLuong,
                    NgayTinhLuong = DateTime.Now,
                    GhiChu = $"Tính lương tự động ngày {DateTime.Now:dd/MM/yyyy}",
                    MaNhanVien = nguoiDung.MaNhanVien
                };

                return luongDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính lương: " + ex.Message);
                throw;
            }
        }

        // Lưu lương vào cơ sở dữ liệu
        public void SaveSalary(LuongDTO luongDTO)
        {
            try
            {
                var luong = new LUONG
                {
                    MaLuong = luongDTO.MaLuong,
                    idNguoiDung = luongDTO.IdNguoiDung,
                    ThangNam = luongDTO.ThangNam,
                    LuongCoDinh = luongDTO.LuongCoDinh,
                    TongDoanhSo = luongDTO.TongDoanhSo,
                    PhatDiMuon = luongDTO.PhatDiMuon,
                    PhatNghiBuoi = luongDTO.PhatNghiBuoi,
                    TroCap = luongDTO.TroCap,
                    Thuong = luongDTO.Thuong,
                    TongLuong = luongDTO.TongLuong,
                    NgayTinhLuong = luongDTO.NgayTinhLuong,
                    GhiChu = luongDTO.GhiChu
                };

                db.LUONGs.Add(luong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu lương: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}