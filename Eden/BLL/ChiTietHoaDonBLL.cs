using System;
using System.Collections.Generic;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class CHITIETHOADONBLL : IDisposable
    {
        private CHITIETHOADONDAL dal;

        public CHITIETHOADONBLL()
        {
            dal = new CHITIETHOADONDAL();
        }

        public List<CHITIETHOADON> GetAll()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy toàn bộ chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        // Thêm phương thức lấy chi tiết hóa đơn theo idHoaDon
        public List<ChiTietHoaDonDTO> GetByHoaDonId(int idHoaDon)
        {
            try
            {
                return dal.GetByHoaDonId(idHoaDon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết hóa đơn theo idHoaDon: " + ex.Message);
                throw;
            }
        }

        public void Add(CHITIETHOADON cthd)
        {
            try
            {
                dal.Add(cthd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Update(CHITIETHOADON cthd)
        {
            try
            {
                dal.Update(cthd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Delete(CHITIETHOADON cthd)
        {
            try
            {
                dal.Delete(cthd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            dal?.Dispose();
        }
    }
}