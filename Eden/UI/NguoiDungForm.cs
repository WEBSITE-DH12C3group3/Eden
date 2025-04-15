using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Eden.BLLCustom;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NguoiDungForm : Form
    {
        private NGUOIDUNGBLL nguoiDungBll = new NGUOIDUNGBLL();
        private NHOMNGUOIDUNGBLL nhomNguoiDungBll = new NHOMNGUOIDUNGBLL();
        private List<NGUOIDUNG> nguoiDungList;
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;

        public NguoiDungForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                nguoiDungList = nguoiDungBll.GetAll();
                nhomNguoiDungList = nhomNguoiDungBll.GetAll();
                dataGridViewNguoiDung.Rows.Clear();
                foreach (var nd in nguoiDungList)
                {
                    dataGridViewNguoiDung.Rows.Add(nd.id, nd.MaNguoiDung, nd.TenNguoiDung, nd.TenDangNhap, nd.NHOMNGUOIDUNG?.TenNhomNguoiDung);
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
                using (var form = new AddEditNguoiDungForm(null, nhomNguoiDungList))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewNguoiDung.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một người dùng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dataGridViewNguoiDung.SelectedRows[0].Cells["colId"].Value);
                var nguoiDung = nguoiDungList.Find(nd => nd.id == id);
                if (nguoiDung == null)
                {
                    MessageBox.Show("Người dùng không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var form = new AddEditNguoiDungForm(nguoiDung, nhomNguoiDungList))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewNguoiDung.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một người dùng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dataGridViewNguoiDung.SelectedRows[0].Cells["colId"].Value);
                var nguoiDung = nguoiDungList.Find(nd => nd.id == id);
                if (nguoiDung == null)
                {
                    MessageBox.Show("Người dùng không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng '{nguoiDung.TenNguoiDung}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    nguoiDungBll.Delete(nguoiDung);
                    LoadData();
                    MessageBox.Show("Đã xóa người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}