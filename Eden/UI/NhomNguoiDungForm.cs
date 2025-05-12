using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Eden.BLLCustom;
using Guna.UI2.WinForms;
using ClosedXML.Excel;
using System.IO;
using System.Linq;

namespace Eden
{
    public partial class NhomNguoiDungForm : Form
    {
        private NHOMNGUOIDUNGBLL nhomNguoiDungBll = new NHOMNGUOIDUNGBLL();
        private List<NHOMNGUOIDUNG> nhomNguoiDungList;
        private int currentPage = 1;
        private const int pageSize = 10;

        public NhomNguoiDungForm()
        {
            InitializeComponent();
            guna2TextBoxTimKiem.TextChanged += new EventHandler(guna2TextBoxTimKiem_TextChanged);
            btnNext.Click += new EventHandler(btnNext_Click);
            btnPrevious.Click += new EventHandler(btnPrevious_Click);
            btnExportExcel.Click += new EventHandler(btnExportExcel_Click);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                nhomNguoiDungList = nhomNguoiDungBll.GetAll();
                FilterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterData(string searchText = "", int page = 1)
        {
            try
            {
                dataGridViewNhomNguoiDung.Rows.Clear();
                searchText = searchText.Trim().ToLower();

                var filteredList = string.IsNullOrEmpty(searchText)
                    ? nhomNguoiDungList
                    : nhomNguoiDungList.FindAll(n => n.TenNhomNguoiDung.ToLower().Contains(searchText));

                int totalItems = filteredList.Count;
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                currentPage = Math.Max(1, Math.Min(page, totalPages));

                var pagedList = filteredList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                foreach (var nhom in pagedList)
                {
                    dataGridViewNhomNguoiDung.Rows.Add(nhom.MaNhomNguoiDung, nhom.TenNhomNguoiDung);
                }

                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            FilterData(guna2TextBoxTimKiem.Text);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            FilterData(guna2TextBoxTimKiem.Text, currentPage);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            FilterData(guna2TextBoxTimKiem.Text, currentPage);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new AddEditNhomNguoiDungForm(null);
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
                LoadData();
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

                string maNhom = dataGridViewNhomNguoiDung.SelectedRows[0].Cells["colNhomId"].Value.ToString();
                var nhom = nhomNguoiDungList.Find(n => n.MaNhomNguoiDung == maNhom);
                if (nhom == null)
                {
                    MessageBox.Show("Nhóm không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var form = new AddEditNhomNguoiDungForm(nhom);
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
                LoadData();
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

                string maNhom = dataGridViewNhomNguoiDung.SelectedRows[0].Cells["colNhomId"].Value.ToString();
                var nhom = nhomNguoiDungList.Find(n => n.MaNhomNguoiDung == maNhom);
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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = "DanhSachNhomNguoiDung.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("NhomNguoiDung");

                            // Thêm tiêu đề cửa hàng
                            worksheet.Cell(1, 1).Value = "Cửa Hàng Hoa Tươi EDEN";
                            worksheet.Cell(1, 1).Style.Font.Bold = true;
                            worksheet.Cell(1, 1).Style.Font.FontSize = 18;
                            worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            worksheet.Range(1, 1, 1, 2).Merge();

                            // Tiêu đề chính
                            worksheet.Cell(2, 1).Value = "Danh Sách Nhóm Người Dùng";
                            worksheet.Cell(2, 1).Style.Font.Bold = true;
                            worksheet.Cell(2, 1).Style.Font.FontSize = 16;
                            worksheet.Range(2, 1, 2, 2).Merge();
                            worksheet.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Thông tin người xuất và ngày xuất (căn phải)
                            string userName = CurrentUser.Username ?? "Không xác định";
                            string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            worksheet.Cell(3, 2).Value = $"Người xuất: {userName}";
                            worksheet.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            worksheet.Range(3, 2, 3, 2).Merge();
                            worksheet.Cell(4, 2).Value = $"Ngày xuất: {exportDateTime}";
                            worksheet.Cell(4, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            worksheet.Range(4, 2, 4, 2).Merge();

                            // Tiêu đề cột
                            worksheet.Cell(6, 1).Value = "Mã Nhóm Người Dùng";
                            worksheet.Cell(6, 2).Value = "Tên Nhóm Người Dùng";
                            var headerRange = worksheet.Range(6, 1, 6, 2);
                            headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(146, 208, 80); // Màu xanh nhạt
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // Lấy dữ liệu
                            var filteredList = string.IsNullOrEmpty(guna2TextBoxTimKiem.Text.Trim())
                                ? nhomNguoiDungList
                                : nhomNguoiDungList.FindAll(n => n.TenNhomNguoiDung.ToLower().Contains(guna2TextBoxTimKiem.Text.Trim().ToLower()));

                            // Thêm dữ liệu vào Excel
                            for (int i = 0; i < filteredList.Count; i++)
                            {
                                worksheet.Cell(i + 7, 1).Value = filteredList[i].MaNhomNguoiDung;
                                worksheet.Cell(i + 7, 2).Value = filteredList[i].TenNhomNguoiDung;

                                var rowRange = worksheet.Range(i + 7, 1, i + 7, 2);
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
                            worksheet.Range(lastRow + 2, 1, lastRow + 2, 2).Merge();

                            worksheet.Cell(lastRow + 3, 1).Value = "Sdt: 0909090909";
                            worksheet.Cell(lastRow + 3, 1).Style.Font.Bold = true;
                            worksheet.Cell(lastRow + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            worksheet.Range(lastRow + 3, 1, lastRow + 3, 2).Merge();

                            worksheet.Column(1).Width = 20;
                            worksheet.Column(2).Width = 30;

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