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
        private HOADONBLL hoaDonBLL;
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 10; // Số bản ghi trên mỗi trang
        private int totalPages = 1; // Tổng số trang
        private string currentSearchText = ""; // Lưu từ khóa tìm kiếm hiện tại

        public HoaDonForm()
        {
            InitializeComponent();
            hoaDonBLL = new HOADONBLL();

            dghoadon.AutoGenerateColumns = false;
            dghoadon.Columns.Clear();
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaHoaDon",
                HeaderText = "Mã Hóa Đơn",
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
                HeaderText = "Mã Khách Hàng"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenKhachHang",
                HeaderText = "Tên Khách Hàng"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNguoiDung",
                HeaderText = "Tên Người Dùng"
            });
            dghoadon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongTien",
                HeaderText = "Tổng Tiền"
            });

            LoadData();

            search.TextChanged += new EventHandler(search_TextChanged);
            search.Text = "Nhập mã hóa đơn hoặc mã khách hàng (số)";
            //search.ForeColor = Color.Gray;
            search.Enter += new EventHandler(search_Enter);
            search.Leave += new EventHandler(search_Leave);
        }

        // Hàm tải dữ liệu lên DataGridView
        private void LoadData()
        {
            try
            {
                DisplayPage(1); // Hiển thị trang đầu tiên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị dữ liệu theo trang
        private void DisplayPage(int page)
        {
            currentPage = page;

            var result = hoaDonBLL.SearchAndPage(currentSearchText, currentPage, pageSize);
            var pageData = result.Data; // List<HoaDonDTO>
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

        // Sự kiện TextChanged: Tìm kiếm theo thời gian thực
        private void search_TextChanged(object sender, EventArgs e)
        {
            string searchText = search.Text.Trim().ToLower();
            if (searchText != "nhập mã hóa đơn hoặc mã khách hàng (số)")
            {
                currentSearchText = searchText; // Lưu từ khóa tìm kiếm
                DisplayPage(1); // Hiển thị lại từ trang 1
            }
            else
            {
                currentSearchText = ""; // Đặt lại từ khóa tìm kiếm khi textbox là placeholder
                DisplayPage(1);
            }
        }

        // Sự kiện Enter: Xóa placeholder khi người dùng nhấp vào ô tìm kiếm
        private void search_Enter(object sender, EventArgs e)
        {
            if (search.Text == "Nhập mã hóa đơn hoặc mã khách hàng (số)")
            {
                search.Text = "";
                //search.ForeColor = Color.Black;
            }
        }

        // Sự kiện Leave: Đặt lại placeholder nếu ô trống
        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                search.Text = "Nhập mã hóa đơn hoặc mã khách hàng (số)";
                //search.ForeColor = Color.Gray;
            }
        }

        // Nút tìm kiếm
        private void searchHD_Click(object sender, EventArgs e)
        {
            search_TextChanged(sender, e);
        }

        // Nút Trang trước
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                DisplayPage(currentPage - 1);
            }
        }

        // Nút Trang sau
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                DisplayPage(currentPage + 1);
            }
        }

        // Mở form thêm hóa đơn
        private void addhoadon_Click(object sender, EventArgs e)
        {
            using (HoaDonAdd formAdd = new HoaDonAdd())
            {
                formAdd.FormClosed += (s, args) => LoadData(); // Làm mới danh sách sau khi thêm
                formAdd.ShowDialog();
            }
        }

        // Xóa hóa đơn
        private void xoahoadon_Click(object sender, EventArgs e)
        {
            if (dghoadon.CurrentRow != null)
            {
                string maHD = dghoadon.CurrentRow.Cells["MaHoaDon"].Value.ToString();
                HOADON hd = new HOADON { MaHoaDon = maHD };

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        hoaDonBLL.Delete(hd);
                        LoadData();
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xem chi tiết hóa đơn
        private void xemct_Click(object sender, EventArgs e)
        {
            if (dghoadon.CurrentRow != null)
            {
                string maHoaDon = dghoadon.CurrentRow.Cells["MaHoaDon"].Value.ToString();
                int idHoaDon = int.Parse(maHoaDon.Replace("HD", ""));
                using (HoaDonChiTiet formCT = new HoaDonChiTiet(idHoaDon))
                {
                    formCT.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xuất Excel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<HoaDonDTO> allHoaDon = hoaDonBLL.GetAll();

            if (allHoaDon == null || allHoaDon.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra và log thông tin người dùng
            string userName = CurrentUser.Username;
            if (string.IsNullOrEmpty(userName))
            {
                userName = Environment.UserName; // Giá trị thay thế
                MessageBox.Show($"Không tìm thấy thông tin người dùng. Sử dụng tên hệ thống: {userName}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Diagnostics.Debug.WriteLine($"[HoaDonForm] Xuất Excel: CurrentUser.Username is null, sử dụng {userName} at {DateTime.Now}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[HoaDonForm] Xuất Excel: CurrentUser.Username = {userName} at {DateTime.Now}");
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = $"DanhSachHoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("HoaDon");

                    // Thiết lập kích thước giấy A4 và các cài đặt in
                    ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
                    ws.PageSetup.Margins.Left = 0.5; // Lề trái 0.5 inch
                    ws.PageSetup.Margins.Right = 0.5; // Lề phải 0.5 inch
                    ws.PageSetup.Margins.Top = 0.75; // Lề trên 0.75 inch
                    ws.PageSetup.Margins.Bottom = 0.75; // Lề dưới 0.75 inch
                    ws.PageSetup.CenterHorizontally = true; // Căn giữa ngang khi in
                    ws.PageSetup.PageOrientation = XLPageOrientation.Portrait; // Hướng giấy dọc

                    // Thêm tiêu đề chính: Tên cửa hàng
                    ws.Cell(1, 1).Value = "Cửa Hàng Hoa Tươi EDEN";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 18;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    ws.Range(1, 1, 1, 6).Merge();

                    // Thêm tiêu đề danh sách
                    ws.Cell(2, 1).Value = "Danh Sách Hóa Đơn";
                    ws.Cell(2, 1).Style.Font.Bold = true;
                    ws.Cell(2, 1).Style.Font.FontSize = 16;
                    ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(2, 1, 2, 6).Merge();

                    // Thông tin người xuất và ngày xuất
                    string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ws.Cell(3, 5).Value = $"Người xuất: {userName}";
                    ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(3, 5).Style.Font.Bold = true;
                    ws.Range(3, 5, 3, 6).Merge();
                    ws.Cell(4, 5).Value = $"Ngày xuất: {exportDateTime}";
                    ws.Cell(4, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(4, 5).Style.Font.Bold = true;
                    ws.Range(4, 5, 4, 6).Merge();

                    // Tạo DataTable để lưu dữ liệu
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

                    // Thêm dữ liệu từ DataTable, bắt đầu từ hàng 6
                    var dataRange = ws.Cell(6, 1).InsertTable(dt.AsEnumerable()).AsRange();

                    // Định dạng tiêu đề cột
                    var headerRow = dataRange.FirstRow();
                    headerRow.Style.Font.Bold = true;
                    headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Định dạng cột "Ngày Lập"
                    var ngayLapColumn = ws.Column(2);
                    ngayLapColumn.Style.DateFormat.Format = "dd/MM/yyyy";

                    // Định dạng cột "Tổng Tiền" (không có phần thập phân)
                    var tongTienColumn = ws.Column(6);
                    tongTienColumn.Style.NumberFormat.Format = "0";

                    // Thêm hàng tổng cộng ở cuối bảng
                    var lastRow = dataRange.LastRow().RowNumber();
                    ws.Cell(lastRow + 1, 5).Value = "Tổng cộng:";
                    ws.Cell(lastRow + 1, 6).Value = allHoaDon.Sum(hd => hd.TongTien);
                    ws.Cell(lastRow + 1, 5).Style.Font.Bold = true;
                    ws.Cell(lastRow + 1, 6).Style.Font.Bold = true;
                    ws.Cell(lastRow + 1, 6).Style.NumberFormat.Format = "0";

                    // Thêm thông tin cửa hàng ở dưới cùng
                    ws.Cell(lastRow + 3, 1).Value = "Địa chỉ: Cây nhà lá vườn";
                    ws.Cell(lastRow + 3, 1).Style.Font.Bold = true;
                    ws.Cell(lastRow + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    ws.Range(lastRow + 3, 1, lastRow + 3, 6).Merge();

                    ws.Cell(lastRow + 4, 1).Value = "Sdt: 0909090909";
                    ws.Cell(lastRow + 4, 1).Style.Font.Bold = true;
                    ws.Cell(lastRow + 4, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    ws.Range(lastRow + 4, 1, lastRow + 4, 6).Merge();

                    // Tự động điều chỉnh độ rộng cột
                    ws.Columns().AdjustToContents();

                    // Thêm đường viền cho bảng
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Lưu file
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            currentPage = 1;
            LoadData();
        }

        private void dghoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể thêm xử lý nếu cần
        }

        private void dghoadon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể thêm xử lý nếu cần
        }

        private void lblPageInfo_Click(object sender, EventArgs e)
        {
        }
    }
}