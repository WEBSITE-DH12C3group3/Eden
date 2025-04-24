using System;
using System.Linq;
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
                    txtTenKhachHang.Text = khDTO.MaKhachHang;
                    txtTenKhachHang.ReadOnly = true; // Ngăn sửa mã khách hàng
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
            this.Close();
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

                khachHangBLL.Update(kh);
                MessageBox.Show("Cập nhật khách hàng thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }
    }
}