using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eden.UI
{

    public partial class SanPhamFormSua : Form
    {
        private SANPHAMBLL sanPhamBLL;
        private NHACUNGCAPBLL nhaCungCapBLL;
        private LOAISANPHAMBLL loaiSanPhamBLL;
        private SANPHAM sanPham;

        public SanPhamFormSua(SANPHAM maSP)
        {
            InitializeComponent();
            sanPhamBLL = new SANPHAMBLL();
            nhaCungCapBLL = new NHACUNGCAPBLL();
            loaiSanPhamBLL = new LOAISANPHAMBLL();
            sanPham = maSP;
            LoadForm();
        }
        private void LoadForm()
        {
            try
            {
                // Load ComboBox Nhà cung cấp
                var dsNCC = nhaCungCapBLL.GetAll();
                guna2ComboBoxNCC.DataSource = dsNCC;
                guna2ComboBoxNCC.DisplayMember = "TenNhaCungCap";
                guna2ComboBoxNCC.ValueMember = "id";

                // Load ComboBox Loại sản phẩm
                var dsLoaiSP = loaiSanPhamBLL.GetAll();
                guna2ComboBoxLoaiSP.DataSource = dsLoaiSP;
                guna2ComboBoxLoaiSP.DisplayMember = "TenLoaiSanPham";
                guna2ComboBoxLoaiSP.ValueMember = "id";

                // Hiển thị dữ liệu sản phẩm
                guna2TextBoxMaSP.Text = sanPham.MaSanPham;
                guna2TextBoxMaSP.ReadOnly = true;
                guna2TextBoxTenSP.Text = sanPham.TenSanPham;
                guna2TextBoxMoTa.Text = sanPham.MoTa;
                guna2TextBoxGia.Text = sanPham.Gia.ToString();
                guna2TextBoxSoLuong.Text = sanPham.SoLuong.ToString();
                guna2TextBoxMauSac.Text = sanPham.MauSac;
                guna2TextBoxAnh.Text = sanPham.AnhChiTiet;

                guna2ComboBoxNCC.SelectedValue = sanPham.idNhaCungCap;
                guna2ComboBoxLoaiSP.SelectedValue = sanPham.idLoaiSanPham;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                sanPham.TenSanPham = guna2TextBoxTenSP.Text.Trim();
                sanPham.MoTa = guna2TextBoxMoTa.Text.Trim();
                sanPham.Gia = decimal.Parse(guna2TextBoxGia.Text.Trim());
                sanPham.SoLuong = int.Parse(guna2TextBoxSoLuong.Text.Trim());
                sanPham.MauSac = guna2TextBoxMauSac.Text.Trim();
                sanPham.AnhChiTiet = guna2TextBoxAnh.Text.Trim();
                sanPham.idNhaCungCap = Convert.ToInt32(guna2ComboBoxNCC.SelectedValue);
                sanPham.idLoaiSanPham = Convert.ToInt32(guna2ComboBoxLoaiSP.SelectedValue);

                sanPhamBLL.Update(sanPham);

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi form cha nếu cần reload
                if (this.Owner is SanPhamForm parentForm)
                {
                    parentForm.UpdateDataGridViewSP(sanPham); // Hoặc UpdateDataGridView gì đó tùy bạn đặt
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
