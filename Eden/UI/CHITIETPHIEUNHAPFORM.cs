using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Eden;
using Guna.UI2.WinForms;

namespace Eden.UI
{
    public partial class CHITIETPHIEUNHAPFORM : Form
    {
        private readonly int _idPhieuNhap;
        private readonly PHIEUNHAPDAL dal = new PHIEUNHAPDAL();

        public CHITIETPHIEUNHAPFORM(int idPhieuNhap)
        {
            InitializeComponent();  // RẤT QUAN TRỌNG
            _idPhieuNhap = idPhieuNhap;
            LoadData();
        }

        // Constructor phụ dùng string → gọi lại constructor chính
        public CHITIETPHIEUNHAPFORM(string maPhieuNhap)
            : this(GetIdPhieuNhapFromMa(maPhieuNhap))
        {
        }

        // Hàm hỗ trợ convert từ mã phiếu nhập sang id
        private static int GetIdPhieuNhapFromMa(string maPhieuNhap)
        {
            // Ví dụ bạn có thể truy vấn DB để lấy id từ maPhieuNhap
            using (var db = new QLBanHoaEntities())
            {
                var phieu = db.PHIEUNHAPs.FirstOrDefault(p => p.MaPhieuNhap == maPhieuNhap);
                return phieu?.id ?? 0;
            }
        }

        private void LoadData()
        {
            try
            {
                using (var db = new QLBanHoaEntities())
                {
                    var data = dal.GetChiTietByPhieuNhap(_idPhieuNhap)
                                  .Select(c => new
                                  {
                                      MaPhieuNhap = db.PHIEUNHAPs
                                                     .Where(p => p.id == c.idPhieuNhap)
                                                     .Select(p => p.MaPhieuNhap)
                                                     .FirstOrDefault() ?? "N/A",
                                      MaSanPham = c.SANPHAM != null ? c.SANPHAM.MaSanPham : "N/A", // Thay idSanPham bằng MaSanPham
                                      TenSanPham = c.SANPHAM != null ? c.SANPHAM.TenSanPham : "N/A",
                                      c.SoLuong,
                                      c.DonGia,
                                      c.ThanhTien
                                  }).ToList();

                    dgvChiTiet.DataSource = data;

                    // Cập nhật tiêu đề cột
                    dgvChiTiet.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
                    dgvChiTiet.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm"; // Cập nhật tiêu đề
                    dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                    dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu chi tiết phiếu nhập: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            //this.Close();
            NhapKhoForm form = new NhapKhoForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }
    }
}