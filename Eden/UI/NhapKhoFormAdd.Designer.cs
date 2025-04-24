using System.Windows.Forms;
using System;
using Guna.UI2.WinForms;

namespace Eden
{
    partial class NhapKhoFormAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declare controls used in InitializeComponent
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayNhap;
        private Guna.UI2.WinForms.Guna2ComboBox cmbNhaCungCap;
        private Guna.UI2.WinForms.Guna2ComboBox cmbTenSP;
        private Guna.UI2.WinForms.Guna2TextBox txtSoLuong;
        private Guna.UI2.WinForms.Guna2TextBox txtDonGia;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2ComboBox cmbIDNguoiDung;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNgayNhap;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNhaCungCap;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenSP;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSoLuong;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDonGia;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNguoiDung;
        private Guna.UI2.WinForms.Guna2TextBox txtMaPhieuNhap;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        // New controls
        private Guna.UI2.WinForms.Guna2DataGridView dgvChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnAddChiTiet;
        private Guna.UI2.WinForms.Guna2Button btnRemoveChiTiet;

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

          

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.dtpNgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbNhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbTenSP = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSoLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDonGia = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbIDNguoiDung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.lblNgayNhap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNhaCungCap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTenSP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSoLuong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDonGia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNguoiDung = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtMaPhieuNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChiTiet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddChiTiet = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemoveChiTiet = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BorderRadius = 10;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(225, 238);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(151, 29);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm sản phẩm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.dtpNgayNhap.BorderRadius = 10;
            this.dtpNgayNhap.Checked = true;
            this.dtpNgayNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dtpNgayNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(185, 61);
            this.dtpNgayNhap.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayNhap.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayNhap.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(150, 29);
            this.dtpNgayNhap.TabIndex = 1;
            this.dtpNgayNhap.Value = new System.DateTime(2025, 4, 9, 10, 0, 46, 222);
            // 
            // cmbNhaCungCap
            // 
            this.cmbNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.cmbNhaCungCap.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.cmbNhaCungCap.BorderRadius = 10;
            this.cmbNhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhaCungCap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.cmbNhaCungCap.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.cmbNhaCungCap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.cmbNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhaCungCap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmbNhaCungCap.ItemHeight = 30;
            this.cmbNhaCungCap.Location = new System.Drawing.Point(185, 102);
            this.cmbNhaCungCap.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNhaCungCap.Name = "cmbNhaCungCap";
            this.cmbNhaCungCap.Size = new System.Drawing.Size(226, 36);
            this.cmbNhaCungCap.TabIndex = 2;
            // 
            // cmbTenSP
            // 
            this.cmbTenSP.BackColor = System.Drawing.Color.Transparent;
            this.cmbTenSP.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.cmbTenSP.BorderRadius = 10;
            this.cmbTenSP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTenSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTenSP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.cmbTenSP.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.cmbTenSP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.cmbTenSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTenSP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmbTenSP.ItemHeight = 30;
            this.cmbTenSP.Location = new System.Drawing.Point(185, 198);
            this.cmbTenSP.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTenSP.Name = "cmbTenSP";
            this.cmbTenSP.Size = new System.Drawing.Size(226, 36);
            this.cmbTenSP.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtSoLuong.BorderRadius = 10;
            this.txtSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoLuong.DefaultText = "";
            this.txtSoLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSoLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSoLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSoLuong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.txtSoLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtSoLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtSoLuong.Location = new System.Drawing.Point(185, 287);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtSoLuong.PlaceholderText = "Nhập số lượng";
            this.txtSoLuong.SelectedText = "";
            this.txtSoLuong.Size = new System.Drawing.Size(131, 29);
            this.txtSoLuong.TabIndex = 5;
            // 
            // txtDonGia
            // 
            this.txtDonGia.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtDonGia.BorderRadius = 10;
            this.txtDonGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDonGia.DefaultText = "";
            this.txtDonGia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDonGia.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDonGia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDonGia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.txtDonGia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtDonGia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtDonGia.Location = new System.Drawing.Point(185, 340);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtDonGia.PlaceholderText = "Nhập đơn giá";
            this.txtDonGia.SelectedText = "";
            this.txtDonGia.Size = new System.Drawing.Size(131, 29);
            this.txtDonGia.TabIndex = 6;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // cmbIDNguoiDung
            // 
            this.cmbIDNguoiDung.BackColor = System.Drawing.Color.Transparent;
            this.cmbIDNguoiDung.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.cmbIDNguoiDung.BorderRadius = 10;
            this.cmbIDNguoiDung.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbIDNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIDNguoiDung.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.cmbIDNguoiDung.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.cmbIDNguoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.cmbIDNguoiDung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIDNguoiDung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmbIDNguoiDung.ItemHeight = 30;
            this.cmbIDNguoiDung.Location = new System.Drawing.Point(185, 150);
            this.cmbIDNguoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.cmbIDNguoiDung.Name = "cmbIDNguoiDung";
            this.cmbIDNguoiDung.Size = new System.Drawing.Size(226, 36);
            this.cmbIDNguoiDung.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(111, 17);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(265, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Thêm Sửa Phiếu Nhập";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNgayNhap.Location = new System.Drawing.Point(38, 65);
            this.lblNgayNhap.Margin = new System.Windows.Forms.Padding(2);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(82, 23);
            this.lblNgayNhap.TabIndex = 1;
            this.lblNgayNhap.Text = "Ngày Nhập";
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNhaCungCap.Location = new System.Drawing.Point(38, 107);
            this.lblNhaCungCap.Margin = new System.Windows.Forms.Padding(2);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(104, 23);
            this.lblNhaCungCap.TabIndex = 2;
            this.lblNhaCungCap.Text = "Nhà Cung Cấp";
            // 
            // lblTenSP
            // 
            this.lblTenSP.BackColor = System.Drawing.Color.Transparent;
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTenSP.Location = new System.Drawing.Point(38, 201);
            this.lblTenSP.Margin = new System.Windows.Forms.Padding(2);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(102, 23);
            this.lblTenSP.TabIndex = 4;
            this.lblTenSP.Text = "Tên Sản Phẩm";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSoLuong.Location = new System.Drawing.Point(38, 289);
            this.lblSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(66, 23);
            this.lblSoLuong.TabIndex = 5;
            this.lblSoLuong.Text = "Số lượng";
            // 
            // lblDonGia
            // 
            this.lblDonGia.BackColor = System.Drawing.Color.Transparent;
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDonGia.Location = new System.Drawing.Point(38, 346);
            this.lblDonGia.Margin = new System.Windows.Forms.Padding(2);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(58, 23);
            this.lblDonGia.TabIndex = 6;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDung.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNguoiDung.Location = new System.Drawing.Point(38, 155);
            this.lblNguoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(89, 23);
            this.lblNguoiDung.TabIndex = 3;
            this.lblNguoiDung.Text = "Người Nhập";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaPhieuNhap.BorderRadius = 10;
            this.txtMaPhieuNhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaPhieuNhap.DefaultText = "";
            this.txtMaPhieuNhap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaPhieuNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaPhieuNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaPhieuNhap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.txtMaPhieuNhap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtMaPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuNhap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaPhieuNhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(185, 20);
            this.txtMaPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtMaPhieuNhap.PlaceholderText = "Mã phiếu nhập";
            this.txtMaPhieuNhap.SelectedText = "";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(150, 29);
            this.txtMaPhieuNhap.TabIndex = 0;
            this.txtMaPhieuNhap.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::Eden.Properties.Resources.del;
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.Location = new System.Drawing.Point(73, 600);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Eden.Properties.Resources.edit;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.Location = new System.Drawing.Point(250, 600);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvChiTiet
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTiet.ColumnHeadersHeight = 4;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTiet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChiTiet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.Location = new System.Drawing.Point(38, 423);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.Size = new System.Drawing.Size(400, 172);
            this.dgvChiTiet.TabIndex = 10;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChiTiet.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTiet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChiTiet.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvChiTiet.ThemeStyle.ReadOnly = false;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChiTiet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChiTiet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTiet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.Height = 22;
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChiTiet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnAddChiTiet
            // 
            this.btnAddChiTiet.BorderRadius = 10;
            this.btnAddChiTiet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChiTiet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChiTiet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddChiTiet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddChiTiet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddChiTiet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnAddChiTiet.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddChiTiet.Location = new System.Drawing.Point(73, 375);
            this.btnAddChiTiet.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddChiTiet.Name = "btnAddChiTiet";
            this.btnAddChiTiet.Size = new System.Drawing.Size(156, 29);
            this.btnAddChiTiet.TabIndex = 11;
            this.btnAddChiTiet.Text = "Thêm Sản Phẩm";
            this.btnAddChiTiet.Click += new System.EventHandler(this.btnAddChiTiet_Click);
            // 
            // btnRemoveChiTiet
            // 
            this.btnRemoveChiTiet.BorderRadius = 10;
            this.btnRemoveChiTiet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveChiTiet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveChiTiet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveChiTiet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveChiTiet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRemoveChiTiet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnRemoveChiTiet.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRemoveChiTiet.Location = new System.Drawing.Point(250, 375);
            this.btnRemoveChiTiet.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveChiTiet.Name = "btnRemoveChiTiet";
            this.btnRemoveChiTiet.Size = new System.Drawing.Size(161, 29);
            this.btnRemoveChiTiet.TabIndex = 12;
            this.btnRemoveChiTiet.Text = "Xóa Sản Phẩm";
            this.btnRemoveChiTiet.Click += new System.EventHandler(this.btnRemoveChiTiet_Click);
            // 
            // NhapKhoFormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(480, 660);
            this.Controls.Add(this.btnRemoveChiTiet);
            this.Controls.Add(this.btnAddChiTiet);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.cmbNhaCungCap);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.cmbIDNguoiDung);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.cmbTenSP);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NhapKhoFormAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Sửa Phiếu Nhập";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

       
    }
}