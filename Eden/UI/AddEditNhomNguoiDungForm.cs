using System;
using System.Windows.Forms;

namespace Eden
{
    public partial class AddEditNhomNguoiDungForm : Form
    {
        private NHOMNGUOIDUNG _nnd; // Đối tượng nhóm người dùng để thêm hoặc sửa
        private bool _isEditMode; // Chế độ: true = sửa, false = thêm

        public NHOMNGUOIDUNG NhomNguoiDung => _nnd; // Thuộc tính để lấy dữ liệu sau khi thêm/sửa

        public AddEditNhomNguoiDungForm(NHOMNGUOIDUNG nnd = null)
        {
            InitializeComponent();
            _nnd = nnd ?? new NHOMNGUOIDUNG(); // Nếu nnd là null (thêm mới), tạo mới
            _isEditMode = nnd != null; // Nếu nnd không null, là chế độ sửa

            // Điền dữ liệu vào form nếu là chế độ sửa
            if (_isEditMode)
            {
                txtMaNhom.Text = _nnd.MaNhomNguoiDung;
                txtTenNhom.Text = _nnd.TenNhomNguoiDung;
                txtMaNhom.Enabled = false; // Không cho sửa mã nhóm khi chỉnh sửa
                this.Text = "Sửa Nhóm Người Dùng";
            }
            else
            {
                this.Text = "Thêm Nhóm Người Dùng";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNhom.Text) || string.IsNullOrWhiteSpace(txtTenNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Nhóm và Tên Nhóm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật dữ liệu vào đối tượng _nnd
            _nnd.MaNhomNguoiDung = txtMaNhom.Text;
            _nnd.TenNhomNguoiDung = txtTenNhom.Text;

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