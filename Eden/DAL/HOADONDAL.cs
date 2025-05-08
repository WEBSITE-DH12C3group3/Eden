using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class HOADONDAL : IDisposable
    {
        private QLBanHoaEntities db;

        public HOADONDAL()
        {
            db = new QLBanHoaEntities();
        }

        public List<HOADON> GetAll()
        {
            return db.HOADONs.ToList();
        }

        public List<HoaDonDTO> GetAllDTO()
        {
            try
            {
                return db.HOADONs
                    .Select(hd => new HoaDonDTO
                    {
                        idHoaDon = hd.id,
                        idKhachHang = hd.idKhachHang.HasValue ? hd.idKhachHang.Value : 0,
                        MaHoaDon = hd.MaHoaDon,
                        NgayLap = hd.NgayLap,
                        MaKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.MaKhachHang : "N/A",
                        TenKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.TenKhachHang : "N/A",
                        idNguoiDung = hd.idNguoiDung.HasValue ? hd.idNguoiDung.Value : 0,
                        TenNguoiDung = hd.NGUOIDUNG != null ? hd.NGUOIDUNG.TenNguoiDung : "N/A",
                        TongTien = hd.TongTien
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy toàn bộ hóa đơn DTO: " + ex.Message);
                throw;
            }
        }

        public (List<HoaDonDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;

                var data = db.HOADONs
                    .OrderBy(hd => hd.MaHoaDon)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(hd => new HoaDonDTO
                    {
                        MaHoaDon = hd.MaHoaDon,
                        NgayLap = hd.NgayLap,
                        MaKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.MaKhachHang : "N/A",
                        TenKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.TenKhachHang : "N/A",
                        idNguoiDung = hd.idNguoiDung.HasValue ? hd.idNguoiDung.Value : 0,
                        TenNguoiDung = hd.NGUOIDUNG != null ? hd.NGUOIDUNG.TenNguoiDung : "N/A",
                        TongTien = hd.TongTien
                    })
                    .ToList();

                int totalRecords = db.HOADONs.Count();
                return (data, totalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu phân trang: " + ex.Message);
                throw;
            }
        }

        public (List<HoaDonDTO> Data, int TotalRecords) SearchAndPage(string searchText, int page, int pageSize, decimal? minPrice = null, decimal? maxPrice = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                int skip = (page - 1) * pageSize;
                var query = db.HOADONs.AsQueryable();

                // Lọc theo searchText
                if (!string.IsNullOrEmpty(searchText))
                {
                    searchText = searchText.ToLower();
                    query = query.Where(hd => hd.MaHoaDon.ToLower().Contains(searchText) ||
                                              (hd.KHACHHANG != null && hd.KHACHHANG.MaKhachHang.ToLower().Contains(searchText)));
                }

                // Lọc theo khoảng giá
                if (minPrice.HasValue)
                {
                    query = query.Where(hd => hd.TongTien >= minPrice.Value);
                }
                if (maxPrice.HasValue)
                {
                    query = query.Where(hd => hd.TongTien <= maxPrice.Value);
                }

                // Lọc theo khoảng ngày
                if (startDate.HasValue)
                {
                    query = query.Where(hd => hd.NgayLap >= startDate.Value);
                }
                if (endDate.HasValue)
                {
                    // Đảm bảo bao gồm cả ngày cuối (đến 23:59:59 của ngày endDate)
                    var endDateInclusive = endDate.Value.Date.AddDays(1).AddTicks(-1);
                    query = query.Where(hd => hd.NgayLap <= endDateInclusive);
                }

                // Tính tổng số bản ghi
                int totalRecords = query.Count();

                // Lấy dữ liệu phân trang
                var data = query
                    .OrderBy(hd => hd.MaHoaDon)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(hd => new HoaDonDTO
                    {
                        MaHoaDon = hd.MaHoaDon,
                        NgayLap = hd.NgayLap,
                        MaKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.MaKhachHang : "N/A",
                        TenKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.TenKhachHang : "N/A",
                        idNguoiDung = hd.idNguoiDung.HasValue ? hd.idNguoiDung.Value : 0,
                        TenNguoiDung = hd.NGUOIDUNG != null ? hd.NGUOIDUNG.TenNguoiDung : "N/A",
                        TongTien = hd.TongTien
                    })
                    .ToList();

                return (data, totalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm và phân trang: " + ex.Message);
                throw;
            }
        }

        public void Add(HOADON hoaDon, List<ChiTietHoaDonDTO> chiTietList)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.HOADONs.Add(hoaDon);
                    db.SaveChanges();

                    foreach (var chiTiet in chiTietList)
                    {
                        var chiTietEntity = new CHITIETHOADON
                        {
                            idHoaDon = hoaDon.id,
                            idSanPham = chiTiet.idSanPham,
                            SoLuong = chiTiet.SoLuong,
                            DonGia = chiTiet.DonGia,
                            ThanhTien = chiTiet.ThanhTien
                        };
                        db.CHITIETHOADONs.Add(chiTietEntity);

                        var sanPham = db.SANPHAMs.FirstOrDefault(sp => sp.id == chiTiet.idSanPham);
                        if (sanPham != null)
                        {
                            sanPham.SoLuong -= chiTiet.SoLuong;
                            if (sanPham.SoLuong < 0)
                            {
                                throw new Exception($"Số lượng tồn của sản phẩm {sanPham.TenSanPham} không đủ.");
                            }
                        }
                    }

                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                    throw;
                }
            }
        }

        public void Update(HOADON entity)
        {
            try
            {
                var existingHD = db.HOADONs.FirstOrDefault(hd => hd.MaHoaDon == entity.MaHoaDon);
                if (existingHD != null)
                {
                    existingHD.idKhachHang = entity.idKhachHang;
                    existingHD.idNguoiDung = entity.idNguoiDung;
                    existingHD.NgayLap = entity.NgayLap;
                    existingHD.TongTien = entity.TongTien;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Hóa đơn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Delete(HOADON entity)
        {
            try
            {
                var existingHD = db.HOADONs.FirstOrDefault(hd => hd.MaHoaDon == entity.MaHoaDon);
                if (existingHD != null)
                {
                    db.HOADONs.Remove(existingHD);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Hóa đơn không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}