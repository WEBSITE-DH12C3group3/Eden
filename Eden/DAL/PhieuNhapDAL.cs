using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Eden
{
    public class PHIEUNHAPDAL : IDisposable
    {
        private readonly QLBanHoaEntities db = new QLBanHoaEntities();

        // Lấy tất cả phiếu nhập cùng thông tin nhà cung cấp và người dùng
        public List<NHACUNGCAP> GetAllNHACUNGCAP()
        {
            return db.NHACUNGCAPs.OrderBy(ncc => ncc.TenNhaCungCap).ToList();
        }

        public List<PHIEUNHAP> GetAll()
        {
            return db.PHIEUNHAPs
                     .Include(p => p.NHACUNGCAP)
                     .Include(p => p.NGUOIDUNG)
                     .OrderByDescending(p => p.NgayNhap)
                     .ToList();
        }

        // Lấy phiếu nhập theo mã phiếu nhập
        public PHIEUNHAP GetByMaPhieuNhap(string maPhieuNhap)
        {
            if (string.IsNullOrEmpty(maPhieuNhap)) return null;

            return db.PHIEUNHAPs
                     .Include(p => p.NHACUNGCAP)
                     .Include(p => p.NGUOIDUNG)
                     .FirstOrDefault(p => p.MaPhieuNhap == maPhieuNhap);
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

        // Lấy danh sách chi tiết phiếu nhập theo id phiếu nhập
        public List<CHITIETPHIEUNHAP> GetChiTietByPhieuNhap(int idPhieuNhap)
        {
            return db.CHITIETPHIEUNHAPs
                     .Where(c => c.idPhieuNhap == idPhieuNhap)
                     .Include(c => c.SANPHAM)
                     .ToList();
        }

        // Thêm chi tiết phiếu nhập
        public void AddChiTiet(CHITIETPHIEUNHAP entity)
        {
            if (entity == null) return;

            db.CHITIETPHIEUNHAPs.Add(entity);
            db.SaveChanges();
        }

        // Cập nhật chi tiết phiếu nhập
        public void UpdateChiTiet(CHITIETPHIEUNHAP entity)
        {
            if (entity == null) return;

            var existing = db.CHITIETPHIEUNHAPs.Find(entity.idPhieuNhap);
            if (existing != null)
            {
                db.Entry(existing).CurrentValues.SetValues(entity);
                db.SaveChanges();
            }
        }

        // Xóa chi tiết phiếu nhập
        public void DeleteChiTiet(CHITIETPHIEUNHAP entity)
        {
            if (entity == null) return;

            var existing = db.CHITIETPHIEUNHAPs.Find(entity.idPhieuNhap);
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
    }
}
