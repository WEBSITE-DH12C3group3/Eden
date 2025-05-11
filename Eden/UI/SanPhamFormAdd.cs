using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Guna.UI2.WinForms;

//using System.Drawing;

namespace Eden.UI
{
    public partial class SanPhamFormAdd : Form
    {
        private LOAISANPHAMBLL loaiSanPhamBLL;
        private NHACUNGCAPBLL nhaCungCapBLL;
        private SANPHAMBLL sanPhamBLL;
        private string duongDanAnh = string.Empty;

        public SanPhamFormAdd()
        {
            InitializeComponent();
            sanPhamBLL = new SANPHAMBLL();
            loaiSanPhamBLL = new LOAISANPHAMBLL();
            nhaCungCapBLL = new NHACUNGCAPBLL();
            GenerateProductID();
            LoadLoaiSanPham();
            LoadNhaCungCap();
        }

        private void GenerateProductID()
        {
            var sanPhamList = sanPhamBLL.GetAll();
            if (sanPhamList.Count > 0)
            {
                var lastSanPham = sanPhamList
                    .Where(sp => sp.MaSanPham.StartsWith("SP")) // Chỉ lấy các mã hợp lệ
                    .OrderByDescending(sp => sp.MaSanPham)
                    .FirstOrDefault();

                if (lastSanPham != null)
                {
                    int lastNumber = int.Parse(lastSanPham.MaSanPham.Substring(2)); // Lấy số từ SPxxx
                    guna2TextBoxMaSP.Text = $"SP{(lastNumber + 1):D3}"; // Định dạng SP001 -> SP999
                }
                else
                {
                    guna2TextBoxMaSP.Text = "SP001"; // Nếu không có mã hợp lệ
                }
            }
            else
            {
                guna2TextBoxMaSP.Text = "SP001"; // Nếu chưa có sản phẩm nào
            }
            guna2TextBoxMaSP.ReadOnly = true; // Không cho phép chỉnh sửa mã
        }

        private void LoadLoaiSanPham()
        {
            try
            {
                var list = loaiSanPhamBLL.GetAll();
                guna2ComboBoxLoaiSP.DataSource = list;
                guna2ComboBoxLoaiSP.DisplayMember = "TenLoaiSanPham";
                guna2ComboBoxLoaiSP.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải loại sản phẩm: " + ex.Message);
            }
        }

        private void LoadNhaCungCap()
        {
            try
            {
                var list = nhaCungCapBLL.GetAll();
                guna2ComboBoxNCC.DataSource = list;
                guna2ComboBoxNCC.DisplayMember = "TenNhaCungCap";
                guna2ComboBoxNCC.ValueMember = "id"; // Chỉ cần id vì MaNhaCungCap được sinh tự động
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhà cung cấp: " + ex.Message);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ảnh sản phẩm
                if (string.IsNullOrWhiteSpace(duongDanAnh))
                {
                    MessageBox.Show("Vui lòng chọn ảnh sản phẩm.", "Thiếu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị từ các ô nhập
                string tenSP = guna2TextBoxTenSP.Text.Trim();
                string moTa = guna2TextBoxMoTa.Text.Trim();
                string giaStr = guna2TextBoxGia.Text.Trim();
                string soLuongStr = guna2TextBoxSoLuong.Text.Trim();
                string mauSac = guna2TextBoxMauSac.Text.Trim();

                // Kiểm tra tên sản phẩm
                if (string.IsNullOrWhiteSpace(tenSP))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (tenSP.Length > 255)
                {
                    MessageBox.Show("Tên sản phẩm không được vượt quá 255 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Regex.IsMatch(tenSP, @"^[\w\sÀ-ỹ]+$"))
                {
                    MessageBox.Show("Tên sản phẩm không được chứa ký tự đặc biệt.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mô tả
                if (moTa.Length > 1000)
                {
                    MessageBox.Show("Mô tả không được vượt quá 1000 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giá
                if (!decimal.TryParse(giaStr, out decimal gia) || gia < 0 || gia > 9999999999.99m)
                {
                    MessageBox.Show("Giá phải là số hợp lệ, không âm và không vượt quá 9,999,999,999.99.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra số lượng
                if (!int.TryParse(soLuongStr, out int soLuong) || soLuong < 0 || soLuong > 1000000)
                {
                    MessageBox.Show("Số lượng phải là số nguyên không âm và không vượt quá 1,000,000.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra màu sắc
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

                // Kiểm tra nhà cung cấp và loại sản phẩm
                if (guna2ComboBoxNCC.SelectedValue == null || guna2ComboBoxLoaiSP.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp và loại sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng sản phẩm
                SANPHAM sp = new SANPHAM
                {
                    TenSanPham = tenSP,
                    MoTa = moTa,
                    Gia = gia,
                    SoLuong = soLuong,
                    MauSac = mauSac,
                    AnhChiTiet = duongDanAnh,
                    idNhaCungCap = Convert.ToInt32(guna2ComboBoxNCC.SelectedValue),
                    idLoaiSanPham = Convert.ToInt32(guna2ComboBoxLoaiSP.SelectedValue)
                };

                // Thêm sản phẩm
                sanPhamBLL.Add(sp);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đặt lại form sau khi thêm thành công
                guna2TextBoxTenSP.Clear();
                guna2TextBoxMoTa.Clear();
                guna2TextBoxGia.Clear();
                guna2TextBoxSoLuong.Clear();
                guna2TextBoxMauSac.Clear();
                duongDanAnh = null;
                guna2CirclePictureBoxAnh.Image = null;

                // Tải lại form sản phẩm
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
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh sản phẩm";
                ofd.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    string fileName = Path.GetFileName(filePath); // lấy tên ảnh
                    string destinationFolder = Path.Combine(Application.StartupPath, @"Resources\Img");
                    string destinationPath = Path.Combine(destinationFolder, fileName);

                    try
                    {
                        // Tạo thư mục nếu chưa có
                        if (!Directory.Exists(destinationFolder))
                            Directory.CreateDirectory(destinationFolder);

                        // Copy ảnh nếu chưa tồn tại
                        if (!File.Exists(destinationPath))
                            File.Copy(filePath, destinationPath);

                        guna2CirclePictureBoxAnh.Image = Image.FromFile(destinationPath);
                        guna2CirclePictureBoxAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        duongDanAnh = fileName; // chỉ lưu tên file vào DB
                        guna2TextAnh.Text = fileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi sao chép ảnh: " + ex.Message);
                    }
                }
            }
        }
    }
}