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
            this.Close();
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
