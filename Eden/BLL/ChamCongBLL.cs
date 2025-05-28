using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Eden.DTO;

namespace Eden
{
    public class ChamCongBLL
    {
        private ChamCongDAL chamCongDAL;

        public ChamCongBLL()
        {
            chamCongDAL = new ChamCongDAL();
        }

        public bool UpdateOrCreateLoginTime(int idNguoiDung, DateTime ngayChamCong, TimeSpan gioDangNhap)
        {
            try
            {
                // Thử cập nhật giờ đăng nhập cho bản ghi đã tồn tại
                bool updated = chamCongDAL.UpdateGioDangNhap(idNguoiDung, ngayChamCong, gioDangNhap);

                if (!updated)
                {
                    // Nếu không tìm thấy bản ghi để cập nhật (chưa chấm công ngày hôm đó)
                    // Thì tạo một bản ghi chấm công mới
                    CHAMCONG newChamCong = new CHAMCONG
                    {
                        // MaChamCong cần được tạo duy nhất. Đây là một ví dụ đơn giản.
                        // Bạn nên có một cơ chế tạo mã robust hơn trong thực tế.
                        //MaChamCong = "CC" + ngayChamCong.ToString("yyyyMMdd") + idNguoiDung + Guid.NewGuid().ToString().Substring(0, 4).ToUpper(),
                        idNguoiDung = idNguoiDung,
                        NgayChamCong = ngayChamCong,
                        GioDangNhap = gioDangNhap,
                        GioDangXuat = null, // Giờ đăng xuất ban đầu là null
                        CaLamViec = "Ca hành chính", // Đặt giá trị mặc định hoặc xác định từ logic
                        TrangThai = "idk" // Trạng thái mặc định khi mới đăng nhập
                    };
                    chamCongDAL.Add(newChamCong); // Sử dụng phương thức Add từ ChamCongDAL
                    return true;
                }
                return true; // Đã cập nhật thành công bản ghi hiện có
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc hiển thị thông báo
                MessageBox.Show($"Lỗi BLL khi cập nhật/tạo giờ đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateUserLogoutTime(int idNguoiDung, DateTime ngayChamCong, TimeSpan gioDangXuat)
        {
            try
            {
                // Gọi DAL để cập nhật giờ đăng xuất
                bool updated = chamCongDAL.UpdateGioDangXuat(idNguoiDung, ngayChamCong, gioDangXuat);

                if (!updated)
                {
                    // Trường hợp này có thể xảy ra nếu người dùng chưa từng đăng nhập trong ngày
                    // hoặc bản ghi chấm công không tồn tại.
                    // Bạn có thể cân nhắc tạo một bản ghi mới nếu không tìm thấy,
                    // nhưng thông thường giờ đăng xuất chỉ cập nhật bản ghi đã có giờ đăng nhập.
                    MessageBox.Show("Không tìm thấy bản ghi chấm công để cập nhật giờ đăng xuất. Vui lòng đảm bảo bạn đã đăng nhập hôm nay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi BLL khi cập nhật giờ đăng xuất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lấy danh sách chấm công
        public List<ChamCongDTO> GetChamCongList()
        {
            return chamCongDAL.GetAllDTO();
        }

        // Lấy danh sách chấm công phân trang
        public (List<ChamCongDTO> Data, int TotalRecords) GetPagedChamCong(int page, int pageSize)
        {
            return chamCongDAL.GetPaged(page, pageSize);
        }

        // Thêm bản ghi chấm công với logic kiểm tra
        public void AddChamCong(CHAMCONG chamCong)
        {
            // Kiểm tra trạng thái dựa trên thời gian đăng nhập và ca làm việc
            if (chamCong.GioDangNhap.HasValue)
            {
                TimeSpan gioBatDauCa = GetStartTimeOfShift(chamCong.CaLamViec);
                if (chamCong.GioDangNhap > gioBatDauCa)
                {
                    chamCong.TrangThai = "Đi muộn";
                }
                else
                {
                    chamCong.TrangThai = "Đi làm";
                }
            }
            else if (!chamCong.GioDangNhap.HasValue && !chamCong.GioDangXuat.HasValue)
            {
                chamCong.TrangThai = "Nghỉ phép";
            }

            chamCongDAL.Add(chamCong);
        }

        // Cập nhật bản ghi chấm công với logic kiểm tra
        public void UpdateChamCong(CHAMCONG chamCong)
        {
            // Kiểm tra trạng thái dựa trên thời gian đăng nhập và ca làm việc
            if (chamCong.GioDangNhap.HasValue)
            {
                TimeSpan gioBatDauCa = GetStartTimeOfShift(chamCong.CaLamViec);
                if (chamCong.GioDangNhap > gioBatDauCa)
                {
                    chamCong.TrangThai = "Đi muộn";
                }
                else
                {
                    chamCong.TrangThai = "Đi làm";
                }
            }
            else if (!chamCong.GioDangNhap.HasValue && !chamCong.GioDangXuat.HasValue)
            {
                chamCong.TrangThai = "Nghỉ phép";
            }

            chamCongDAL.Update(chamCong);
        }

        // Xóa bản ghi chấm công
        public void DeleteChamCong(int id)
        {
            chamCongDAL.Delete(id);
        }

        // Lấy thời gian bắt đầu của ca làm việc
        private TimeSpan GetStartTimeOfShift(string caLamViec)
        {
            switch (caLamViec)
            {
                case "Ca 1: 7h-12h": return new TimeSpan(7, 0, 0);  // Ca 1: 7h-12h
                case "Ca 2: 12h-17h": return new TimeSpan(12, 0, 0); // Ca 2: 12h-17h
                case "Ca 3: 17h-22h": return new TimeSpan(17, 0, 0); // Ca 3: 17h-22h
                default: throw new ArgumentException("Ca làm việc không hợp lệ!");
            }
        }
    }
}