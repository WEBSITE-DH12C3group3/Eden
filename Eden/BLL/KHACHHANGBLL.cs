using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<KHACHHANG> GetAll()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy toàn bộ khách hàng: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách khách hàng theo trang (phân trang)
        public (List<KHACHHANG> Data, int TotalRecords) GetPaged(int page, int pageSize)
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
        public (List<KHACHHANG> Data, int TotalRecords) SearchAndPage(string searchText, int page, int pageSize)
        {
            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    return GetPaged(page, pageSize); // Nếu không có từ khóa, trả về phân trang thông thường
                }

                return dal.SearchAndPage(searchText, page, pageSize);
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