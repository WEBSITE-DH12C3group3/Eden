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
                if (string.IsNullOrWhiteSpace(txtMaNhaCungCap.Text) || string.IsNullOrWhiteSpace(txtTenNhaCungCap.Text))
                {
                    MessageBox.Show("Mã và tên nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DialogResult = DialogResult.OK; // Báo hiệu thêm thành công
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}