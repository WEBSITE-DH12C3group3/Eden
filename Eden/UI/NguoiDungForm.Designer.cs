using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Eden
{
    partial class NguoiDungForm
    {
        private Guna2DataGridView dgvNguoiDung;
        private Guna2Button btnThem;
        private Guna2Button btnSua;
        private Guna2Button btnXoa;
        private Guna2TextBox txtSearch;
        private Guna2Button btnSearch;
        private Label lblSearch;
        private Guna2Button btnPrevious;
        private Guna2Button btnNext;
        private Label lblPageInfo;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNguoiDung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.SuspendLayout();

            // dgvNguoiDung
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNguoiDung.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNguoiDung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNguoiDung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.Location = new System.Drawing.Point(50, 100);
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.RowHeadersVisible = false;
            this.dgvNguoiDung.RowHeadersWidth = 51;
            this.dgvNguoiDung.Size = new System.Drawing.Size(900, 500);
            this.dgvNguoiDung.TabIndex = 3;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNguoiDung.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDung.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvNguoiDung.ThemeStyle.ReadOnly = false;
            this.dgvNguoiDung.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoiDung.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNguoiDung.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNguoiDung.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNguoiDung.ThemeStyle.RowsStyle.Height = 22;
            this.dgvNguoiDung.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNguoiDung.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));

            // btnThem
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(50, 50);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(170, 50);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(290, 50);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // txtSearch
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(500, 50);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Nhập tên đăng nhập";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(250, 30);
            this.txtSearch.TabIndex = 4;

            // btnSearch
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(770, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(410, 50);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(73, 20);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Tìm kiếm:";

            // btnPrevious
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(50, 610);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 35);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Trang trước";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);

            // btnNext
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(850, 610);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 35);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "Trang sau";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // lblPageInfo
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageInfo.Location = new System.Drawing.Point(450, 620);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(72, 20);
            this.lblPageInfo.TabIndex = 9;
            this.lblPageInfo.Text = "Trang 1/1";

            // NguoiDungForm
            this.ClientSize = new System.Drawing.Size(1026, 738);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvNguoiDung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NguoiDungForm";
            this.Text = "Quản lý người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}