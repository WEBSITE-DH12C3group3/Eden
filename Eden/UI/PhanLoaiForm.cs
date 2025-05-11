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

            // Thêm cột ID nếu chưa tồn tại
            if (!dgvLoaiSanPham.Columns.Contains("Id"))
            {
                dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Id",
                    HeaderText = "ID",
                    Name = "Id",
                    Visible = false // Ẩn cột ID nếu không cần hiển thị
                });
            }

            // Đảm bảo cột Mã Loại Sản Phẩm và Tên Loại Sản Phẩm đã tồn tại
            if (!dgvLoaiSanPham.Columns.Contains("MaLoaiSanPham"))
            {
                dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaLoaiSanPham",
                    HeaderText = "Mã Loại Sản Phẩm",
                    Name = "MaLoaiSanPham"
                });
            }

            if (!dgvLoaiSanPham.Columns.Contains("TenLoaiSanPham"))
            {
                dgvLoaiSanPham.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenLoaiSanPham",
                    HeaderText = "Tên Loại Sản Phẩm",
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
            // using (PhanLoaiFormAdd formAdd = new PhanLoaiFormAdd())
            // {
            //     formAdd.ShowDialog();
            //     LoadLoaiSanPham(); // Cập nhật danh sách sau khi thêm
            // }
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
            try
            {
                // Kiểm tra dữ liệu
                if (dgvLoaiSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy tên người dùng
                string userName = CurrentUser.Username;
                if (string.IsNullOrEmpty(userName))
                {
                    userName = Environment.UserName;
                    MessageBox.Show($"Không tìm thấy thông tin người dùng. Sử dụng tên hệ thống: {userName}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Hộp thoại lưu file
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                    saveFileDialog.Title = "Lưu file Excel";
                    saveFileDialog.FileName = $"DanhSachPhanLoai_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("LoaiSanPham");
                            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
                            ws.PageSetup.Margins.Left = 0.5;
                            ws.PageSetup.Margins.Right = 0.5;
                            ws.PageSetup.Margins.Top = 0.75;
                            ws.PageSetup.Margins.Bottom = 0.75;
                            ws.PageSetup.CenterHorizontally = true;
                            ws.PageSetup.PageOrientation = XLPageOrientation.Portrait;

                            // Tiêu đề cửa hàng
                            ws.Cell(1, 1).Value = "Cửa Hàng Hoa Tươi EDEN";
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 18;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            ws.Range(1, 1, 1, 6).Merge();

                            // Tiêu đề bảng
                            ws.Cell(2, 1).Value = "Danh Sách Phân Loại";
                            ws.Cell(2, 1).Style.Font.Bold = true;
                            ws.Cell(2, 1).Style.Font.FontSize = 16;
                            ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Range(2, 1, 2, 6).Merge();

                            // Người xuất và ngày xuất
                            ws.Cell(3, 5).Value = $"Người xuất: {userName}";
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            ws.Cell(3, 5).Style.Font.Bold = true;
                            ws.Range(3, 5, 3, 6).Merge();

                            ws.Cell(4, 5).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                            ws.Cell(4, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            ws.Cell(4, 5).Style.Font.Bold = true;
                            ws.Range(4, 5, 4, 6).Merge();

                            // Dữ liệu từ DataGridView
                            DataTable dt = new DataTable();
                            foreach (DataGridViewColumn column in dgvLoaiSanPham.Columns)
                            {
                                if (column.Visible)
                                    dt.Columns.Add(column.HeaderText, typeof(string));
                            }

                            foreach (DataGridViewRow row in dgvLoaiSanPham.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    DataRow dr = dt.NewRow();
                                    for (int i = 0; i < dgvLoaiSanPham.Columns.Count; i++)
                                    {
                                        if (dgvLoaiSanPham.Columns[i].Visible)
                                            dr[i] = row.Cells[i].Value?.ToString();
                                    }
                                    dt.Rows.Add(dr);
                                }
                            }

                            var dataRange = ws.Cell(6, 1).InsertTable(dt.AsEnumerable()).AsRange();
                            var headerRow = dataRange.FirstRow();
                            headerRow.Style.Font.Bold = true;
                            headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Tự động chỉnh cột
                            ws.Columns().AdjustToContents();

                            // Đường viền
                            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // Lưu file
                            wb.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.Trim();
            var ketQua = loaiSanPhamBLL.TimKiemTheoTen(tuKhoa);
            dgvLoaiSanPham.DataSource = ketQua;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadLoaiSanPham();
        }

        private void dgvLoaiSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idLoaiSanPham = (int)dgvLoaiSanPham.Rows[e.RowIndex].Cells["Id"].Value;
                PhanLoaiFormListSP formListSP = new PhanLoaiFormListSP(idLoaiSanPham);
                this.Controls.Clear();
                formListSP.TopLevel = false;
                formListSP.FormBorderStyle = FormBorderStyle.None;
                formListSP.Dock = DockStyle.Fill;
                this.Controls.Add(formListSP);
                formListSP.Show();
            }
        }
    }
}