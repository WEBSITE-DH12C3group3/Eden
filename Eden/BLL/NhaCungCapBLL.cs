using System;
using System.Collections.Generic;
using System.Linq;

namespace Eden
{
    public class NHACUNGCAPBLL : IDisposable
    {
        private NHACUNGCAPDAL dal = new NHACUNGCAPDAL();

        public NHACUNGCAPBLL()
        {
            dal = new NHACUNGCAPDAL();
        }

        public List<NHACUNGCAP> GetAll()
        {
            return dal.GetAll();
        }

        public void Add(NHACUNGCAP ncc)
        {
            dal.Add(ncc);
        }

        public void Update(NHACUNGCAP ncc)
        {
            dal.Update(ncc);
        }

        public void Delete(NHACUNGCAP nhaCungCap)
        {
            using (var db = new QLBanHoaEntities())
            {
                // Tìm bản ghi bằng MaNhaCungCap (khóa chính)
                var entity = db.NHACUNGCAPs.FirstOrDefault(n => n.MaNhaCungCap == nhaCungCap.MaNhaCungCap);
                if (entity != null)
                {
                    // Kiểm tra ràng buộc với PHIEUNHAP
                    var relatedPhieuNhap = db.PHIEUNHAPs.Any(p => p.idNhaCungCap == entity.id);
                    if (relatedPhieuNhap)
                    {
                        throw new Exception("Không thể xóa nhà cung cấp vì đang được sử dụng trong phiếu nhập.");
                    }

                    db.NHACUNGCAPs.Remove(entity);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Không tìm thấy nhà cung cấp với mã {nhaCungCap.MaNhaCungCap}.");
                }
            }
        }

        public void Dispose()
        {
            dal.Dispose();
        }
    }
}
