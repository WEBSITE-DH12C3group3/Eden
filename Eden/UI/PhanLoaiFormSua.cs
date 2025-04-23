using System;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Eden.UI
{
    public partial class PhanLoaiFormSua : Form
    {
        private LOAISANPHAMBLL loaiSanPhamBLL;
        private string maLSP;

        public PhanLoaiFormSua(string maLSP)
        {
            InitializeComponent();
            this.loaiSanPhamBLL = new LOAISANPHAMBLL();
            this.maLSP = maLSP;
            PhanLoaiFormSua_Load();
        }

        private void PhanLoaiFormSua_Load()
        {
            try
            {
                // Lấy thông tin loại sản phẩm từ cơ sở dữ liệu
                LOAISANPHAM lsp = loaiSanPhamBLL.GetAll().FirstOrDefault(l => l.MaLoaiSanPham == maLSP);

                if (lsp != null) // Nếu sản phẩm tồn tại
                {
                    // Đổ thông tin sản phẩm vào các ô nhập liệu
                    txtMaLoai.Text = lsp.MaLoaiSanPham;
                    txtMaLoai.ReadOnly = true; // Không cho phép sửa mã loại sản phẩm
                    txtTenLoai.Text = lsp.TenLoaiSanPham;
                }
                else // Nếu không tìm thấy sản phẩm
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm với mã: " + maLSP, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Đóng form nếu không tìm thấy sản phẩm
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu có lỗi
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                LOAISANPHAM lsp = new LOAISANPHAM
                {
                    MaLoaiSanPham = maLSP,
                    TenLoaiSanPham = txtTenLoai.Text.Trim(),
                };

                loaiSanPhamBLL.Update(lsp);

                MessageBox.Show("Cập nhật loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi phương thức cập nhật DataGridView từ form cha
                if (this.Owner is PhanLoaiForm parentForm)
                {
                    parentForm.UpdateDataGridView(lsp);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}