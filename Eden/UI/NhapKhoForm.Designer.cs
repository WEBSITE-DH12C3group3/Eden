using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Eden
{
    partial class NhapKhoForm
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
            // Cấu hình các điều khiển Guna UI2
            this.dgvPhieuNhap = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.SuspendLayout();

            // Guna2DataGridView: Dữ liệu phiếu nhập
            this.dgvPhieuNhap.AllowUserToAddRows = false;
            this.dgvPhieuNhap.AllowUserToDeleteRows = false;
            this.dgvPhieuNhap.AllowUserToResizeColumns = true;
            this.dgvPhieuNhap.AllowUserToResizeRows = false;
            this.dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhieuNhap.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhieuNhap.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(20, 100);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            this.dgvPhieuNhap.RowHeadersVisible = false;
            this.dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(760, 350);
            this.dgvPhieuNhap.TabIndex = 0;

            // Guna2Button: Thêm phiếu nhập
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.FillColor = System.Drawing.Color.Green;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 460);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // Guna2Button: Sửa phiếu nhập
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.FillColor = System.Drawing.Color.Orange;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(160, 460);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            // Guna2Button: Xóa phiếu nhập
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.FillColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(300, 460);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            // Guna2Button: Tìm kiếm phiếu nhập
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.FillColor = System.Drawing.Color.Cyan;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(700, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 40);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Guna2TextBox: TextBox tìm kiếm
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = Cursors.IBeam;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(670, 40);
            this.txtSearch.TabIndex = 5;

            // Guna2Button: Làm mới danh sách phiếu nhập
            this.btnRefresh.BorderRadius = 10;
            this.btnRefresh.FillColor = System.Drawing.Color.LightGray;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(20, 520);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Guna2Button: Xuất ra Excel
            this.btnExportExcel.BorderRadius = 10;
            this.btnExportExcel.FillColor = System.Drawing.Color.Blue;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(160, 520);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(120, 40);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new EventHandler(this.btnExportExcel_Click);

            btnXemChiTiet = new Guna2Button
            {
                Text = "Xem Chi Tiết",
                Size = new System.Drawing.Size(150, 36),
                Location = new System.Drawing.Point(400, 400), // Đặt vị trí phù hợp trên form
                FillColor = System.Drawing.Color.MediumSlateBlue,
                ForeColor = System.Drawing.Color.White
            };
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            this.Controls.Add(btnXemChiTiet);


            // NhapKhoForm: Cấu hình form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvPhieuNhap);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExportExcel);
            this.Name = "NhapKhoForm";
            this.Text = "Quản lý Phiếu Nhập";
            this.Load += new EventHandler(this.NhapKhoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}