using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NguoiDungForm : Form
    {
        private NGUOIDUNGBLL nguoiDungBLL = new NGUOIDUNGBLL();
        private NHOMNGUOIDUNGBLL nhomBLL = new NHOMNGUOIDUNGBLL();
        private List<NGUOIDUNG> allUsers; // Lưu toàn bộ danh sách người dùng
        private int pageSize = 5;
        private int currentPage = 1;

        // Enum cho phân quyền (tương tự NhomNguoiDungForm)
        public enum UserRole
        {
            Admin,  // Có toàn quyền
            Editor, // Có thể thêm, sửa, nhưng không xóa
            Viewer  // Chỉ xem
        }
        private UserRole currentUserRole = UserRole.Admin; // Giả lập vai trò (có thể thay đổi)

        public NguoiDungForm()
        {
            InitializeComponent();
            ApplyPermissions(); // Áp dụng phân quyền
            LoadComboBox();
            LoadUsers();
        }

        private void ApplyPermissions()
        {
            // Áp dụng phân quyền dựa trên vai trò người dùng
            switch (currentUserRole)
            {
                case UserRole.Admin:
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    break;
                case UserRole.Editor:
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = false;
                    break;
                case UserRole.Viewer:
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }
        }

        private void LoadComboBox()
        {
            try
            {
                var groups = nhomBLL.GetAll();
                cbUserGroup.DataSource = groups;
                cbUserGroup.DisplayMember = "TenNhomNguoiDung"; // Sửa từ "TenNhom" thành "TenNhomNguoiDung" để khớp với bảng
                cbUserGroup.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            try
            {
                // Lấy toàn bộ danh sách người dùng
                allUsers = nguoiDungBLL.GetAll();

                // Lọc theo từ khóa tìm kiếm (nếu có)
                var filteredList = allUsers;
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    string keyword = txtSearch.Text.ToLower();
                    filteredList = allUsers
                        .Where(x => x.MaNguoiDung.ToLower().Contains(keyword) ||
                                    x.TenNguoiDung.ToLower().Contains(keyword) ||
                                    x.TenDangNhap.ToLower().Contains(keyword))
                        .ToList();
                }

                // Tính toán phân trang
                int totalRecords = filteredList.Count;
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

                // Hiển thị dữ liệu cho trang hiện tại
                var pagedList = filteredList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .Select(u => new
                    {
                        u.id,
                        u.MaNguoiDung,
                        u.TenNguoiDung,
                        u.TenDangNhap,
                        u.MatKhau,
                        TenNhomNguoiDung = nhomBLL.GetAll().FirstOrDefault(g => g.id == u.idNhomNguoiDung)?.TenNhomNguoiDung
                    })
                    .ToList();
                dgvUsers.DataSource = pagedList;

                // Cập nhật trạng thái nút điều hướng
                btnPrev.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateMaNguoiDung()
        {
            // Lấy số lượng người dùng hiện có để sinh mã
            int count = nguoiDungBLL.GetAll().Count + 1;
            return $"ND{count:D4}"; // Định dạng NDxxxx (ví dụ: ND0001, ND0002)
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cbUserGroup.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = new NGUOIDUNG
                {
                    MaNguoiDung = GenerateMaNguoiDung(), // Tự động sinh mã
                    TenNguoiDung = txtUserName.Text,
                    TenDangNhap = txtLogin.Text,
                    MatKhau = txtPassword.Text,
                    idNhomNguoiDung = Convert.ToInt32(cbUserGroup.SelectedValue)
                };
                nguoiDungBLL.Add(user);
                LoadUsers();
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cbUserGroup.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selected = (dynamic)dgvUsers.CurrentRow.DataBoundItem;
                var user = nguoiDungBLL.GetAll().FirstOrDefault(u => u.id == selected.id);
                if (user != null)
                {
                    user.TenNguoiDung = txtUserName.Text;
                    user.TenDangNhap = txtLogin.Text;
                    user.MatKhau = txtPassword.Text;
                    user.idNhomNguoiDung = Convert.ToInt32(cbUserGroup.SelectedValue);
                    nguoiDungBLL.Update(user);
                    LoadUsers();
                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                var selected = (dynamic)dgvUsers.CurrentRow.DataBoundItem;
                var user = nguoiDungBLL.GetAll().FirstOrDefault(u => u.id == selected.id);
                if (user != null)
                {
                    nguoiDungBLL.Delete(user);
                    LoadUsers();
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            currentPage = 1; // Reset về trang đầu khi tìm kiếm
            LoadUsers();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadUsers();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            int totalRecords = allUsers.Count;
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadUsers();
            }
        }
    }
}