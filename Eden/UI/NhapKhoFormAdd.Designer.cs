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
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();

            this.SuspendLayout();

            // txtMaPhieuNhap
            this.txtMaPhieuNhap.Cursor = Cursors.IBeam;
            this.txtMaPhieuNhap.DefaultText = "";
            this.txtMaPhieuNhap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtMaPhieuNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtMaPhieuNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtMaPhieuNhap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtMaPhieuNhap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtMaPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaPhieuNhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(12, 12);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.PasswordChar = '\0';
            this.txtMaPhieuNhap.PlaceholderText = "Mã phiếu nhập";
            this.txtMaPhieuNhap.SelectedText = "";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(300, 36);
            this.txtMaPhieuNhap.TabIndex = 0;

            // dtpNgayNhap
            this.dtpNgayNhap.CheckedState.Parent = this.dtpNgayNhap;
            this.dtpNgayNhap.FillColor = System.Drawing.Color.White;
            this.dtpNgayNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgayNhap.HoverState.Parent = this.dtpNgayNhap;
            this.dtpNgayNhap.Location = new System.Drawing.Point(12, 54);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(300, 36);
            this.dtpNgayNhap.TabIndex = 1;

            // cmbNhaCungCap
            this.cmbNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbNhaCungCap.ForeColor = System.Drawing.Color.Black;
            this.cmbNhaCungCap.FormattingEnabled = true;
            this.cmbNhaCungCap.Location = new System.Drawing.Point(12, 96);
            this.cmbNhaCungCap.Name = "cmbNhaCungCap";
            this.cmbNhaCungCap.Size = new System.Drawing.Size(300, 36);
            this.cmbNhaCungCap.TabIndex = 2;

            // btnSave
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(118, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // NhapKhoFormAdd
            this.ClientSize = new System.Drawing.Size(330, 200);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.cmbNhaCungCap);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "NhapKhoFormAdd";
            this.Text = "Thêm/Sửa Phiếu Nhập Kho";

            this.ResumeLayout(false);
        }

        #endregion
    }
}