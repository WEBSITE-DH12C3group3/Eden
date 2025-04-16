using System;
using System.Collections.Generic;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class KHACHHANGBLL : IDisposable
    {
        private KHACHHANGDAL dal;

        public KHACHHANGBLL()
        {
            dal = new KHACHHANGDAL();
        }

        // Lấy toàn bộ danh sách khách hàng (giữ nguyên để tương thích với code cũ)
        public List<KhachHangDTO> GetAll()
        {
            try
            {
                return dal.GetAllDTO();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy toàn bộ khach hang: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách khách hàng theo trang (phân trang)
        public (List<KhachHangDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
        {
            try
            {
                return dal.GetPaged(page, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu phân trang: " + ex.Message);
                throw;
            }
        }

        // Tìm kiếm và phân trang
        public (List<KhachHangDTO> Data, int TotalRecords) SearchAndPage(string searchText, int page, int pageSize)
        {
            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    return GetPaged(page, pageSize); // Nếu không có từ khóa, trả về phân trang thông thường
                }
                var result = dal.SearchAndPage(searchText, page, pageSize);

                // Chuyển đổi từ List<KHACHHANG> sang List<KhachHangDTO>
                var data = result.Data.Select(kh => new KhachHangDTO
                {
                    MaKhachHang = kh.MaKhachHang,
                    TenKhachHang = kh.TenKhachHang,
                    DiaChi = kh.DiaChi,
                    SoDienThoai = kh.SoDienThoai
                }).ToList();
                return (data, result.TotalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm và phân trang: " + ex.Message);
                throw;
            }
        }

       

    public void Add(KHACHHANG kh)
        {
            try
            {
                dal.Add(kh);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                throw;
            }
        }

        public void Update(KHACHHANG kh)
        {
            try
            {
                dal.Update(kh);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật khách hàng: " + ex.Message);
                throw;
            }
        }

        public void Delete(KHACHHANG kh)
        {
            try
            {
                dal.Delete(kh);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa khách hàng: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            dal?.Dispose();
        }
    }
}