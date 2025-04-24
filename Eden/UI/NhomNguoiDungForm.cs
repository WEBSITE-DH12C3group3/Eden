using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Eden.BLLCustom;
using Guna.UI2.WinForms;
using ClosedXML.Excel; // Thêm thư viện ClosedXML
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
            btnExportExcel.Click += new EventHandler(btnExportExcel_Click); // Thêm sự kiện cho btnExportExcel
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
                using (var form = new AddEditNhomNguoiDungForm(null))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
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

                using (var form = new AddEditNhomNguoiDungForm(nhom))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
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
                            // Thêm tiêu đề cột
                            worksheet.Cell(1, 1).Value = "Mã Nhóm Người Dùng";
                            worksheet.Cell(1, 2).Value = "Tên Nhóm Người Dùng";

                            // Lấy dữ liệu (bao gồm cả bộ lọc tìm kiếm, nhưng xuất toàn bộ danh sách)
                            var filteredList = string.IsNullOrEmpty(guna2TextBoxTimKiem.Text.Trim())
                                ? nhomNguoiDungList
                                : nhomNguoiDungList.FindAll(n => n.TenNhomNguoiDung.ToLower().Contains(guna2TextBoxTimKiem.Text.Trim().ToLower()));

                            // Thêm dữ liệu vào Excel
                            for (int i = 0; i < filteredList.Count; i++)
                            {
                                worksheet.Cell(i + 2, 1).Value = filteredList[i].MaNhomNguoiDung;
                                worksheet.Cell(i + 2, 2).Value = filteredList[i].TenNhomNguoiDung;
                            }

                            // Tự động điều chỉnh độ rộng cột
                            worksheet.Columns().AdjustToContents();
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