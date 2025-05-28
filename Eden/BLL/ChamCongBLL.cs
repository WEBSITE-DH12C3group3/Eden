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
                string status;
                switch (CurrentUser.Pharse)
                {
                    case "Ca 1: 7h-12h":
                        if (gioDangNhap > new TimeSpan(7, 0, 1))
                        {
                            status = "Đi muộn"; // Nếu giờ đăng nhập không trong khoảng ca 1
                        }
                        else
                        {
                            status = "Đi làm"; // Nếu giờ đăng nhập trong khoảng ca 1
                        }
                        break;

                    case "Ca 2: 12h-17h":
                        if (gioDangNhap > new TimeSpan(12, 0, 1))
                        {
                            status = "Đi muộn"; // Nếu giờ đăng nhập không trong khoảng ca 2
                        }
                        else
                        {
                            status = "Đi làm"; // Nếu giờ đăng nhập trong khoảng ca 2
                        }
                        break;

                    case "Ca 3: 17h-22h":
                        if (gioDangNhap > new TimeSpan(17, 0, 1))
                        {
                            status = "Đi muộn"; // Nếu giờ đăng nhập không trong khoảng ca 3
                        }
                        else
                        {
                            status = "Đi làm"; // Nếu giờ đăng nhập trong khoảng ca 3
                        }
                        break;

                    default:
                        status = "Lỗi"; // Hoặc một giá trị mặc định khác tùy thuộc vào logic của bạn
                        break;
                }
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
                        CaLamViec = CurrentUser.Pharse,  // Đặt giá trị mặc định hoặc xác định từ logic
                        TrangThai = status // Trạng thái mặc định khi mới đăng nhập
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

        private string GetShiftByTime(TimeSpan loginTime)
        {
            TimeSpan ca1Start = new TimeSpan(7, 0, 0);  // 7:00:00
            TimeSpan ca1End = new TimeSpan(12, 0, 0);   // 12:00:00

            TimeSpan ca2Start = new TimeSpan(12, 0, 1); // 12:00:01 (để tránh trùng lặp với Ca 1 kết thúc)
            TimeSpan ca2End = new TimeSpan(17, 0, 0);   // 17:00:00

            TimeSpan ca3Start = new TimeSpan(17, 0, 1); // 17:00:01
            TimeSpan ca3End = new TimeSpan(22, 0, 0);   // 22:00:00

            if (loginTime >= ca1Start && loginTime <= ca1End)
            {
                return "Ca 1: 7h-12h";
            }
            else if (loginTime >= ca2Start && loginTime <= ca2End)
            {
                return "Ca 2: 12h-17h";
            }
            else if (loginTime >= ca3Start && loginTime <= ca3End)
            {
                return "Ca 3: 17h-22h";
            }
            else
            {
                // Nếu giờ đăng nhập không nằm trong bất kỳ ca nào đã định nghĩa
                return "Ca ngoài giờ"; // Hoặc một giá trị mặc định khác tùy thuộc vào logic của bạn
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