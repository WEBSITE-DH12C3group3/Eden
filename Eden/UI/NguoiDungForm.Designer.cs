namespace Eden
{
    partial class NguoiDungForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNguoiDung;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;

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
            this.labelTitle = new System.Windows.Forms.Label();
            this.dgvNguoiDung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.SuspendLayout();
            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke; // Matched SanPhamForm color
            this.labelTitle.Location = new System.Drawing.Point(18, 22); // Matched SanPhamForm location
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(280, 40); // Adjusted size based on text
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Quản Lý Người Dùng"; // Kept existing text
            //
            // dgvNguoiDung
            //
            this.dgvNguoiDung.AllowUserToAddRows = false; // Matched SanPhamForm
            this.dgvNguoiDung.AllowUserToDeleteRows = false; // Matched SanPhamForm
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93))))); // Matched SanPhamForm color
            this.dgvNguoiDung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNguoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // Matched SanPhamForm anchor
            this.dgvNguoiDung.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))); // Matched SanPhamForm color
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm color
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguoiDung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNguoiDung.ColumnHeadersHeight = 50; // Matched SanPhamForm height
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Matched SanPhamForm
            this.dgvNguoiDung.Cursor = System.Windows.Forms.Cursors.Arrow; // Matched SanPhamForm cursor
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver; // Matched SanPhamForm color
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNguoiDung.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNguoiDung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dgvNguoiDung.Location = new System.Drawing.Point(21, 104); // Adjusted location to match SanPhamForm layout
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true; // Matched SanPhamForm
            // RowHeadersDefaultCellStyle was present in original, copying relevant parts to ThemeStyle
            this.dgvNguoiDung.RowHeadersVisible = false; // Matched SanPhamForm
            this.dgvNguoiDung.RowHeadersWidth = 100; // Matched SanPhamForm
            this.dgvNguoiDung.RowTemplate.Height = 40; // Matched SanPhamForm height
            this.dgvNguoiDung.RowTemplate.ReadOnly = true; // Set ReadOnly as in SanPhamForm
            this.dgvNguoiDung.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False; // Matched SanPhamForm
            this.dgvNguoiDung.Size = new System.Drawing.Size(921, 547); // Adjusted size to fit layout
            this.dgvNguoiDung.TabIndex = 1;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93))))); // Matched SanPhamForm
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNguoiDung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNguoiDung.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm
            this.dgvNguoiDung.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))); // Matched SanPhamForm
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Matched SanPhamForm
            this.dgvNguoiDung.ThemeStyle.HeaderStyle.Height = 50; // Matched SanPhamForm height
            this.dgvNguoiDung.ThemeStyle.ReadOnly = true; // Matched SanPhamForm
            this.dgvNguoiDung.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dgvNguoiDung.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNguoiDung.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.dgvNguoiDung.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Silver; // Matched SanPhamForm color
            this.dgvNguoiDung.ThemeStyle.RowsStyle.Height = 40; // Matched SanPhamForm height
            this.dgvNguoiDung.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255))))); // Matched SanPhamForm color
            this.dgvNguoiDung.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94))))); // Matched SanPhamForm color

            //
            // btnAdd
            //
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnAdd.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnAdd.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // Matched SanPhamForm add button color (Teal)
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::Eden.Properties.Resources.add; // Matched SanPhamForm image (ensure resource exists)
            this.btnAdd.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.btnAdd.Location = new System.Drawing.Point(226, 661); // Adjusted location to center buttons
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm"; // Matched SanPhamForm text
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            //
            // btnEdit
            //
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnEdit.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))); // Matched SanPhamForm edit button color (Purple)
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = global::Eden.Properties.Resources.edit; // Matched SanPhamForm image (ensure resource exists)
            this.btnEdit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.btnEdit.Location = new System.Drawing.Point(406, 661); // Adjusted location to center buttons
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Sửa"; // Matched SanPhamForm text
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            //
            // btnDelete
            //
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnDelete.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))); // Matched SanPhamForm delete button color (Orange)
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::Eden.Properties.Resources.del; // Matched SanPhamForm image (ensure resource exists)
            this.btnDelete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.btnDelete.Location = new System.Drawing.Point(586, 661); // Adjusted location to center buttons
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa"; // Matched SanPhamForm text
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            //
            // NguoiDungForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63))))); // Matched SanPhamForm background
            this.ClientSize = new System.Drawing.Size(962, 749); // Matched SanPhamForm size
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvNguoiDung);
            this.Controls.Add(this.labelTitle);
            this.ForeColor = System.Drawing.Color.WhiteSmoke; // Set form fore color for overall theme
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Matched SanPhamForm border style
            this.MaximizeBox = false; // Kept existing setting
            this.MinimizeBox = false; // Kept existing setting
            this.Name = "NguoiDungForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Kept existing setting
            this.Text = "Quản Lý Người Dùng"; // Kept existing text
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        // Declarations are already present at the top of the partial class
        // private System.Windows.Forms.Label labelTitle;
        // private Guna.UI2.WinForms.Guna2DataGridView dgvNguoiDung;
        // private Guna.UI2.WinForms.Guna2Button btnAdd;
        // private Guna.UI2.WinForms.Guna2Button btnEdit;
        // private Guna.UI2.WinForms.Guna2Button btnDelete;
    }
}