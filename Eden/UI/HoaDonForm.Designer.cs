using System.Drawing;
using System.Windows.Forms;

namespace Eden
{
    partial class HoaDonForm
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
            this.dghoadon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.addhoadon = new Guna.UI2.WinForms.Guna2Button();
            this.xoahoadon = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreviousPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.searchHD = new Guna.UI2.WinForms.Guna2Button();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.xemct = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.labelTitle = new System.Windows.Forms.Label(); // Added Title Label
            ((System.ComponentModel.ISupportInitialize)(this.dghoadon)).BeginInit();
            this.SuspendLayout();
            //
            // dghoadon
            //
            this.dghoadon.AllowUserToAddRows = false;
            this.dghoadon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93))))); // Matched SanPhamForm color
            this.dghoadon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dghoadon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dghoadon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dghoadon.BorderStyle = System.Windows.Forms.BorderStyle.None; // Changed to None as in SanPhamForm
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))); // Matched SanPhamForm color
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm color
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dghoadon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dghoadon.ColumnHeadersHeight = 50; // Matched SanPhamForm height
            this.dghoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Matched SanPhamForm
            this.dghoadon.Cursor = System.Windows.Forms.Cursors.Arrow; // Matched SanPhamForm cursor
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver; // Matched SanPhamForm color
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94))))); // Matched SanPhamForm color
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dghoadon.DefaultCellStyle = dataGridViewCellStyle3;
            this.dghoadon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dghoadon.Location = new System.Drawing.Point(21, 104); // Adjusted location to match SanPhamForm layout
            this.dghoadon.Margin = new System.Windows.Forms.Padding(2);
            this.dghoadon.Name = "dghoadon";
            this.dghoadon.ReadOnly = true; // Matched SanPhamForm
            this.dghoadon.RowHeadersVisible = false; // Matched SanPhamForm
            this.dghoadon.RowHeadersWidth = 100; // Matched SanPhamForm
            this.dghoadon.RowTemplate.Height = 40; // Matched SanPhamForm height
            this.dghoadon.RowTemplate.ReadOnly = true; // Matched SanPhamForm
            this.dghoadon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False; // Matched SanPhamForm
            this.dghoadon.Size = new System.Drawing.Size(921, 474); // Adjusted size to fit layout
            this.dghoadon.TabIndex = 0;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93))))); // Matched SanPhamForm
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm
            this.dghoadon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm
            this.dghoadon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))); // Matched SanPhamForm
            this.dghoadon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dghoadon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.dghoadon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dghoadon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing; // Matched SanPhamForm
            this.dghoadon.ThemeStyle.HeaderStyle.Height = 50; // Matched SanPhamForm height
            this.dghoadon.ThemeStyle.ReadOnly = true; // Matched SanPhamForm
            this.dghoadon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86))))); // Matched SanPhamForm color
            this.dghoadon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dghoadon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.dghoadon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Silver; // Matched SanPhamForm color
            this.dghoadon.ThemeStyle.RowsStyle.Height = 40; // Matched SanPhamForm height
            this.dghoadon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255))))); // Matched SanPhamForm color
            this.dghoadon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94))))); // Matched SanPhamForm color
            this.dghoadon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dghoadon_CellContentClick_1);
            //
            // addhoadon
            //
            this.addhoadon.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.addhoadon.BorderRadius = 10; // Matched SanPhamForm border radius
            this.addhoadon.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.addhoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addhoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addhoadon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); // Matched SanPhamForm add button color
            this.addhoadon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.addhoadon.ForeColor = System.Drawing.Color.White;
            this.addhoadon.Image = global::Eden.Properties.Resources.add; // Matched SanPhamForm image (ensure resource exists)
            this.addhoadon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.addhoadon.Location = new System.Drawing.Point(126, 661); // Matched SanPhamForm location
            this.addhoadon.Margin = new System.Windows.Forms.Padding(2);
            this.addhoadon.Name = "addhoadon";
            this.addhoadon.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.addhoadon.TabIndex = 1;
            this.addhoadon.Text = "Thêm"; // Simplified text to match SanPhamForm button
            this.addhoadon.Click += new System.EventHandler(this.addhoadon_Click);
            //
            // xoahoadon
            //
            this.xoahoadon.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.xoahoadon.BorderRadius = 10; // Matched SanPhamForm border radius
            this.xoahoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoahoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoahoadon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))); // Matched SanPhamForm delete button color
            this.xoahoadon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.xoahoadon.ForeColor = System.Drawing.Color.White;
            this.xoahoadon.Image = global::Eden.Properties.Resources.del; // Matched SanPhamForm image (ensure resource exists)
            this.xoahoadon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.xoahoadon.Location = new System.Drawing.Point(506, 661); // Matched SanPhamForm location
            this.xoahoadon.Margin = new System.Windows.Forms.Padding(2);
            this.xoahoadon.Name = "xoahoadon";
            this.xoahoadon.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.xoahoadon.TabIndex = 3;
            this.xoahoadon.Text = "Xóa"; // Simplified text to match SanPhamForm button
            this.xoahoadon.Click += new System.EventHandler(this.xoahoadon_Click);
            //
            // btnPreviousPage
            //
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnPreviousPage.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnPreviousPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm pagination button color
            this.btnPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(370, 590); // Adjusted location to match SanPhamForm layout
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPreviousPage.Size = new System.Drawing.Size(40, 40); // Matched SanPhamForm size
            this.btnPreviousPage.TabIndex = 4;
            this.btnPreviousPage.Text = "<"; // Matched SanPhamForm text
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            //
            // btnNextPage
            //
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnNextPage.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnNextPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm pagination button color
            this.btnNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(522, 590); // Adjusted location to match SanPhamForm layout
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(40, 40); // Matched SanPhamForm size
            this.btnNextPage.TabIndex = 5;
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
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "Trang 1/1"; // Matched SanPhamForm text format
            this.lblPageInfo.Click += new System.EventHandler(this.lblPageInfo_Click);
            //
            // searchHD
            //
            this.searchHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); // Matched SanPhamForm anchor
            this.searchHD.BorderRadius = 10; // Matched SanPhamForm border radius
            this.searchHD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.searchHD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.searchHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.searchHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.searchHD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm search button color
            this.searchHD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.searchHD.ForeColor = System.Drawing.Color.White;
            this.searchHD.Image = global::Eden.Properties.Resources.seach; // Matched SanPhamForm image (ensure resource exists)
            this.searchHD.Location = new System.Drawing.Point(877, 22); // Matched SanPhamForm location
            this.searchHD.Margin = new System.Windows.Forms.Padding(2);
            this.searchHD.Name = "searchHD";
            this.searchHD.Size = new System.Drawing.Size(55, 55); // Matched SanPhamForm size
            this.searchHD.TabIndex = 7;
            this.searchHD.Click += new System.EventHandler(this.searchHD_Click);
            //
            // search
            //
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))); // Matched SanPhamForm anchor
            this.search.BorderColor = System.Drawing.Color.WhiteSmoke; // Matched SanPhamForm border color
            this.search.BorderRadius = 10; // Matched SanPhamForm border radius
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63))))); // Matched SanPhamForm fill color
            this.search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm focused border color
            this.search.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.search.ForeColor = System.Drawing.Color.Transparent; // Use Transparent or a light color that fits the theme
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173))))); // Matched SanPhamForm hover border color
            this.search.Location = new System.Drawing.Point(442, 22); // Adjusted location to match SanPhamForm layout
            this.search.Margin = new System.Windows.Forms.Padding(4);
            this.search.Name = "search";
            this.search.Padding = new System.Windows.Forms.Padding(2);
            this.search.PlaceholderForeColor = System.Drawing.Color.LightGray; // Matched SanPhamForm placeholder color
            this.search.PlaceholderText = "Nhập mã hóa đơn"; // Changed placeholder text
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(429, 55); // Matched SanPhamForm size
            this.search.TabIndex = 8;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.StyleChanged += new System.EventHandler(this.search_TextChanged); // Kept existing event handler
            //
            // xemct
            //
            this.xemct.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.xemct.BorderRadius = 10; // Matched SanPhamForm border radius
            this.xemct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xemct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xemct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))); // Using the SanPhamForm Edit button color
            this.xemct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.xemct.ForeColor = System.Drawing.Color.White;
            // Assuming you might use a similar image as edit or view, or no image
            // this.xemct.Image = global::Eden.Properties.Resources.edit; // Example image
            // this.xemct.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xemct.Location = new System.Drawing.Point(316, 661); // Placed next to Add button
            this.xemct.Margin = new System.Windows.Forms.Padding(2);
            this.xemct.Name = "xemct";
            this.xemct.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.xemct.TabIndex = 9;
            this.xemct.Text = "Xem Chi Tiết";
            this.xemct.Click += new System.EventHandler(this.xemct_Click);
            //
            // btnExportExcel
            //
            this.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Matched SanPhamForm anchor
            this.btnExportExcel.BorderRadius = 10; // Matched SanPhamForm border radius
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.FillColor = System.Drawing.Color.Green; // Matched SanPhamForm export button color
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Matched SanPhamForm font
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = global::Eden.Properties.Resources.exel; // Matched SanPhamForm image (ensure resource exists)
            this.btnExportExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left; // Matched SanPhamForm image align
            this.btnExportExcel.Location = new System.Drawing.Point(696, 661); // Matched SanPhamForm location
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(160, 55); // Matched SanPhamForm size
            this.btnExportExcel.TabIndex = 10; // Adjusted TabIndex
            this.btnExportExcel.Text = "Xuất excel"; // Matched SanPhamForm text
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            //
            // labelTitle
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(18, 22); // Matched SanPhamForm location
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(252, 40); // Adjusted size based on text
            this.labelTitle.TabIndex = 11; // Adjusted TabIndex
            this.labelTitle.Text = "Quản Lý Hóa Đơn"; // Set Title Text
            //
            // HoaDonForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63))))); // Matched SanPhamForm background
            this.ClientSize = new System.Drawing.Size(962, 749); // Matched SanPhamForm size
            this.Controls.Add(this.labelTitle); // Added Title Label to controls
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.xemct);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchHD);
            // Removed guna2HtmlLabel2 - using placeholder text in textbox instead
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.xoahoadon);
            this.Controls.Add(this.addhoadon);
            this.Controls.Add(this.dghoadon);
            this.ForeColor = System.Drawing.Color.WhiteSmoke; // Matched SanPhamForm fore color
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Matched SanPhamForm border style
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HoaDonForm";
            this.Text = "HoaDonForm"; // Kept existing Text property
            ((System.ComponentModel.ISupportInitialize)(this.dghoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout(); // Added PerformLayout for the new label

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dghoadon;
        private Guna.UI2.WinForms.Guna2Button addhoadon;
        private Guna.UI2.WinForms.Guna2Button xoahoadon;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageInfo;
        // Removed guna2HtmlLabel2
        private Guna.UI2.WinForms.Guna2Button searchHD;
        private Guna.UI2.WinForms.Guna2TextBox search;
        private Guna.UI2.WinForms.Guna2Button xemct;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private System.Windows.Forms.Label labelTitle; // Declaration for the title label
    }
}