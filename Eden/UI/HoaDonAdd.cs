using System;
using Eden;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden.DTO;

namespace Eden.UI
{
    public partial class HoaDonAdd : Form
    {
        private HOADONBLL hoaDonBLL;
        private KHACHHANGBLL khachHangBLL;
        private SANPHAMBLL sanPhamBLL;
        private List<ChiTietHoaDonDTO> chiTietList; // Danh sách chi tiết hóa đơn

        public HoaDonAdd()
        {
            InitializeComponent();
            hoaDonBLL = new HOADONBLL();
            khachHangBLL = new KHACHHANGBLL();
            sanPhamBLL = new SANPHAMBLL();
            chiTietList = new List<ChiTietHoaDonDTO>();

            // Kiểm tra đăng nhập
            if (CurrentUser.Id == 0)
            {
                MessageBox.Show("Vui lòng đăng nhập để tiếp tục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Thiết lập DateTimePicker
            dtpNgayLap.Value = DateTime.Now;

            // Load danh sách khách hàng vào ComboBox
            var khachHangList = khachHangBLL.GetAll();
            cbKhachHang.DataSource = khachHangList;
            cbKhachHang.DisplayMember = "MaKhachHang";
            cbKhachHang.ValueMember = "id";

            cbKhachHang.SelectedIndexChanged += cbKhachHang_SelectedIndexChanged;

            // Hiển thị thông tin khách hàng mặc định (nếu có khách hàng được chọn)
            if (cbKhachHang.SelectedItem != null)
            {
                var khachHang = cbKhachHang.SelectedItem as KHACHHANG;
                string tenKhachHang = khachHang.TenKhachHang ?? "Không có tên";
                string soDienThoai = khachHang.SoDienThoai ?? "Không có SĐT";
                lblKhachHangInfo.Text = $"Tên: {tenKhachHang} | SĐT: {soDienThoai}";
            }

            // Hiển thị tên người dùng
            lblNguoiDung.Text = $"{CurrentUser.Username} ({CurrentUser.Role})";

            // Load danh sách sản phẩm vào ComboBox
            var sanPhamList = sanPhamBLL.GetAll();
            cbSanPham.DataSource = sanPhamList;
            cbSanPham.DisplayMember = "TenSanPham";
            cbSanPham.ValueMember = "MaSanPham";

            // Thiết lập DataGridView cho chi tiết hóa đơn
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSanPham",
                HeaderText = "Mã Sản Phẩm",
                Name = "idSanPham"
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSanPham",
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSanPham"
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số Lượng",
                Name = "SoLuong"
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn Giá",
                Name = "DonGia"
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành Tiền",
                Name = "ThanhTien"
            });
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            using (KhachHangadd formAdd = new KhachHangadd())
            {
                formAdd.FormClosed += (s, args) =>
                {
                    var khachHangList = khachHangBLL.GetAll();
                    cbKhachHang.DataSource = khachHangList;
                    cbKhachHang.DisplayMember = "MaKhachHang";
                    cbKhachHang.ValueMember = "id";

                    // Tự động chọn khách hàng mới nhất
                    var lastKhachHang = khachHangList.LastOrDefault();
                    if (lastKhachHang != null)
                    {
                        cbKhachHang.SelectedValue = lastKhachHang.id;
                    }
                };
                formAdd.ShowDialog();
            }
        }

        private void cbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhachHang.SelectedItem != null)
            {
                var khachHang = cbKhachHang.SelectedItem as KHACHHANG;
                string tenKhachHang = khachHang.TenKhachHang ?? "Không có tên";
                string soDienThoai = khachHang.SoDienThoai ?? "Không có SĐT";
                lblKhachHangInfo.Text = $"Tên: {tenKhachHang} | SĐT: {soDienThoai}";
            }
            else
            {
                lblKhachHangInfo.Text = "Tên: | SĐT: ";
            }
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (cbSanPham.SelectedItem == null || string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sanPham = cbSanPham.SelectedItem as SANPHAM;
            if (sanPham.SoLuong < soLuong)
            {
                MessageBox.Show($"Số lượng tồn của sản phẩm {sanPham.TenSanPham} không đủ. Hiện tại chỉ còn {sanPham.SoLuong} sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo chi tiết hóa đơn
            var chiTiet = new ChiTietHoaDonDTO
            {
                idSanPham = sanPham.id,
                MaSanPham = sanPham.MaSanPham,
                TenSanPham = sanPham.TenSanPham,
                SoLuong = soLuong,
                DonGia = sanPham.Gia,
                ThanhTien = soLuong * sanPham.Gia
            };

            chiTietList.Add(chiTiet);
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = chiTietList;

            // Cập nhật tổng tiền
            decimal tongTien = chiTietList.Sum(ct => ct.ThanhTien);
            lblTongTien.Text = $"{tongTien:N0}";

            // Reset số lượng
            txtSoLuong.Text = "";
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count > 0)
            {
                var chiTiet = dgvChiTiet.SelectedRows[0].DataBoundItem as ChiTietHoaDonDTO;
                chiTietList.Remove(chiTiet);
                dgvChiTiet.DataSource = null;
                dgvChiTiet.DataSource = chiTietList;

                // Cập nhật tổng tiền
                decimal tongTien = chiTietList.Sum(ct => ct.ThanhTien);
                lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chi tiết hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chiTietList.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm vào hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbKhachHang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo hóa đơn
                var hoaDon = new HOADON
                {
                    NgayLap = dtpNgayLap.Value,
                    idKhachHang = (int)cbKhachHang.SelectedValue,
                    idNguoiDung = CurrentUser.Id, // Lấy idNguoiDung từ CurrentUser
                    TongTien = chiTietList.Sum(ct => ct.ThanhTien)
                };

                // Tạo MaHoaDon tự động
                var hoaDonList = hoaDonBLL.GetAll();
                int soThuTu = hoaDonList.Count + 1;
                hoaDon.MaHoaDon = $"HD{soThuTu:D4}"; // Ví dụ: HD0001, HD0002, ...

                // Lưu hóa đơn và chi tiết hóa đơn
                hoaDonBLL.Add(hoaDon, chiTietList);

                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}