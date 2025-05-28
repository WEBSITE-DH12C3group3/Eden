using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class THONGTINNVDAL : IDisposable
    {
        private readonly QLBanHoaEntities db;

        public THONGTINNVDAL()
        {
            db = new QLBanHoaEntities();
        }

        // Lấy danh sách tất cả nhân viên
        public List<THONGTINNHANVIEN> GetAll()
        {
            try
            {
                return db.THONGTINNHANVIENs.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách nhân viên dưới dạng DTO
        public List<ThongTinNhanVienDTO> GetAllDTO()
        {
            try
            {
                return db.THONGTINNHANVIENs
                    .Include(nv => nv.NGUOIDUNG)
                    .Select(nv => new ThongTinNhanVienDTO
                    {
                        Id = nv.id,
                        MaNhanVien = nv.MaNhanVien,
                        TenNguoiDung = nv.NGUOIDUNG.TenNguoiDung,
                        LuongCoDinh = nv.LuongCoDinh,
                        NgayBatDauLam = nv.NgayBatDauLam,
                        TrangThai = nv.TrangThai
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách nhân viên DTO: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách nhân viên phân trang
        public (List<ThongTinNhanVienDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;

                var data = db.THONGTINNHANVIENs
                    .Include(nv => nv.NGUOIDUNG)
                    .OrderBy(nv => nv.MaNhanVien)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(nv => new ThongTinNhanVienDTO
                    {
                        Id = nv.id,
                        MaNhanVien = nv.MaNhanVien,
                        TenNguoiDung = nv.NGUOIDUNG.TenNguoiDung,
                        LuongCoDinh = nv.LuongCoDinh,
                        NgayBatDauLam = nv.NgayBatDauLam,
                        TrangThai = nv.TrangThai
                    })
                    .ToList();

                int totalRecords = db.THONGTINNHANVIENs.Count();
                return (data, totalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu nhân viên phân trang: " + ex.Message);
                throw;
            }
        }

        // Thêm nhân viên mới
        public void Add(THONGTINNHANVIEN nhanVien)
        {
            try
            {
                db.THONGTINNHANVIENs.Add(nhanVien);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm nhân viên: " + ex.Message);
                throw;
            }
        }

        // Cập nhật thông tin nhân viên
        public void Update(THONGTINNHANVIEN nhanVien)
        {
            try
            {
                var existingNV = db.THONGTINNHANVIENs.Find(nhanVien.id);
                if (existingNV != null)
                {
                    db.Entry(existingNV).CurrentValues.SetValues(nhanVien);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật nhân viên: " + ex.Message);
                throw;
            }
        }

        // Xóa nhân viên
        public void Delete(int id)
        {
            try
            {
                var nhanVien = db.THONGTINNHANVIENs.Find(id);
                if (nhanVien != null)
                {
                    db.THONGTINNHANVIENs.Remove(nhanVien);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Nhân viên không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa nhân viên: " + ex.Message);
                throw;
            }
        }

        // Tìm nhân viên theo ID
        public THONGTINNHANVIEN GetById(int id)
        {
            try
            {
                return db.THONGTINNHANVIENs.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm nhân viên: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}