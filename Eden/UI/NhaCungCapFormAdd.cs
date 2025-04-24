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
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NHACUNGCAP ncc = new NHACUNGCAP
                {
                    MaNhaCungCap = txtMaNhaCungCap.Text.Trim(),
                    TenNhaCungCap = txtTenNhaCungCap.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                nhaCungCapBLL.Add(ncc);
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}