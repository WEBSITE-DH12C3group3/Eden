using System;
using System.Linq;
using System.Text.RegularExpressions;
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
                string tenLoai = txtTenLoai.Text.Trim();

                if (string.IsNullOrEmpty(tenLoai))
                {
                    MessageBox.Show("Vui lòng nhập tên loại sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tenLoai.Length > 50)
                {
                    MessageBox.Show("Tên loại sản phẩm không được vượt quá 50 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(tenLoai, @"^[\w\sÀ-ỹ]+$"))
                {
                    MessageBox.Show("Tên loại sản phẩm không được chứa ký tự đặc biệt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy loại sản phẩm từ mã (txtMaLoai đã là ReadOnly)
                string maLSP = txtMaLoai.Text.Trim();
                LOAISANPHAM lsp = loaiSanPhamBLL.GetAll().FirstOrDefault(l => l.MaLoaiSanPham == maLSP);

                if (lsp != null)
                {
                    lsp.TenLoaiSanPham = tenLoai;
                    loaiSanPhamBLL.Update(lsp);

                    MessageBox.Show("Cập nhật loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Quay lại form chính (nếu cần)
                    PhanLoaiForm form = new PhanLoaiForm();
                    this.Controls.Clear();
                    form.TopLevel = false;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;
                    this.Controls.Add(form);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}