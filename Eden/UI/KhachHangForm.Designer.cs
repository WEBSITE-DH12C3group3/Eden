using System.Drawing;
using System.Windows.Forms;

namespace Eden
{
    partial class KhachHangForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addkhachhang = new Guna.UI2.WinForms.Guna2Button();
            this.suakhachhang = new Guna.UI2.WinForms.Guna2Button();
            this.xoakhachhang = new Guna.UI2.WinForms.Guna2Button();
            this.dgkhachhang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.searchHK = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreviousPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.labelTitle = new System.Windows.Forms.Label(); // Added Title Label
            // Removed guna2HtmlLabel1 - using placeholder text in textbox instead
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).BeginInit();
            this.SuspendLayout();
            //
            // addkhachhang
            //
            this.addkhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.addkhachhang.BorderRadius = 10; // Matched SanPhamForm border radius
            this.addkhachhang.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.addkhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.addkhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.addkhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.addkhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.addkhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // Matched SanPhamForm add button color (Teal)
            this.addkhachhang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.addkhachhang.ForeColor = System.Drawing.Color.White;
            this.addkhachhang.Image = global::Eden.Properties.Resources.add; // Matched SanPhamForm image (ensure resource exists)
            this.addkhachhang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.addkhachhang.Location = new System.Drawing.Point(126, 661); // Adjusted location to match SanPhamForm layout
            this.addkhachhang.Margin = new System.Windows.Forms.Padding(2);
            this.addkhachhang.Name = "addkhachhang";
            this.addkhachhang.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.addkhachhang.TabIndex = 1;
            this.addkhachhang.Text = "Thêm"; // Simplified text to match SanPhamForm button
            this.addkhachhang.Click += new System.EventHandler(this.addkhachhang_Click);
            //
            // suakhachhang
            //
            this.suakhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.suakhachhang.BorderRadius = 10; // Matched SanPhamForm border radius
            this.suakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.suakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.suakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.suakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.suakhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))); // Matched SanPhamForm edit button color (Purple)
            this.suakhachhang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.suakhachhang.ForeColor = System.Drawing.Color.White;
            this.suakhachhang.Image = global::Eden.Properties.Resources.edit; // Matched SanPhamForm image (ensure resource exists)
            this.suakhachhang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.suakhachhang.Location = new System.Drawing.Point(316, 661); // Adjusted location to match SanPhamForm layout
            this.suakhachhang.Margin = new System.Windows.Forms.Padding(2);
            this.suakhachhang.Name = "suakhachhang";
            this.suakhachhang.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.suakhachhang.TabIndex = 2;
            this.suakhachhang.Text = "Sửa"; // Simplified text to match SanPhamForm button
            this.suakhachhang.Click += new System.EventHandler(this.suakhachhang_Click);
            //
            // xoakhachhang
            //
            this.xoakhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.xoakhachhang.BorderRadius = 10; // Matched SanPhamForm border radius
            this.xoakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.xoakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.xoakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.xoakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.xoakhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))); // Matched SanPhamForm delete button color (Orange)
            this.xoakhachhang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.xoakhachhang.ForeColor = System.Drawing.Color.White;
            this.xoakhachhang.Image = global::Eden.Properties.Resources.del; // Matched SanPhamForm image (ensure resource exists)
            this.xoakhachhang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.xoakhachhang.Location = new System.Drawing.Point(506, 661); // Adjusted location to match SanPhamForm layout
            this.xoakhachhang.Margin = new System.Windows.Forms.Padding(2);
            this.xoakhachhang.Name = "xoakhachhang";
            this.xoakhachhang.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.xoakhachhang.TabIndex = 3;
            this.xoakhachhang.Text = "Xóa"; // Simplified text to match SanPhamForm button
            this.xoakhachhang.Click += new System.EventHandler(this.xoakhachhang_Click);
            //
            // dgkhachhang
            //
            this.dgkhachhang.AllowUserToAddRows = false; // Matched SanPhamForm
            this.dgkhachhang.AllowUserToDeleteRows = false; // Matched SanPhamForm
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93))))); // Matched SanPhamForm color
            this.dgkhachhang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgkhachhang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // Matched SanPhamForm anchor
            this.dgkhachhang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dgkhachhang.BorderStyle = System.Windows.Forms.BorderStyle.None; // Changed to None as in SanPhamForm
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))); // Matched SanPhamForm color
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm color
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgkhachhang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgkhachhang.ColumnHeadersHeight = 50; // Matched SanPhamForm height
            this.dgkhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Matched SanPhamForm
            this.dgkhachhang.Cursor = System.Windows.Forms.Cursors.Arrow; // Matched SanPhamForm cursor
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver; // Matched SanPhamForm color
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgkhachhang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgkhachhang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dgkhachhang.Location = new System.Drawing.Point(21, 104); // Adjusted location to match SanPhamForm layout
            this.dgkhachhang.Margin = new System.Windows.Forms.Padding(2);
            this.dgkhachhang.Name = "dgkhachhang";
            this.dgkhachhang.ReadOnly = true; // Matched SanPhamForm
            this.dgkhachhang.RowHeadersVisible = false; // Matched SanPhamForm
            this.dgkhachhang.RowHeadersWidth = 100; // Matched SanPhamForm
            this.dgkhachhang.RowTemplate.Height = 40; // Matched SanPhamForm height
            this.dgkhachhang.RowTemplate.ReadOnly = true; // Set ReadOnly as in SanPhamForm
            this.dgkhachhang.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False; // Matched SanPhamForm
            this.dgkhachhang.Size = new System.Drawing.Size(921, 474); // Adjusted size to fit layout
            this.dgkhachhang.TabIndex = 4;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93))))); // Matched SanPhamForm
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm
            this.dgkhachhang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm
            this.dgkhachhang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))); // Matched SanPhamForm
            this.dgkhachhang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgkhachhang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.dgkhachhang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgkhachhang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Matched SanPhamForm
            this.dgkhachhang.ThemeStyle.HeaderStyle.Height = 50; // Matched SanPhamForm height
            this.dgkhachhang.ThemeStyle.ReadOnly = true; // Matched SanPhamForm
            this.dgkhachhang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dgkhachhang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgkhachhang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.dgkhachhang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Silver; // Matched SanPhamForm color
            this.dgkhachhang.ThemeStyle.RowsStyle.Height = 40; // Matched SanPhamForm height
            this.dgkhachhang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255))))); // Matched SanPhamForm color
            this.dgkhachhang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94))))); // Matched SanPhamForm color
            //
            // searchHK
            //
            this.searchHK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); // Matched SanPhamForm anchor
            this.searchHK.BorderColor = System.Drawing.Color.WhiteSmoke; // Matched SanPhamForm border color
            this.searchHK.BorderRadius = 10; // Matched SanPhamForm border radius
            this.searchHK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchHK.DefaultText = "";
            this.searchHK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208))))); // Matched SanPhamForm disabled state
            this.searchHK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226))))); // Matched SanPhamForm disabled state
            this.searchHK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138))))); // Matched SanPhamForm disabled state
            this.searchHK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138))))); // Matched SanPhamForm disabled state
            this.searchHK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63))))); // Matched SanPhamForm fill color
            this.searchHK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm focused border color
            this.searchHK.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.searchHK.ForeColor = System.Drawing.Color.WhiteSmoke; // Use WhiteSmoke for visible text
            this.searchHK.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm hover border color
            this.searchHK.Location = new System.Drawing.Point(442, 22); // Adjusted location to match SanPhamForm layout
            this.searchHK.Margin = new System.Windows.Forms.Padding(4);
            this.searchHK.Name = "searchHK";
            this.searchHK.Padding = new System.Windows.Forms.Padding(2);
            this.searchHK.PlaceholderForeColor = System.Drawing.Color.LightGray; // Matched SanPhamForm placeholder color
            this.searchHK.PlaceholderText = "Nhập tên khách hàng"; // Updated placeholder text
            this.searchHK.SelectedText = "";
            this.searchHK.Size = new System.Drawing.Size(429, 55); // Matched SanPhamForm size
            this.searchHK.TabIndex = 5;
            this.searchHK.TextChanged += new System.EventHandler(this.btnSearch_Click); // Kept existing event handler

            //
            // btnSearch
            //
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); // Matched SanPhamForm anchor
            this.btnSearch.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm search button color (Blue)
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::Eden.Properties.Resources.seach; // Matched SanPhamForm image (ensure resource exists)
            this.btnSearch.Location = new System.Drawing.Point(877, 22); // Adjusted location to match SanPhamForm layout
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 55); // Matched SanPhamForm size
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            //
            // btnPreviousPage
            //
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnPreviousPage.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnPreviousPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm pagination button color (Blue)
            this.btnPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(370, 590); // Adjusted location to match SanPhamForm layout
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPreviousPage.Size = new System.Drawing.Size(40, 40); // Matched SanPhamForm size
            this.btnPreviousPage.TabIndex = 7;
            this.btnPreviousPage.Text = "<"; // Matched SanPhamForm text
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);

            //
            // btnNextPage
            //
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnNextPage.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnNextPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm pagination button color (Blue)
            this.btnNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(522, 590); // Adjusted location to match SanPhamForm layout
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(40, 40); // Matched SanPhamForm size
            this.btnNextPage.TabIndex = 8;
            this.btnNextPage.Text = ">"; // Matched SanPhamForm text
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);

            //
            // lblPageInfo
            //
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.lblPageInfo.ForeColor = System.Drawing.Color.WhiteSmoke; // Matched SanPhamForm color
            this.lblPageInfo.Location = new System.Drawing.Point(432, 599); // Adjusted location to match SanPhamForm layout
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(2);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(71, 23); // Matched SanPhamForm size
            this.lblPageInfo.TabIndex = 9;
            this.lblPageInfo.Text = "Trang 1/1"; // Matched SanPhamForm text format

            //
            // btnExportExcel
            //
            this.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnExportExcel.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray; // Matched SanPhamForm disabled state
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169))))); // Matched SanPhamForm disabled state
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141))))); // Matched SanPhamForm disabled state
            this.btnExportExcel.FillColor = System.Drawing.Color.Green; // Matched SanPhamForm export button color (Green)
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = global::Eden.Properties.Resources.exel; // Matched SanPhamForm image (ensure resource exists)
            this.btnExportExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.btnExportExcel.Location = new System.Drawing.Point(696, 661); // Matched SanPhamForm location
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.btnExportExcel.TabIndex = 10;

            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(18, 22); // Matched SanPhamForm location
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(280, 40); // Adjusted size based on text
            this.labelTitle.TabIndex = 11; // Adjusted TabIndex
            this.labelTitle.Text = "Quản Lý Khách Hàng"; // Set Title Text


            //
            // KhachHangForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63))))); // Matched SanPhamForm background
            this.ClientSize = new System.Drawing.Size(962, 749); // Matched SanPhamForm size
            this.Controls.Add(this.labelTitle); // Added Title Label to controls
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchHK);
            // Removed guna2HtmlLabel1
            this.Controls.Add(this.dgkhachhang);
            this.Controls.Add(this.xoakhachhang);
            this.Controls.Add(this.suakhachhang);
            this.Controls.Add(this.addkhachhang);
            this.ForeColor = System.Drawing.Color.WhiteSmoke; // Matched SanPhamForm fore color
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Matched SanPhamForm border style
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "KhachHangForm";
            this.Text = "Quản Lý Khách Hàng"; // Updated form title
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout(); // Added PerformLayout for controls

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button addkhachhang; // Button "Thêm"
        private Guna.UI2.WinForms.Guna2Button suakhachhang; // Button "Sửa"
        private Guna.UI2.WinForms.Guna2Button xoakhachhang; // Button "Xóa"
        private Guna.UI2.WinForms.Guna2DataGridView dgkhachhang;
        // Removed guna2HtmlLabel1
        private Guna.UI2.WinForms.Guna2TextBox searchHK; // Search Textbox
        private Guna.UI2.WinForms.Guna2Button btnSearch; // Search Button
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage; // Previous Page Button
        private Guna.UI2.WinForms.Guna2Button btnNextPage; // Next Page Button
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageInfo; // Page Info Label
        private Guna.UI2.WinForms.Guna2Button btnExportExcel; // Export Excel Button
        private System.Windows.Forms.Label labelTitle; // Declaration for the title label
    }
}