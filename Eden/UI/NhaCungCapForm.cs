﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Eden.UI;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NhaCungCapForm : Form
    {
        private NHACUNGCAPBLL nhaCungCapBLL;
        private NHACUNGCAPDAL nhaCungCapDAL;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private string searchTerm = "";

        public NhaCungCapForm()
        {
            InitializeComponent();
            nhaCungCapBLL = new NHACUNGCAPBLL();
            nhaCungCapDAL = new NHACUNGCAPDAL();
            LoadData();
        }

        public List<NHACUNGCAP> GetAll()
        {
            using (var db = new QLBanHoaEntities())
            {
                var list = db.NHACUNGCAPs.ToList();
                Console.WriteLine($"Số nhà cung cấp: {list.Count}");
                return list;
            }
        }

        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu phân trang
                var nhaCungCapList = nhaCungCapDAL.GetPagedNhaCungCap(currentPage, pageSize, out totalRecords, searchTerm);

                // Tính tổng số trang
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (totalPages == 0) totalPages = 1;

                // Gán dữ liệu cho DataGridView
                guna2DataGridViewNCC.DataSource = nhaCungCapList.Select(n => new
                {
                    n.MaNhaCungCap,
                    n.TenNhaCungCap,
                    n.DiaChi,
                    n.SoDienThoai,
                    n.Email
                }).ToList();

                // Cập nhật tiêu đề cột
                guna2DataGridViewNCC.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
                guna2DataGridViewNCC.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
                guna2DataGridViewNCC.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                guna2DataGridViewNCC.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                guna2DataGridViewNCC.Columns["Email"].HeaderText = "Email";

                // Cập nhật label trang
                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

                // Cập nhật trạng thái nút
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
            searchTerm = txtSearch.Text.Trim();
            currentPage = 1;
            LoadData();
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
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NhaCungCapFormAdd formAdd = new NhaCungCapFormAdd();
            this.Controls.Clear();
            formAdd.TopLevel = false;
            formAdd.FormBorderStyle = FormBorderStyle.None;
            formAdd.Dock = DockStyle.Fill;
            this.Controls.Add(formAdd);
            formAdd.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridViewNCC.CurrentRow != null)
            {
                string maNCC = guna2DataGridViewNCC.CurrentRow.Cells["MaNhaCungCap"].Value?.ToString();
                if (string.IsNullOrEmpty(maNCC))
                {
                    MessageBox.Show("Mã nhà cung cấp không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NhaCungCapFormSua form = new NhaCungCapFormSua(maNCC);
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridViewNCC.CurrentRow != null)
            {
                string maNCC = guna2DataGridViewNCC.CurrentRow.Cells["MaNhaCungCap"].Value?.ToString();
                if (string.IsNullOrEmpty(maNCC))
                {
                    MessageBox.Show("Mã nhà cung cấp không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Console.WriteLine($"MaNCC được chọn: {maNCC}");
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhà cung cấp với mã {maNCC}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var existingNCC = nhaCungCapBLL.GetAll().FirstOrDefault(n => n.MaNhaCungCap == maNCC);
                        if (existingNCC != null)
                        {
                            Console.WriteLine($"Đang xóa nhà cung cấp: {maNCC}");
                            nhaCungCapBLL.Delete(existingNCC);
                            LoadData();
                            MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy nhà cung cấp với mã {maNCC}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa nhà cung cấp: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in guna2DataGridViewNCC.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in guna2DataGridViewNCC.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < guna2DataGridViewNCC.Columns.Count; i++)
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
                FileName = $"DanhSachNhaCungCap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("NhaCungCap");

                    ws.Cell(1, 1).Value = "Danh Sách Nhà Cung Cấp";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 16;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, 5).Merge();

                    ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range(2, 1, 2, 5).Merge();

                    var dataRange = ws.Cell(4, 1).InsertTable(dt.AsEnumerable()).AsRange();

                    var headerRow = dataRange.FirstRow();
                    headerRow.Style.Font.Bold = true;
                    headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Đặt màu chữ của dữ liệu về màu đen
                    dataRange.Rows().Style.Font.FontColor = XLColor.Black;

                    var lastRow = dataRange.LastRow().RowNumber();
                    ws.Cell(lastRow + 1, 1).Value = "Tổng số nhà cung cấp:";
                    ws.Cell(lastRow + 1, 2).Value = dt.Rows.Count;
                    ws.Cell(lastRow + 1, 1).Style.Font.Bold = true;
                    ws.Cell(lastRow + 1, 2).Style.Font.Bold = true;

                    ws.Columns().AdjustToContents();

                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}