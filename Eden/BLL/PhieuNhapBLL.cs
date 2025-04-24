using System;
using System.Collections.Generic;
using System.Linq;
using Eden.Eden;

namespace Eden
{
    public class PHIEUNHAPBLL : IDisposable
    {
        private readonly PHIEUNHAPDAL dal;
        private readonly CHITIETPHIEUNHAPDAL chiTietDal = new CHITIETPHIEUNHAPDAL();

        public PHIEUNHAPBLL()
        {
            dal = new PHIEUNHAPDAL();
        }

        // Lấy tất cả phiếu nhập (có tên nhà cung cấp)
        public List<PHIEUNHAP> GetAll()
        {
            return dal.GetAll();
        }
        public PHIEUNHAP GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID phiếu nhập không hợp lệ!");
            return dal.GetById(id);
        }
        // Các phương thức khác...


        // Lấy phiếu nhập theo mã phiếu
        public PHIEUNHAP GetByMaPhieuNhap(string maPhieuNhap)
        {
            try
            {
                using (var db = new QLBanHoaEntities())
                {
                    return db.PHIEUNHAPs
                        .FirstOrDefault(p => p.MaPhieuNhap == maPhieuNhap);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy phiếu nhập theo mã: {ex.Message}", ex);
            }
        }

        // Thêm phiếu nhập
        public bool Add(PHIEUNHAP p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p), "Dữ liệu phiếu nhập không được null!");
            if (p.NgayNhap == default)
                throw new ArgumentException("Ngày nhập không hợp lệ!");
            if (p.TongTien < 0)
                throw new ArgumentException("Tổng tiền không hợp lệ!");

            try
            {
                dal.Add(p);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm phiếu nhập: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw; // Ném lại ngoại lệ để hiển thị chi tiết trong UI
            }
        }

        // Cập nhật phiếu nhập
        public bool Update(PHIEUNHAP p)
        {
            if (p == null || p.id <= 0)
                throw new ArgumentException("Dữ liệu phiếu nhập không hợp lệ!");
            if (p.NgayNhap == default)
                throw new ArgumentException("Ngày nhập không hợp lệ!");
            if (p.TongTien < 0)
                throw new ArgumentException("Tổng tiền không hợp lệ!");

            try
            {
                bool result = dal.Update(p);
                if (!result)
                {
                    throw new Exception("Cập nhật phiếu nhập thất bại: Không tìm thấy phiếu nhập hoặc lỗi dữ liệu.");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật phiếu nhập: {ex.Message}");
                throw; // Ném lại để hiển thị chi tiết lỗi
            }
        }

        // Xóa phiếu nhập
        public bool Delete(PHIEUNHAP p)
        {
            if (p == null || p.id <= 0)
                throw new ArgumentException("Dữ liệu phiếu nhập không hợp lệ!");

            using (var db = new QLBanHoaEntities())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Console.WriteLine($"Xóa chi tiết phiếu nhập cho idPhieuNhap={p.id}");
                    chiTietDal.DeleteByPhieuNhapId(p.id, db); // Truyền DbContext

                    Console.WriteLine($"Xóa phiếu nhập: id={p.id}");
                    bool result = dal.Delete(p.id, db); // Truyền DbContext
                    if (!result)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Lỗi khi xóa phiếu nhập: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw;
                }
            }
        }

        // Lấy chi tiết phiếu nhập theo ID phiếu nhập
        public List<CHITIETPHIEUNHAP> GetChiTietByPhieuNhap(int idPhieuNhap)
        {
            try
            {
                using (var db = new QLBanHoaEntities())
                {
                    return db.CHITIETPHIEUNHAPs
                        .Where(c => c.idPhieuNhap == idPhieuNhap)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết phiếu nhập: {ex.Message}", ex);
            }
        }

        // Thêm chi tiết phiếu nhập
        public bool AddChiTiet(CHITIETPHIEUNHAP c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c), "Chi tiết phiếu nhập không được null!");

            try
            {
                dal.AddChiTiet(c);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm chi tiết phiếu nhập: {ex.Message}");
                return false;
            }
        }

        // Cập nhật chi tiết phiếu nhập
        public bool UpdateChiTiet(CHITIETPHIEUNHAP c)
        {
            if (c == null || c.idPhieuNhap <= 0)
                throw new ArgumentException("Dữ liệu chi tiết phiếu nhập không hợp lệ!");

            try
            {
                dal.UpdateChiTiet(c);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật chi tiết phiếu nhập: {ex.Message}");
                return false;
            }
        }

        // Xóa chi tiết phiếu nhập
        public bool DeleteChiTiet(CHITIETPHIEUNHAP c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c), "Chi tiết phiếu nhập không được null!");

            try
            {
                dal.DeleteChiTiet(c);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa chi tiết phiếu nhập: {ex.Message}");
                return false;
            }
        }

        // Giải phóng tài nguyên
        public void Dispose()
        {
            dal.Dispose();
        }

        
    }
}
