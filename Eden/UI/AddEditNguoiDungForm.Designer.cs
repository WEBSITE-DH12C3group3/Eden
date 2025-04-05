namespace Eden
{
    partial class AddEditNguoiDungForm
    {
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblNhomNguoiDung;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.ComboBox cboNhomNguoiDung;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;

        private void InitializeComponent()
        {
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblNhomNguoiDung = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.cboNhomNguoiDung = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTenDangNhap
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(30, 30);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(100, 20);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên Đăng Nhập:";

            // lblMatKhau
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(30, 70);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(70, 20);
            this.lblMatKhau.TabIndex = 1;
            this.lblMatKhau.Text = "Mật Khẩu:";

            // lblNhomNguoiDung
            this.lblNhomNguoiDung.AutoSize = true;
            this.lblNhomNguoiDung.Location = new System.Drawing.Point(30, 110);
            this.lblNhomNguoiDung.Name = "lblNhomNguoiDung";
            this.lblNhomNguoiDung.Size = new System.Drawing.Size(110, 20);
            this.lblNhomNguoiDung.TabIndex = 2;
            this.lblNhomNguoiDung.Text = "Nhóm Người Dùng:";

            // txtTenDangNhap
            this.txtTenDangNhap.Location = new System.Drawing.Point(150, 30);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(200, 27);
            this.txtTenDangNhap.TabIndex = 3;

            // txtMatKhau
            this.txtMatKhau.Location = new System.Drawing.Point(150, 70);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(200, 27);
            this.txtMatKhau.TabIndex = 4;

            // cboNhomNguoiDung
            this.cboNhomNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomNguoiDung.FormattingEnabled = true;
            this.cboNhomNguoiDung.Location = new System.Drawing.Point(150, 110);
            this.cboNhomNguoiDung.Name = "cboNhomNguoiDung";
            this.cboNhomNguoiDung.Size = new System.Drawing.Size(200, 28);
            this.cboNhomNguoiDung.TabIndex = 5;

            // btnLuu
            this.btnLuu.Location = new System.Drawing.Point(150, 160);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 30);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(250, 160);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // AddEditNguoiDungForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 220);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboNhomNguoiDung);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblNhomNguoiDung);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenDangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditNguoiDungForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Sửa Người Dùng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}