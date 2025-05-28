using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Eden.DTO;

namespace Eden
{
    public class TinhLuongBLL
    {
        private readonly TinhLuongDAL tinhLuongDAL;

        public TinhLuongBLL()
        {
            tinhLuongDAL = new TinhLuongDAL();
        }

        // Kiểm tra kết nối cơ sở dữ liệu
        public bool TestConnection()
        {
            try
            {
                using (var context = new QLBanHoaEntities())
                {
                    context.Database.Connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy danh sách lương
        public List<LuongDTO> GetLuongList()
        {
            try
            {
                return tinhLuongDAL.GetAllDTO();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<LuongDTO>();
            }
        }

        // Lấy danh sách lương phân trang
        public (List<LuongDTO> Data, int TotalRecords) GetPagedLuong(int page, int pageSize)
        {
            try
            {
                return tinhLuongDAL.GetPaged(page, pageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu lương phân trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (new List<LuongDTO>(), 0);
            }
        }

        // Tính lương cho nhân viên
        public bool CalculateAndSaveSalary(int? idNguoiDung, int thang, int nam)
        {
            try
            {
                string thangNam = $"{thang:D2}{nam}";
                var existingLuong = tinhLuongDAL.GetAllDTO()
                    .FirstOrDefault(l => l.IdNguoiDung == idNguoiDung && l.ThangNam == thangNam);

                if (existingLuong != null)
                {
                    MessageBox.Show($"Lương của nhân viên này trong tháng {thang:D2}/{nam} đã được tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                var luongDTOs = tinhLuongDAL.CalculateSalary(idNguoiDung, thang, nam);
                foreach (var luongDTO in luongDTOs)
                {
                    tinhLuongDAL.SaveSalary(luongDTO);
                }
                return luongDTOs.Any();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính và lưu lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Thêm bản ghi lương với logic kiểm tra
        public void AddLuong(LUONG luong)
        {
            try
            {
                // Kiểm tra xem lương đã tồn tại cho nhân viên và tháng/năm
                string thangNam = luong.ThangNam;
                var existingLuong = tinhLuongDAL.GetAll()
                    .FirstOrDefault(l => l.idNguoiDung == luong.idNguoiDung && l.ThangNam == thangNam);

                if (existingLuong != null)
                {
                    throw new Exception($"Lương cho nhân viên này trong tháng {thangNam.Substring(0, 2)}/{thangNam.Substring(2)} đã tồn tại.");
                }

                tinhLuongDAL.Add(luong);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Cập nhật bản ghi lương
        public void UpdateLuong(LUONG luong)
        {
            try
            {
                tinhLuongDAL.Update(luong);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Xóa bản ghi lương
        public void DeleteLuong(int id)
        {
            try
            {
                tinhLuongDAL.Delete(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}