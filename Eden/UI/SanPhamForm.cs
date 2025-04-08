using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Eden.DTO;
using Eden.UI;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class SanPhamForm : Form
    {
        private SANPHAMBLL sanphamBLL; // Đổi tên theo chuẩn CamelCase
        
        public SanPhamForm()
        {
            InitializeComponent();
            sanphamBLL = new SANPHAMBLL(); // Khởi tạo BLL
            LoadSanPham(); // Gọi hàm tải dữ liệu
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            dgSanPham.DataSource = ds;
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
            if (dgSanPham.CurrentRow != null)
            {
                string maSP = dgSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
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
            foreach (DataGridViewRow row in dgSanPham.Rows)
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
            if (dgSanPham.CurrentRow != null)
            {
                // Lấy mã sản phẩm từ dòng được chọn
                string maSP = dgSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();

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
                dgSanPham.DataSource = ketQua;
            }
            else
            {
                dgSanPham.DataSource = sanphamBLL.TimKiemTheoTen(""); // Hoặc sanphamBLL.GetAllDTO()
            }
        }
    }
}
