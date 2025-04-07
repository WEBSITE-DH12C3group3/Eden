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
                        MaKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.MaKhachHang : "N/A", // Lấy MaKhachHang từ KHACHHANG
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

        public (List<HoaDonDTO> Data, int TotalRecords) SearchAndPage(string searchText, int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;
                var query = db.HOADONs.AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    if (int.TryParse(searchText, out int searchNumber))
                    {
                        query = query.Where(hd => hd.idNguoiDung == searchNumber ||
                                                  (hd.idKhachHang.HasValue && hd.idKhachHang.Value == searchNumber));
                    }
                }

                int totalRecords = query.Count();

                var data = query
                    .OrderBy(hd => hd.MaHoaDon)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(hd => new HoaDonDTO
                    {
                        MaHoaDon = hd.MaHoaDon,
                        NgayLap = hd.NgayLap,
                        MaKhachHang = hd.KHACHHANG != null ? hd.KHACHHANG.MaKhachHang : "N/A", // Lấy MaKhachHang từ KHACHHANG
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

        public void Add(HOADON entity)
        {
            try
            {
                db.HOADONs.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                throw;
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