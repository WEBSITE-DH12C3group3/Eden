using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Eden.BLLCustom;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NhomNguoiDungForm : Form
    {
        private NHOMNGUOIDUNGBLL nhomNguoiDungBll = new NHOMNGUOIDUNGBLL();
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;

        public NhomNguoiDungForm()
        {
            InitializeComponent();
            guna2TextBoxTimKiem.TextChanged += new EventHandler(guna2TextBoxTimKiem_TextChanged); // Gán sự kiện TextChanged
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                nhomNguoiDungList = nhomNguoiDungBll.GetAll();
                FilterData(); // Gọi hàm lọc để hiển thị dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData()
        {
            try
            {
                dataGridViewNhomNguoiDung.Rows.Clear();
                string searchText = guna2TextBoxTimKiem.Text.Trim().ToLower();

                var filteredList = string.IsNullOrEmpty(searchText)
                    ? nhomNguoiDungList
                    : nhomNguoiDungList.FindAll(n => n.TenNhomNguoiDung.ToLower().Contains(searchText));

                foreach (var nhom in filteredList)
                {
                    dataGridViewNhomNguoiDung.Rows.Add(nhom.MaNhomNguoiDung, nhom.TenNhomNguoiDung);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            FilterData(); // Lọc lại dữ liệu mỗi khi text thay đổi
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AddEditNhomNguoiDungForm(null))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewNhomNguoiDung.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một nhóm để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maNhom = dataGridViewNhomNguoiDung.SelectedRows[0].Cells["colNhomId"].Value.ToString();
                var nhom = nhomNguoiDungList.Find(n => n.MaNhomNguoiDung == maNhom);
                if (nhom == null)
                {
                    MessageBox.Show("Nhóm không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var form = new AddEditNhomNguoiDungForm(nhom))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewNhomNguoiDung.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một nhóm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maNhom = dataGridViewNhomNguoiDung.SelectedRows[0].Cells["colNhomId"].Value.ToString();
                var nhom = nhomNguoiDungList.Find(n => n.MaNhomNguoiDung == maNhom);
                if (nhom == null)
                {
                    MessageBox.Show("Nhóm không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm '{nhom.TenNhomNguoiDung}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nhomNguoiDungBll.Delete(nhom);
                    LoadData();
                    MessageBox.Show("Đã xóa nhóm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            guna2TextBoxTimKiem.Text = string.Empty; // Xóa nội dung tìm kiếm
            LoadData();
        }
    }
}