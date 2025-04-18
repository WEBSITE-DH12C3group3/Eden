namespace Eden
{
    partial class AddEditNguoiDungForm
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2TextBox txtTenNguoiDung;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDangNhap;
        private Guna.UI2.WinForms.Guna2TextBox txtMatKhau;
        private Guna.UI2.WinForms.Guna2ComboBox cbNhomNguoiDung;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;

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
            this.components = new System.ComponentModel.Container();
            this.txtTenNguoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenDangNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbNhomNguoiDung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtTenNguoiDung
            // 
            this.txtTenNguoiDung.BorderRadius = 10;
            this.txtTenNguoiDung.Location = new System.Drawing.Point(12, 50);
            this.txtTenNguoiDung.Name = "txtTenNguoiDung";
            this.txtTenNguoiDung.PlaceholderText = "Tên người dùng";
            this.txtTenNguoiDung.Size = new System.Drawing.Size(250, 36);
            this.txtTenNguoiDung.TabIndex = 0;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BorderRadius = 10;
            this.txtTenDangNhap.Location = new System.Drawing.Point(12, 92);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.PlaceholderText = "Tên đăng nhập";
            this.txtTenDangNhap.Size = new System.Drawing.Size(250, 36);
            this.txtTenDangNhap.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BorderRadius = 10;
            this.txtMatKhau.Location = new System.Drawing.Point(12, 134);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PlaceholderText = "Mật khẩu";
            this.txtMatKhau.Size = new System.Drawing.Size(250, 36);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // cbNhomNguoiDung
            // 
            this.cbNhomNguoiDung.BorderRadius = 10;
            this.cbNhomNguoiDung.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNhomNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhomNguoiDung.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbNhomNguoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbNhomNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbNhomNguoiDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbNhomNguoiDung.ItemHeight = 30;
            this.cbNhomNguoiDung.Location = new System.Drawing.Point(12, 176);
            this.cbNhomNguoiDung.Name = "cbNhomNguoiDung";
            this.cbNhomNguoiDung.Size = new System.Drawing.Size(250, 36);
            this.cbNhomNguoiDung.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(142, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEditNguoiDungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 266);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbNhomNguoiDung);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.txtTenNguoiDung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditNguoiDungForm";
            this.Text = "Thêm/Chỉnh sửa Người dùng";
            this.ResumeLayout(false);
        }
    }
}