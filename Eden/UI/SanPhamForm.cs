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
            LoadSanPham();
        }

        private void guna2dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện nếu cần
        }

        private void LoadSanPham()
        {
            var ds = sanphamBLL.GetAll()
                .Select(sp => new SanPhamDTO
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    MoTa = sp.MoTa,
                    Gia = sp.Gia,
                    SoLuong = sp.SoLuong,
                    MauSac = sp.MauSac,
                    AnhChiTiet = sp.AnhChiTiet,
                    TenLoaiSanPham = sp.TenLoaiSanPham,
                    TenNhaCungCap = sp.TenNhaCungCap
                })
                .ToList();

            // Lấy tổng số lượng sản phẩm để tính tổng số trang
            int tongSanPham = sanphamBLL.DemSoLuongSanPham();
            totalPage = (int)Math.Ceiling((double)tongSanPham / pageSize);

            // Lấy danh sách sản phẩm theo trang hiện tại
            var danhSach = sanphamBLL.LaySanPhamTheoTrang(currentPage, pageSize);
            dgvSanPham.DataSource = danhSach;

            // Cập nhật label số trang
            lblPage.Text = $"Trang {currentPage}/{totalPage}";
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
                string tenFileAnh = row.Cells["AnhChiTiet"].Value?.ToString();

                if (!string.IsNullOrEmpty(tenFileAnh))
                {
                    string duongDanGoc = Path.Combine(Application.StartupPath, @"..\..\Resources\img", tenFileAnh);
                    string duongDanAnh = Path.GetFullPath(duongDanGoc);

                    if (File.Exists(duongDanAnh))
                    {
                        pictureBoxSanPham.Image = Image.FromFile(duongDanAnh);
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
    }
}