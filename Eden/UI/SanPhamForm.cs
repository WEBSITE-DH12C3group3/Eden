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
            using (SanPhamFormAdd formAdd = new SanPhamFormAdd())
            {
                formAdd.ShowDialog();
                LoadSanPham();
            }
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
                    formSua.Owner = this;
                    formSua.ShowDialog();
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
            try
            {
                // Kiểm tra xem có dữ liệu để xuất không
                if (dgvSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo DataTable từ DataGridView
                DataTable dt = new DataTable("DanhSachSanPham");

                // Định nghĩa các cột với kiểu dữ liệu phù hợp
                dt.Columns.Add("Mã Sản Phẩm", typeof(string));
                dt.Columns.Add("Tên Sản Phẩm", typeof(string));
                dt.Columns.Add("Mô Tả", typeof(string));
                dt.Columns.Add("Giá", typeof(decimal));
                dt.Columns.Add("Số Lượng", typeof(int));
                dt.Columns.Add("Màu Sắc", typeof(string));
                dt.Columns.Add("Ảnh Chi Tiết", typeof(string));
                dt.Columns.Add("Tên Nhà Cung Cấp", typeof(string));
                dt.Columns.Add("Tên Loại Sản Phẩm", typeof(string));
                dt.Columns.Add("Đã Bán", typeof(int));

                // Duyệt qua từng dòng trong DataGridView và thêm vào DataTable
                foreach (DataGridViewRow row in dgvSanPham.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Mã Sản Phẩm"] = row.Cells["MaSanPham"].Value?.ToString() ?? "";
                        dr["Tên Sản Phẩm"] = row.Cells["TenSanPham"].Value?.ToString() ?? "";
                        dr["Mô Tả"] = row.Cells["MoTa"].Value?.ToString() ?? "";
                        dr["Giá"] = row.Cells["Gia"].Value != null ? Convert.ToDecimal(row.Cells["Gia"].Value) : 0;
                        dr["Số Lượng"] = row.Cells["SoLuong"].Value != null ? Convert.ToInt32(row.Cells["SoLuong"].Value) : 0;
                        dr["Màu Sắc"] = row.Cells["MauSac"].Value?.ToString() ?? "";
                        dr["Ảnh Chi Tiết"] = row.Cells["AnhChiTiet"].Value?.ToString() ?? "";
                        dr["Tên Nhà Cung Cấp"] = row.Cells["TenNhaCungCap"].Value?.ToString() ?? "";
                        dr["Tên Loại Sản Phẩm"] = row.Cells["TenLoaiSanPham"].Value?.ToString() ?? "";
                        dr["Đã Bán"] = row.Cells["SoLuongDaBan"].Value != null ? Convert.ToInt32(row.Cells["SoLuongDaBan"].Value) : 0;
                        dt.Rows.Add(dr);
                    }
                }

                // Hiển thị hộp thoại lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    Title = "Lưu file Excel",
                    FileName = $"DanhSachSanPham_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var worksheet = wb.Worksheets.Add(dt, "DanhSachSanPham");

                        // Định dạng tiêu đề
                        var titleRow = worksheet.Row(1);
                        titleRow.Style.Font.Bold = true;
                        titleRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                        titleRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Định dạng cột "Giá" (dạng tiền tệ)
                        var giaColumn = worksheet.Column(4);
                        giaColumn.Style.NumberFormat.Format = "#,##0 VNĐ";

                        // Định dạng cột "Số Lượng" (dạng số nguyên)
                        var soLuongColumn = worksheet.Column(5);
                        soLuongColumn.Style.NumberFormat.Format = "#,##0";

                        // Tự động điều chỉnh độ rộng cột
                        worksheet.Columns().AdjustToContents();

                        // Lưu file Excel
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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