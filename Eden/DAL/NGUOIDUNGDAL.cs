using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Eden;

namespace Eden.DALCustom
{
    public class NGUOIDUNGDAL
    {
        public List<NGUOIDUNG> GetAll()
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NGUOIDUNGs
                    .Include(nd => nd.NHOMNGUOIDUNG)
                    .ToList();
            }
        }

        public NGUOIDUNG GetById(int id)
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NGUOIDUNGs
                    .Include(nd => nd.NHOMNGUOIDUNG)
                    .FirstOrDefault(nd => nd.id == id);
            }
        }

        public void Add(NGUOIDUNG nguoiDung)
        {
            using (var context = new QLBanHoaEntities())
            {
                try
                {
                    if (nguoiDung.idNhomNguoiDung != 0)
                    {
                        var nhom = context.NHOMNGUOIDUNGs.Find(nguoiDung.idNhomNguoiDung);
                        if (nhom == null)
                            throw new Exception($"Không tìm thấy nhóm người dùng với ID: {nguoiDung.idNhomNguoiDung}");
                    }

                    context.NGUOIDUNGs.Add(nguoiDung);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    var errors = dbEx.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");
                    throw new Exception($"Lỗi xác thực dữ liệu: {string.Join("; ", errors)}", dbEx);
                }
                catch (DbUpdateException dbUpdateEx)
                {
                    var innerException = dbUpdateEx.InnerException?.InnerException?.Message ?? dbUpdateEx.Message;
                    throw new Exception($"Lỗi khi lưu dữ liệu: {innerException}", dbUpdateEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi thêm người dùng: {ex.Message}", ex);
                }
            }
        }

        public void Update(NGUOIDUNG nguoiDung)
        {
            using (var context = new QLBanHoaEntities())
            {
                try
                {
                    var existingUser = context.NGUOIDUNGs.Find(nguoiDung.id);
                    if (existingUser == null)
                        throw new Exception($"Không tìm thấy người dùng với ID: {nguoiDung.id}");

                    if (nguoiDung.idNhomNguoiDung != 0)
                    {
                        var nhom = context.NHOMNGUOIDUNGs.Find(nguoiDung.idNhomNguoiDung);
                        if (nhom == null)
                            throw new Exception($"Không tìm thấy nhóm người dùng với ID: {nguoiDung.idNhomNguoiDung}");
                    }

                    existingUser.MaNguoiDung = nguoiDung.MaNguoiDung;
                    existingUser.TenNguoiDung = nguoiDung.TenNguoiDung;
                    existingUser.TenDangNhap = nguoiDung.TenDangNhap;
                    existingUser.MatKhau = nguoiDung.MatKhau;
                    existingUser.idNhomNguoiDung = nguoiDung.idNhomNguoiDung;
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    var errors = dbEx.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");
                    throw new Exception($"Lỗi xác thực dữ liệu: {string.Join("; ", errors)}", dbEx);
                }
                catch (DbUpdateException dbUpdateEx)
                {
                    var innerException = dbUpdateEx.InnerException?.InnerException?.Message ?? dbUpdateEx.Message;
                    throw new Exception($"Lỗi khi lưu dữ liệu: {innerException}", dbUpdateEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi cập nhật người dùng: {ex.Message}", ex);
                }
            }
        }

        public void Delete(int id)
        {
            using (var context = new QLBanHoaEntities())
            {
                try
                {
                    var user = context.NGUOIDUNGs.Find(id);
                    if (user == null)
                        throw new Exception($"Không tìm thấy người dùng với ID: {id}");

                    context.NGUOIDUNGs.Remove(user);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    var errors = dbEx.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");
                    throw new Exception($"Lỗi xác thực dữ liệu: {string.Join("; ", errors)}", dbEx);
                }
                catch (DbUpdateException dbUpdateEx)
                {
                    var innerException = dbUpdateEx.InnerException?.InnerException?.Message ?? dbUpdateEx.Message;
                    throw new Exception($"Lỗi khi lưu dữ liệu: {innerException}", dbUpdateEx);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi xóa người dùng: {ex.Message}", ex);
                }
            }
        }

        public bool CheckTenDangNhapExists(string tenDangNhap)
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NGUOIDUNGs.Any(u => u.TenDangNhap == tenDangNhap);
            }
        }

        public bool CheckTenDangNhapExistsForOther(string tenDangNhap, int userId)
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NGUOIDUNGs.Any(u => u.TenDangNhap == tenDangNhap && u.id != userId);
            }
        }
    }
}