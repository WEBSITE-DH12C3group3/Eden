using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Eden.DTO;
using Eden.UI;
using ClosedXML.Excel;
using Guna.UI2.WinForms;
using System.Drawing;

namespace Eden
{
    public partial class SanPhamForm : Form
    {
        private SANPHAMBLL sanphamBLL;
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalPage = 1;

        public SanPhamForm()
        {
            InitializeComponent();
            sanphamBLL = new SANPHAMBLL();

            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSanPham",
                HeaderText = "Mã Sản Phẩm",
                Name = "MaSanPham"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSanPham",
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSanPham"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoTa",
                HeaderText = "Mô Tả",
                Name = "MoTa"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gia",
                HeaderText = "Giá",
                Name = "Gia"
            });

            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số Lượng",
                Name = "SoLuong"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongDaBan",
                HeaderText = "Số Lượng Đã Bán",
                Name = "SoLuongDaBan"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MauSac",
                HeaderText = "Màu Sắc",
                Name = "MauSac"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AnhChiTiet",
                HeaderText = "Ảnh Chi Tiết",
                Name = "AnhChiTiet"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNhaCungCap",
                HeaderText = "Nhà Cung Cấp",
                Name = "TenNhaCungCap"
            });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenLoaiSanPham",
                HeaderText = "Loại Sản Phẩm",
                Name = "TenLoaiSanPham"
            });
            // Tạo các phạm vi giá
            List<string> giaRanges = new List<string>
            {
                "0 đến 100k",
                "100k đến 500k",
                "500k đến 1 triệu",
                "1 triệu đến 5 triệu",
                "5 triệu trở lên"
            };

            // Gán danh sách vào ComboBox
            cmbGia.DataSource = giaRanges;

            // Chọn mục mặc định cho ComboBox
            if (cmbGia.Items.Count > 0)
            {
                cmbGia.SelectedIndex = 0; // Chọn mục đầu tiên làm mặc định
            }
            LoadSanPham();
        }

        private void LoadSanPham()
        {
            var ds = sanphamBLL.GetAll(); // Đã là DTO, chứa SoLuongDaBan
            int tongSanPham = ds.Count;
            totalPage = (int)Math.Ceiling((double)tongSanPham / pageSize);

            // Phân trang trực tiếp trên ds
            var danhSachPhanTrang = ds
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            dgvSanPham.DataSource = danhSachPhanTrang;
            lblPage.Text = $"Trang {currentPage}/{totalPage}";
            foreach (var sp in ds)
            {
                Console.WriteLine($"{sp.TenSanPham} - Đã bán: {sp.SoLuongDaBan}");
            }
            string selectedRange = cmbGia.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedRange))
            {
                // Lựa chọn mặc định nếu chưa chọn gì
                selectedRange = "Giá từ 0 đến 100k";  // Giá trị mặc định
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SanPhamFormAdd formAdd = new SanPhamFormAdd();

            this.Controls.Clear();
            formAdd.TopLevel = false;
            formAdd.FormBorderStyle = FormBorderStyle.None;
            formAdd.Dock = DockStyle.Fill;
            this.Controls.Add(formAdd);
            formAdd.Show();
        }

        public void UpdateDataGridViewSP(SANPHAM updatedSP)
        {
            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                var maSP = row.Cells["MaSanPham"].Value?.ToString();
                if (maSP == updatedSP.MaSanPham)
                {
                    row.Cells["TenSanPham"].Value = updatedSP.TenSanPham;
                    row.Cells["MoTa"].Value = updatedSP.MoTa;
                    row.Cells["Gia"].Value = updatedSP.Gia;
                    row.Cells["SoLuong"].Value = updatedSP.SoLuong;
                    row.Cells["SoLuongDaBan"].Value = updatedSP.SoLuongDaBan;
                    row.Cells["MauSac"].Value = updatedSP.MauSac;
                    row.Cells["AnhChiTiet"].Value = updatedSP.AnhChiTiet;
                    row.Cells["TenLoaiSanPham"].Value = updatedSP.LOAISANPHAM?.TenLoaiSanPham;
                    row.Cells["TenNhaCungCap"].Value = updatedSP.NHACUNGCAP?.TenNhaCungCap;
                    break;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
            {
                string maSP = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                var sanPham = sanphamBLL.GetByMaSanPham(maSP); // Lấy SANPHAM thay vì SanPhamDTO

                if (sanPham != null)
                {
                    SanPhamFormSua formSua = new SanPhamFormSua(sanPham);

                    this.Controls.Clear();
                    formSua.TopLevel = false;
                    formSua.FormBorderStyle = FormBorderStyle.None;
                    formSua.Dock = DockStyle.Fill;
                    this.Controls.Add(formSua);
                    formSua.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
            {
                string maSP = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var existingSP = sanphamBLL.GetByMaSanPham(maSP); // Lấy SANPHAM thay vì SanPhamDTO
                        if (existingSP != null)
                        {
                            sanphamBLL.Delete(existingSP);
                            LoadSanPham();
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2ButtonTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = guna2TextBoxTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                var ketQua = sanphamBLL.TimKiemTheoTen(tuKhoa);
                dgvSanPham.DataSource = ketQua;
            }
            else
            {
                dgvSanPham.DataSource = sanphamBLL.TimKiemTheoTen("");
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadSanPham();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                LoadSanPham();
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSanPham.Rows[e.RowIndex];

                // Lấy thông tin từ dòng được chọn
                string tenSP = row.Cells["TenSanPham"].Value?.ToString();
                string gia = row.Cells["Gia"].Value?.ToString();
                string soLuong = row.Cells["SoLuong"].Value?.ToString();
                string mauSac = row.Cells["MauSac"].Value?.ToString();
                string tenFileAnh = row.Cells["AnhChiTiet"].Value?.ToString();

                // Gán vào các label hiển thị
                lblTenSanPham.Text = "Tên: " + tenSP;
                lblGia.Text = "Giá: " + gia;
                lblSoLuong.Text = "Số lượng: " + soLuong;
                lblMauSac.Text = "Màu sắc: " + mauSac;

                // Hiển thị ảnh
                if (!string.IsNullOrEmpty(tenFileAnh))
                {
                    string duongDanAnh = Path.Combine(Application.StartupPath, @"Resources\img", tenFileAnh);

                    if (File.Exists(duongDanAnh))
                    {
                        pictureBoxSanPham.Image = Image.FromFile(duongDanAnh);
                        pictureBoxSanPham.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pictureBoxSanPham.Image = null;
                        MessageBox.Show("Không tìm thấy ảnh tại:\n" + duongDanAnh);
                    }
                }
                else
                {
                    pictureBoxSanPham.Image = null;
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            List<SanPhamDTO> allSanPham = sanphamBLL.GetAll();

            if (allSanPham == null || allSanPham.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Sản Phẩm");
            dt.Columns.Add("Mô Tả");
            dt.Columns.Add("Giá", typeof(decimal));
            dt.Columns.Add("Số Lượng", typeof(int));
            dt.Columns.Add("Màu Sắc");
            dt.Columns.Add("Ảnh Chi Tiết");
            dt.Columns.Add("Mã Nhà Cung Cấp");
            dt.Columns.Add("Mã Loại Sản Phẩm");
            dt.Columns.Add("Mã Sản Phẩm");

            foreach (var sp in allSanPham)
            {
                dt.Rows.Add(
                    sp.TenSanPham,
                    sp.MoTa,
                    sp.Gia,
                    sp.SoLuong,
                    sp.MauSac,
                    sp.AnhChiTiet,
                    sp.TenNhaCungCap.ToString(),
                    sp.TenLoaiSanPham.ToString(),
                    sp.MaSanPham
                );
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = $"DanhSachSanPham_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("SanPham");

                    // Tiêu đề chính
                    ws.Cell(1, 1).Value = "Danh Sách Sản Phẩm";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 16;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, 9).Merge();

                    // Ngày xuất
                    ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range(2, 1, 2, 9).Merge();

                    // Dữ liệu
                    var dataRange = ws.Cell(4, 1).InsertTable(dt.AsEnumerable()).AsRange();

                    // Định dạng tiêu đề cột
                    var headerRow = dataRange.FirstRow();
                    headerRow.Style.Font.Bold = true;
                    headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Định dạng số
                    ws.Column(3).Style.NumberFormat.Format = "0"; // Giá
                    ws.Column(4).Style.NumberFormat.Format = "0"; // Số lượng

                    // Tự động chỉnh độ rộng
                    ws.Columns().AdjustToContents();

                    // Đường viền bảng
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    // Lưu file
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guna2TextBoxTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string tuKhoa = guna2TextBoxTimKiem.Text.Trim();
            var ketQua = sanphamBLL.TimKiemTheoTen(tuKhoa);
            dgvSanPham.DataSource = ketQua;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu SelectedItem là null, không làm gì
            if (cmbGia.SelectedItem == null) return;

            // Lấy phạm vi giá được chọn từ ComboBox
            string selectedRange = cmbGia.SelectedItem.ToString();

            decimal giaFrom = 0;
            decimal giaTo = decimal.MaxValue;

            // Phân tích phạm vi giá đã chọn
            if (selectedRange == "0 đến 100k")
            {
                giaFrom = 0;
                giaTo = 100000;
            }
            else if (selectedRange == "100k đến 500k")
            {
                giaFrom = 100000;
                giaTo = 500000;
            }
            else if (selectedRange == "500k đến 1 triệu")
            {
                giaFrom = 500000;
                giaTo = 1000000;
            }
            else if (selectedRange == "1 triệu đến 5 triệu")
            {
                giaFrom = 1000000;
                giaTo = 5000000;
            }
            else if (selectedRange == "5 triệu trở lên")
            {
                giaFrom = 5000000;
                giaTo = decimal.MaxValue;
            }

            // Lọc sản phẩm theo giá đã chọn
            var ds = sanphamBLL.GetAll(); // Lấy tất cả sản phẩm
            var filteredList = ds.Where(sp => sp.Gia >= giaFrom && sp.Gia <= giaTo).ToList();

            // Cập nhật lại DataGridView với danh sách đã lọc
            dgvSanPham.DataSource = filteredList;
        }
    }
}