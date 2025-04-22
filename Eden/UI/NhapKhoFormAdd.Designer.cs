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
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();

            //this.txtMaPhieuNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpNgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbNhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();

            this.cmbTenSP = new Guna.UI2.WinForms.Guna2ComboBox(); // Đổi từ txtTenSP
            this.txtSoLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDonGia = new Guna.UI2.WinForms.Guna2TextBox();

            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();

            this.SuspendLayout();

            // txtMaPhieuNhap
            //this.txtMaPhieuNhap.Location = new System.Drawing.Point(20, 20);
            //this.txtMaPhieuNhap.Size = new System.Drawing.Size(300, 36);
            //this.txtMaPhieuNhap.PlaceholderText = "Mã phiếu nhập";

            // dtpNgayNhap
            this.dtpNgayNhap.Location = new System.Drawing.Point(20, 70);
            this.dtpNgayNhap.Size = new System.Drawing.Size(300, 36);

            // cmbNhaCungCap
            this.cmbNhaCungCap.Location = new System.Drawing.Point(20, 120);
            this.cmbNhaCungCap.Size = new System.Drawing.Size(300, 36);

            // cmbTenSP
            this.cmbTenSP.Location = new System.Drawing.Point(20, 180);
            this.cmbTenSP.Size = new System.Drawing.Size(240, 36);
            this.cmbTenSP.Text = "Tên SP";
            // cmbIDNguoiDung
            this.cmbIDNguoiDung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbIDNguoiDung.Location = new System.Drawing.Point(20, 270); // dưới cmbTenSP
            this.cmbIDNguoiDung.Size = new System.Drawing.Size(300, 36);
            this.cmbIDNguoiDung.Text = "ID Người Dùng";
            



            // btnThem
            this.btnThem.Location = new System.Drawing.Point(270, 180); // Cách phải 10px
            this.btnThem.Size = new System.Drawing.Size(70, 36);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new EventHandler(this.btnThem_Click);


            // txtSoLuong
            this.txtSoLuong.Location = new System.Drawing.Point(20, 320);
            this.txtSoLuong.Size = new System.Drawing.Size(140, 36);
            this.txtSoLuong.PlaceholderText = "Số lượng";

            // txtDonGia
            this.txtDonGia.Location = new System.Drawing.Point(170, 320 );
            this.txtDonGia.Size = new System.Drawing.Size(140, 36);
            this.txtDonGia.PlaceholderText = "Đơn giá";

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(20, 380);
            this.btnSave.Size = new System.Drawing.Size(100, 36);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(130, 380);
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(500, 450);
            //this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.cmbNhaCungCap);
            this.Controls.Add(this.cmbTenSP); // Thêm combo box
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnThem); // Thêm vào Form
            this.Controls.Add(this.cmbIDNguoiDung);


            this.Name = "NhapKhoFormAdd";
            this.Text = "Thêm/Sửa Phiếu Nhập";

            this.ResumeLayout(false);
        }

        

        #endregion
    }
}