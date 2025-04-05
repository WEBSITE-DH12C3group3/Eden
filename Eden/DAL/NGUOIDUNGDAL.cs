using System;
using System.Collections.Generic;
using System.Linq;

namespace Eden
{
    public class NGUOIDUNGDAL
    {
        public List<NGUOIDUNG> GetAll()
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    return db.NGUOIDUNGs.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lấy danh sách người dùng từ database: " + ex.Message, ex);
                }
            }
        }

        public void Add(NGUOIDUNG nd)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    db.NGUOIDUNGs.Add(nd);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm người dùng vào database: " + ex.Message, ex);
                }
            }
        }

        public void Update(NGUOIDUNG nd)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    var existing = db.NGUOIDUNGs.Find(nd.id);
                    if (existing == null)
                        throw new KeyNotFoundException($"Không tìm thấy người dùng với ID: {nd.id}");

                    existing.TenDangNhap = nd.TenDangNhap;
                    existing.MatKhau = nd.MatKhau;
                    existing.idNhomNguoiDung = nd.idNhomNguoiDung;

                    db.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi cập nhật người dùng trong database: " + ex.Message, ex);
                }
            }
        }

        public void Delete(NGUOIDUNG nd)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    var existing = db.NGUOIDUNGs.Find(nd.id);
                    if (existing == null)
                        throw new KeyNotFoundException($"Không tìm thấy người dùng với ID: {nd.id}");

                    db.NGUOIDUNGs.Remove(existing);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi xóa người dùng khỏi database: " + ex.Message, ex);
                }
            }
        }

        public bool CheckIfUsernameExists(string tenDangNhap)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    return db.NGUOIDUNGs.Any(x => x.TenDangNhap.ToLower() == tenDangNhap.ToLower());
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi kiểm tra tên đăng nhập trong database: " + ex.Message, ex);
                }
            }
        }

        public bool CheckIfUsernameExistsForOther(string tenDangNhap, int currentId)
        {
            using (var db = new QLBanHoaEntities())
            {
                try
                {
                    return db.NGUOIDUNGs.Any(x => x.TenDangNhap.ToLower() == tenDangNhap.ToLower() && x.id != currentId);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi kiểm tra tên đăng nhập trong database: " + ex.Message, ex);
                }
            }
        }
    }
}