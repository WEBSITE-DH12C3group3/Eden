using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private string duongDanAnh = string.Empty;

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
                guna2ComboBoxNCC.DataSource = nhaCungCapBLL.GetAll();
                guna2ComboBoxNCC.DisplayMember = "TenNhaCungCap";
                guna2ComboBoxNCC.ValueMember = "id";

                guna2ComboBoxLoaiSP.DataSource = loaiSanPhamBLL.GetAll();
                guna2ComboBoxLoaiSP.DisplayMember = "TenLoaiSanPham";
                guna2ComboBoxLoaiSP.ValueMember = "id";

                guna2TextBoxMaSP.Text = sanPham.MaSanPham;
                guna2TextBoxMaSP.ReadOnly = true;
                guna2TextBoxTenSP.Text = sanPham.TenSanPham;
                guna2TextBoxMoTa.Text = sanPham.MoTa;
                guna2TextBoxGia.Text = sanPham.Gia.ToString();
                guna2TextBoxSoLuong.Text = sanPham.SoLuong.ToString();
                guna2TextBoxMauSac.Text = sanPham.MauSac;
                guna2TextAnh.Text = sanPham.AnhChiTiet;

                guna2ComboBoxNCC.SelectedValue = sanPham.idNhaCungCap;
                guna2ComboBoxLoaiSP.SelectedValue = sanPham.idLoaiSanPham;

                // Load ảnh vào PictureBox nếu có
                string path = Path.Combine(Application.StartupPath, "Resources\\Img", sanPham.AnhChiTiet ?? "");
                if (File.Exists(path))
                {
                    guna2CirclePictureBoxAnh.Image = Image.FromFile(path);
                    guna2CirclePictureBoxAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    duongDanAnh = sanPham.AnhChiTiet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                this.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(duongDanAnh))
                {
                    MessageBox.Show("Vui lòng chọn ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenSP = guna2TextBoxTenSP.Text.Trim();
                string moTa = guna2TextBoxMoTa.Text.Trim();
                string giaStr = guna2TextBoxGia.Text.Trim();
                string soLuongStr = guna2TextBoxSoLuong.Text.Trim();
                string mauSac = guna2TextBoxMauSac.Text.Trim();

                if (string.IsNullOrWhiteSpace(tenSP))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tenSP.Length > 100)
                {
                    MessageBox.Show("Tên sản phẩm không được vượt quá 100 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(tenSP, @"^[\w\sÀ-ỹ]+$"))
                {
                    MessageBox.Show("Tên sản phẩm không được chứa ký tự đặc biệt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(giaStr, out decimal gia) || gia < 0)
                {
                    MessageBox.Show("Giá phải là số hợp lệ và không âm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(soLuongStr, out int soLuong) || soLuong < 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên không âm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (mauSac.Length > 50)
                {
                    MessageBox.Show("Màu sắc không được vượt quá 50 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(mauSac, @"^[\w\sÀ-ỹ]*$"))
                {
                    MessageBox.Show("Màu sắc không được chứa ký tự đặc biệt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (guna2ComboBoxNCC.SelectedValue == null || guna2ComboBoxLoaiSP.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp và loại sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                sanPham.TenSanPham = tenSP;
                sanPham.MoTa = moTa;
                sanPham.Gia = gia;
                sanPham.SoLuong = soLuong;
                sanPham.MauSac = mauSac;
                sanPham.AnhChiTiet = duongDanAnh;
                sanPham.idNhaCungCap = Convert.ToInt32(guna2ComboBoxNCC.SelectedValue);
                sanPham.idLoaiSanPham = Convert.ToInt32(guna2ComboBoxLoaiSP.SelectedValue);

                sanPhamBLL.Update(sanPham);

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (this.Owner is SanPhamForm parentForm)
                {
                    parentForm.UpdateDataGridViewSP(sanPham);
                }

                SanPhamForm form = new SanPhamForm();
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SanPhamForm form = new SanPhamForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }

        private void guna2ChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string tenTep = Path.GetFileName(ofd.FileName);
                    string thuMucDich = Path.Combine(Application.StartupPath, "Resources\\Img");

                    if (!Directory.Exists(thuMucDich))
                        Directory.CreateDirectory(thuMucDich);

                    string duongDanDich = Path.Combine(thuMucDich, tenTep);

                    try
                    {
                        File.Copy(ofd.FileName, duongDanDich, true);
                        guna2CirclePictureBoxAnh.Image = Image.FromFile(duongDanDich);
                        guna2CirclePictureBoxAnh.SizeMode = PictureBoxSizeMode.Zoom;

                        duongDanAnh = tenTep;
                        guna2TextAnh.Text = tenTep;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể sao chép ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void SanPhamFormSua_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}