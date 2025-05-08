using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.Excel;
using Eden.DTO;

namespace Eden.UI
{
    public partial class PhanLoaiFormListSP : Form
    {
        private SANPHAMBLL sanPhamBLL;
        private int Id;
        private int currentPage = 1;
        private int pageSize = 10; // số lượng item mỗi trang
        private int totalPages = 1;
        public PhanLoaiFormListSP(int id)
        {
            InitializeComponent();
            this.Id = id;
            sanPhamBLL = new SANPHAMBLL();
            sanPhamList.AutoGenerateColumns = false;
            sanPhamList.Columns.Clear();
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSanPham",
                HeaderText = "Mã Sản Phẩm",
                Name = "MaSanPham"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSanPham",
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSanPham"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoTa",
                HeaderText = "Mô tả",
                Name = "MoTa"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gia",
                HeaderText = "Giá",
                Name = "Gia"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số Lượng",
                Name = "SoLuong"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongDaBan",
                HeaderText = "Số Lượng Đã Bán",
                Name = "SoLuongDaBan"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MauSac",
                HeaderText = "Màu Sắc",
                Name = "MauSac"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AnhChiTiet",
                HeaderText = "Ảnh Chi Tiết",
                Name = "AnhChiTiet"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNhaCungCap",
                HeaderText = "Tên Nhà Cung Cấp",
                Name = "TenNhaCungCap"
            });
            sanPhamList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenLoaiSanPham",
                HeaderText = "Tên Loại Sản Phẩm",
                Name = "TenLoaiSanPham"
            });

            LoadSanPhamTheoLoai(Id);
        }

        private void LoadSanPhamTheoLoai(int maLoaiSanPham)
        {
            try
            {
                // Lấy toàn bộ sản phẩm theo mã loại sản phẩm
                List<SanPhamDTO> allSanPhamList = sanPhamBLL.GetByMaLoaiSanPham(maLoaiSanPham);

                // Đếm số trang
                int totalRecords = allSanPhamList.Count;
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                // Lấy dữ liệu cho trang hiện tại
                var sanPhamPage = allSanPhamList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                // Gán dữ liệu vào DataGridView
                sanPhamList.DataSource = sanPhamPage;

                // Cập nhật thông tin phân trang
                lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            //this.Close();
            PhanLoaiForm formSua = new PhanLoaiForm();

            this.Controls.Clear();
            formSua.TopLevel = false;
            formSua.FormBorderStyle = FormBorderStyle.None;
            formSua.Dock = DockStyle.Fill;
            this.Controls.Add(formSua);
            formSua.Show();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadSanPhamTheoLoai(Id);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadSanPhamTheoLoai(Id);
            }
        }
    }
}
