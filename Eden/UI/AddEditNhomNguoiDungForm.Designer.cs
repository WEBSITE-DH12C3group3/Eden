namespace Eden
{
    partial class AddEditNhomNguoiDungForm
    {
        private System.Windows.Forms.Label lblMaNhom;
        private System.Windows.Forms.Label lblTenNhom;
        private System.Windows.Forms.TextBox txtMaNhom;
        private System.Windows.Forms.TextBox txtTenNhom;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;

        private void InitializeComponent()
        {
            this.lblMaNhom = new System.Windows.Forms.Label();
            this.lblTenNhom = new System.Windows.Forms.Label();
            this.txtMaNhom = new System.Windows.Forms.TextBox();
            this.txtTenNhom = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblMaNhom
            this.lblMaNhom.AutoSize = true;
            this.lblMaNhom.Location = new System.Drawing.Point(30, 30);
            this.lblMaNhom.Name = "lblMaNhom";
            this.lblMaNhom.Size = new System.Drawing.Size(78, 20);
            this.lblMaNhom.TabIndex = 0;
            this.lblMaNhom.Text = "Mã Nhóm:";

            // lblTenNhom
            this.lblTenNhom.AutoSize = true;
            this.lblTenNhom.Location = new System.Drawing.Point(30, 70);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(80, 20);
            this.lblTenNhom.TabIndex = 1;
            this.lblTenNhom.Text = "Tên Nhóm:";

            // txtMaNhom
            this.txtMaNhom.Location = new System.Drawing.Point(120, 30);
            this.txtMaNhom.Name = "txtMaNhom";
            this.txtMaNhom.Size = new System.Drawing.Size(200, 27);
            this.txtMaNhom.TabIndex = 2;

            // txtTenNhom
            this.txtTenNhom.Location = new System.Drawing.Point(120, 70);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(200, 27);
            this.txtTenNhom.TabIndex = 3;

            // btnLuu
            this.btnLuu.Location = new System.Drawing.Point(120, 120);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 30);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(220, 120);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // AddEditNhomNguoiDungForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 180);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtTenNhom);
            this.Controls.Add(this.txtMaNhom);
            this.Controls.Add(this.lblTenNhom);
            this.Controls.Add(this.lblMaNhom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditNhomNguoiDungForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Sửa Nhóm Người Dùng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}