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
            search.ForeColor = Color.Gray;
            search.Enter += new EventHandler(search_Enter);
            search.Leave += new EventHandler(search_Leave); // Sửa lại để dùng search
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
            if (searchText != "nhập mã hóa đơn hoặc mã khách hàng (số)") // Sửa lại để khớp với placeholder
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
                search.ForeColor = Color.Black;
            }
        }

        // Sự kiện Leave: Đặt lại placeholder nếu ô trống
        private void search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search.Text))
            {
                search.Text = "Nhập mã hóa đơn hoặc mã khách hàng (số)";
                search.ForeColor = Color.Gray;
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

        // Mở form sửa hóa đơn


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
                        MessageBox.Show("Xóa hóa đơn thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.");
            }
        }

        // Xử lý sự kiện click trong DataGridView (nếu cần)
        private void dghoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể thêm xử lý nếu cần
        }

        private void xemct_Click(object sender, EventArgs e) // Xem chi tiết hóa đơn
        {

            if (dghoadon.CurrentRow != null)
            {
                // Lấy MaHoaDon từ dòng được chọn (ví dụ: "HD0001")
                string maHoaDon = dghoadon.CurrentRow.Cells["MaHoaDon"].Value.ToString();

                // Chuyển MaHoaDon thành idHoaDon (lấy số từ chuỗi HDxxxx)
                int idHoaDon = int.Parse(maHoaDon.Replace("HD", ""));

                // Khởi tạo form HoaDonChiTiet với idHoaDon
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



        private void dghoadon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ DataGridView
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dghoadon.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dghoadon.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dghoadon.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value?.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Lưu Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "DanhSach.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "DanhSach");
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}