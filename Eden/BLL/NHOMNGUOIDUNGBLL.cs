using System;
using System.Collections.Generic;

namespace Eden
{
    public class NHOMNGUOIDUNGBLL
    {
        private NHOMNGUOIDUNGDAL dal = new NHOMNGUOIDUNGDAL();

        public List<NHOMNGUOIDUNG> GetAll()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhóm người dùng: " + ex.Message, ex);
            }
        }

        public void Add(NHOMNGUOIDUNG nnd)
        {
            try
            {
                if (nnd == null)
                    throw new ArgumentNullException(nameof(nnd), "Thông tin nhóm người dùng không được để trống.");

                if (string.IsNullOrWhiteSpace(nnd.MaNhomNguoiDung))
                    throw new ArgumentException("Mã nhóm người dùng không được để trống.", nameof(nnd.MaNhomNguoiDung));

                if (string.IsNullOrWhiteSpace(nnd.TenNhomNguoiDung))
                    throw new ArgumentException("Tên nhóm người dùng không được để trống.", nameof(nnd.TenNhomNguoiDung));

                if (dal.CheckIfCodeExists(nnd.MaNhomNguoiDung))
                    throw new InvalidOperationException($"Mã nhóm người dùng '{nnd.MaNhomNguoiDung}' đã tồn tại.");

                dal.Add(nnd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhóm người dùng: " + ex.Message, ex);
            }
        }

        public void Update(NHOMNGUOIDUNG nnd)
        {
            try
            {
                if (nnd == null)
                    throw new ArgumentNullException(nameof(nnd), "Thông tin nhóm người dùng không được để trống.");

                if (nnd.id <= 0) // Sửa Id thành id
                    throw new ArgumentException("ID nhóm người dùng không hợp lệ.", nameof(nnd.id));

                if (string.IsNullOrWhiteSpace(nnd.MaNhomNguoiDung))
                    throw new ArgumentException("Mã nhóm người dùng không được để trống.", nameof(nnd.MaNhomNguoiDung));

                if (string.IsNullOrWhiteSpace(nnd.TenNhomNguoiDung))
                    throw new ArgumentException("Tên nhóm người dùng không được để trống.", nameof(nnd.TenNhomNguoiDung));

                if (dal.CheckIfCodeExistsForOther(nnd.MaNhomNguoiDung, nnd.id)) // Sửa Id thành id
                    throw new InvalidOperationException($"Mã nhóm người dùng '{nnd.MaNhomNguoiDung}' đã tồn tại ở một nhóm khác.");

                dal.Update(nnd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhóm người dùng: " + ex.Message, ex);
            }
        }

        public void Delete(NHOMNGUOIDUNG nnd)
        {
            try
            {
                if (nnd == null)
                    throw new ArgumentNullException(nameof(nnd), "Thông tin nhóm người dùng không được để trống.");

                if (nnd.id <= 0) // Sửa Id thành id
                    throw new ArgumentException("ID nhóm người dùng không hợp lệ.", nameof(nnd.id));

                dal.Delete(nnd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhóm người dùng: " + ex.Message, ex);
            }
        }
    }
}