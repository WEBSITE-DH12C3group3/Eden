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
            // Thêm các cột mới
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNhanVien",
                HeaderText = "Mã Nhân Viên",
                Name = "MaNhanVien"
            });
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CaLamViec",
                HeaderText = "Ca Làm Việc",
                Name = "CaLamViec"
            });
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LuongCoDinh",
                HeaderText = "Lương Cố Định",
                Name = "LuongCoDinh"
            });
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayBatDauLam",
                HeaderText = "Ngày Bắt Đầu Làm",
                Name = "NgayBatDauLam"
            });
            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng Thái",
                Name = "TrangThai"
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
                                nd.TenDangNhap.ToLower().Contains(searchTerm.ToLower()) ||
                                nd.MaNhanVien.ToLower().Contains(searchTerm.ToLower()) || // Thêm tìm kiếm theo MaNhanVien
                                (nd.CaLamViec != null && nd.CaLamViec.ToLower().Contains(searchTerm.ToLower())) ||
                                (nd.TrangThai != null && nd.TrangThai.ToLower().Contains(searchTerm.ToLower())))
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
                        NhomNguoiDung = nd.NHOMNGUOIDUNG?.TenNhomNguoiDung ?? "N/A",
                        MaNhanVien = nd.MaNhanVien, // Thêm trường mới
                        CaLamViec = nd.CaLamViec, // Thêm trường mới
                        LuongCoDinh = nd.LuongCoDinh, // Thêm trường mới
                        NgayBatDauLam = nd.NgayBatDauLam?.ToString("dd/MM/yyyy"), // Thêm trường mới, định dạng ngày
                        TrangThai = nd.TrangThai // Thêm trường mới
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
            LoadData(txtSearch.Text.Trim(), currentPage); // Refresh data after form interaction
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
            LoadData(txtSearch.Text.Trim(), currentPage); // Refresh data after form interaction
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
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = "DanhSachNguoiDung.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("NguoiDung");

                            // Thêm tiêu đề cửa hàng
                            worksheet.Cell(1, 1).Value = "Cửa Hàng Hoa Tươi EDEN";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 18;
                            worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            worksheet.Range(1, 1, 1, 9).Merge(); // Cập nhật merge để phù hợp số cột mới

                            // Tiêu đề chính
                            worksheet.Cell(2, 1).Value = "Danh Sách Người Dùng";
                            worksheet.Cell(2, 1).Style.Font.Bold = true;
                            worksheet.Cell(2, 1).Style.Font.FontSize = 16;
                            worksheet.Range(2, 1, 2, 9).Merge();
                            worksheet.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Thông tin người xuất và ngày xuất (căn phải)
                            string userName = CurrentUser.Username ?? "Không xác định";
                            string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            worksheet.Cell(3, 9).Value = $"Người xuất: {userName}";
                            worksheet.Cell(3, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            worksheet.Range(3, 9, 3, 9).Merge();
                            worksheet.Cell(4, 9).Value = $"Ngày xuất: {exportDateTime}";
                            worksheet.Cell(4, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            worksheet.Range(4, 9, 4, 9).Merge();

                            // Tiêu đề cột
                            worksheet.Cell(6, 1).Value = "Mã Người Dùng";
                            worksheet.Cell(6, 2).Value = "Tên Người Dùng";
                            worksheet.Cell(6, 3).Value = "Tên Đăng Nhập";
                            worksheet.Cell(6, 4).Value = "Nhóm Người Dùng";
                            worksheet.Cell(6, 5).Value = "Mã Nhân Viên";
                            worksheet.Cell(6, 6).Value = "Ca Làm Việc";
                            worksheet.Cell(6, 7).Value = "Lương Cố Định";
                            worksheet.Cell(6, 8).Value = "Ngày Bắt Đầu Làm";
                            worksheet.Cell(6, 9).Value = "Trạng Thái";
                            var headerRange = worksheet.Range(6, 1, 6, 9);
                            headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(146, 208, 80); // Màu xanh nhạt
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // Lấy dữ liệu
                            var nguoiDungList = nguoiDungBll.GetAll();
                            var filteredList = nguoiDungList
                                .Where(nd => string.IsNullOrEmpty(txtSearch.Text.Trim()) ||
                                            nd.TenNguoiDung.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                                            nd.MaNguoiDung.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                                            nd.TenDangNhap.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                                            nd.MaNhanVien.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                                            (nd.CaLamViec != null && nd.CaLamViec.ToLower().Contains(txtSearch.Text.Trim().ToLower())) ||
                                            (nd.TrangThai != null && nd.TrangThai.ToLower().Contains(txtSearch.Text.Trim().ToLower())))
                                .ToList();

                            // Thêm dữ liệu vào Excel
                            for (int i = 0; i < filteredList.Count; i++)
                            {
                                worksheet.Cell(i + 7, 1).Value = filteredList[i].MaNguoiDung;
                                worksheet.Cell(i + 7, 2).Value = filteredList[i].TenNguoiDung;
                                worksheet.Cell(i + 7, 3).Value = filteredList[i].TenDangNhap;
                                worksheet.Cell(i + 7, 4).Value = filteredList[i].NHOMNGUOIDUNG?.TenNhomNguoiDung ?? "N/A";
                                worksheet.Cell(i + 7, 5).Value = filteredList[i].MaNhanVien;
                                worksheet.Cell(i + 7, 6).Value = filteredList[i].CaLamViec;
                                worksheet.Cell(i + 7, 7).Value = filteredList[i].LuongCoDinh;
                                worksheet.Cell(i + 7, 8).Value = filteredList[i].NgayBatDauLam?.ToString("dd/MM/yyyy");
                                worksheet.Cell(i + 7, 9).Value = filteredList[i].TrangThai;

                                var rowRange = worksheet.Range(i + 7, 1, i + 7, 9);
                                rowRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                rowRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                rowRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                                if (i % 2 == 0)
                                {
                                    rowRange.Style.Fill.BackgroundColor = XLColor.FromArgb(216, 228, 188);
                                }
                            }

                            // Thêm thông tin cửa hàng ở dưới cùng
                            int lastRow = filteredList.Count + 6;
                            worksheet.Cell(lastRow + 2, 1).Value = "Địa chỉ: Cây nhà lá vườn";
                            worksheet.Cell(lastRow + 2, 1).Style.Font.Bold = true;
                            worksheet.Cell(lastRow + 2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            worksheet.Range(lastRow + 2, 1, lastRow + 2, 9).Merge();

                            worksheet.Cell(lastRow + 3, 1).Value = "Sdt: 0909090909";
                            worksheet.Cell(lastRow + 3, 1).Style.Font.Bold = true;
                            worksheet.Cell(lastRow + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            worksheet.Range(lastRow + 3, 1, lastRow + 3, 9).Merge();

                            // Điều chỉnh độ rộng cột
                            worksheet.Column(1).Width = 15; // MaNguoiDung
                            worksheet.Column(2).Width = 25; // TenNguoiDung
                            worksheet.Column(3).Width = 20; // TenDangNhap
                            worksheet.Column(4).Width = 25; // NhomNguoiDung
                            worksheet.Column(5).Width = 15; // MaNhanVien
                            worksheet.Column(6).Width = 20; // CaLamViec
                            worksheet.Column(7).Width = 15; // LuongCoDinh
                            worksheet.Column(8).Width = 20; // NgayBatDauLam
                            worksheet.Column(9).Width = 15; // TrangThai

                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }
    }
}