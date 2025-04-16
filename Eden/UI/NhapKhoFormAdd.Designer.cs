using System.Windows.Forms;
using System;

namespace Eden
{
    partial class NhapKhoFormAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMaPhieuNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbNhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();

            this.txtMaSP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenSP = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSoLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDonGia = new Guna.UI2.WinForms.Guna2TextBox();

            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();

            this.SuspendLayout();

            // txtMaPhieuNhap
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(20, 20);
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(300, 36);
            this.txtMaPhieuNhap.PlaceholderText = "Mã phiếu nhập";

            // dtpNgayNhap
            this.dtpNgayNhap.Location = new System.Drawing.Point(20, 70);
            this.dtpNgayNhap.Size = new System.Drawing.Size(300, 36);

            // cmbNhaCungCap
            this.cmbNhaCungCap.Location = new System.Drawing.Point(20, 120);
            this.cmbNhaCungCap.Size = new System.Drawing.Size(300, 36);

            // txtMaSP
            this.txtMaSP.Location = new System.Drawing.Point(20, 180);
            this.txtMaSP.Size = new System.Drawing.Size(140, 36);
            this.txtMaSP.PlaceholderText = "Mã SP";

            // txtTenSP
            this.txtTenSP.Location = new System.Drawing.Point(170, 180);
            this.txtTenSP.Size = new System.Drawing.Size(300, 36);
            this.txtTenSP.PlaceholderText = "Tên SP";

            // txtSoLuong
            this.txtSoLuong.Location = new System.Drawing.Point(20, 230);
            this.txtSoLuong.Size = new System.Drawing.Size(140, 36);
            this.txtSoLuong.PlaceholderText = "Số lượng";

            // txtDonGia
            this.txtDonGia.Location = new System.Drawing.Point(170, 230);
            this.txtDonGia.Size = new System.Drawing.Size(140, 36);
            this.txtDonGia.PlaceholderText = "Đơn giá";

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(20, 290);
            this.btnSave.Size = new System.Drawing.Size(100, 36);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(130, 290);
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.cmbNhaCungCap);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "NhapKhoFormAdd";
            this.Text = "Thêm/Sửa Phiếu Nhập";

            this.ResumeLayout(false);
        }


        #endregion
    }
}