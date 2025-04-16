using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NhapKhoFormAdd : Form
    {
        private string maPhieuNhap;
        private PHIEUNHAPBLL phieuNhapBLL;
        private NHACUNGCAPBLL nhaCungCapBLL;

        public NhapKhoFormAdd(string maPhieuNhap = "")
        {
            InitializeComponent();
            this.maPhieuNhap = maPhieuNhap;
            phieuNhapBLL = new PHIEUNHAPBLL();
            nhaCungCapBLL = new NHACUNGCAPBLL();

            if (!string.IsNullOrEmpty(maPhieuNhap))
            {
                LoadData(maPhieuNhap);
            }
        }

        // Load dữ liệu nếu là sửa phiếu nhập
        private void LoadData(string maPhieuNhap)
        {
            var phieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
            if (phieuNhap != null)
            {
                txtMaPhieuNhap.Text = phieuNhap.MaPhieuNhap;
                dtpNgayNhap.Value = phieuNhap.NgayNhap;
                cmbNhaCungCap.SelectedItem = phieuNhap.NHACUNGCAP.TenNhaCungCap;
            }
        }

        // Lưu phiếu nhập (Thêm hoặc Sửa)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var phieuNhap = new PHIEUNHAP
                {
                    MaPhieuNhap = txtMaPhieuNhap.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    TenNhaCungCap = (cmbNhaCungCap.SelectedItem as NHACUNGCAP)?.TenNhaCungCap
                };

                if (string.IsNullOrEmpty(maPhieuNhap))
                {
                    // Thêm mới phiếu nhập
                    phieuNhapBLL.Add(phieuNhap);
                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cập nhật phiếu nhập
                    phieuNhapBLL.Update(phieuNhap);
                    MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hủy bỏ và đóng form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Guna.UI2.WinForms.Guna2TextBox txtMaPhieuNhap;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayNhap;
        private Guna.UI2.WinForms.Guna2ComboBox cmbNhaCungCap;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;

    }
}
