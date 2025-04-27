using System;
using ClosedXML.Excel;

using System.Windows.Forms;
using Eden;
using Eden.UI;
using System.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using Eden.DTO;
using System.Collections.Generic;

namespace Eden
{
    public partial class KhachHangForm : Form
    {
        private KHACHHANGBLL khachHangBLL;
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 10; // Số bản ghi trên mỗi trang
        private int totalPages = 1; // Tổng số trang
        private string currentSearchText = ""; // Lưu từ khóa tìm kiếm hiện tại

        public KhachHangForm()
        {
            InitializeComponent();
            khachHangBLL = new KHACHHANGBLL();
            dgkhachhang.AutoGenerateColumns = false;
            dgkhachhang.Columns.Clear();
            dgkhachhang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaKhachHang",
                HeaderText = "Mã Khách Hàng",
                Name = "MaKhachHang"
            });
            dgkhachhang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenKhachHang",
                HeaderText = "Tên Khách Hàng"
            });
            dgkhachhang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "Số Điện Thoại"
            });
            dgkhachhang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiaChi",
                HeaderText = "Địa Chỉ"
            });
            dgkhachhang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email"
            });
            LoadData();

            // Thêm sự kiện TextChanged cho tìm kiếm theo thời gian thực
            searchHK.TextChanged += new EventHandler(searchHK_TextChanged);

            // Thiết lập placeholder cho searchHK
            searchHK.Text = "Nhập tên hoặc mã KH";
            //searchHK.ForeColor = Color.Gray;
            searchHK.Enter += new EventHandler(searchHK_Enter);
            searchHK.Leave += new EventHandler(searchHK_Leave);
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
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Hiển thị dữ liệu theo trang
        private void DisplayPage(int page)
        {
            currentPage = page;

            // Lấy dữ liệu từ BLL
            var result = khachHangBLL.SearchAndPage(currentSearchText, currentPage, pageSize);
            var pageData = result.Data;
            int totalRecords = result.TotalRecords;

            // Tính tổng số trang
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1; // Đảm bảo ít nhất 1 trang

            // Điều chỉnh trang hiện tại nếu vượt quá giới hạn
            if (currentPage > totalPages) currentPage = totalPages;
            if (currentPage < 1) currentPage = 1;

            // Cập nhật DataGridView
            dgkhachhang.DataSource = null;
            dgkhachhang.DataSource = pageData;

            // Cập nhật thông tin trang
            lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

            // Kích hoạt/vô hiệu hóa nút
            btnPreviousPage.Enabled = currentPage > 1;
            btnNextPage.Enabled = currentPage < totalPages;
        }

        // Sự kiện TextChanged: Tìm kiếm theo thời gian thực
        private void searchHK_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchHK.Text.Trim().ToLower();
            if (searchText != "nhập tên hoặc mã kh")
            {
                currentSearchText = searchText; // Lưu từ khóa tìm kiếm
                DisplayPage(1); // Hiển thị lại từ trang 1
            }
        }

        // Sự kiện Enter: Xóa placeholder khi người dùng nhấp vào ô tìm kiếm
        private void searchHK_Enter(object sender, EventArgs e)
        {
            if (searchHK.Text == "Nhập tên hoặc mã KH")
            {
                searchHK.Text = "";
                //searchHK.ForeColor = Color.Black;
            }
        }

        // Sự kiện Leave: Đặt lại placeholder nếu ô trống
        private void searchHK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchHK.Text))
            {
                searchHK.Text = "Nhập tên hoặc mã KH";
                //searchHK.ForeColor = Color.Gray;
            }
        }

        // Nút tìm kiếm (tùy chọn)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchHK_TextChanged(sender, e);
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

        // Mở form thêm khách hàng
        private void addkhachhang_Click(object sender, EventArgs e)
        {
            using (KhachHangadd formAdd = new KhachHangadd())
            {
                formAdd.ShowDialog();
                LoadData();
            }
        }

        // Mở form sửa khách hàng
        private void suakhachhang_Click(object sender, EventArgs e)
        {
            if (dgkhachhang.CurrentRow != null)
            {
                string maKH = dgkhachhang.CurrentRow.Cells["MaKhachHang"].Value.ToString();

                using (KhachHangsua formSua = new KhachHangsua(maKH))
                {
                    formSua.FormClosed += (s, args) => LoadData();
                    formSua.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.");
            }
        }

        // Xóa khách hàng
        private void xoakhachhang_Click(object sender, EventArgs e)
        {
            if (dgkhachhang.CurrentRow != null)
            {
                string maKH = dgkhachhang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
                KHACHHANG kh = new KHACHHANG { MaKhachHang = maKH };

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        khachHangBLL.Delete(kh);
                        LoadData();
                        MessageBox.Show("Xóa khách hàng thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
            }
        }

        // Xử lý sự kiện click trong DataGridView (nếu cần)
        private void dgkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể thêm xử lý nếu cần
        }
        //luu excel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            List<KhachHangDTO> allKhachHang = khachHangBLL.GetAll();

            if (allKhachHang == null || allKhachHang.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo DataTable để lưu dữ liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách hàng");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Tên địa chỉ");
            dt.Columns.Add("Email");
            dt.Columns.Add("Số điện thoại");

            foreach (var kh in allKhachHang)
            {
                dt.Rows.Add(
                    kh.MaKhachHang,
                    kh.TenKhachHang,
                    kh.DiaChi,
                    kh.Email,
                    kh.SoDienThoai
                );
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = $"DanhSachkhachhang_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("KhachHang");

                    // Thêm tiêu đề chính
                    ws.Cell(1, 1).Value = "Danh Sách khách hàng";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 16;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, 6).Merge();

                    // Thêm ngày xuất file
                    ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range(2, 1, 2, 6).Merge();

                    // Thêm dữ liệu từ DataTable (bắt đầu từ hàng 4)
                    var dataRange = ws.Cell(4, 1).InsertTable(dt.AsEnumerable()).AsRange();

                    // Định dạng tiêu đề cột
                    var headerRow = dataRange.FirstRow();
                    headerRow.Style.Font.Bold = true;
                    headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Định dạng cột "Ngày Lập"
                    var ngayLapColumn = ws.Column(2);
                    ngayLapColumn.Style.DateFormat.Format = "dd/MM/yyyy";

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

        private void searchHK_TextChanged_1(object sender, EventArgs e)
        {
        }
    }
}