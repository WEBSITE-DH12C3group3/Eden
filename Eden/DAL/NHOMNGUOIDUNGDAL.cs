using System;
using System.Collections.Generic;
using System.Linq;

namespace Eden
{
    public class NHOMNGUOIDUNGDAL
    {
        public List<NHOMNGUOIDUNG> GetAll()
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    return db.NHOMNGUOIDUNGs.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách nhóm người dùng từ database: " + ex.Message, ex);
                }
            }
        }

        public void Add(NHOMNGUOIDUNG nnd)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    db.NHOMNGUOIDUNGs.Add(nnd);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm nhóm người dùng vào database: " + ex.Message, ex);
                }
            }
        }

        public void Update(NHOMNGUOIDUNG nnd)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    var existing = db.NHOMNGUOIDUNGs.Find(nnd.id); // Sửa Id thành id
                    if (existing == null)
                        throw new KeyNotFoundException($"Không tìm thấy nhóm người dùng với ID: {nnd.id}");

                    existing.MaNhomNguoiDung = nnd.MaNhomNguoiDung;
                    existing.TenNhomNguoiDung = nnd.TenNhomNguoiDung;

                    db.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật nhóm người dùng trong database: " + ex.Message, ex);
                }
            }
        }

        public void Delete(NHOMNGUOIDUNG nnd)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    var existing = db.NHOMNGUOIDUNGs.Find(nnd.id); // Sửa Id thành id
                    if (existing == null)
                        throw new KeyNotFoundException($"Không tìm thấy nhóm người dùng với ID: {nnd.id}");

                    db.NHOMNGUOIDUNGs.Remove(existing);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi xóa nhóm người dùng khỏi database: " + ex.Message, ex);
                }
            }
        }

        public bool CheckIfCodeExists(string maNhomNguoiDung)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    return db.NHOMNGUOIDUNGs.Any(x => x.MaNhomNguoiDung.ToLower() == maNhomNguoiDung.ToLower());
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi kiểm tra mã nhóm người dùng trong database: " + ex.Message, ex);
                }
            }
        }

        public bool CheckIfCodeExistsForOther(string maNhomNguoiDung, int currentId)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    return db.NHOMNGUOIDUNGs.Any(x => x.MaNhomNguoiDung.ToLower() == maNhomNguoiDung.ToLower() && x.id != currentId); // Sửa Id thành id
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi kiểm tra mã nhóm người dùng trong database: " + ex.Message, ex);
                }
            }
        }
    }
}