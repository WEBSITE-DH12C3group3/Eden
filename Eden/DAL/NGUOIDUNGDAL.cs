using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Eden.DALCustom
{
    public class NGUOIDUNGDAL
    {
        public List<NGUOIDUNG> GetAll()
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NGUOIDUNGs.Include(nd => nd.NHOMNGUOIDUNG).ToList();
            }
        }

        public void Add(NGUOIDUNG nd)
        {
            using (var context = new QLBanHoaEntities())
            {
                context.NGUOIDUNGs.Add(nd);
                context.SaveChanges();
            }
        }

        public void Update(NGUOIDUNG nd)
        {
            using (var context = new QLBanHoaEntities())
            {
                var existingUser = context.NGUOIDUNGs.Find(nd.id);
                if (existingUser == null)
                    throw new Exception($"Không tìm thấy người dùng với ID: {nd.id}");

                existingUser.MaNguoiDung = nd.MaNguoiDung;
                existingUser.TenNguoiDung = nd.TenNguoiDung;
                existingUser.TenDangNhap = nd.TenDangNhap;
                existingUser.MatKhau = nd.MatKhau;
                existingUser.idNhomNguoiDung = nd.idNhomNguoiDung;
                context.SaveChanges();
            }
        }

        public void Delete(NGUOIDUNG nd)
        {
            using (var context = new QLBanHoaEntities())
            {
                var user = context.NGUOIDUNGs.Find(nd.id);
                if (user == null)
                    throw new Exception($"Không tìm thấy người dùng với ID: {nd.id}");

                context.NGUOIDUNGs.Remove(user);
                context.SaveChanges();
            }
        }

        public bool CheckIfUsernameExists(string username)
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NGUOIDUNGs.Any(u => u.TenDangNhap == username);
            }
        }

        public bool CheckIfUsernameExistsForOther(string username, int userId)
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NGUOIDUNGs.Any(u => u.TenDangNhap == username && u.id != userId);
            }
        }
    }
}