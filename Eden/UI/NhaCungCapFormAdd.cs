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
    public partial class NhaCungCapFormAdd : Form
    {
        private NHACUNGCAPBLL nhaCungCapBLL;

        public NhaCungCapFormAdd()
        {
            InitializeComponent();
            nhaCungCapBLL = new NHACUNGCAPBLL();
            GenerateSupplierID();
        }

        private void GenerateSupplierID()
        {
            var nhaCungCapList = nhaCungCapBLL.GetAll();

            if (nhaCungCapList.Count > 0)
            {
                var lastNhaCungCap = nhaCungCapList
                    .Where(n => n.MaNhaCungCap.StartsWith("NCC") && int.TryParse(n.MaNhaCungCap.Substring(3), out _))
                    .OrderByDescending(n => int.Parse(n.MaNhaCungCap.Substring(3)))
                    .FirstOrDefault();

                if (lastNhaCungCap != null)
                {
                    int lastNumber = int.Parse(lastNhaCungCap.MaNhaCungCap.Substring(3));
                    txtMaNhaCungCap.Text = $"NCC{(lastNumber + 1):D3}";
                }
                else
                {
                    txtMaNhaCungCap.Text = "NCC001";
                }
            }
            else
            {
                txtMaNhaCungCap.Text = "NCC001";
            }

            txtMaNhaCungCap.ReadOnly = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
                if (string.IsNullOrWhiteSpace(txtMaNhaCungCap.Text) || string.IsNullOrWhiteSpace(txtTenNhaCungCap.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Tất cả các trường (Mã, Tên, Địa chỉ, Số điện thoại, Email) không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng số điện thoại (ví dụ: chỉ chứa số và độ dài hợp lệ)
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtSoDienThoai.Text.Trim(), @"^\d{10}$"))
                {
                    MessageBox.Show("Số điện thoại phải là 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng email (cơ bản)
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NHACUNGCAP ncc = new NHACUNGCAP
                {
                    MaNhaCungCap = txtMaNhaCungCap.Text.Trim(),
                    TenNhaCungCap = txtTenNhaCungCap.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                // Kiểm tra trùng MaNhaCungCap
                var existingNCC = nhaCungCapBLL.GetAll().FirstOrDefault(n => n.MaNhaCungCap == ncc.MaNhaCungCap);
                if (existingNCC != null)
                {
                    MessageBox.Show($"Mã nhà cung cấp {ncc.MaNhaCungCap} đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nhaCungCapBLL.Add(ncc);
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}