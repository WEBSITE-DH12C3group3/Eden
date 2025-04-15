namespace Eden
{
    using System.Windows.Forms;
    using Guna.UI2.WinForms; // Đảm bảo namespace Guna.UI2.WinForms được thêm

    partial class AddEditNguoiDungForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblTenNguoiDung = new Label();
            this.txtTenNguoiDung = new Guna2TextBox();
            this.lblTenDangNhap = new Label();
            this.txtTenDangNhap = new Guna2TextBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new Guna2TextBox();
            this.lblNhomNguoiDung = new Label();
            this.cbNhomNguoiDung = new Guna2ComboBox();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông Tin Người Dùng";

            // lblTenNguoiDung
            this.lblTenNguoiDung.AutoSize = true;
            this.lblTenNguoiDung.Location = new System.Drawing.Point(20, 50);
            this.lblTenNguoiDung.Name = "lblTenNguoiDung";
            this.lblTenNguoiDung.Size = new System.Drawing.Size(90, 13);
            this.lblTenNguoiDung.TabIndex = 1;
            this.lblTenNguoiDung.Text = "Tên Người Dùng";

            // txtTenNguoiDung
            this.txtTenNguoiDung.Location = new System.Drawing.Point(130, 45);
            this.txtTenNguoiDung.Name = "txtTenNguoiDung";
            this.txtTenNguoiDung.Size = new System.Drawing.Size(220, 30);
            this.txtTenNguoiDung.TabIndex = 2;
            this.txtTenNguoiDung.BorderRadius = 5;

            // lblTenDangNhap
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(20, 90);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(80, 13);
            this.lblTenDangNhap.TabIndex = 3;
            this.lblTenDangNhap.Text = "Tên Đăng Nhập";

            // txtTenDangNhap
            this.txtTenDangNhap.Location = new System.Drawing.Point(130, 85);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(220, 30);
            this.txtTenDangNhap.TabIndex = 4;
            this.txtTenDangNhap.BorderRadius = 5;

            // lblMatKhau
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(20, 130);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(50, 13);
            this.lblMatKhau.TabIndex = 5;
            this.lblMatKhau.Text = "Mật Khẩu";

            // txtMatKhau
            this.txtMatKhau.Location = new System.Drawing.Point(130, 125);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(220, 30);
            this.txtMatKhau.TabIndex = 6;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.BorderRadius = 5;

            // lblNhomNguoiDung
            this.lblNhomNguoiDung.AutoSize = true;
            this.lblNhomNguoiDung.Location = new System.Drawing.Point(20, 170);
            this.lblNhomNguoiDung.Name = "lblNhomNguoiDung";
            this.lblNhomNguoiDung.Size = new System.Drawing.Size(90, 13);
            this.lblNhomNguoiDung.TabIndex = 7;
            this.lblNhomNguoiDung.Text = "Nhóm Người Dùng";

            // cbNhomNguoiDung
            this.cbNhomNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList; // Thay Guna2ComboBoxStyle bằng ComboBoxStyle
            this.cbNhomNguoiDung.Location = new System.Drawing.Point(130, 165);
            this.cbNhomNguoiDung.Name = "cbNhomNguoiDung";
            this.cbNhomNguoiDung.Size = new System.Drawing.Size(220, 30);
            this.cbNhomNguoiDung.TabIndex = 8;
            this.cbNhomNguoiDung.BorderRadius = 5;

            // btnSave
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.btnSave.Location = new System.Drawing.Point(130, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.BorderRadius = 5;

            // btnCancel
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(255, 85, 85);
            this.btnCancel.Location = new System.Drawing.Point(230, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.BorderRadius = 5;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 260);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTenNguoiDung);
            this.Controls.Add(this.txtTenNguoiDung);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblNhomNguoiDung);
            this.Controls.Add(this.cbNhomNguoiDung);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditNguoiDungForm";
            this.Text = "Thêm/Chỉnh Sửa Người Dùng";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle;
        private Label lblTenNguoiDung;
        private Guna2TextBox txtTenNguoiDung;
        private Label lblTenDangNhap;
        private Guna2TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private Guna2TextBox txtMatKhau;
        private Label lblNhomNguoiDung;
        private Guna2ComboBox cbNhomNguoiDung;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
    }
}