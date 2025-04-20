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
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(duongDanAnh))
                {
                    MessageBox.Show("Vui lòng chọn ảnh sản phẩm.", "Thiếu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SANPHAM sp = new SANPHAM
                {
                    TenSanPham = guna2TextBoxTenSP.Text.Trim(),
                    MoTa = guna2TextBoxMoTa.Text.Trim(),
                    Gia = decimal.Parse(guna2TextBoxGia.Text.Trim()),
                    SoLuong = int.Parse(guna2TextBoxSoLuong.Text.Trim()),
                    MauSac = guna2TextBoxMauSac.Text.Trim(),
                    AnhChiTiet = duongDanAnh, // lưu đường dẫn ảnh
                    idNhaCungCap = Convert.ToInt32(guna2ComboBoxNCC.SelectedValue),
                    idLoaiSanPham = Convert.ToInt32(guna2ComboBoxLoaiSP.SelectedValue)
                };

                sanPhamBLL.Add(sp);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá và số lượng phải là số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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