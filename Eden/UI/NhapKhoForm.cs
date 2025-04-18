using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Eden
{
    public partial class NhapKhoForm : Form
    {
        private PHIEUNHAPBLL phieuNhapBLL;
        private CHITIETPHIEUNHAPBLL chiTietPhieuNhapBLL; // Để lấy thông tin chi tiết phiếu nhập

        public object ChiTiet { get; private set; }

        public NhapKhoForm()
        {
            InitializeComponent();
            phieuNhapBLL = new PHIEUNHAPBLL();
            chiTietPhieuNhapBLL = new CHITIETPHIEUNHAPBLL(); // Khởi tạo để lấy dữ liệu từ bảng chi tiết phiếu nhập
            LoadData();
        }

        // Hàm Load dữ liệu phiếu nhập vào DataGridView
        private void LoadData(string searchTerm = "")
        {
            try
            {
                var phieuNhaps = string.IsNullOrEmpty(searchTerm) ? phieuNhapBLL.GetAll() :
                                  phieuNhapBLL.GetAll()
                                              .Where(p => p.MaPhieuNhap.ToLower().Contains(searchTerm) ||
                                                          p.NHACUNGCAP.TenNhaCungCap.ToLower().Contains(searchTerm))
                                              .ToList();

                // Tính tổng tiền cho mỗi phiếu nhập từ chi tiết phiếu nhập
                var tongTienDict = phieuNhaps.ToDictionary(
                    p => p.MaPhieuNhap,
                    p => p.CHITIETPHIEUNHAPs.Sum(c => c.SoLuong * c.DonGia)
                );

                // Gán dữ liệu vào DataGridView (tính lại tổng tiền thủ công)
                var listDto = phieuNhaps.SelectMany(p => p.CHITIETPHIEUNHAPs, (p, c) => new
                {
                    MaPhieuNhap = p.MaPhieuNhap,
                    NgayNhap = p.NgayNhap.ToString("dd/MM/yyyy"),
                    TenNhaCungCap = p.NHACUNGCAP.TenNhaCungCap,
                    idNguoiDung = p.idNguoiDung,
                    TongTien = tongTienDict[p.MaPhieuNhap], // lấy từ dictionary
                    TenSanPham = c.SANPHAM.TenSanPham,
                    SoLuong = c.SoLuong,
                    DonGia = c.DonGia,
                    ThanhTien = c.SoLuong * c.DonGia
                }).ToList();

                dgvPhieuNhap.DataSource = listDto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phiếu nhập: " + ex.Message);
            }
        }




        // Sự kiện Thêm phiếu nhập
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var formAdd = new NhapKhoFormAdd())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
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
            using (var formAdd = new NhapKhoFormAdd(maPhieuNhap))
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        // Sự kiện Tìm kiếm phiếu nhập
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            LoadData(searchTerm);
        }

        // Sự kiện Refresh lại danh sách phiếu nhập
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Sự kiện Xóa phiếu nhập
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

        // Xuất dữ liệu ra Excel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ DataGridView
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvPhieuNhap.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in dgvPhieuNhap.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgvPhieuNhap.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value?.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Lưu Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Lưu file Excel",
                FileName = "DanhSach.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "DanhSach");
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Giao diện khởi tạo và sự kiện CellContentClick
        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Dòng này không còn cần thiết nữa, vì đã tối ưu hóa LoadData() trong sự kiện khác.
        }

        private void NhapKhoForm_Load(object sender, EventArgs e)
        {
            // Dòng này không cần thiết, LoadData đã được gọi trong constructor.
        }
        private Guna.UI2.WinForms.Guna2DataGridView dgvPhieuNhap;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
    }
}
