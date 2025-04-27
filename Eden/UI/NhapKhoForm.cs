using System;
using System.Collections.Generic;
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
        private SANPHAMBLL sanPHAMBLL;
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
            sanPHAMBLL = new SANPHAMBLL();
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
            try
            {
                // Lấy danh sách phiếu nhập
                var allPhieuNhap = phieuNhapBLL.GetAll();
                if (allPhieuNhap == null)
                {
                    MessageBox.Show("Danh sách phiếu nhập trả về null. Kiểm tra phương thức GetAll trong PHIEUNHAPBLL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (allPhieuNhap.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phiếu nhập trong cơ sở dữ liệu. Vui lòng thêm phiếu nhập trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Phiếu Nhập");
                dt.Columns.Add("Ngày Nhập");
                dt.Columns.Add("Mã Nhà Cung Cấp");
                dt.Columns.Add("Tên Nhà Cung Cấp");
                dt.Columns.Add("Tên Người Dùng");
                dt.Columns.Add("Tổng Tiền");
                dt.Columns.Add("Mã Sản Phẩm");
                dt.Columns.Add("Tên Sản Phẩm");
                dt.Columns.Add("Số Lượng");
                dt.Columns.Add("Đơn Giá");
                dt.Columns.Add("Thành Tiền");

                foreach (var pn in allPhieuNhap)
                {
                    var chiTietList = phieuNhapBLL.GetChiTietByPhieuNhap(pn.id);
                    if (chiTietList != null && chiTietList.Any())
                    {
                        foreach (var chiTiet in chiTietList)
                        {
                            var sanPham = sanPHAMBLL.GetById(chiTiet.idSanPham);
                            if (sanPham == null)
                            {
                                // Ghi log nếu sản phẩm không tìm thấy
                                System.Diagnostics.Debug.WriteLine($"Sản phẩm với id {chiTiet.idSanPham} không tìm thấy cho phiếu nhập {pn.MaPhieuNhap}.");
                            }
                            dt.Rows.Add(
                                pn.MaPhieuNhap,
                                pn.NgayNhap.ToString("dd/MM/yyyy"),
                                pn.NHACUNGCAP?.MaNhaCungCap ?? "N/A",
                                pn.NHACUNGCAP?.TenNhaCungCap ?? "N/A",
                                pn.NGUOIDUNG?.TenNguoiDung ?? "N/A",
                                pn.TongTien,
                                sanPham?.MaSanPham ?? "N/A",
                                sanPham?.TenSanPham ?? "N/A",
                                chiTiet.SoLuong,
                                chiTiet.DonGia,
                                chiTiet.ThanhTien
                            );
                        }
                    }
                    else
                    {
                        dt.Rows.Add(
                            pn.MaPhieuNhap,
                            pn.NgayNhap.ToString("dd/MM/yyyy"),
                            pn.NHACUNGCAP?.MaNhaCungCap ?? "N/A",
                            pn.NHACUNGCAP?.TenNhaCungCap ?? "N/A",
                            pn.NGUOIDUNG?.TenNguoiDung ?? "N/A",
                            pn.TongTien,
                            "", "", "", "", ""
                        );
                    }
                }

                // Hiển thị SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = $"DanhSachPhieuNhap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("PhieuNhap");

                        ws.Cell(1, 1).Value = "Danh Sách Phiếu Nhập";
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 11).Merge();

                        ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                        ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        ws.Range(2, 1, 2, 11).Merge();

                        var dataRange = ws.Cell(4, 1).InsertTable(dt.AsEnumerable()).AsRange();

                        var headerRow = dataRange.FirstRow();
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        var ngayNhapColumn = ws.Column(2);
                        ngayNhapColumn.Style.DateFormat.Format = "dd/MM/yyyy";

                        ws.Column(9).Style.NumberFormat.Format = "0";
                        ws.Column(10).Style.NumberFormat.Format = "0";
                        ws.Column(11).Style.NumberFormat.Format = "0";
                        ws.Column(6).Style.NumberFormat.Format = "0";

                        var lastRow = dataRange.LastRow().RowNumber();
                        ws.Cell(lastRow + 1, 5).Value = "Tổng cộng:";
                        ws.Cell(lastRow + 1, 6).Value = allPhieuNhap.Sum(pn => pn.TongTien);
                        ws.Cell(lastRow + 1, 5).Style.Font.Bold = true;
                        ws.Cell(lastRow + 1, 6).Style.Font.Bold = true;
                        ws.Cell(lastRow + 1, 6).Style.NumberFormat.Format = "0";

                        ws.Columns().AdjustToContents();

                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2Button btnXemChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPage;
    }
}