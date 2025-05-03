using System;
using System.Linq;
using System.Text.RegularExpressions;
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
                txtMaKhachHang.Text = $"KH{(lastNumber + 1):D4}"; // Tạo mã mới KHxxxx
            }
            else
            {
                txtMaKhachHang.Text = "KH0001"; // Nếu chưa có khách hàng nào
            }
            txtMaKhachHang.ReadOnly = true; // Không cho phép chỉnh sửa mã khách hàng
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            KhachHangForm formAdd = new KhachHangForm();
            this.Controls.Clear();
            formAdd.TopLevel = false;
            formAdd.FormBorderStyle = FormBorderStyle.None;
            formAdd.Dock = DockStyle.Fill;
            this.Controls.Add(formAdd);
            formAdd.Show();
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
                // Kiểm tra trống
                if (string.IsNullOrEmpty(txtTenKhachHang.Text))
                {
                    MessageBox.Show("Tên khách hàng không được để trống.");
                    return;
                }

                // Kiểm tra có chứa số hoặc ký tự lạ
                if (!Regex.IsMatch(txtTenKhachHang.Text, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Tên khách hàng chỉ được chứa chữ cái và khoảng trắng.");
                    return;
                }

                if (string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống.");
                    return;
                }

                // Kiểm tra ký tự hợp lệ
                if (!Regex.IsMatch(txtDiaChi.Text, @"^[\p{L}0-9\s\.,\/\-]+$"))
                {
                    MessageBox.Show("Địa chỉ chỉ được chứa chữ cái, số và một số ký tự đặc biệt như . , / -");
                    return;
                }
                if (Regex.IsMatch(txtDiaChi.Text, @"^\d+$"))
                {
                    MessageBox.Show("Địa chỉ không được chỉ toàn số.");
                    return;
                }

                // Kiểm tra trống
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Email không được để trống.");
                    return;
                }

                // Kiểm tra định dạng email
                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không đúng định dạng.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text)
                    || !txtSoDienThoai.Text.All(char.IsDigit)
                    || txtSoDienThoai.Text.Length < 9
                    || txtSoDienThoai.Text.Length > 11)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ (phải từ 9-11 chữ số).");
                    return;
                }


                khachHangBLL.Add(kh);
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // this.Close(); // Đóng form sau khi thêm thành công
                KhachHangForm formAdd = new KhachHangForm();
                this.Controls.Clear();
                formAdd.TopLevel = false;
                formAdd.FormBorderStyle = FormBorderStyle.None;
                formAdd.Dock = DockStyle.Fill;
                this.Controls.Add(formAdd);
                formAdd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}