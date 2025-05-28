using System;
using System.Collections.Generic;
using System.Data;
using Guna.UI2.WinForms;

using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Eden
{
    public class LoginBLL
    {
        private readonly LoginDAL loginDAL = new LoginDAL();
        private readonly ChamCongBLL chamCongBLL = new ChamCongBLL();

        public bool ValidateUser(string username, string password)
        {
            username = username?.Trim();
            password = password?.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Kiểm tra độ dài
            if (username.Length < 4 || username.Length > 20)
            {
                MessageBox.Show("Tên đăng nhập phải từ 4 đến 20 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (password.Length < 6 || password.Length > 50)
            {
                MessageBox.Show("Mật khẩu phải từ 6 đến 50 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Khoảng trắng
            if (username.Contains(" ") || password.Contains(" "))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được chứa khoảng trắng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. Ký tự đặc biệt (chỉ cho chữ cái, số, dấu gạch dưới)
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Tên đăng nhập chỉ được chứa chữ cái và số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 4. Không cho phép viết hoa (tuỳ chọn)
            if (username.Any(char.IsUpper))
            {
                MessageBox.Show("Tên đăng nhập không được chứa chữ in hoa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 5. Gọi DAL để kiểm tra đúng/sai
            var user = loginDAL.ValidateUser(username, password);
            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 6. Nếu hợp lệ, lưu vào CurrentUser
            CurrentUser.Id = user.id;
            CurrentUser.Username = user.TenNguoiDung;
            CurrentUser.Role = user.NHOMNGUOIDUNG?.TenNhomNguoiDung;
            CurrentUser.Pharse = user.CaLamViec;
            CurrentUser.UserGroupId = user.idNhomNguoiDung;
            CurrentUser.Permissions = loginDAL.GetUserPermissions(user.idNhomNguoiDung).ToList();

            try
            {
                DateTime ngayChamCong = DateTime.Today; // Lấy ngày hiện tại (không bao gồm giờ)
                TimeSpan now = DateTime.Now.TimeOfDay;
                TimeSpan gioDangNhap = new TimeSpan(now.Hours, now.Minutes, now.Seconds);

                // Gọi ChamCongBLL để cập nhật hoặc tạo mới bản ghi giờ đăng nhập
                bool success = chamCongBLL.UpdateOrCreateLoginTime(CurrentUser.Id, ngayChamCong, gioDangNhap);

                if (!success)
                {
                    // Nếu có lỗi xảy ra trong quá trình cập nhật/tạo giờ đăng nhập
                    Console.WriteLine($"Không thể cập nhật/tạo giờ đăng nhập cho người dùng {CurrentUser.Username}.");
                    // Bạn có thể chọn hiển thị MessageBox ở đây hoặc chỉ log lỗi
                    // MessageBox.Show("Có lỗi khi ghi nhận giờ chấm công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình cập nhật giờ đăng nhập
                Console.WriteLine($"Lỗi không mong muốn khi cập nhật giờ đăng nhập: {ex.Message}");
                // Bạn có thể chọn hiển thị MessageBox ở đây hoặc chỉ log lỗi
                // MessageBox.Show($"Lỗi hệ thống khi cập nhật giờ chấm công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }
    }
}