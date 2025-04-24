using System;
using System.Linq;
using System.Windows.Forms;
using Eden;

namespace Eden.UI
{
    public partial class KhachHangadd : Form
    {
        private KHACHHANGBLL khachHangBLL;

        public KhachHangadd()
        {
            InitializeComponent();
            khachHangBLL = new KHACHHANGBLL();
            GenerateCustomerID(); // Tạo mã khách hàng tự động khi mở form
        }

        // Tạo mã khách hàng tự động dạng KH0001, KH0002
        private void GenerateCustomerID()
        {
            var customers = khachHangBLL.GetAll();
            if (customers.Count > 0)
            {
                var lastCustomer = customers.OrderByDescending(c => c.MaKhachHang).FirstOrDefault();
                int lastNumber = int.Parse(lastCustomer.MaKhachHang.Substring(2)); // Lấy số từ KHxxxx
                txtTenKhachHang.Text = $"KH{(lastNumber + 1):D4}"; // Tạo mã mới KHxxxx
            }
            else
            {
                txtTenKhachHang.Text = "KH0001"; // Nếu chưa có khách hàng nào
            }
            txtTenKhachHang.ReadOnly = true; // Không cho phép chỉnh sửa mã khách hàng
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                KHACHHANG kh = new KHACHHANG
                {
                    MaKhachHang = txtMaKhachHang.Text.Trim(),
                    TenKhachHang = txtTenKhachHang.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                khachHangBLL.Add(kh);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi thêm thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}