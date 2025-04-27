using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Eden.DTO;
namespace Eden
{
    public class KHACHHANGDAL : IDisposable
    {
        private QLBanHoaEntities db;

        public KHACHHANGDAL()
        {
            db = new QLBanHoaEntities();

        }

        // Lấy toàn bộ danh sách khách hàng
        public List<KHACHHANG> GetAll()
        {
            return db.KHACHHANGs.ToList();
        }



        // Lấy danh sách khách hàng theo trang
        public (List<KhachHangDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;

                // Lấy dữ liệu cho trang hiện tại
                var data = db.KHACHHANGs
                    .OrderBy(kh => kh.MaKhachHang) // Sắp xếp theo MaKhachHang
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(kh => new KhachHangDTO
                    {
                        MaKhachHang = kh.MaKhachHang,
                        TenKhachHang = kh.TenKhachHang,
                        SoDienThoai = kh.SoDienThoai,
                        DiaChi = kh.DiaChi,
                        Email = kh.Email
                    })
                    .ToList();


                // Tính tổng số bản ghi
                int totalRecords = db.KHACHHANGs.Count();

                return (data, totalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu phân trang: " + ex.Message);
                throw;
            }
        }

        public List<KhachHangDTO> GetAllDTO()
        {
            try
            {
                return db.KHACHHANGs
                    .Select(kh => new KhachHangDTO
                    {
                        id = kh.id,
                        MaKhachHang = kh.MaKhachHang,
                        TenKhachHang = kh.TenKhachHang,
                        DiaChi = kh.DiaChi,
                        Email = kh.Email,
                        SoDienThoai = kh.SoDienThoai

                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy toàn bộ hóa đơn DTO: " + ex.Message);
                throw;
            }
        }


        // Tìm kiếm và phân trang
        public (List<KHACHHANG> Data, int TotalRecords) SearchAndPage(string searchText, int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;

                // Tạo truy vấn cơ bản
                var query = db.KHACHHANGs.AsQueryable();

                // Nếu có từ khóa tìm kiếm, lọc dữ liệu
                if (!string.IsNullOrEmpty(searchText))
                {
                    searchText = searchText.ToLower();
                    query = query.Where(kh => kh.TenKhachHang.ToLower().Contains(searchText) ||
                                              kh.MaKhachHang.ToLower().Contains(searchText));
                }

                // Tính tổng số bản ghi
                int totalRecords = query.Count();

                // Lấy dữ liệu cho trang hiện tại
                var data = query
                    .OrderBy(kh => kh.MaKhachHang) // Sắp xếp theo MaKhachHang
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();

                return (data, totalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm và phân trang: " + ex.Message);
                throw;
            }
        }

        public void Add(KHACHHANG entity)
        {
            try
            {
                db.KHACHHANGs.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                throw;
            }
        }

        public void Update(KHACHHANG entity)
        {
            try
            {
                Console.WriteLine("Cập nhật khách hàng: " + entity.MaKhachHang);

                var existingKH = db.KHACHHANGs.FirstOrDefault(k => k.MaKhachHang == entity.MaKhachHang);
                if (existingKH != null)
                {
                    existingKH.TenKhachHang = entity.TenKhachHang;
                    existingKH.SoDienThoai = entity.SoDienThoai;
                    existingKH.DiaChi = entity.DiaChi;
                    existingKH.Email = entity.Email;

                    Console.WriteLine("Dữ liệu cập nhật: " + existingKH.TenKhachHang);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Không tìm thấy khách hàng!");
                    throw new Exception("Khách hàng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật khách hàng: " + ex.Message);
                throw;
            }
        }

        public void Delete(KHACHHANG entity)
        {
            try
            {
                var existingKH = db.KHACHHANGs.FirstOrDefault(k => k.MaKhachHang == entity.MaKhachHang);
                if (existingKH != null)
                {
                    db.KHACHHANGs.Remove(existingKH);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Khách hàng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa khách hàng: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}