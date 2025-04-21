using System;
using System.Linq;
using System.Windows.Forms;
using Eden.BLLCustom;
using Eden.DTO;
using Eden.Eden;
using Eden.UI;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NhapKhoFormAdd : Form
    {
        private string maPhieuNhap;
        private PHIEUNHAPBLL phieuNhapBLL;
        private NHACUNGCAPBLL nhaCungCapBLL;
        private SANPHAMBLL sanPHAMBLL = new SANPHAMBLL();
        private NGUOIDUNGBLL nguoiDungBLL = new NGUOIDUNGBLL();


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
                cmbIDNguoiDung.DisplayMember = "TenNguoiDung"; // Hiển thị tên người dùng
                cmbIDNguoiDung.ValueMember = "id"; // Lấy id làm giá trị
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Load dữ liệu nếu là sửa phiếu nhập
        private void LoadData(string maPhieuNhap)
        {
            var phieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
            if (phieuNhap != null)
            {
                // Lấy thông tin phiếu nhập
                txtMaPhieuNhap.Text = phieuNhap.MaPhieuNhap;
                dtpNgayNhap.Value = phieuNhap.NgayNhap;

                // Lấy danh sách nhà cung cấp và hiển thị lên ComboBox
                var nhaCungCapList = nhaCungCapBLL.GetAll(); // Giả sử bạn có phương thức GetAll() trong NHACUNGCAPBLL
                cmbNhaCungCap.DataSource = nhaCungCapList;
                cmbNhaCungCap.DisplayMember = "TenNhaCungCap";  // Hiển thị tên nhà cung cấp
                cmbNhaCungCap.ValueMember = "MaNhaCungCap";    // Lưu mã nhà cung cấp khi người dùng chọn

                // Cập nhật lựa chọn hiện tại cho ComboBox (nếu đang sửa)
                if (!string.IsNullOrEmpty(maPhieuNhap))
                {
                    cmbNhaCungCap.SelectedValue = phieuNhap.idNhaCungCap; // Đặt giá trị nhà cung cấp hiện tại
                }
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
                    TongTien = 0 // Gán mặc định, sẽ cập nhật sau
                };

                // Thêm hoặc cập nhật phiếu nhập
                if (string.IsNullOrEmpty(maPhieuNhap))
                {
                    try
                    {
                        bool isAdded = phieuNhapBLL.Add(phieuNhap);
                        if (isAdded)
                        {
                            // Lấy lại phiếu nhập vừa thêm (dùng id để suy ra MaPhieuNhap)
                            var addedPhieuNhap = phieuNhapBLL.GetByMaPhieuNhap($"PN{phieuNhap.id:D4}");
                            if (addedPhieuNhap != null)
                            {
                                phieuNhap.id = addedPhieuNhap.id;
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
                            MessageBox.Show("Thêm phiếu nhập thất bại! Vui lòng kiểm tra dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    phieuNhapBLL.Update(phieuNhap);
                    MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Thêm chi tiết phiếu nhập
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

                    CHITIETPHIEUNHAPBLL chiTietBLL = new CHITIETPHIEUNHAPBLL();
                    try
                    {
                        chiTietBLL.Add(chiTietPhieuNhap);
                        // Cập nhật TongTien
                        phieuNhap.TongTien = chiTietPhieuNhap.ThanhTien; // Cộng dồn nếu có nhiều chi tiết
                        phieuNhapBLL.Update(phieuNhap);
                        MessageBox.Show("Thêm chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Thêm chi tiết phiếu nhập thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Lỗi cập nhật danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                formAdd.ShowDialog();
            }
        }



        private Guna.UI2.WinForms.Guna2TextBox txtMaPhieuNhap;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayNhap;
        private Guna.UI2.WinForms.Guna2ComboBox cmbNhaCungCap;
        private Guna.UI2.WinForms.Guna2ComboBox cmbIDNguoiDung;

        // Các textbox chi tiết sản phẩm
        private Guna.UI2.WinForms.Guna2Button btnThem;

        private Guna.UI2.WinForms.Guna2ComboBox cmbTenSP;
        private Guna.UI2.WinForms.Guna2TextBox txtSoLuong;
        private Guna.UI2.WinForms.Guna2TextBox txtDonGia;

        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;





    }
}
