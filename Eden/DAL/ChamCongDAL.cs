using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class ChamCongDAL : IDisposable
    {
        private QLBanHoaEntities db;

        public ChamCongDAL()
        {
            db = new QLBanHoaEntities();
        }

        // Lấy danh sách chấm công
        public List<CHAMCONG> GetAll()
        {
            return db.CHAMCONGs.ToList();
        }

        // Lấy danh sách chấm công dưới dạng DTO
        public List<ChamCongDTO> GetAllDTO()
        {
            try
            {
                return db.CHAMCONGs
                    .Include(cc => cc.THONGTINNHANVIEN.NGUOIDUNG)
                    .Select(cc => new ChamCongDTO
                    {
                        id = cc.id,
                        MaChamCong = cc.MaChamCong,
                        MaNhanVien = cc.THONGTINNHANVIEN.MaNhanVien,
                        TenNguoiDung = cc.THONGTINNHANVIEN.NGUOIDUNG.TenNguoiDung,
                        NgayChamCong = cc.NgayChamCong,
                        GioDangNhap = cc.GioDangNhap,
                        GioDangXuat = cc.GioDangXuat,
                        CaLamViec = cc.CaLamViec,
                        TrangThai = cc.TrangThai
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chấm công DTO: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách chấm công phân trang
        public (List<ChamCongDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;

                var data = db.CHAMCONGs
                    .Include(cc => cc.THONGTINNHANVIEN.NGUOIDUNG)
                    .OrderBy(cc => cc.MaChamCong)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(cc => new ChamCongDTO
                    {
                        id = cc.id,
                        MaChamCong = cc.MaChamCong,
                        MaNhanVien = cc.THONGTINNHANVIEN.MaNhanVien,
                        TenNguoiDung = cc.THONGTINNHANVIEN.NGUOIDUNG.TenNguoiDung,
                        NgayChamCong = cc.NgayChamCong,
                        GioDangNhap = cc.GioDangNhap,
                        GioDangXuat = cc.GioDangXuat,
                        CaLamViec = cc.CaLamViec,
                        TrangThai = cc.TrangThai
                    })
                    .ToList();

                int totalRecords = db.CHAMCONGs.Count();
                return (data, totalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu chấm công phân trang: " + ex.Message);
                throw;
            }
        }

        // Thêm bản ghi chấm công
        public void Add(CHAMCONG chamCong)
        {
            try
            {
                db.CHAMCONGs.Add(chamCong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chấm công: " + ex.Message);
                throw;
            }
        }

        // Cập nhật bản ghi chấm công
        public void Update(CHAMCONG chamCong)
        {
            try
            {
                var existingCC = db.CHAMCONGs.Find(chamCong.id);
                if (existingCC != null)
                {
                    db.Entry(existingCC).CurrentValues.SetValues(chamCong);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Bản ghi chấm công không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chấm công: " + ex.Message);
                throw;
            }
        }

        // Xóa bản ghi chấm công
        public void Delete(int id)
        {
            try
            {
                var chamCong = db.CHAMCONGs.Find(id);
                if (chamCong != null)
                {
                    db.CHAMCONGs.Remove(chamCong);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Bản ghi chấm công không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chấm công: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}