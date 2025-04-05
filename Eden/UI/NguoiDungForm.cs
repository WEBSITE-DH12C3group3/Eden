using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NguoiDungForm : Form
    {
        private NGUOIDUNGBLL bll = new NGUOIDUNGBLL();
        private List<NGUOIDUNG> allNguoiDung;
        private int currentPage = 1;
        private int pageSize = 10;
        private UserRole currentUserRole = UserRole.Viewer;

        public NguoiDungForm()
        {
            InitializeComponent();
            currentUserRole = UserRole.Admin; // Giả lập vai trò, bạn có thể thay đổi
            ApplyPermissions();
            ConfigureDataGridView();
            LoadData();
        }

        private void ConfigureDataGridView()
        {
            dgvNguoiDung.AutoGenerateColumns = false;
            if (dgvNguoiDung.Columns.Count == 0)
            {
                dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "id",
                    HeaderText = "ID",
                    Name = "id"
                });
                dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenDangNhap",
                    HeaderText = "Tên Đăng Nhập",
                    Name = "TenDangNhap"
                });
                dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MatKhau",
                    HeaderText = "Mật Khẩu",
                    Name = "MatKhau"
                });
                dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "idNhomNguoiDung",
                    HeaderText = "ID Nhóm",
                    Name = "idNhomNguoiDung"
                });
            }
        }

        private void ApplyPermissions()
        {
            switch (currentUserRole)
            {
                case UserRole.Admin:
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    break;
                case UserRole.Editor:
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = false;
                    break;
                case UserRole.Viewer:
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    break;
            }
        }

        private void LoadData()
        {
            try
            {
                allNguoiDung = bll.GetAll();
                var filteredList = allNguoiDung;
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    string keyword = txtSearch.Text.ToLower();
                    filteredList = allNguoiDung
                        .Where(n => n.TenDangNhap.ToLower().Contains(keyword))
                        .ToList();
                }

                int totalRecords = filteredList.Count;
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

                var pagedList = filteredList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
                dgvNguoiDung.DataSource = pagedList;

                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditNguoiDungForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var nd = form.NguoiDung;
                        bll.Add(nd);
                        LoadData();
                        MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nd = dgvNguoiDung.CurrentRow.DataBoundItem as NGUOIDUNG;
            using (var form = new AddEditNguoiDungForm(nd))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bll.Update(form.NguoiDung);
                        LoadData();
                        MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi sửa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var nd = dgvNguoiDung.CurrentRow.DataBoundItem as NGUOIDUNG;
                if (nd != null)
                {
                    bll.Delete(nd);
                    LoadData();
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalRecords = allNguoiDung.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }
    }
}