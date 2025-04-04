using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Eden
{
    public partial class NhapKhoForm : Form
    {
        private PHIEUNHAPBLL phieuNhapBLL;

        public NhapKhoForm()
        {
            InitializeComponent();
            phieuNhapBLL = new PHIEUNHAPBLL();
            LoadData();
        }

        // Hàm Load dữ liệu phiếu nhập vào DataGridView
        private void LoadData()
        {
            try
            {
                var phieuNhaps = phieuNhapBLL.GetAll();
                dgvPhieuNhap.DataSource = phieuNhaps.Select(p => new
                {
                    p.MaPhieuNhap,
                    p.NgayNhap,
                    NhaCungCap = p.NHACUNGCAP.TenNhaCungCap,
                    NguoiDung = p.NGUOIDUNG.TenNguoiDung
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu nhập: " + ex.Message);
            }
        }

        // Sự kiện Thêm phiếu nhập
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NhapKhoFormAdd formAdd = new NhapKhoFormAdd();
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        // Sự kiện Sửa phiếu nhập
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để sửa.");
                return;
            }

            string maPhieuNhap = dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value.ToString();
            NhapKhoFormAdd formAdd = new NhapKhoFormAdd(maPhieuNhap);
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        // Sự kiện Xóa phiếu nhập

        // Sự kiện Tìm kiếm phiếu nhập
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            var phieuNhaps = phieuNhapBLL.GetAll()
                                           .Where(p => p.MaPhieuNhap.ToLower().Contains(searchTerm) ||
                                                       p.NHACUNGCAP.TenNhaCungCap.ToLower().Contains(searchTerm) ||
                                                       p.NGUOIDUNG.TenNguoiDung.ToLower().Contains(searchTerm))
                                           .ToList();
            dgvPhieuNhap.DataSource = phieuNhaps.Select(p => new
            {
                p.MaPhieuNhap,
                p.NgayNhap,
                NhaCungCap = p.NHACUNGCAP.TenNhaCungCap,
                NguoiDung = p.NGUOIDUNG.TenNguoiDung
            }).ToList();
        }

        // Sự kiện Refresh lại danh sách phiếu nhập
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm khởi tạo giao diện cho form chính này
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa.");
                return;
            }

            string maPhieuNhap = dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value.ToString();
            PHIEUNHAP phieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);

            if (phieuNhap != null)
            {
                var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu nhập này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    phieuNhapBLL.Delete(phieuNhap);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Phiếu nhập không tồn tại.");
            }
        }

        private DataGridView dgvPhieuNhap;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
