using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Eden.DALCustom;
using Eden.BLLCustom;
using ClosedXML.Excel;
using System.IO;

namespace Eden
{
    public partial class NguoiDungForm : Form
    {
        private NGUOIDUNGBLL nguoiDungBll = new NGUOIDUNGBLL();
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;
        private int currentPage = 1;
        private const int pageSize = 10;

        public NguoiDungForm()
        {
            var nhomNguoiDungDal = new NHOMNGUOIDUNGDAL();
            this.nhomNguoiDungList = nhomNguoiDungDal.GetAll();
            InitializeComponent();
            dgvNguoiDung.AutoGenerateColumns = false;
            dgvNguoiDung.Columns.Clear();
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNguoiDung",
                HeaderText = "Mã Người Dùng",
                Name = "MaNguoiDung"
            });
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNguoiDung",
                HeaderText = "Tên Người Dùng",
                Name = "TenNguoiDung"
            });
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên Đăng Nhập",
                Name = "TenDangNhap"
            });
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NhomNguoiDung",
                HeaderText = "Nhóm Người Dùng",
                Name = "NhomNguoiDung"
            });

            LoadData();
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            btnNext.Click += new EventHandler(btnNext_Click);
            btnPrevious.Click += new EventHandler(btnPrevious_Click);
            btnExportExcel.Click += new EventHandler(btnExportExcel_Click);
        }

        public NguoiDungForm(List<NHOMNGUOIDUNG> nhomNguoiDungList)
        {
            this.nhomNguoiDungList = nhomNguoiDungList;
            InitializeComponent();
            LoadData();
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            btnNext.Click += new EventHandler(btnNext_Click);
            btnPrevious.Click += new EventHandler(btnPrevious_Click);
            btnExportExcel.Click += new EventHandler(btnExportExcel_Click);
        }

        private void LoadData(string searchTerm = "", int page = 1)
        {
            try
            {
                var nguoiDungList = nguoiDungBll.GetAll();
                var filteredList = nguoiDungList
                    .Where(nd => string.IsNullOrEmpty(searchTerm) ||
                                nd.TenNguoiDung.ToLower().Contains(searchTerm.ToLower()) ||
                                nd.MaNguoiDung.ToLower().Contains(searchTerm.ToLower()) ||
                                nd.TenDangNhap.ToLower().Contains(searchTerm.ToLower()))
                    .ToList();

                int totalItems = filteredList.Count;
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                currentPage = Math.Max(1, Math.Min(page, totalPages));

                var pagedList = filteredList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .Select(nd => new
                    {
                        MaNguoiDung = nd.MaNguoiDung,
                        TenNguoiDung = nd.TenNguoiDung,
                        TenDangNhap = nd.TenDangNhap,
                        NhomNguoiDung = nd.NHOMNGUOIDUNG?.TenNhomNguoiDung ?? "N/A"
                    })
                    .ToList();

                dgvNguoiDung.DataSource = pagedList;
                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData(txtSearch.Text.Trim(), currentPage);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadData(txtSearch.Text.Trim(), currentPage);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadData(txtSearch.Text.Trim(), currentPage);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddEditNguoiDungForm(null, nhomNguoiDungList);
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedMaNguoiDung = dgvNguoiDung.SelectedRows[0].Cells["MaNguoiDung"].Value.ToString();
            var nguoiDungList = nguoiDungBll.GetAll();
            var nguoiDung = nguoiDungList.FirstOrDefault(nd => nd.MaNguoiDung == selectedMaNguoiDung);

            if (nguoiDung == null)
            {
                MessageBox.Show("Không tìm thấy người dùng với mã này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new AddEditNguoiDungForm(nguoiDung, nhomNguoiDungList);

            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
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
                    string selectedMaNguoiDung = dgvNguoiDung.SelectedRows[0].Cells["MaNguoiDung"].Value.ToString();
                    var nguoiDungList = nguoiDungBll.GetAll();
                    var nguoiDung = nguoiDungList.FirstOrDefault(nd => nd.MaNguoiDung == selectedMaNguoiDung);

                    if (nguoiDung == null)
                    {
                        MessageBox.Show("Không tìm thấy người dùng với mã này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    nguoiDungBll.Delete(nguoiDung.id);
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(txtSearch.Text.Trim(), currentPage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }
    }
}