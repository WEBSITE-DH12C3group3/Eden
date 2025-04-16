using System;
using System.Collections.Generic;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class SANPHAMBLL : IDisposable
    {
        private SANPHAMDAL dal = new SANPHAMDAL();

        public SANPHAMBLL()
        {
            dal = new SANPHAMDAL();
        }

        public List<SanPhamDTO> GetAll()
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

        public void Add(SANPHAM sp)
        {
            dal.Add(sp);
        }

        public void Update(SANPHAM sp)
        {
            dal.Update(sp);
        }

        public void Delete(SANPHAM sp)
        {
            dal.Delete(sp);
        }
        public List<SanPhamDTO>TimKiemTheoTen(string tuKhoa)
        {
            return dal.TimKiemTheoTen(tuKhoa);
        }
        public List<SanPhamDTO> LaySanPhamTheoTrang(int page, int pageSize)
        {
            return dal.LaySanPhamTheoTrang(page, pageSize);
        }

        public int DemSoLuongSanPham()
        {
            return dal.DemSoLuongSanPham();
        }

        public SANPHAM GetByMaSanPham(string maSanPham)
        {
            return dal.GetByMaSanPham(maSanPham);
        }

        public void Dispose()
        {
            dal.Dispose();
        }
    }
}
