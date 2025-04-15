using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Eden.BLLCustom;
using Guna.UI2.WinForms; // Thêm namespace cho Guna.UI2.WinForms

namespace Eden
{
    public partial class AddEditNguoiDungForm : Form
    {
        private NGUOIDUNG nguoiDung;
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;
        private NGUOIDUNGBLL nguoiDungBll = new NGUOIDUNGBLL();

        public AddEditNguoiDungForm(NGUOIDUNG nguoiDung, List<NHOMNGUOIDUNG> nhomNguoiDungList)
        {
            InitializeComponent();
            this.nguoiDung = nguoiDung;
            this.nhomNguoiDungList = nhomNguoiDungList;
            LoadNhomNguoiDung();
            if (nguoiDung != null)
            {
                txtTenNguoiDung.Text = nguoiDung.TenNguoiDung;
                txtTenDangNhap.Text = nguoiDung.TenDangNhap;
                txtMatKhau.Text = nguoiDung.MatKhau;
                cbNhomNguoiDung.SelectedValue = nguoiDung.idNhomNguoiDung;
                this.Text = "Chỉnh Sửa Người Dùng";
            }
            else
            {
                this.Text = "Thêm Người Dùng";
            }
        }

        private void LoadNhomNguoiDung()
        {
            cbNhomNguoiDung.DataSource = nhomNguoiDungList;
            cbNhomNguoiDung.DisplayMember = "TenNhomNguoiDung";
            cbNhomNguoiDung.ValueMember = "id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNguoiDung.Text))
                {
                    MessageBox.Show("Tên người dùng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbNhomNguoiDung.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhóm người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nguoiDung == null)
                {
                    nguoiDung = new NGUOIDUNG();
                    nguoiDung.TenNguoiDung = txtTenNguoiDung.Text;
                    nguoiDung.TenDangNhap = txtTenDangNhap.Text;
                    nguoiDung.MatKhau = txtMatKhau.Text;
                    nguoiDung.idNhomNguoiDung = (int)cbNhomNguoiDung.SelectedValue;
                    nguoiDungBll.Add(nguoiDung);
                    MessageBox.Show("Đã thêm người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    nguoiDung.TenNguoiDung = txtTenNguoiDung.Text;
                    nguoiDung.TenDangNhap = txtTenDangNhap.Text;
                    nguoiDung.MatKhau = txtMatKhau.Text;
                    nguoiDung.idNhomNguoiDung = (int)cbNhomNguoiDung.SelectedValue;
                    nguoiDungBll.Update(nguoiDung);
                    MessageBox.Show("Đã cập nhật người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}