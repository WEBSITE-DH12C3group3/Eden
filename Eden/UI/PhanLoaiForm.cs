using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;
using Eden.DTO;
using Eden.UI;

namespace Eden
{
    public partial class PhanLoaiForm : Form
    {
        private LOAISANPHAMBLL loaiSanPhamBLL;
        private int currentPage = 1;
        private int pageSize = 10; // số lượng item mỗi trang
        private int totalPages = 1;

        public PhanLoaiForm()
        {
            InitializeComponent();
            loaiSanPhamBLL = new LOAISANPHAMBLL();
            dgvLoaiSanPham.AutoGenerateColumns = false;
            dgvLoaiSanPham.Columns.Clear();
            dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaLoaiSanPham",
                HeaderText = "Mã Loại Sản Phẩm",
                Name = "MaLoaiSanPham"
            });
            dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenLoaiSanPham",
                HeaderText = "Tên Loại Sản Phẩm",
                Name = "TenLoaiSanPham"
            });
            dgvLoaiSanPham.Columns[0].Width = 200;

            LoadLoaiSanPham();
            ConfigureLoaiSanPhamGridView();
        }

        private void ConfigureLoaiSanPhamGridView()
        {
            dgvLoaiSanPham.AutoGenerateColumns = false;

            if (dgvLoaiSanPham.Columns.Count == 0)
            {
                dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "id", // hoặc MaLoaiSanPham nếu bạn dùng tên khác
                    HeaderText = "ID",
                    Name = "id"
                });

                dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaLoaiSanPham",
                    HeaderText = "Mã Loại",
                    Name = "MaLoaiSanPham"
                });

                dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenLoaiSanPham",
                    HeaderText = "Tên Loại",
                    Name = "TenLoaiSanPham"
                });
            }
        }

        private void LoadLoaiSanPham()
        {
            try
            {
                dgvLoaiSanPham.DataSource = null; // Xóa nguồn dữ liệu cũ
                dgvLoaiSanPham.DataSource = loaiSanPhamBLL.GetAll(); // Load dữ liệu mới từ DB
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int totalRecords = loaiSanPhamBLL.GetTotalCount();
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = loaiSanPhamBLL.GetPagedLoaiSanPham(currentPage, pageSize);
            dgvLoaiSanPham.DataSource = data;

            lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PhanLoaiFormAdd formAdd = new PhanLoaiFormAdd();
            this.Controls.Clear();
            formAdd.TopLevel = false;
            formAdd.FormBorderStyle = FormBorderStyle.None;
            formAdd.Dock = DockStyle.Fill;
            this.Controls.Add(formAdd);
            formAdd.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSanPham.CurrentRow != null)
            {
                string maLSP = dgvLoaiSanPham.CurrentRow.Cells["MaLoaiSanPham"].Value.ToString();
                PhanLoaiFormSua formSua = new PhanLoaiFormSua(maLSP);
                this.Controls.Clear();
                formSua.TopLevel = false;
                formSua.FormBorderStyle = FormBorderStyle.None;
                formSua.Dock = DockStyle.Fill;
                this.Controls.Add(formSua);
                formSua.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSanPham.CurrentRow != null)
            {
                // Lấy giá trị "MaLoaiSanPham" từ cột trong DataGridView
                string maLSP = dgvLoaiSanPham.CurrentRow.Cells["MaLoaiSanPham"].Value.ToString(); // Đảm bảo đúng tên cột
                LOAISANPHAM lsp = new LOAISANPHAM { MaLoaiSanPham = maLSP };

                // Hỏi người dùng có chắc chắn muốn xóa loại sản phẩm này không
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tìm loại sản phẩm trong cơ sở dữ liệu trước khi xóa
                        var existingLSP = loaiSanPhamBLL.GetAll().FirstOrDefault(l => l.MaLoaiSanPham == maLSP);

                        if (existingLSP != null) // Nếu loại sản phẩm tồn tại
                        {
                            // Gọi phương thức Delete để xóa loại sản phẩm
                            loaiSanPhamBLL.Delete(existingLSP);
                            LoadLoaiSanPham(); // Load lại danh sách sau khi xóa
                            MessageBox.Show("Xóa loại sản phẩm thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy loại sản phẩm cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateDataGridView(LOAISANPHAM updatedLSP)
        {
            foreach (DataGridViewRow row in dgvLoaiSanPham.Rows)
            {
                if (row.Cells["MaLoaiSanPham"].Value.ToString() == updatedLSP.MaLoaiSanPham)
                {
                    row.Cells["TenLoaiSanPham"].Value = updatedLSP.TenLoaiSanPham;
                    break;
                }
            }
        }

        private void guna2ButtonTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                var ketQua = loaiSanPhamBLL.TimKiemTheoTen(tuKhoa);
                dgvLoaiSanPham.DataSource = ketQua;
            }
            else
            {
                // Nếu không có từ khóa thì hiển thị toàn bộ
                dgvLoaiSanPham.DataSource = loaiSanPhamBLL.GetAll()
                    .Select(lsp => new LoaiSanPhamDTO
                    {
                        Id = lsp.id,
                        MaLoaiSanPham = lsp.MaLoaiSanPham,
                        TenLoaiSanPham = lsp.TenLoaiSanPham
                    })
                    .ToList();
            }
        }

        private void guna2TextBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                dgvLoaiSanPham.DataSource = loaiSanPhamBLL.TimKiemTheoTen(tuKhoa);
            }
            else
            {
                dgvLoaiSanPham.DataSource = loaiSanPhamBLL.GetAll();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadLoaiSanPham();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadLoaiSanPham();
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ DataGridView
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvLoaiSanPham.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dgvLoaiSanPham.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgvLoaiSanPham.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value?.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Lưu Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "DanhSach.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "DanhSach");
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.Trim();
            var ketQua = loaiSanPhamBLL.TimKiemTheoTen(tuKhoa);
            dgvLoaiSanPham.DataSource = ketQua;
        }
    }
}