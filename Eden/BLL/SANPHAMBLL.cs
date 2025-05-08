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

        public SANPHAM GetById(int id)
        {
            try
            {
                using (var db = new QLBanHoaEntities())
                {
                    return db.SANPHAMs.Find(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy sản phẩm theo ID: {ex.Message}", ex);
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
        public List<SanPhamDTO> GetByMaLoaiSanPham(int idLoaiSanPham)
        {
            return dal.GetByMaLoaiSanPham(idLoaiSanPham);
        }
        public void Dispose()
        {
            dal.Dispose();
        }
    }
}
