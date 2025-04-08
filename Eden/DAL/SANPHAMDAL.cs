using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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

        public void Delete(SANPHAM sp)
        {
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
        }
    }
}
