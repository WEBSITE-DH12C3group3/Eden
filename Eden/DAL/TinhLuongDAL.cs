using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class TinhLuongDAL : IDisposable
    {
        private readonly QLBanHoaEntities db;

        public TinhLuongDAL()
        {
            db = new QLBanHoaEntities();
        }

        // Lấy danh sách lương
        public List<LUONG> GetAll()
        {
            try
            {
                return db.LUONGs.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lương: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách lương dưới dạng DTO, loại bỏ admin
        public List<LuongDTO> GetAllDTO()
        {
            try
            {
                return db.LUONGs
                    .Include("NGUOIDUNG")
                    .Where(l => l.NGUOIDUNG.idNhomNguoiDung != 1) // Loại bỏ admin
                    .Select(l => new LuongDTO
                    {
                        Id = l.id,
                        MaLuong = l.MaLuong,
                        IdNguoiDung = l.idNguoiDung,
                        MaNguoiDung = l.NGUOIDUNG.MaNguoiDung,
                        MaNhanVien = l.NGUOIDUNG.MaNhanVien,
                        TenNguoiDung = l.NGUOIDUNG.TenNguoiDung,
                        ThangNam = l.ThangNam,
                        LuongCoDinh = l.LuongCoDinh,
                        TongDoanhSo = l.TongDoanhSo,
                        PhatDiMuon = l.PhatDiMuon ?? 0,
                        PhatNghiBuoi = l.PhatNghiBuoi ?? 0,
                        TroCap = l.TroCap ?? 0,
                        Thuong = l.Thuong ?? 0,
                        TongLuong = l.TongLuong,
                        NgayTinhLuong = l.NgayTinhLuong,
                        GhiChu = l.GhiChu
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách lương DTO: " + ex.Message);
                throw;
            }
        }

        // Lấy danh sách lương phân trang
        public (List<LuongDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;

                var data = db.LUONGs
                    .Include("NGUOIDUNG")
                    .Where(l => l.NGUOIDUNG.idNhomNguoiDung != 1) // Loại bỏ admin
                    .OrderBy(l => l.MaLuong)
                    .Skip(skip)
                    .Take(pageSize)
                    .Select(l => new LuongDTO
                    {
                        Id = l.id,
                        MaLuong = l.MaLuong,
                        IdNguoiDung = l.idNguoiDung,
                        MaNguoiDung = l.NGUOIDUNG.MaNguoiDung,
                        MaNhanVien = l.NGUOIDUNG.MaNhanVien,
                        TenNguoiDung = l.NGUOIDUNG.TenNguoiDung,
                        ThangNam = l.ThangNam,
                        LuongCoDinh = l.LuongCoDinh,
                        TongDoanhSo = l.TongDoanhSo,
                        PhatDiMuon = l.PhatDiMuon ?? 0,
                        PhatNghiBuoi = l.PhatNghiBuoi ?? 0,
                        TroCap = l.TroCap ?? 0,
                        Thuong = l.Thuong ?? 0,
                        TongLuong = l.TongLuong,
                        NgayTinhLuong = l.NgayTinhLuong,
                        GhiChu = l.GhiChu
                    })
                    .ToList();

                int totalRecords = db.LUONGs.Count(l => l.NGUOIDUNG.idNhomNguoiDung != 1);
                return (data, totalRecords);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu lương phân trang: " + ex.Message);
                throw;
            }
        }

        // Thêm bản ghi lương
        public void Add(LUONG luong)
        {
            try
            {
                db.LUONGs.Add(luong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm lương: " + ex.Message);
                throw;
            }
        }

        // Cập nhật bản ghi lương
        public void Update(LUONG luong)
        {
            try
            {
                var existingLuong = db.LUONGs.Find(luong.id);
                if (existingLuong != null)
                {
                    db.Entry(existingLuong).CurrentValues.SetValues(luong);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Bản ghi lương không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật lương: " + ex.Message);
                throw;
            }
        }

        // Xóa bản ghi lương
        public void Delete(int id)
        {
            try
            {
                var luong = db.LUONGs.Find(id);
                if (luong != null)
                {
                    db.LUONGs.Remove(luong);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Bản ghi lương không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa lương: " + ex.Message);
                throw;
            }
        }

        // Tính lương bằng stored procedure
        public List<LuongDTO> CalculateSalary(int? idNguoiDung, int thang, int nam)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@ThangNam", $"{thang:D2}{nam}"),
                    idNguoiDung.HasValue ? new SqlParameter("@idNguoiDung", idNguoiDung.Value) : new SqlParameter("@idNguoiDung", DBNull.Value)
                };

                var data = db.Database.SqlQuery<LuongDTO>(
                    "EXEC TinhLuong @ThangNam, @idNguoiDung",
                    parameters
                ).ToList();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính lương: " + ex.Message);
                throw;
            }
        }

        // Lưu lương vào cơ sở dữ liệu
        public void SaveSalary(LuongDTO luongDTO)
        {
            try
            {
                var luong = new LUONG
                {
                    idNguoiDung = luongDTO.IdNguoiDung,
                    ThangNam = luongDTO.ThangNam,
                    LuongCoDinh = luongDTO.LuongCoDinh,
                    TongDoanhSo = luongDTO.TongDoanhSo,
                    PhatDiMuon = luongDTO.PhatDiMuon,
                    PhatNghiBuoi = luongDTO.PhatNghiBuoi,
                    TroCap = luongDTO.TroCap,
                    Thuong = luongDTO.Thuong,
                    TongLuong = luongDTO.TongLuong,
                    NgayTinhLuong = luongDTO.NgayTinhLuong,
                    GhiChu = luongDTO.GhiChu
                };

                db.LUONGs.Add(luong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu lương: " + ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}