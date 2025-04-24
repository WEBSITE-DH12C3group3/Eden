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
            using (var form = new AddEditNguoiDungForm(null, nhomNguoiDungList))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text.Trim(), currentPage);
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

            string selectedMaNguoiDung = dgvNguoiDung.SelectedRows[0].Cells["MaNguoiDung"].Value.ToString();
            var nguoiDungList = nguoiDungBll.GetAll();
            var nguoiDung = nguoiDungList.FirstOrDefault(nd => nd.MaNguoiDung == selectedMaNguoiDung);

            if (nguoiDung == null)
            {
                MessageBox.Show("Không tìm thấy người dùng với mã này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var form = new AddEditNguoiDungForm(nguoiDung, nhomNguoiDungList))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData(txtSearch.Text.Trim(), currentPage);
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

                            // Tiêu đề chính
                            worksheet.Cell(1, 1).Value = "Danh Sách Người Dùng";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                            worksheet.Range(1, 1, 1, 4).Merge();
                            worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Thông tin người xuất và ngày xuất (căn phải)
                            string userName = CurrentUser.Username ?? "Không xác định";
                            string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            worksheet.Cell(2, 4).Value = $"Người xuất: {userName}";
                            worksheet.Cell(2, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            worksheet.Cell(3, 4).Value = $"Ngày xuất: {exportDateTime}";
                            worksheet.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            // Tiêu đề cột
                            worksheet.Cell(5, 1).Value = "Mã Người Dùng";
                            worksheet.Cell(5, 2).Value = "Tên Người Dùng";
                            worksheet.Cell(5, 3).Value = "Tên Đăng Nhập";
                            worksheet.Cell(5, 4).Value = "Nhóm Người Dùng";
                            var headerRange = worksheet.Range(5, 1, 5, 4);
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
                                            nd.TenDangNhap.ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                                .ToList();

                            // Thêm dữ liệu vào Excel
                            for (int i = 0; i < filteredList.Count; i++)
                            {
                                worksheet.Cell(i + 6, 1).Value = filteredList[i].MaNguoiDung;
                                worksheet.Cell(i + 6, 2).Value = filteredList[i].TenNguoiDung;
                                worksheet.Cell(i + 6, 3).Value = filteredList[i].TenDangNhap;
                                worksheet.Cell(i + 6, 4).Value = filteredList[i].NHOMNGUOIDUNG?.TenNhomNguoiDung ?? "N/A";

                                var rowRange = worksheet.Range(i + 6, 1, i + 6, 4);
                                rowRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                rowRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                rowRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                                if (i % 2 == 0)
                                {
                                    rowRange.Style.Fill.BackgroundColor = XLColor.FromArgb(216, 228, 188);
                                }
                            }

                            worksheet.Column(1).Width = 15;
                            worksheet.Column(2).Width = 25;
                            worksheet.Column(3).Width = 20;
                            worksheet.Column(4).Width = 25;

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

    }
}