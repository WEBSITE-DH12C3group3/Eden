using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Eden.BLLCustom;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class AddEditNguoiDungForm : Form
    {
        private NGUOIDUNG nguoiDung;
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;
        private NGUOIDUNGBLL nguoiDungBll = new NGUOIDUNGBLL();

        public AddEditNguoiDungForm(NGUOIDUNG nguoiDung, List<NHOMNGUOIDUNG> nhomNguoiDungList)
        {
            this.nguoiDung = nguoiDung;
            this.nhomNguoiDungList = nhomNguoiDungList;
            InitializeComponent();
            LoadNhomNguoiDung();
            if (nguoiDung != null)
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

        private void LoadData()
        {
            txtTenNguoiDung.Text = nguoiDung.TenNguoiDung;
            txtTenDangNhap.Text = nguoiDung.TenDangNhap;
            txtMatKhau.Text = nguoiDung.MatKhau;
            if (nguoiDung.idNhomNguoiDung != null)
            {
                cbNhomNguoiDung.SelectedValue = nguoiDung.idNhomNguoiDung;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNguoiDung.Text))
                {
                    MessageBox.Show("Tên người dùng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                {
                    MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbNhomNguoiDung.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhóm người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (nguoiDung == null)
                {
                    nguoiDung = new NGUOIDUNG();
                }

                // Tạo mã người dùng dựa trên số thứ tự
                var allUsers = nguoiDungBll.GetAll();
                int nextId = allUsers.Count + 1; // Số thứ tự tiếp theo
                nguoiDung.MaNguoiDung = $"ND{nextId.ToString().PadLeft(4, '0')}";

                nguoiDung.TenNguoiDung = txtTenNguoiDung.Text.Trim();
                nguoiDung.TenDangNhap = txtTenDangNhap.Text.Trim();
                nguoiDung.MatKhau = txtMatKhau.Text.Trim();
                nguoiDung.idNhomNguoiDung = Convert.ToInt32(cbNhomNguoiDung.SelectedValue);

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