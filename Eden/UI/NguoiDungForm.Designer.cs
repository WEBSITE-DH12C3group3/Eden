namespace Eden
{
    partial class NguoiDungForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNguoiDung;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.dgvNguoiDung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.SuspendLayout();

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(200, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Quản Lý Người Dùng";

            // dgvNguoiDung
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiDung.Location = new System.Drawing.Point(12, 50);
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true;
            this.dgvNguoiDung.RowHeadersVisible = false;
            this.dgvNguoiDung.Size = new System.Drawing.Size(560, 300);
            this.dgvNguoiDung.TabIndex = 1;

            // btnAdd
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.Location = new System.Drawing.Point(12, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(255, 165, 0);
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(102, 360);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(255, 85, 85);
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.Location = new System.Drawing.Point(192, 360);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // NguoiDungForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 400);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvNguoiDung);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NguoiDungForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Người Dùng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}