using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Eden.DALCustom;
using Eden.BLLCustom;

namespace Eden
{
    public partial class NguoiDungForm : Form
    {
        private NGUOIDUNGBLL nguoiDungBll = new NGUOIDUNGBLL();
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;

        // Constructor không tham số
        public NguoiDungForm()
        {
            var nhomNguoiDungDal = new NHOMNGUOIDUNGDAL();
            this.nhomNguoiDungList = nhomNguoiDungDal.GetAll();
            InitializeComponent();
            LoadData();
        }

        // Constructor hiện tại (giữ nguyên để tương thích)
        public NguoiDungForm(List<NHOMNGUOIDUNG> nhomNguoiDungList)
        {
            this.nhomNguoiDungList = nhomNguoiDungList;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var nguoiDungList = nguoiDungBll.GetAll();
                dgvNguoiDung.DataSource = nguoiDungList.Select(nd => new
                {
                    ID = nd.id,
                    MaNguoiDung = nd.MaNguoiDung,
                    TenNguoiDung = nd.TenNguoiDung,
                    TenDangNhap = nd.TenDangNhap,
                    NhomNguoiDung = nd.NHOMNGUOIDUNG?.TenNhomNguoiDung ?? "N/A"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditNguoiDungForm(null, nhomNguoiDungList))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = Convert.ToInt32(dgvNguoiDung.SelectedRows[0].Cells["ID"].Value);
            var nguoiDung = nguoiDungBll.GetById(selectedId);

            using (var form = new AddEditNguoiDungForm(nguoiDung, nhomNguoiDungList))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int selectedId = Convert.ToInt32(dgvNguoiDung.SelectedRows[0].Cells["ID"].Value);
                    nguoiDungBll.Delete(selectedId);
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}