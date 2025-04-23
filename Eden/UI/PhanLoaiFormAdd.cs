using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Linq;

namespace Eden
{
    public partial class PhanLoaiFormAdd : Form
    {
        private LOAISANPHAMBLL loaiSanPhamBLL;

        public PhanLoaiFormAdd()
        {
            InitializeComponent();
            loaiSanPhamBLL = new LOAISANPHAMBLL();
            GenerateCustomerID();
        }

        private void GenerateCustomerID()
        {
            var loaiSanPhamList = loaiSanPhamBLL.GetAll();
            if (loaiSanPhamList.Count > 0)
            {
                var lastLoaiSanPham = loaiSanPhamList
                    .Where(l => l.MaLoaiSanPham.StartsWith("LSP")) // Chỉ lấy các mã hợp lệ
                    .OrderByDescending(l => l.MaLoaiSanPham)
                    .FirstOrDefault();

                if (lastLoaiSanPham != null)
                {
                    int lastNumber = int.Parse(lastLoaiSanPham.MaLoaiSanPham.Substring(3)); // Lấy số từ LSPxxx
                    txtMaLoai.Text = $"LSP{(lastNumber + 1):D3}"; // Chỉ dùng 3 số (LSP001 -> LSP999)
                }
                else
                {
                    txtMaLoai.Text = "LSP001"; // Nếu không có mã hợp lệ
                }
            }
            else
            {
                txtMaLoai.Text = "LSP001"; // Nếu chưa có loại sản phẩm nào
            }
            txtMaLoai.ReadOnly = true; // Không cho phép chỉnh sửa mã
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                LOAISANPHAM lsp = new LOAISANPHAM
                {
                    MaLoaiSanPham = txtMaLoai.Text.Trim(),
                    TenLoaiSanPham = txtTenLoai.Text.Trim(),
                };

                loaiSanPhamBLL.Add(lsp);
                MessageBox.Show("Thêm loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}