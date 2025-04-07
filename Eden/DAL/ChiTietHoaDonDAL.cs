using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class CHITIETHOADONDAL : IDisposable
    {
        private QLBanHoaEntities db = new QLBanHoaEntities();

        public List<CHITIETHOADON> GetAll()
        {
            return db.CHITIETHOADONs.ToList();
        }

        // Thêm phương thức lấy chi tiết hóa đơn theo idHoaDon
        public List<ChiTietHoaDonDTO> GetByHoaDonId(int idHoaDon)
        {
            try
            {
                return db.CHITIETHOADONs
                    .Where(ct => ct.idHoaDon == idHoaDon)
                    .Select(ct => new ChiTietHoaDonDTO
                    {
                        idHoaDon = ct.idHoaDon,
                        idSanPham = ct.idSanPham,
                        TenSanPham = ct.SANPHAM.TenSanPham, // Lấy tên sản phẩm từ bảng SANPHAM
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ThanhTien = ct.ThanhTien
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Add(CHITIETHOADON entity)
        {
            try
            {
                db.CHITIETHOADONs.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Update(CHITIETHOADON entity)
        {
            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Delete(CHITIETHOADON entity)
        {
            try
            {
                db.CHITIETHOADONs.Remove(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}