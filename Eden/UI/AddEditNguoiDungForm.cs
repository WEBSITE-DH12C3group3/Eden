using System;
using System.Linq;
using System.Windows.Forms;

namespace Eden
{
    public partial class AddEditNguoiDungForm : Form
    {
        private NGUOIDUNG _nd; // Đối tượng người dùng để thêm hoặc sửa
        private bool _isEditMode; // Chế độ: true = sửa, false = thêm
        private NHOMNGUOIDUNGBLL _nhomBll = new NHOMNGUOIDUNGBLL();

        public NGUOIDUNG NguoiDung => _nd; // Thuộc tính để lấy dữ liệu sau khi thêm/sửa

        public AddEditNguoiDungForm(NGUOIDUNG nd = null)
        {
            InitializeComponent();
            _nd = nd ?? new NGUOIDUNG(); // Nếu nd là null (thêm mới), tạo mới
            _isEditMode = nd != null; // Nếu nd không null, là chế độ sửa

            // Load danh sách nhóm người dùng vào ComboBox
            LoadNhomNguoiDung();

            // Điền dữ liệu vào form nếu là chế độ sửa
            if (_isEditMode)
            {
                txtTenDangNhap.Text = _nd.TenDangNhap;
                txtMatKhau.Text = _nd.MatKhau;
                txtTenDangNhap.Enabled = false; // Không cho sửa tên đăng nhập khi chỉnh sửa
                cboNhomNguoiDung.SelectedValue = _nd.idNhomNguoiDung;
                this.Text = "Sửa Người Dùng";
            }
            else
            {
                this.Text = "Thêm Người Dùng";
            }
        }

        private void LoadNhomNguoiDung()
        {
            try
            {
                var nhomList = _nhomBll.GetAll();
                cboNhomNguoiDung.DataSource = nhomList;
                cboNhomNguoiDung.DisplayMember = "TenNhomNguoiDung";
                cboNhomNguoiDung.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhóm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text) || cboNhomNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật dữ liệu vào đối tượng _nd
            _nd.TenDangNhap = txtTenDangNhap.Text;
            _nd.MatKhau = txtMatKhau.Text;
            _nd.idNhomNguoiDung = (int)cboNhomNguoiDung.SelectedValue;

            this.DialogResult = DialogResult.OK; // Đóng form và trả về kết quả OK
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đóng form và trả về kết quả Cancel
            this.Close();
        }
    }
}