using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden.UI;
using Guna.UI2.WinForms;
using Eden.DTO;

namespace Eden
{
    public partial class HoaDonForm : Form
    {
        private HOADONBLL hoaDonBLL = new HOADONBLL();
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 10; // Số bản ghi trên mỗi trang
        private int totalPages = 1; // Tổng số trang
        private string currentSearchText = ""; // Lưu từ khóa tìm kiếm hiện tại
        private decimal? minPrice = null; // Giá tối thiểu
        private decimal? maxPrice = null; // Giá tối đa
        private DateTime? startDate = null; // Ngày bắt đầu
        private DateTime? endDate = null; // Ngày kết thúc

        public HoaDonForm()
        {
            InitializeComponent();
            dghoadon.AutoGenerateColumns = false;
            dghoadon.Columns.Clear();
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaHoaDon",
                HeaderText = "Mã hóa đơn",
                Name = "MaHoaDon"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayLap",
                HeaderText = "Ngày Lập"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaKhachHang",
                HeaderText = "Mã khách hàng"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenKhachHang",
                HeaderText = "Tên khách hàng"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNguoiDung",
                HeaderText = "Tên người dùng"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongTien",
                HeaderText = "Tổng tiền"
            });

            // Cấu hình ComboBox để hiển thị các lựa chọn
            cbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterType.Items.Clear(); // Xóa các mục cũ (nếu có)
            cbFilterType.Items.AddRange(new string[] { "Tất cả", "Theo giá", "Theo ngày" });
            cbFilterType.SelectedIndex = 0; // Chọn mặc định là "Tất cả"

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DisplayPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPage(int page)
        {
            try
            {
                currentPage = page;
                var result = hoaDonBLL.SearchAndPage(currentSearchText, currentPage, pageSize, minPrice, maxPrice, startDate, endDate);
                var pageData = result.Data;
                int totalRecords = result.TotalRecords;

                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (totalPages == 0) totalPages = 1;

                if (currentPage > totalPages) currentPage = totalPages;
                if (currentPage < 1) currentPage = 1;

                dghoadon.DataSource = null;
                dghoadon.DataSource = pageData;

                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";
                btnPreviousPage.Enabled = currentPage > 1;
                btnNextPage.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudMinPrice.Visible = false;
            nudMaxPrice.Visible = false;
            dtpStartDate.Visible = false;
            dtpEndDate.Visible = false;
            btnApplyFilter.Visible = false;
            guna2Button1.Visible = false;

            switch (cbFilterType.SelectedIndex)
            {
                case 1: // Theo giá
                    nudMinPrice.Visible = true;
                    nudMaxPrice.Visible = true;
                    btnApplyFilter.Visible = true;
                    guna2Button1.Visible = true;
                    break;
                case 2: // Theo ngày
                    dtpStartDate.Visible = true;
                    dtpEndDate.Visible = true;
                    btnApplyFilter.Visible = true;
                    guna2Button1.Visible = true;
                    break;
                case 0: // Tất cả
                default:
                    minPrice = null;
                    maxPrice = null;
                    startDate = null;
                    endDate = null;
                    DisplayPage(1);
                    break;
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbFilterType.SelectedIndex == 1) // Theo giá
                {
                    minPrice = nudMinPrice.Value > 0 ? nudMinPrice.Value : (decimal?)null;
                    maxPrice = nudMaxPrice.Value > 0 ? nudMaxPrice.Value : (decimal?)null;
                    startDate = null;
                    endDate = null;

                    if (minPrice.HasValue && maxPrice.HasValue && minPrice > maxPrice)
                    {
                        MessageBox.Show("Giá tối thiểu không được lớn hơn giá tối đa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (cbFilterType.SelectedIndex == 2) // Theo ngày
                {
                    minPrice = null;
                    maxPrice = null;
                    startDate = dtpStartDate.Value.Date;
                    endDate = dtpEndDate.Value.Date;

                    if (startDate > endDate)
                    {
                        MessageBox.Show("Ngày bắt đầu không được sau ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DisplayPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            try
            {
                minPrice = null;
                maxPrice = null;
                startDate = null;
                endDate = null;

                nudMinPrice.Value = 0;
                nudMaxPrice.Value = 0;
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Today;

                cbFilterType.SelectedIndex = 0;
                DisplayPage(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt lại bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = search.Text.Trim().ToLower();
                if (searchText != "nhập mã hóa đơn hoặc mã khách hàng")
                {
                    currentSearchText = searchText;
                    DisplayPage(1);
                }
                else
                {
                    currentSearchText = "";
                    DisplayPage(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_Enter(object sender, EventArgs e)
        {
            if (search.Text == "Nhập mã hóa đơn hoặc mã khách hàng")
            {
                search.Text = "";
            }
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                search.Text = "Nhập mã hóa đơn hoặc mã khách hàng";
            }
        }

        private void searchHD_Click(object sender, EventArgs e)
        {
            search_TextChanged(sender, e);
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                DisplayPage(currentPage - 1);
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                DisplayPage(currentPage + 1);
            }
        }

        private void addhoadon_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new HoaDonAdd())
                {
                    form.FormClosed += (s, args) => LoadData();
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thêm hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoahoadon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dghoadon.CurrentRow != null)
                {
                    string maHD = dghoadon.CurrentRow.Cells["MaHoaDon"].Value?.ToString();
                    if (string.IsNullOrEmpty(maHD))
                    {
                        MessageBox.Show("Mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    HOADON hd = new HOADON { MaHoaDon = maHD };
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        hoaDonBLL.Delete(hd);
                        LoadData();
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xemct_Click(object sender, EventArgs e)
        {
            try
            {
                if (dghoadon.CurrentRow != null)
                {
                    string maHoaDon = dghoadon.CurrentRow.Cells["MaHoaDon"].Value?.ToString();
                    if (string.IsNullOrEmpty(maHoaDon))
                    {
                        MessageBox.Show("Mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (int.TryParse(maHoaDon.Replace("HD", ""), out int idHoaDon))
                    {
                        using (var form = new HoaDonChiTiet(idHoaDon))
                        {
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Định dạng mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                List<HoaDonDTO> allHoaDon = hoaDonBLL.GetAll();
                if (allHoaDon == null || allHoaDon.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string userName = CurrentUser.Username;
                if (string.IsNullOrEmpty(userName))
                {
                    userName = Environment.UserName;
                    MessageBox.Show($"Không tìm thấy thông tin người dùng. Sử dụng tên hệ thống: {userName}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Diagnostics.Debug.WriteLine($"[HoaDonForm] Xuất Excel: CurrentUser.Username is null, sử dụng {userName} at {DateTime.Now}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[HoaDonForm] Xuất Excel: CurrentUser.Username = {userName} at {DateTime.Now}");
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                    saveFileDialog.Title = "Lưu file Excel";
                    saveFileDialog.FileName = $"DanhSachHoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("HoaDon");
                            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
                            ws.PageSetup.Margins.Left = 0.5;
                            ws.PageSetup.Margins.Right = 0.5;
                            ws.PageSetup.Margins.Top = 0.75;
                            ws.PageSetup.Margins.Bottom = 0.75;
                            ws.PageSetup.CenterHorizontally = true;
                            ws.PageSetup.PageOrientation = XLPageOrientation.Portrait;

                            ws.Cell(1, 1).Value = "Cửa Hàng Hoa Tươi EDEN";
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 18;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            ws.Range(1, 1, 1, 6).Merge();

                            ws.Cell(2, 1).Value = "Danh Sách Hóa Đơn";
                            ws.Cell(2, 1).Style.Font.Bold = true;
                            ws.Cell(2, 1).Style.Font.FontSize = 16;
                            ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Range(2, 1, 2, 6).Merge();

                            string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            ws.Cell(3, 5).Value = $"Người xuất: {userName}";
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            ws.Cell(3, 5).Style.Font.Bold = true;
                            ws.Range(3, 5, 3, 6).Merge();
                            ws.Cell(4, 5).Value = $"Ngày xuất: {exportDateTime}";
                            ws.Cell(4, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            ws.Cell(4, 5).Style.Font.Bold = true;
                            ws.Range(4, 5, 4, 6).Merge();

                            DataTable dt = new DataTable();
                            dt.Columns.Add("Mã Hóa Đơn");
                            dt.Columns.Add("Ngày Lập");
                            dt.Columns.Add("Mã Khách Hàng");
                            dt.Columns.Add("Tên Khách Hàng");
                            dt.Columns.Add("Tên Người Dùng");
                            dt.Columns.Add("Tổng Tiền");

                            foreach (var hd in allHoaDon)
                            {
                                dt.Rows.Add(
                                    hd.MaHoaDon,
                                    hd.NgayLap.ToString("dd/MM/yyyy"),
                                    hd.MaKhachHang,
                                    hd.TenKhachHang,
                                    hd.TenNguoiDung,
                                    hd.TongTien
                                );
                            }

                            var dataRange = ws.Cell(6, 1).InsertTable(dt.AsEnumerable()).AsRange();
                            var headerRow = dataRange.FirstRow();
                            headerRow.Style.Font.Bold = true;
                            headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Column(2).Style.DateFormat.Format = "dd/MM/yyyy";
                            ws.Column(6).Style.NumberFormat.Format = "#,##0";

                            var lastRow = dataRange.LastRow().RowNumber();
                            ws.Cell(lastRow + 1, 5).Value = "Tổng cộng:";
                            ws.Cell(lastRow + 1, 6).Value = allHoaDon.Sum(hd => hd.TongTien);
                            ws.Cell(lastRow + 1, 5).Style.Font.Bold = true;
                            ws.Cell(lastRow + 1, 6).Style.Font.Bold = true;
                            ws.Cell(lastRow + 1, 6).Style.NumberFormat.Format = "#,##0";

                            ws.Cell(lastRow + 3, 1).Value = "Địa chỉ: Cây nhà lá vườn";
                            ws.Cell(lastRow + 3, 1).Style.Font.Bold = true;
                            ws.Cell(lastRow + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            ws.Range(lastRow + 3, 1, lastRow + 3, 6).Merge();

                            ws.Cell(lastRow + 4, 1).Value = "Sdt: 0909090909";
                            ws.Cell(lastRow + 4, 1).Style.Font.Bold = true;
                            ws.Cell(lastRow + 4, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            ws.Range(lastRow + 4, 1, lastRow + 4, 6).Merge();

                            ws.Columns().AdjustToContents();
                            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

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
    }
}