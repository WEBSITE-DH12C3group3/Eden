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
using ClosedXML.Excel;


namespace Eden
{
    public partial class SanPhamForm : Form
    {
        private SANPHAMBLL sanphamBLL; // Đổi tên theo chuẩn CamelCase
        private int pageSize = 10; // số sản phẩm mỗi trang
        private int currentPage = 1;
        private int totalPage = 1;

        public SanPhamForm()
        {
            InitializeComponent();
            sanphamBLL = new SANPHAMBLL(); // Khởi tạo BLL
            LoadSanPham(); // Gọi hàm tải dữ liệu
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
                TenLoaiSanPham = sp.LOAISANPHAM?.TenLoaiSanPham,
                TenNhaCungCap = sp.NHACUNGCAP?.TenNhaCungCap
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
                LoadSanPham(); // Cập nhật danh sách sau khi thêm
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
            {
                string maSP = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                var sanPham = sanphamBLL.GetAll().FirstOrDefault(sp => sp.MaSanPham == maSP);

                if (sanPham != null)
                {
                    SanPhamFormSua formSua = new SanPhamFormSua(sanPham);
                    formSua.Owner = this;
                    formSua.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần sửa.");
                }
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null)
            {
                // Lấy mã sản phẩm từ dòng được chọn
                string maSP = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();

                // Xác nhận từ người dùng
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tìm sản phẩm trong DB
                        var existingSP = sanphamBLL.GetAll().FirstOrDefault(sp => sp.MaSanPham == maSP);

                        if (existingSP != null)
                        {
                            // Gọi phương thức xóa trong BLL
                            sanphamBLL.Delete(existingSP);

                            // Xóa dòng khỏi DataGridView
                            LoadSanPham(); // Gọi lại phương thức nạp lại danh sách


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
                var ketQua = sanphamBLL.TimKiemTheoTen(tuKhoa); // List<SanPhamDTO>
                dgvSanPham.DataSource = ketQua;
            }
            else
            {
                dgvSanPham.DataSource = sanphamBLL.TimKiemTheoTen(""); // Hoặc sanphamBLL.GetAllDTO()
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
            // Tạo DataTable từ DataGridView
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvSanPham.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgvSanPham.Columns.Count; i++)
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
