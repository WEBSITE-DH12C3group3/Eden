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

        public List<PHIEUNHAP> GetPagedPhieuNhap(int pageNumber, int pageSize, out int totalRecords, string searchTerm = "")
        {
            var query = db.PHIEUNHAPs.AsQueryable();

            // Lọc theo MaPhieuNhap nếu có searchTerm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.MaPhieuNhap.Contains(searchTerm));
            }

            // Lấy tổng số bản ghi
            totalRecords = query.Count();

            // Phân trang
            return query
                   .OrderBy(p => p.id)
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .ToList();
        }

        public PHIEUNHAP GetById(int id)
        {
            return db.PHIEUNHAPs.Find(id);
        }
        // Thêm phiếu nhập
        public void Add(PHIEUNHAP entity)
        {
            if (entity == null) return;

            try
            {
                db.PHIEUNHAPs.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // In thông báo lỗi để dễ dàng phát hiện
                Console.WriteLine($"Lỗi khi thêm phiếu nhập: {ex.Message}");
                throw;
            }
        }

        // Cập nhật phiếu nhập
        public bool Update(PHIEUNHAP p)
        {
            try
            {
                var entity = db.PHIEUNHAPs.Find(p.id);
                if (entity == null)
                {
                    return false; // Không tìm thấy phiếu nhập
                }

                // Cập nhật các trường
                entity.NgayNhap = p.NgayNhap;
                entity.idNhaCungCap = p.idNhaCungCap;
                entity.idNguoiDung = p.idNguoiDung;
                entity.TongTien = p.TongTien;

                db.SaveChanges();
                return true; // Cập nhật thành công
            }
            catch
            {
                return false; // Cập nhật thất bại
            }
        }
        // Xóa phiếu nhập
        public bool Delete(int id, QLBanHoaEntities db)
        {
            try
            {
                var entity = db.PHIEUNHAPs.Find(id);
                if (entity == null)
                {
                    Console.WriteLine($"Không tìm thấy phiếu nhập với id={id}");
                    return false;
                }

                Console.WriteLine($"Xóa phiếu nhập với id={id}");
                db.PHIEUNHAPs.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa phiếu nhập: {ex.Message}\nStackTrace: {ex.StackTrace}");
                return false;
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
