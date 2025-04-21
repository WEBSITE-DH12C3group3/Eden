using System;
using System.Collections.Generic;
using System.Linq;

namespace Eden
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Eden
    {
        public class CHITIETPHIEUNHAPDAL : IDisposable
        {
            private QLBanHoaEntities db;

            // Constructor khởi tạo DbContext
            public CHITIETPHIEUNHAPDAL()
            {
                db = new QLBanHoaEntities();
            }

            public bool DeleteByPhieuNhapId(int idPhieuNhap, QLBanHoaEntities db)
            {
                try
                {
                    var chiTietList = db.CHITIETPHIEUNHAPs.Where(c => c.idPhieuNhap == idPhieuNhap).ToList();
                    Console.WriteLine($"Tìm thấy {chiTietList.Count} chi tiết phiếu nhập cho idPhieuNhap={idPhieuNhap}");

                    foreach (var chiTiet in chiTietList)
                    {
                        db.CHITIETPHIEUNHAPs.Remove(chiTiet);
                    }

                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa chi tiết phiếu nhập: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    return false;
                }
            }

            // Lấy danh sách tất cả chi tiết phiếu nhập
            public List<CHITIETPHIEUNHAP> GetAll()
            {
                return db.CHITIETPHIEUNHAPs.ToList();
            }

            // Thêm chi tiết phiếu nhập mới
            public void Add(CHITIETPHIEUNHAP entity)
            {
                db.CHITIETPHIEUNHAPs.Add(entity);
                db.SaveChanges();
            }

            // Cập nhật chi tiết phiếu nhập
            public void Update(CHITIETPHIEUNHAP entity)
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            // Xóa chi tiết phiếu nhập
            public void Delete(CHITIETPHIEUNHAP entity)
            {
                db.CHITIETPHIEUNHAPs.Remove(entity);
                db.SaveChanges();
            }

            // Giải phóng tài nguyên khi không còn sử dụng
            public void Dispose()
            {
                db.Dispose();
            }
        }
    }
}
