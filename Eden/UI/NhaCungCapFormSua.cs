using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eden.UI
{
    public partial class NhaCungCapFormSua : Form
    {
        private NHACUNGCAPBLL nhaCungCapBLL;
        private string maNCC;

        public NhaCungCapFormSua(string maNCC)
        {
            InitializeComponent();
            this.nhaCungCapBLL = new NHACUNGCAPBLL();
            this.maNCC = maNCC;
            LoadNhaCungCap();
        }

        private void LoadNhaCungCap()
        {
            try
            {
                // Lấy thông tin nhà cung cấp từ cơ sở dữ liệu
                NHACUNGCAP ncc = nhaCungCapBLL.GetAll().FirstOrDefault(n => n.MaNhaCungCap == maNCC);

                if (ncc != null) // Nếu tìm thấy nhà cung cấp
                {
                    txtMaNhaCungCap.Text = ncc.MaNhaCungCap;
                    txtMaNhaCungCap.ReadOnly = true; // Không cho phép sửa mã NCC
                    txtTenNhaCungCap.Text = ncc.TenNhaCungCap;
                    txtDiaChi.Text = ncc.DiaChi;
                    txtSoDienThoai.Text = ncc.SoDienThoai;
                    txtEmail.Text = ncc.Email;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Đóng form nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu có lỗi
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.Close();
            NhaCungCapForm form = new NhaCungCapForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtTenNhaCungCap.Text))
                {
                    MessageBox.Show("Tên nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NHACUNGCAP ncc = new NHACUNGCAP
                {
                    MaNhaCungCap = maNCC,
                    TenNhaCungCap = txtTenNhaCungCap.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                nhaCungCapBLL.Update(ncc);

                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //DialogResult = DialogResult.OK; // Báo hiệu sửa thành công
                //Close();
                NhaCungCapForm formAdd = new NhaCungCapForm();
                this.Controls.Clear();
                formAdd.TopLevel = false;
                formAdd.FormBorderStyle = FormBorderStyle.None;
                formAdd.Dock = DockStyle.Fill;
                this.Controls.Add(formAdd);
                formAdd.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}