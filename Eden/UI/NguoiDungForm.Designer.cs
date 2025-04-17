namespace Eden
{
    partial class NguoiDungForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewNguoiDung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNguoiDung
            // 
            this.dataGridViewNguoiDung.AllowUserToAddRows = false;
            this.dataGridViewNguoiDung.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewNguoiDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewNguoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewNguoiDung.ColumnHeadersHeight = 29;
            this.dataGridViewNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMaNguoiDung,
            this.colTenNguoiDung,
            this.colTenDangNhap});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewNguoiDung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewNguoiDung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewNguoiDung.Location = new System.Drawing.Point(-1, 68);
            this.dataGridViewNguoiDung.Name = "dataGridViewNguoiDung";
            this.dataGridViewNguoiDung.ReadOnly = true;
            this.dataGridViewNguoiDung.RowHeadersVisible = false;
            this.dataGridViewNguoiDung.RowHeadersWidth = 51;
            this.dataGridViewNguoiDung.RowTemplate.Height = 29;
            this.dataGridViewNguoiDung.Size = new System.Drawing.Size(1152, 304);
            this.dataGridViewNguoiDung.TabIndex = 3;
            this.dataGridViewNguoiDung.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridViewNguoiDung.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewNguoiDung.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewNguoiDung.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewNguoiDung.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewNguoiDung.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewNguoiDung.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewNguoiDung.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataGridViewNguoiDung.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewNguoiDung.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewNguoiDung.ThemeStyle.HeaderStyle.Height = 29;
            this.dataGridViewNguoiDung.ThemeStyle.ReadOnly = true;
            this.dataGridViewNguoiDung.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewNguoiDung.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewNguoiDung.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataGridViewNguoiDung.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewNguoiDung.ThemeStyle.RowsStyle.Height = 29;
            this.dataGridViewNguoiDung.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dataGridViewNguoiDung.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colId
            // 
            this.colId.HeaderText = "Mã người dùng";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colMaNguoiDung
            // 
            this.colMaNguoiDung.HeaderText = "tên người dùng";
            this.colMaNguoiDung.MinimumWidth = 6;
            this.colMaNguoiDung.Name = "colMaNguoiDung";
            this.colMaNguoiDung.ReadOnly = true;
            // 
            // colTenNguoiDung
            // 
            this.colTenNguoiDung.HeaderText = "Tên đăng nhập";
            this.colTenNguoiDung.MinimumWidth = 6;
            this.colTenNguoiDung.Name = "colTenNguoiDung";
            this.colTenNguoiDung.ReadOnly = true;
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.HeaderText = "Nhóm người dùng";
            this.colTenDangNhap.MinimumWidth = 6;
            this.colTenDangNhap.Name = "colTenDangNhap";
            this.colTenDangNhap.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.BorderRadius = 4;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(204, 410);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 53);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.BorderRadius = 4;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(383, 410);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 53);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.BorderRadius = 4;
            this.btnDelete.FillColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(560, 410);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 53);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRefresh.BorderRadius = 4;
            this.btnRefresh.FillColor = System.Drawing.Color.Navy;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(729, 410);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 53);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // NguoiDungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 606);
            this.Controls.Add(this.dataGridViewNguoiDung);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NguoiDungForm";
            this.Text = "Quản Lý Người Dùng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNguoiDung)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewNguoiDung;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
    }
}