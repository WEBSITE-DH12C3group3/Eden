using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class LOAISANPHAMDAL : IDisposable
    {
        private QLBanHoaEntities db = new QLBanHoaEntities();

        public List<LOAISANPHAM> GetAll() => db.LOAISANPHAMs.ToList();
        public void Add(LOAISANPHAM entity) { db.LOAISANPHAMs.Add(entity); db.SaveChanges(); }
        public void Update(LOAISANPHAM entity) {
            Console.WriteLine("Cập nhật loại sản phẩm: " + entity.MaLoaiSanPham);

            var existingLSP = db.LOAISANPHAMs.FirstOrDefault(l => l.MaLoaiSanPham == entity.MaLoaiSanPham);
            if (existingLSP != null)
            {
                existingLSP.TenLoaiSanPham = entity.TenLoaiSanPham;

                Console.WriteLine("Dữ liệu cập nhật: " + existingLSP.TenLoaiSanPham);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Không tìm thấy loại sản phẩm!");
                throw new Exception("Loại sản phẩm không tồn tại.");
            }
        }
        public List<LoaiSanPhamDTO> TimKiemTheoTen(string tuKhoa)
        {
            using (var db = new QLBanHoaEntities())
            {
                return db.LOAISANPHAMs
                         .Where(l => l.TenLoaiSanPham.Contains(tuKhoa))
                         .Select(l => new LoaiSanPhamDTO
                         {
                             Id = l.id,
                             TenLoaiSanPham = l.TenLoaiSanPham,
                             MaLoaiSanPham = l.MaLoaiSanPham
                         })
                         .ToList();
            }
        }


        public void Delete(LOAISANPHAM entity) { db.LOAISANPHAMs.Remove(entity); db.SaveChanges(); }
        public void Dispose() { db.Dispose(); }
    }
}