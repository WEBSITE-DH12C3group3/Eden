using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Eden;
using Eden.DTO;

namespace Eden.UI
{
    public partial class KhachHangsua : Form
    {
        private KHACHHANGBLL khachHangBLL;
        private string maKH;

        public KhachHangsua(string maKH)
        {
            InitializeComponent();
            this.khachHangBLL = new KHACHHANGBLL();
            this.maKH = maKH;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                KhachHangDTO khDTO = khachHangBLL.GetAll().FirstOrDefault(k => k.MaKhachHang == maKH);

                if (khDTO != null) // Nếu tìm thấy khách hàng
                {
                    txtMaKhachHang.Text = khDTO.MaKhachHang;
                    txtMaKhachHang.ReadOnly = true; // Ngăn sửa mã khách hàng
                    txtTenKhachHang.Text = khDTO.TenKhachHang;
                    txtDiaChi.Text = khDTO.DiaChi;
                    txtSoDienThoai.Text = khDTO.SoDienThoai;
                    txtEmail.Text = khDTO.Email;
                }
                else // Nếu không tìm thấy khách hàng
                {
                    MessageBox.Show("Không tìm thấy khách hàng với mã: " + maKH, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Đóng form sửa để tránh hiển thị form trống
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                this.Close(); // Đóng form nếu xảy ra lỗi
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
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
                    MaKhachHang = maKH,
                    TenKhachHang = txtTenKhachHang.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),// Sửa lại đây
                    SoDienThoai = txtSoDienThoai.Text.Trim(),  // Sửa lại đây
                    Email = txtEmail.Text.Trim()          // Thêm Email
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

                khachHangBLL.Update(kh);
                MessageBox.Show("Cập nhật khách hàng thành công!");
                //this.Close();
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
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }
    }
}