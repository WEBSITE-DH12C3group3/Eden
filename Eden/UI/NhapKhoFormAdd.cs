using System;
using System.Linq;
using System.Windows.Forms;
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
                var list = phieuNhapBLL.GetAll();
                cmbIDNguoiDung.DataSource = list;
                cmbIDNguoiDung.DisplayMember = "IDNguoiDung";
                cmbIDNguoiDung.ValueMember = "id";
            }
            catch (Exception ex) 
            {
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
                var phieuNhap = new PHIEUNHAP
                {
                    MaPhieuNhap = txtMaPhieuNhap.Text.Trim(),
                    NgayNhap = dtpNgayNhap.Value,
                    TenNhaCungCap = (cmbNhaCungCap.SelectedItem as NHACUNGCAP)?.TenNhaCungCap,
                    idNhaCungCap = Convert.ToInt32(cmbNhaCungCap.SelectedValue),
                    idNguoiDung = Convert.ToInt32(cmbIDNguoiDung.SelectedValue)

                };

                if (string.IsNullOrEmpty(maPhieuNhap))
                {
                    // Thêm mới
                    phieuNhapBLL.Add(phieuNhap);
                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cập nhật
                    phieuNhapBLL.Update(phieuNhap);
                    MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

               
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var sanPhamList = sanPHAMBLL.GetAll();
                    cmbTenSP.DataSource = sanPhamList;
                    cmbTenSP.DisplayMember = "TenSanPham"; // hoặc "MaSanPham" nếu bạn muốn hiển thị mã
                    cmbTenSP.ValueMember = "id";

                    var lastSanPham = sanPhamList.LastOrDefault();
                    if (lastSanPham != null)
                    {
                        cmbTenSP.SelectedValue = lastSanPham.MaSanPham;
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
