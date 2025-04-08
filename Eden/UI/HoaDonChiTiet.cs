using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden; // Thêm namespace để sử dụng CHITIETHOADONBLL

namespace Eden.UI
{
    public partial class HoaDonChiTiet : Form
    {
        private CHITIETHOADONBLL chiTietHoaDonBLL;
        private int idHoaDon; // Lưu idHoaDon được truyền từ HoaDonForm

        public HoaDonChiTiet(int idHoaDon)
        {
            InitializeComponent();
            this.idHoaDon = idHoaDon;
            chiTietHoaDonBLL = new CHITIETHOADONBLL();

            // Cấu hình DataGridView
            dgchitietHD.AutoGenerateColumns = false;
            dgchitietHD.Columns.Clear();
            dgchitietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaHoaDon",
                HeaderText = "Mã Hóa Đơn"
            });
            dgchitietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSanPham",
                HeaderText = "Mã Sản Phẩm"
            });
            dgchitietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSanPham",
                HeaderText = "Tên Sản Phẩm"
            });
            dgchitietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số Lượng"
            });
            dgchitietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn Giá"
            });
            dgchitietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành Tiền"
            });

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var chiTietList = chiTietHoaDonBLL.GetByHoaDonId(idHoaDon);
                dgchitietHD.DataSource = null;
                dgchitietHD.DataSource = chiTietList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgchitietHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể thêm xử lý nếu cần (ví dụ: hiển thị thông tin chi tiết hơn)
        }

        private void back_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại và quay lại HoaDonForm
            this.Close();
        }

        private void HoaDonChiTiet_Load(object sender, EventArgs e)
        {

        }
    }
}