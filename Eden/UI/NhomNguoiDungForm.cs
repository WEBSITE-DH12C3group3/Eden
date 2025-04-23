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
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                nhomNguoiDungList = nhomNguoiDungBll.GetAll();
                dataGridViewNhomNguoiDung.Rows.Clear();
                foreach (var nhom in nhomNguoiDungList)
                {
                    dataGridViewNhomNguoiDung.Rows.Add(nhom.MaNhomNguoiDung, nhom.TenNhomNguoiDung);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                int id = Convert.ToInt32(dataGridViewNhomNguoiDung.SelectedRows[0].Cells["colNhomId"].Value);
                var nhom = nhomNguoiDungList.Find(n => n.id == id);
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

                int id = Convert.ToInt32(dataGridViewNhomNguoiDung.SelectedRows[0].Cells["colNhomId"].Value);
                var nhom = nhomNguoiDungList.Find(n => n.id == id);
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
            LoadData();
        }
    }
}