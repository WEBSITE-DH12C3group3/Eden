using System;
using System.Collections.Generic;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class HOADONBLL : IDisposable
    {
        private HOADONDAL dal;

        public HOADONBLL()
        {
            dal = new HOADONDAL();
        }

        // Lấy toàn bộ danh sách hóa đơn
        public List<HOADON> GetAll()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy toàn bộ hóa đơn: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách hóa đơn theo trang
        public (List<HoaDonDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
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

        public (List<HoaDonDTO> Data, int TotalRecords) SearchAndPage(string searchText, int page, int pageSize)
        {
            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    return GetPaged(page, pageSize);
                }
                return dal.SearchAndPage(searchText, page, pageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm và phân trang: " + ex.Message);
                throw;
            }
        }

        public void Add(HOADON hd)
        {
            try
            {
                dal.Add(hd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Update(HOADON hd)
        {
            try
            {
                dal.Update(hd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Delete(HOADON hd)
        {
            try
            {
                dal.Delete(hd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            dal?.Dispose();
        }
    }
}