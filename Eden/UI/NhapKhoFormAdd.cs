﻿using System;
using System.Windows.Forms;

namespace Eden
{
    public partial class NhapKhoFormAdd : Form
    {
        private PHIEUNHAPBLL phieuNhapBLL;
        private string maPhieuNhap; // Mã phiếu nhập khi sửa
        private PHIEUNHAP currentPhieuNhap; // Phiếu nhập hiện tại khi sửa

        public NhapKhoFormAdd()
        {
            InitializeComponent();
            phieuNhapBLL = new PHIEUNHAPBLL();
            this.Text = "Thêm Phiếu Nhập";
            LoadNhapKho();
        }

        // Constructor cho Sửa phiếu nhập
        public NhapKhoFormAdd(string maPhieuNhap) : this()
        {
            this.maPhieuNhap = maPhieuNhap;
            this.Text = "Sửa Phiếu Nhập";
            LoadDataForEdit();
        }

        // Hàm Load dữ liệu cho việc Sửa phiếu nhập
        private void LoadDataForEdit()
        {
            try
            {
                currentPhieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
                if (currentPhieuNhap != null)
                {
                    txtMaPhieuNhap.Text = currentPhieuNhap.MaPhieuNhap;
                    dtpNgayNhap.Value = currentPhieuNhap.NgayNhap;
                    cmbNhaCungCap.SelectedItem = currentPhieuNhap.NHACUNGCAP;
                    cmbNguoiDung.SelectedItem = currentPhieuNhap.NGUOIDUNG;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void LoadNhapKho()
        {
            try
            {
                // Gọi BLL để lấy danh sách nhà cung cấp
                var phieuNhapBLL = new PHIEUNHAPBLL();
                var listNCC = phieuNhapBLL.GetAll();

                if (listNCC.Count > 0)
                {
                    // Gán dữ liệu cho ComboBox
                    cmbNhaCungCap.DataSource = listNCC;
                    cmbNhaCungCap.DisplayMember = "TenNhaCungCap"; // Hiển thị tên nhà cung cấp
                    cmbNhaCungCap.ValueMember = "MaNhaCungCap"; // Lưu mã nhà cung cấp
                }
                else
                {
                    MessageBox.Show("Không có nhà cung cấp nào trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Sự kiện Lưu (Thêm hoặc Sửa)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PHIEUNHAP phieuNhap = new PHIEUNHAP
                {
                    MaPhieuNhap = txtMaPhieuNhap.Text,
                    NgayNhap = dtpNgayNhap.Value,
                    idNhaCungCap = ((NHACUNGCAP)cmbNhaCungCap.SelectedItem).id,
                    idNguoiDung = ((NGUOIDUNG)cmbNguoiDung.SelectedItem).id
                };

                if (string.IsNullOrEmpty(maPhieuNhap))  
                {
                    // Thêm mới
                    phieuNhapBLL.Add(phieuNhap);
                    MessageBox.Show("Thêm phiếu nhập thành công.");
                }
                else
                {
                    // Sửa
                    phieuNhapBLL.Update(phieuNhap);
                    MessageBox.Show("Cập nhật phiếu nhập thành công.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện Hủy
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm khởi tạo giao diện cho form này
        

        private TextBox txtMaPhieuNhap;
        private DateTimePicker dtpNgayNhap;
        private ComboBox cmbNhaCungCap;
        private ComboBox cmbNguoiDung;
        private Button btnSave;
        private Button btnCancel;
        private Label lblMaPhieuNhap;
        private Label lblNgayNhap;
        private Label lblNhaCungCap;
        private Label lblNguoiDung;
    }
}
