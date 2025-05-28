using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace Eden
{
    public static class CurrentUser
    {
        private static ChamCongBLL chamCongBLL = new ChamCongBLL();
        public static int Id { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string Pharse { get; set; }
        public static int UserGroupId { get; set; }
        public static List<string> Permissions { get; set; } = new List<string>();

        public static void Logout(List<Guna2GradientButton> sidebarButtons, Guna2Panel guna2Panel2)
        {
            if (Id != 0) // Chỉ cập nhật nếu có người dùng đang đăng nhập
            {
                try
                {
                    DateTime ngayChamCong = DateTime.Today; // Ngày hiện tại
                    // Lấy giờ hiện tại và làm tròn đến giây gần nhất
                    TimeSpan currentTimeOfDay = DateTime.Now.TimeOfDay;
                    TimeSpan gioDangXuat = new TimeSpan(currentTimeOfDay.Hours, currentTimeOfDay.Minutes, currentTimeOfDay.Seconds);

                    bool success = chamCongBLL.UpdateUserLogoutTime(Id, ngayChamCong, gioDangXuat);

                    if (!success)
                    {
                        Console.WriteLine($"Cảnh báo: Không thể cập nhật giờ đăng xuất cho người dùng ID {Id} vào ngày {ngayChamCong.ToShortDateString()}.");
                        // Bạn có thể hiển thị MessageBox hoặc log lỗi chi tiết hơn
                        // MessageBox.Show("Không thể ghi nhận giờ đăng xuất. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật giờ đăng xuất: {ex.Message}");
                    // MessageBox.Show($"Lỗi hệ thống khi cập nhật giờ đăng xuất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Id = 0;
            Username = null;
            Role = null;
            UserGroupId = 0;
            Pharse = null;
            Permissions.Clear();
            // Xóa tất cả các nút sidebar
            foreach (var btn in sidebarButtons)
            {
                guna2Panel2.Controls.Remove(btn); // Hoặc yourPanel.Controls.Remove(btn)
                btn.Dispose(); // Giải phóng tài nguyên
            }
            sidebarButtons.Clear(); // Xóa danh sách
        }
    }
}