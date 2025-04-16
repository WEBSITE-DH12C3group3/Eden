using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Eden.DTO;

namespace Eden
{
    public class SANPHAMDAL : IDisposable
    {
        private QLBanHoaEntities db = new QLBanHoaEntities();

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }

        public List<SANPHAM> GetAll()
        {
            return db.SANPHAMs
            .Include(sp => sp.NHACUNGCAP)
            .Include(sp => sp.LOAISANPHAM)
            .ToList();
        }
        public List<SanPhamDTO>TimKiemTheoTen(string tuKhoa)
        {
            using (var db = new QLBanHoaEntities())
            {
                return db.SANPHAMs
                    .Where(sp => sp.TenSanPham.Contains(tuKhoa))
                    .Select(sp => new SanPhamDTO
                    {
                        MaSanPham = sp.MaSanPham,
                        TenSanPham = sp.TenSanPham,
                        MoTa = sp.MoTa,
                        Gia = sp.Gia,
                        SoLuong = sp.SoLuong,
                        MauSac = sp.MauSac,
                        AnhChiTiet = sp.AnhChiTiet,
                        TenNhaCungCap = sp.NHACUNGCAP.TenNhaCungCap,
                        TenLoaiSanPham = sp.LOAISANPHAM.TenLoaiSanPham
                    }).ToList();
            }
        }

        public List<SanPhamDTO> GetAllDTO()
        {
            try
            {
                return db.SANPHAMs
                    .Select(sp => new SanPhamDTO
                    {
                        idSanPham = sp.id,
                        MaSanPham = sp.MaSanPham,
                        TenSanPham = sp.TenSanPham,
                        MoTa = sp.MoTa,
                        Gia = sp.Gia,
                        SoLuong = sp.SoLuong,
                        MauSac = sp.MauSac,
                        TenNhaCungCap = sp.NHACUNGCAP.TenNhaCungCap,
                        TenLoaiSanPham = sp.LOAISANPHAM.TenLoaiSanPham

                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy toàn bộ hóa đơn DTO: " + ex.Message);
                throw;
            }
        }

        public void Add(SANPHAM sp)
        {
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
        }

        public void Update(SANPHAM entity)
        {
            Console.WriteLine("Cập nhật sản phẩm: " + entity.MaSanPham);

            var existingSP = db.SANPHAMs.FirstOrDefault(sp => sp.MaSanPham == entity.MaSanPham);
            if (existingSP != null)
            {
                existingSP.TenSanPham = entity.TenSanPham;
                existingSP.MoTa = entity.MoTa;
                existingSP.Gia = entity.Gia;
                existingSP.SoLuong = entity.SoLuong;
                existingSP.MauSac = entity.MauSac;
                existingSP.AnhChiTiet = entity.AnhChiTiet;
                existingSP.idNhaCungCap = entity.idNhaCungCap;
                existingSP.idLoaiSanPham = entity.idLoaiSanPham;

                Console.WriteLine("Dữ liệu cập nhật: " + existingSP.TenSanPham);

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string errorMsg = "";
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            errorMsg += $"Thuộc tính: {validationError.PropertyName} - Lỗi: {validationError.ErrorMessage}\n";
                        }
                    }

                    Console.WriteLine(errorMsg);
                    throw new Exception("Lỗi khi cập nhật dữ liệu:\n" + errorMsg);
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm!");
                throw new Exception("Sản phẩm không tồn tại.");
            }
        }
        public List<SanPhamDTO> LaySanPhamTheoTrang(int page, int pageSize)
        {
            using (var db = new QLBanHoaEntities())
            {
                return db.SANPHAMs
                    .OrderBy(sp => sp.MaSanPham)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(sp => new SanPhamDTO
                    {
                        MaSanPham = sp.MaSanPham,
                        TenSanPham = sp.TenSanPham,
                        MoTa = sp.MoTa,
                        Gia = sp.Gia,
                        SoLuong = sp.SoLuong,
                        MauSac = sp.MauSac,
                        AnhChiTiet = sp.AnhChiTiet,
                        TenNhaCungCap = sp.NHACUNGCAP.TenNhaCungCap,
                        TenLoaiSanPham = sp.LOAISANPHAM.TenLoaiSanPham
                    })
                    .ToList();
            }
        }

        public int DemSoLuongSanPham()
        {
            using (var db = new QLBanHoaEntities())
            {
                return db.SANPHAMs.Count();
            }
        }

        public void Delete(SANPHAM sp)
        {
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
        }

        public SANPHAM GetByMaSanPham(string maSanPham)
        {
            return db.SANPHAMs
                .Include(sp => sp.NHACUNGCAP)
                .Include(sp => sp.LOAISANPHAM)
                .FirstOrDefault(sp => sp.MaSanPham == maSanPham);
        }
    }
}
