using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Eden.BLLCustom;
using Guna.UI2.WinForms;
using System.Data.Entity.Validation;

namespace Eden
{
    public partial class AddEditNhomNguoiDungForm : Form
    {
        private NHOMNGUOIDUNG nhomNguoiDung;
        private NHOMNGUOIDUNGBLL nhomNguoiDungBll = new NHOMNGUOIDUNGBLL();
        private List<CHUCNANG> chucNangList;
        private List<int> selectedPermissions;

        public AddEditNhomNguoiDungForm(NHOMNGUOIDUNG nhomNguoiDung)
        {
            InitializeComponent();
            this.nhomNguoiDung = nhomNguoiDung;
            LoadChucNang();
            if (nhomNguoiDung != null)
            {
                txtTenNhom.Text = nhomNguoiDung.TenNhomNguoiDung;
                selectedPermissions = nhomNguoiDungBll.GetPermissionsForGroup(nhomNguoiDung.id);
                foreach (ListViewItem item in listViewQuyen.Items)
                {
                    int chucNangId = (int)item.Tag;
                    item.Checked = selectedPermissions.Contains(chucNangId);
                }
                this.Text = "Chỉnh Sửa Nhóm Người Dùng";
            }
            else
            {
                selectedPermissions = new List<int>();
                this.Text = "Thêm Nhóm Người Dùng";
            }
        }

        private void LoadChucNang()
        {
            try
            {
                chucNangList = nhomNguoiDungBll.GetAllPermissions();
                listViewQuyen.Items.Clear();
                foreach (var chucNang in chucNangList)
                {
                    var item = new ListViewItem(chucNang.TenManHinh)
                    {
                        Tag = chucNang.id
                    };
                    listViewQuyen.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewQuyen_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int chucNangId = (int)e.Item.Tag;
            if (e.Item.Checked)
            {
                if (!selectedPermissions.Contains(chucNangId))
                    selectedPermissions.Add(chucNangId);
            }
            else
            {
                selectedPermissions.Remove(chucNangId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve input values
                string tenNhomNguoiDung = txtTenNhom.Text.Trim();

                // Validation
                if (string.IsNullOrWhiteSpace(tenNhomNguoiDung))
                {
                    MessageBox.Show("Tên nhóm người dùng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(tenNhomNguoiDung, @"^[\p{L}\s]{1,50}$"))
                {
                    MessageBox.Show("Tên nhóm người dùng chỉ được chứa chữ cái và khoảng trắng, tối đa 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check uniqueness of TenNhomNguoiDung
                var allGroups = nhomNguoiDungBll.GetAll();
                if (nhomNguoiDung == null || tenNhomNguoiDung != nhomNguoiDung.TenNhomNguoiDung)
                {
                    if (allGroups.Any(g => g.TenNhomNguoiDung.Equals(tenNhomNguoiDung, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Tên nhóm người dùng đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Check if at least one permission is selected
                if (selectedPermissions == null || !selectedPermissions.Any())
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một quyền cho nhóm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Prepare data
                if (nhomNguoiDung == null)
                {
                    nhomNguoiDung = new NHOMNGUOIDUNG
                    {
                        TenNhomNguoiDung = tenNhomNguoiDung,
                        MaNhomNguoiDung = $"NND{DateTime.Now.Ticks.ToString().Substring(0, 3)}"
                    };
                    int newGroupId = nhomNguoiDungBll.Add(nhomNguoiDung);
                    nhomNguoiDungBll.UpdatePermissionsForGroup(newGroupId, selectedPermissions);
                    MessageBox.Show("Đã thêm nhóm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    nhomNguoiDung.TenNhomNguoiDung = tenNhomNguoiDung;
                    nhomNguoiDungBll.Update(nhomNguoiDung);
                    nhomNguoiDungBll.UpdatePermissionsForGroup(nhomNguoiDung.id, selectedPermissions);
                    MessageBox.Show("Đã cập nhật nhóm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Navigate back to NhomNguoiDungForm
                var form = new NhomNguoiDungForm();
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
            }
            catch (DbEntityValidationException dbEx)
            {
                string errorMessage = "Lỗi chi tiết:\n";
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += $"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}\n";
                    }
                }
                MessageBox.Show(errorMessage, "Lỗi Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: Lỗi khi cập nhật nhóm người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var form = new NhomNguoiDungForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }
    }
}