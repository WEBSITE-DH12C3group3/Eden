using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Linq;
using System.Text.RegularExpressions;

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
                string maLoai = txtMaLoai.Text.Trim();
                string tenLoai = txtTenLoai.Text.Trim();

                if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(tenLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (maLoai.Length > 50 || tenLoai.Length > 50)
                {
                    MessageBox.Show("Mã hoặc tên loại không được vượt quá 50 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(tenLoai, @"^[\w\sÀ-ỹ]+$"))
                {
                    MessageBox.Show("Tên loại không được chứa ký tự đặc biệt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mã loại có trùng không
                List<LOAISANPHAM> danhSachLoai = loaiSanPhamBLL.GetAll();
                if (danhSachLoai.Any(l => l.MaLoaiSanPham == maLoai))
                {
                    MessageBox.Show("Mã loại sản phẩm đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoai.Focus();
                    return;
                }

                LOAISANPHAM lsp = new LOAISANPHAM
                {
                    MaLoaiSanPham = maLoai,
                    TenLoaiSanPham = tenLoai,
                };

                loaiSanPhamBLL.Add(lsp);
                MessageBox.Show("Thêm loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại form
                PhanLoaiForm formAdd = new PhanLoaiForm();
                this.Controls.Clear();
                formAdd.TopLevel = false;
                formAdd.FormBorderStyle = FormBorderStyle.None;
                formAdd.Dock = DockStyle.Fill;
                this.Controls.Add(formAdd);
                formAdd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PhanLoaiForm form = new PhanLoaiForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }

        private void txtTenLoai_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblTenLoai_Click(object sender, EventArgs e)
        {
        }

        private void txtMaLoai_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblMaLoai_Click(object sender, EventArgs e)
        {
        }
    }
}