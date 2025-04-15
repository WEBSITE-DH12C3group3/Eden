using System;
using System.Collections.Generic;

namespace Eden.BLLCustom
{
    public class NGUOIDUNGBLL
    {
        private DALCustom.NGUOIDUNGDAL dal = new DALCustom.NGUOIDUNGDAL();

        public List<NGUOIDUNG> GetAll()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách người dùng: " + ex.Message, ex);
            }
        }

        public void Add(NGUOIDUNG nd)
        {
            try
            {
                if (nd == null)
                    throw new ArgumentNullException(nameof(nd), "Thông tin người dùng không được để trống.");

                if (string.IsNullOrWhiteSpace(nd.TenNguoiDung))
                    throw new ArgumentException("Tên người dùng không được để trống.", nameof(nd.TenNguoiDung));

                if (string.IsNullOrWhiteSpace(nd.TenDangNhap))
                    throw new ArgumentException("Tên đăng nhập không được để trống.", nameof(nd.TenDangNhap));

                if (string.IsNullOrWhiteSpace(nd.MatKhau))
                    throw new ArgumentException("Mật khẩu không được để trống.", nameof(nd.MatKhau));

                if (nd.idNhomNguoiDung <= 0)
                    throw new ArgumentException("Nhóm người dùng không hợp lệ.", nameof(nd.idNhomNguoiDung));

                if (dal.CheckIfUsernameExists(nd.TenDangNhap))
                    throw new InvalidOperationException($"Tên đăng nhập '{nd.TenDangNhap}' đã tồn tại.");

                if (string.IsNullOrWhiteSpace(nd.MaNguoiDung))
                    nd.MaNguoiDung = $"ND{DateTime.Now.Ticks}";

                dal.Add(nd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm người dùng: " + ex.Message, ex);
            }
        }

        public void Update(NGUOIDUNG nd)
        {
            try
            {
                if (nd == null)
                    throw new ArgumentNullException(nameof(nd), "Thông tin người dùng không được để trống.");

                if (nd.id <= 0)
                    throw new ArgumentException("ID người dùng không hợp lệ.", nameof(nd.id));

                if (string.IsNullOrWhiteSpace(nd.TenNguoiDung))
                    throw new ArgumentException("Tên người dùng không được để trống.", nameof(nd.TenNguoiDung));

                if (string.IsNullOrWhiteSpace(nd.TenDangNhap))
                    throw new ArgumentException("Tên đăng nhập không được để trống.", nameof(nd.TenDangNhap));

                if (string.IsNullOrWhiteSpace(nd.MatKhau))
                    throw new ArgumentException("Mật khẩu không được để trống.", nameof(nd.MatKhau));

                if (nd.idNhomNguoiDung <= 0)
                    throw new ArgumentException("Nhóm người dùng không hợp lệ.", nameof(nd.idNhomNguoiDung));

                if (dal.CheckIfUsernameExistsForOther(nd.TenDangNhap, nd.id))
                    throw new InvalidOperationException($"Tên đăng nhập '{nd.TenDangNhap}' đã tồn tại ở một người dùng khác.");

                dal.Update(nd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật người dùng: " + ex.Message, ex);
            }
        }

        public void Delete(NGUOIDUNG nd)
        {
            try
            {
                if (nd == null)
                    throw new ArgumentNullException(nameof(nd), "Thông tin người dùng không được để trống.");

                if (nd.id <= 0)
                    throw new ArgumentException("ID người dùng không hợp lệ.", nameof(nd.id));

                dal.Delete(nd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa người dùng: " + ex.Message, ex);
            }
        }
    }
}