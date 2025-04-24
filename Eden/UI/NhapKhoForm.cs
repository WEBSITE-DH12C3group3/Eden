using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using Eden.UI;

namespace Eden
{
    public partial class NhapKhoForm : Form
    {
        private PHIEUNHAPBLL phieuNhapBLL;
        private PHIEUNHAPDAL phieuNhapDAL;
        private CHITIETPHIEUNHAPBLL chiTietPhieuNhapBLL;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private string searchTerm = "";

        public NhapKhoForm()
        {
            InitializeComponent();
            phieuNhapBLL = new PHIEUNHAPBLL();
            phieuNhapDAL = new PHIEUNHAPDAL();
            chiTietPhieuNhapBLL = new CHITIETPHIEUNHAPBLL();
            LoadData();
        }

       private void LoadData(string searchTerm = "")
        {
            try
            {
                // Lấy dữ liệu phân trang
                var phieuNhapList = phieuNhapDAL.GetPagedPhieuNhap(currentPage, pageSize, out totalRecords, searchTerm);

                // Tính tổng số trang
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (totalPages == 0) totalPages = 1;

                // Gán dữ liệu cho DataGridView
                dgvPhieuNhap.DataSource = phieuNhapList.Select(p => new
                {
                    p.MaPhieuNhap,
                    NgayNhap = p.NgayNhap.ToString("dd/MM/yyyy"),
                    TenNhaCungCap = p.NHACUNGCAP != null ? p.NHACUNGCAP.TenNhaCungCap : "N/A",
                    p.TongTien
                }).ToList();

                // Cập nhật tiêu đề cột
                dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
                dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvPhieuNhap.Columns["TenNhaCungCap"].HeaderText = "Nhà Cung Cấp";
                dgvPhieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";

                // Cập nhật label trang
                lblPage.Text = $"Trang {currentPage}/{totalPages}";

                // Cập nhật trạng thái nút
                btnPrev.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTerm = txtSearch.Text.Trim();
            currentPage = 1;
            LoadData(searchTerm);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchTerm = txtSearch.Text.Trim();
            currentPage = 1;
            LoadData(searchTerm);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            searchTerm = "";
            txtSearch.Text = "";
            currentPage = 1;
            LoadData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData(searchTerm);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData(searchTerm);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var formAdd = new NhapKhoFormAdd())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadData(searchTerm);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieuNhap = dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value?.ToString();
            if (string.IsNullOrEmpty(maPhieuNhap))
            {
                MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var formAdd = new NhapKhoFormAdd(maPhieuNhap))
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadData(searchTerm);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieuNhap = dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value?.ToString();
            if (string.IsNullOrEmpty(maPhieuNhap))
            {
                MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PHIEUNHAP phieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
            if (phieuNhap == null)
            {
                MessageBox.Show("Phiếu nhập không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu nhập này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = phieuNhapBLL.Delete(phieuNhap);
                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(searchTerm);
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgvPhieuNhap.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dgvPhieuNhap.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgvPhieuNhap.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value?.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "DanhSachPhieuNhap.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "PhieuNhap");
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null)
            {
                var maPhieuNhapCell = dgvPhieuNhap.CurrentRow.Cells["MaPhieuNhap"].Value;
                if (maPhieuNhapCell != null)
                {
                    string maPhieuNhap = maPhieuNhapCell.ToString();
                    try
                    {
                        var form = new CHITIETPHIEUNHAPFORM(maPhieuNhap);
                        form.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi mở chi tiết phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Guna.UI2.WinForms.Guna2DataGridView dgvPhieuNhap;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2Button btnXemChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
    }
}