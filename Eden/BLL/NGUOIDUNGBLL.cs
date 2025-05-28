using System;
using System.Collections.Generic;
using Eden;
using Eden.DALCustom;

namespace Eden.BLLCustom
{
    public class NGUOIDUNGBLL
    {
        private NGUOIDUNGDAL nguoiDungDal = new NGUOIDUNGDAL();

        public List<NGUOIDUNG> GetAll()
        {
            return nguoiDungDal.GetAll();
        }

        public NGUOIDUNG GetById(int id)
        {
            return nguoiDungDal.GetById(id);
        }

        public void Add(NGUOIDUNG nguoiDung)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nguoiDung.TenNguoiDung))
                    throw new Exception("Tên người dùng không được để trống.");

                if (nguoiDung.TenNguoiDung.Length > 255)
                    throw new Exception("Tên người dùng không được dài quá 255 ký tự.");

                if (string.IsNullOrWhiteSpace(nguoiDung.TenDangNhap))
                    throw new Exception("Tên đăng nhập không được để trống.");

                if (nguoiDung.TenDangNhap.Length > 100)
                    throw new Exception("Tên đăng nhập không được dài quá 100 ký tự.");

                if (nguoiDungDal.CheckTenDangNhapExists(nguoiDung.TenDangNhap))
                    throw new Exception($"Tên đăng nhập '{nguoiDung.TenDangNhap}' đã tồn tại.");

                if (string.IsNullOrWhiteSpace(nguoiDung.MatKhau))
                    throw new Exception("Mật khẩu không được để trống.");

                if (nguoiDung.MatKhau.Length > 255)
                    throw new Exception("Mật khẩu không được dài quá 255 ký tự.");

                if (string.IsNullOrWhiteSpace(nguoiDung.MaNguoiDung))
                    throw new Exception("Mã người dùng không được để trống.");

                if (nguoiDung.MaNguoiDung.Length > 6)
                    throw new Exception("Mã người dùng không được dài quá 6 ký tự.");

                if (nguoiDung.idNhomNguoiDung == 0)
                    throw new Exception("Nhóm người dùng không được để trống.");

                nguoiDungDal.Add(nguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm người dùng: {ex.Message}", ex);
            }
        }

        public void Update(NGUOIDUNG nguoiDung)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nguoiDung.TenNguoiDung))
                    throw new Exception("Tên người dùng không được để trống.");

                if (nguoiDung.TenNguoiDung.Length > 255)
                    throw new Exception("Tên người dùng không được dài quá 255 ký tự.");

                if (string.IsNullOrWhiteSpace(nguoiDung.TenDangNhap))
                    throw new Exception("Tên đăng nhập không được để trống.");

                if (nguoiDung.TenDangNhap.Length > 100)
                    throw new Exception("Tên đăng nhập không được dài quá 100 ký tự.");

                if (nguoiDungDal.CheckTenDangNhapExistsForOther(nguoiDung.TenDangNhap, nguoiDung.id))
                    throw new Exception($"Tên đăng nhập '{nguoiDung.TenDangNhap}' đã tồn tại cho người dùng khác.");

                if (string.IsNullOrWhiteSpace(nguoiDung.MatKhau))
                    throw new Exception("Mật khẩu không được để trống.");

                if (nguoiDung.MatKhau.Length > 255)
                    throw new Exception("Mật khẩu không được dài quá 255 ký tự.");

                if (string.IsNullOrWhiteSpace(nguoiDung.MaNguoiDung))
                    throw new Exception("Mã người dùng không được để trống.");

                if (nguoiDung.MaNguoiDung.Length > 6)
                    throw new Exception("Mã người dùng không được dài quá 6 ký tự.");

                if (nguoiDung.idNhomNguoiDung == 0)
                    throw new Exception("Nhóm người dùng không được để trống.");

               

                nguoiDungDal.Update(nguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật người dùng: {ex.Message}", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                nguoiDungDal.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa người dùng: {ex.Message}", ex);
            }
        }
    }
}