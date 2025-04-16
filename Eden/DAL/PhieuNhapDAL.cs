using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Eden
{
    public class PHIEUNHAPDAL : IDisposable
    {
        private readonly QLBanHoaEntities db = new QLBanHoaEntities();

        // Lấy tất cả phiếu nhập + tên nhà cung cấp (chỉ lấy tên, không Include toàn bộ đối tượng)
        public List<PHIEUNHAP> GetAll()
        {
            return db.PHIEUNHAPs
                     .Include(p => p.NHACUNGCAP) // cần Include để truy cập TenNCC
                     .OrderByDescending(p => p.NgayNhap)
                     .ToList();
        }

        // Thêm phiếu nhập
        public void Add(PHIEUNHAP entity)
        {
            if (entity == null) return;

            db.PHIEUNHAPs.Add(entity);
            db.SaveChanges();
        }

        // Cập nhật phiếu nhập
        public void Update(PHIEUNHAP entity)
        {
            if (entity == null) return;

            var existing = db.PHIEUNHAPs.Find(entity.MaPhieuNhap);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }

        // Xóa phiếu nhập
        public void Delete(PHIEUNHAP entity)
        {
            if (entity == null) return;

            var existing = db.PHIEUNHAPs.Find(entity.MaPhieuNhap);
            if (existing != null)
            {
                db.PHIEUNHAPs.Remove(existing);
                db.SaveChanges();
            }
        }

        // Lấy chi tiết theo mã phiếu nhập
        public List<CHITIETPHIEUNHAP> GetChiTietByPhieuNhap(int idPhieuNhap)
        {
            return db.CHITIETPHIEUNHAPs
                     .Where(c => c.idPhieuNhap == idPhieuNhap)
                     .Include(c => c.SANPHAM) // nếu cần tên sản phẩm, đơn giá,...
                     .ToList();
        }

        // Thêm chi tiết phiếu nhập
        public void AddChiTiet(CHITIETPHIEUNHAP entity)
        {
            if (entity == null) return;

            db.CHITIETPHIEUNHAPs.Add(entity);
            db.SaveChanges();
        }

        // Cập nhật chi tiết
        public void UpdateChiTiet(CHITIETPHIEUNHAP entity)
        {
            if (entity == null) return;

            var existing = db.CHITIETPHIEUNHAPs
                             .FirstOrDefault(c => c.idPhieuNhap == entity.idPhieuNhap && c.idSanPham == entity.idSanPham);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }

        // Xóa chi tiết
        public void DeleteChiTiet(CHITIETPHIEUNHAP entity)
        {
            if (entity == null) return;

            var existing = db.CHITIETPHIEUNHAPs
                             .FirstOrDefault(c => c.idPhieuNhap == entity.idPhieuNhap && c.idSanPham == entity.idSanPham);
            if (existing != null)
            {
                db.CHITIETPHIEUNHAPs.Remove(existing);
                db.SaveChanges();
            }
        }

        // Hủy tài nguyên
        public void Dispose()
        {
            db.Dispose();
        }

        internal PHIEUNHAP GetByMaPhieuNhap(string maPhieuNhap)
        {
            if (string.IsNullOrEmpty(maPhieuNhap)) return null;

            return db.PHIEUNHAPs
                     .Include(p => p.NHACUNGCAP) // nếu cần cả thông tin NCC
                     .FirstOrDefault(p => p.MaPhieuNhap == maPhieuNhap);
        }

    }
}
