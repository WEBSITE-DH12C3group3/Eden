using System;
using System.Collections.Generic;
using System.Linq;
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
                    var item = new ListViewItem(chucNang.TenChucNang)
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
                if (string.IsNullOrWhiteSpace(txtTenNhom.Text))
                {
                    MessageBox.Show("Tên nhóm không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem có quyền nào được chọn không
                if (selectedPermissions == null || !selectedPermissions.Any())
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một quyền cho nhóm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nhomNguoiDung == null)
                {
                    nhomNguoiDung = new NHOMNGUOIDUNG
                    {
                        TenNhomNguoiDung = txtTenNhom.Text,
                        MaNhomNguoiDung = $"NND{DateTime.Now.Ticks.ToString().Substring(0, 3)}"
                    };
                    int newGroupId = nhomNguoiDungBll.Add(nhomNguoiDung);
                    nhomNguoiDungBll.UpdatePermissionsForGroup(newGroupId, selectedPermissions);
                    MessageBox.Show("Đã thêm nhóm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    nhomNguoiDung.TenNhomNguoiDung = txtTenNhom.Text;
                    nhomNguoiDungBll.Update(nhomNguoiDung);
                    nhomNguoiDungBll.UpdatePermissionsForGroup(nhomNguoiDung.id, selectedPermissions);
                    MessageBox.Show("Đã cập nhật nhóm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}