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
                    .Include(l => l.THONGTINNHANVIEN.NGUOIDUNG)
                    .Select(l => new LuongDTO
                    {
                        Id = l.id,
                        MaLuong = l.MaLuong,
                        TenNguoiDung = l.THONGTINNHANVIEN.NGUOIDUNG.TenNguoiDung,
                        ThangNam = l.ThangNam,
                        LuongCoDinh = l.LuongCoDinh,  // Được đảm bảo NOT NULL trong DB
                        TongDoanhSo = l.TongDoanhSo,  // Được đảm bảo NOT NULL trong DB
                        PhatDiMuon = l.PhatDiMuon ?? 0,  // Gán 0 nếu NULL
                        PhatNghiBuoi = l.PhatNghiBuoi ?? 0,  // Gán 0 nếu NULL
                        TroCap = l.TroCap ?? 0,  // Gán 0 nếu NULL
                        Thuong = l.Thuong ?? 0,  // Gán 0 nếu NULL
                        TongLuong = l.TongLuong,  // Được đảm bảo NOT NULL trong DB
                        NgayTinhLuong = l.NgayTinhLuong,
                        GhiChu = l.GhiChu
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lương DTO: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}