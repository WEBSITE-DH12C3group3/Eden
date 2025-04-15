namespace Eden
{
    partial class NhomNguoiDungForm
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
            this.dataGridViewNhomNguoiDung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colNhomId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhomNguoiDung)).BeginInit();
            this.SuspendLayout();

            // dataGridViewNhomNguoiDung
            this.dataGridViewNhomNguoiDung.AllowUserToAddRows = false;
            this.dataGridViewNhomNguoiDung.AllowUserToDeleteRows = false;
            this.dataGridViewNhomNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNhomId,
                this.colTenNhom});
            this.dataGridViewNhomNguoiDung.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewNhomNguoiDung.Name = "dataGridViewNhomNguoiDung";
            this.dataGridViewNhomNguoiDung.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewNhomNguoiDung.TabIndex = 0;

            // colNhomId
            this.colNhomId.HeaderText = "ID";
            this.colNhomId.Name = "colNhomId";
            this.colNhomId.ReadOnly = true;
            this.colNhomId.Width = 50;

            // colTenNhom
            this.colTenNhom.HeaderText = "Tên Nhóm";
            this.colTenNhom.Name = "colTenNhom";
            this.colTenNhom.ReadOnly = true;
            this.colTenNhom.Width = 200;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 430);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(105, 430);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 30);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(190, 430);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(275, 430);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.dataGridViewNhomNguoiDung);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NhomNguoiDungForm";
            this.Text = "Quản Lý Nhóm Người Dùng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhomNguoiDung)).EndInit();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewNhomNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhomId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNhom;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
    }
}