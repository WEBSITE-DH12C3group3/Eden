using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Eden.BLLCustom;

namespace Eden
{
    public partial class AddEditNguoiDungForm : Form
    {
        private NGUOIDUNG nguoiDung;
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;
        private NGUOIDUNGBLL nguoiDungBll = new NGUOIDUNGBLL();
        private List<string> caLamViecList = new List<string> { "Ca 1: 7h-12h", "Ca 2: 12h-17h", "Ca 3: 17h-22h" };

        public AddEditNguoiDungForm(NGUOIDUNG nguoiDung, List<NHOMNGUOIDUNG> nhomNguoiDungList)
        {
            this.nguoiDung = nguoiDung;
            this.nhomNguoiDungList = nhomNguoiDungList;
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = false;
            LoadNhomNguoiDung();
            if (nguoiDung == null)
            {
                LoadCaLamViec();
            }
            else
            {
                LoadData();
            }
        }

        private void LoadNhomNguoiDung()
        {
            if (cbNhomNguoiDung != null)
            {
                cbNhomNguoiDung.DataSource = nhomNguoiDungList;
                cbNhomNguoiDung.DisplayMember = "TenNhomNguoiDung";
                cbNhomNguoiDung.ValueMember = "id";
            }
        }

        private void LoadCaLamViec()
        {
            if (cbCaLamViec != null)
            {
                cbCaLamViec.DataSource = caLamViecList;
            }
        }

        private void LoadData()
        {
            txtTenNguoiDung.Text = nguoiDung.TenNguoiDung;
            txtTenDangNhap.Text = nguoiDung.TenDangNhap;
            txtMatKhau.Text = nguoiDung.MatKhau;
            cbNhomNguoiDung.SelectedValue = nguoiDung.idNhomNguoiDung;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve input values
                string tenNguoiDung = txtTenNguoiDung.Text.Trim();
                string tenDangNhap = txtTenDangNhap.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                object selectedNhomId = cbNhomNguoiDung.SelectedValue;
                string selectedCaLamViec = nguoiDung == null ? cbCaLamViec?.SelectedItem?.ToString() : null;

                // Validation
                if (string.IsNullOrWhiteSpace(tenNguoiDung))
                {
                    MessageBox.Show("Tên người dùng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(tenNguoiDung, @"^[\p{L}\s]{1,50}$"))
                {
                    MessageBox.Show("Tên người dùng chỉ được chứa chữ cái và khoảng trắng, tối đa 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tenDangNhap))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(tenDangNhap, @"^[a-zA-Z0-9]{3,20}$"))
                {
                    MessageBox.Show("Tên đăng nhập chỉ được chứa chữ cái và số, từ 3 đến 20 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check uniqueness of TenDangNhap
                var allUsers = nguoiDungBll.GetAll();
                if (nguoiDung == null || tenDangNhap != nguoiDung.TenDangNhap)
                {
                    if (allUsers.Any(u => u.TenDangNhap.Equals(tenDangNhap, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(matKhau))
                {
                    MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(matKhau, @"^(?=.*[a-zA-Z])(?=.*\d).{6,50}$"))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự, tối đa 50 ký tự, và chứa cả chữ cái và số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedNhomId == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhóm người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nguoiDung == null && string.IsNullOrEmpty(selectedCaLamViec))
                {
                    MessageBox.Show("Vui lòng chọn một ca làm việc khi thêm người dùng mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Prepare data
                if (nguoiDung == null)
                {
                    nguoiDung = new NGUOIDUNG();
                }

                // Auto-generate MaNguoiDung
                int nextId = allUsers.Count + 1;
                nguoiDung.MaNguoiDung = $"ND{nextId.ToString().PadLeft(4, '0')}";

                nguoiDung.TenNguoiDung = tenNguoiDung;
                nguoiDung.TenDangNhap = tenDangNhap;
                nguoiDung.MatKhau = matKhau; // Assume hashing in BLL
                nguoiDung.idNhomNguoiDung = Convert.ToInt32(selectedNhomId);
                // Save data
                if (nguoiDung.id == 0)
                {
                    nguoiDungBll.Add(nguoiDung);
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    nguoiDungBll.Update(nguoiDung);
                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Navigate back to NguoiDungForm
                var form = new NguoiDungForm();
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var form = new NguoiDungForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }
    }
}