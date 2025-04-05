using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Eden
{
    public enum UserRole
    {
        Admin,
        Editor,
        Viewer
    }

    public partial class NhomNguoiDungForm : Form
    {
        private NHOMNGUOIDUNGBLL bll = new NHOMNGUOIDUNGBLL();
        private List<NHOMNGUOIDUNG> allNhomNguoiDung;
        private int currentPage = 1;
        private int pageSize = 10;
        private UserRole currentUserRole = UserRole.Viewer;

        public NhomNguoiDungForm()
        {
            InitializeComponent();
            currentUserRole = UserRole.Admin; // Giả lập vai trò, bạn có thể thay đổi
            ApplyPermissions();
            ConfigureDataGridView();
            LoadData();
        }

        private void ConfigureDataGridView()
        {
            dgvNhomNguoiDung.AutoGenerateColumns = false;
            if (dgvNhomNguoiDung.Columns.Count == 0)
            {
                dgvNhomNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "id",
                    HeaderText = "ID",
                    Name = "id"
                });
                dgvNhomNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaNhomNguoiDung",
                    HeaderText = "Mã Nhóm",
                    Name = "MaNhomNguoiDung"
                });
                dgvNhomNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenNhomNguoiDung",
                    HeaderText = "Tên Nhóm",
                    Name = "TenNhomNguoiDung"
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
                allNhomNguoiDung = bll.GetAll();
                var filteredList = allNhomNguoiDung;
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    string keyword = txtSearch.Text.ToLower();
                    filteredList = allNhomNguoiDung
                        .Where(n => n.MaNhomNguoiDung.ToLower().Contains(keyword) ||
                                    n.TenNhomNguoiDung.ToLower().Contains(keyword))
                        .ToList();
                }

                int totalRecords = filteredList.Count;
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

                var pagedList = filteredList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
                dgvNhomNguoiDung.DataSource = pagedList;

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
            using (var form = new AddEditNhomNguoiDungForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var nnd = form.NhomNguoiDung;
                        bll.Add(nnd);
                        LoadData();
                        MessageBox.Show("Thêm nhóm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhomNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nnd = dgvNhomNguoiDung.CurrentRow.DataBoundItem as NHOMNGUOIDUNG;
            using (var form = new AddEditNhomNguoiDungForm(nnd))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bll.Update(form.NhomNguoiDung);
                        LoadData();
                        MessageBox.Show("Cập nhật nhóm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi sửa nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhomNguoiDung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nhóm để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhóm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var nnd = dgvNhomNguoiDung.CurrentRow.DataBoundItem as NHOMNGUOIDUNG;
                if (nnd != null)
                {
                    bll.Delete(nnd);
                    LoadData();
                    MessageBox.Show("Xóa nhóm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhomNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Không cần hiển thị dữ liệu lên ô nhập liệu nữa vì đã dùng form con
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
            int totalRecords = allNhomNguoiDung.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }
    }
}