using System;
using System.Linq;
using System.Windows.Forms;
using Eden.BLLCustom;
using Eden.DTO;
using Eden.Eden;
using Eden.UI;
using Guna.UI2.WinForms;
using Eden;

namespace Eden
{
    public partial class NhapKhoFormAdd : Form
    {
        private string maPhieuNhap;
        private PHIEUNHAPBLL phieuNhapBLL;
        private NHACUNGCAPBLL nhaCungCapBLL;
        private SANPHAMBLL sanPHAMBLL = new SANPHAMBLL();
        private NGUOIDUNGBLL nguoiDungBLL = new NGUOIDUNGBLL();
        private CHITIETPHIEUNHAPBLL chiTietPhieuNhapBLL = new CHITIETPHIEUNHAPBLL();

        public NhapKhoFormAdd(string maPhieuNhap = "")
        {
            InitializeComponent();
            this.maPhieuNhap = maPhieuNhap;

            phieuNhapBLL = new PHIEUNHAPBLL();
            nhaCungCapBLL = new NHACUNGCAPBLL();

            LoadNhaCungCap(); // Gọi trước để cmbNhaCungCap luôn được khởi tạo dữ liệu
            LoadSanPham();
            LoadIDNguoiDung();

            if (!string.IsNullOrEmpty(maPhieuNhap))
            {
                LoadData(maPhieuNhap); // Gọi sau khi đã có danh sách nhà cung cấp
            }
        }

        private void LoadNhaCungCap()
        {
            try
            {
                var list = nhaCungCapBLL.GetAll();
                cmbNhaCungCap.DataSource = list;
                cmbNhaCungCap.DisplayMember = "TenNhaCungCap";
                cmbNhaCungCap.ValueMember = "id"; // Chỉ cần id vì MaNhaCungCap được sinh tự động
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhà cung cấp: " + ex.Message);
            }
        }

        private void LoadSanPham()
        {
            try
            {
                var list = sanPHAMBLL.GetAll();
                cmbTenSP.DataSource = list;
                cmbTenSP.DisplayMember = "TenSanPham";
                cmbTenSP.ValueMember = "id"; // Giả sử "id" là khóa chính của sản phẩm
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadIDNguoiDung()
        {
            try
            {
                var list = nguoiDungBLL.GetAll();
                if (list.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy người dùng nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cmbIDNguoiDung.DataSource = list;
                cmbIDNguoiDung.DisplayMember = "TenNguoiDung";
                cmbIDNguoiDung.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load dữ liệu nếu là sửa phiếu nhập
        private void LoadData(string maPhieuNhap)
        {
            Console.WriteLine($"Đang tải dữ liệu cho MaPhieuNhap: {maPhieuNhap}");
            var phieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
            if (phieuNhap == null)
            {
                MessageBox.Show($"Không tìm thấy phiếu nhập với mã {maPhieuNhap}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //txtMaPhieuNhap.Text = phieuNhap.MaPhieuNhap;

            //txtMaPhieuNhap.ReadOnly = true; // Ngăn chỉnh sửa MaPhieuNhap
            dtpNgayNhap.Value = phieuNhap.NgayNhap;

            // Tải danh sách nhà cung cấp
            var nhaCungCapList = nhaCungCapBLL.GetAll();
            cmbNhaCungCap.DataSource = nhaCungCapList;
            cmbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cmbNhaCungCap.ValueMember = "id";
            cmbNhaCungCap.SelectedValue = phieuNhap.idNhaCungCap;

            // Tải danh sách người dùng
            var nguoiDungList = nguoiDungBLL.GetAll();
            cmbIDNguoiDung.DataSource = nguoiDungList;
            cmbIDNguoiDung.DisplayMember = "TenNguoiDung";
            cmbIDNguoiDung.ValueMember = "id";
            cmbIDNguoiDung.SelectedValue = phieuNhap.idNguoiDung;

            // Tải chi tiết phiếu nhập (nếu có)
            var chiTietList = phieuNhapBLL.GetChiTietByPhieuNhap(phieuNhap.id); // Sử dụng phieuNhapBLL
            if (chiTietList != null && chiTietList.Any())
            {
                // Lấy chi tiết đầu tiên (hoặc điều chỉnh nếu cần hiển thị nhiều chi tiết)
                var chiTiet = chiTietList.First();
                var sanPhamList = sanPHAMBLL.GetAll(); // Giả sử bạn có SANPHAMBLL
                cmbTenSP.DataSource = sanPhamList;
                cmbTenSP.DisplayMember = "TenSanPham";
                cmbTenSP.ValueMember = "idSanPham";
                cmbTenSP.SelectedValue = chiTiet.idSanPham;

                txtSoLuong.Text = chiTiet.SoLuong.ToString();
                txtDonGia.Text = chiTiet.DonGia.ToString();
            }
            else
            {
                // Để trống nếu không có chi tiết
                cmbTenSP.SelectedIndex = -1;
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
            }
        }

        // Lưu phiếu nhập (Thêm hoặc Sửa)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (cmbNhaCungCap.SelectedValue == null || !int.TryParse(cmbNhaCungCap.SelectedValue.ToString(), out int idNhaCungCap))
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbIDNguoiDung.SelectedValue == null || !int.TryParse(cmbIDNguoiDung.SelectedValue.ToString(), out int idNguoiDung))
                {
                    MessageBox.Show("Vui lòng chọn người dùng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var phieuNhap = new PHIEUNHAP
                {
                    NgayNhap = dtpNgayNhap.Value,
                    idNhaCungCap = idNhaCungCap,
                    idNguoiDung = idNguoiDung,
                    TongTien = 0 // Sẽ cập nhật sau
                };

                // Thêm hoặc cập nhật phiếu nhập
                if (string.IsNullOrEmpty(maPhieuNhap))
                {
                    try
                    {
                        bool isAdded = phieuNhapBLL.Add(phieuNhap);
                        if (isAdded)
                        {
                            // Lấy id của phiếu nhập vừa thêm
                            var addedPhieuNhap = phieuNhapBLL.GetById(phieuNhap.id); // Giả sử có GetById
                            if (addedPhieuNhap != null)
                            {
                                phieuNhap.id = addedPhieuNhap.id;
                                maPhieuNhap = addedPhieuNhap.MaPhieuNhap;
                                MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy phiếu nhập vừa thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thêm phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Thêm phiếu nhập thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        // Lấy id từ maPhieuNhap
                        var existingPhieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
                        if (existingPhieuNhap == null)
                        {
                            MessageBox.Show($"Phiếu nhập với mã {maPhieuNhap} không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        phieuNhap.id = existingPhieuNhap.id; // Gán id để cập nhật
                        bool isUpdated = phieuNhapBLL.Update(phieuNhap);
                        if (isUpdated)
                        {
                            MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Cập nhật phiếu nhập thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Thêm hoặc cập nhật chi tiết phiếu nhập
                var selectedSanPham = cmbTenSP.SelectedItem as SanPhamDTO;
                if (selectedSanPham != null)
                {
                    if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
                    {
                        MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var chiTietPhieuNhap = new CHITIETPHIEUNHAP
                    {
                        idPhieuNhap = phieuNhap.id,
                        idSanPham = selectedSanPham.idSanPham,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        ThanhTien = soLuong * donGia
                    };

                    try
                    {
                        // Kiểm tra xem chi tiết đã tồn tại chưa
                        var existingChiTiet = phieuNhapBLL.GetChiTietByPhieuNhap(phieuNhap.id)
                            .FirstOrDefault(c => c.idSanPham == chiTietPhieuNhap.idSanPham);
                        if (existingChiTiet != null)
                        {
                            chiTietPhieuNhapBLL.Update(chiTietPhieuNhap);
                        }
                        else
                        {
                            chiTietPhieuNhapBLL.Add(chiTietPhieuNhap);
                        }

                        // Cập nhật TongTien
                        var chiTietList = phieuNhapBLL.GetChiTietByPhieuNhap(phieuNhap.id);
                        phieuNhap.TongTien = chiTietList.Sum(c => c.ThanhTien);
                        phieuNhapBLL.Update(phieuNhap);
                        MessageBox.Show("Lưu chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lưu chi tiết phiếu nhập thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định khi lưu phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hủy bỏ và đóng form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SanPhamFormAdd formAdd = new SanPhamFormAdd())
            {
                formAdd.FormClosed += (s, args) =>
                {
                    try
                    {
                        // Lấy lại danh sách sản phẩm mới nhất
                        var sanPhamList = sanPHAMBLL.GetAll();
                        cmbTenSP.DataSource = null;
                        cmbTenSP.DataSource = sanPhamList;
                        cmbTenSP.DisplayMember = "TenSanPham";
                        cmbTenSP.ValueMember = "id";

                        // Tự động chọn sản phẩm vừa mới thêm (sắp xếp theo id giảm dần)
                        var lastSanPham = sanPhamList.OrderByDescending(sp => sp.MaSanPham).FirstOrDefault();
                        if (lastSanPham != null)
                        {
                            cmbTenSP.SelectedValue = lastSanPham.MaSanPham;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật danh sách sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                formAdd.ShowDialog();
            }
        }
    }
}