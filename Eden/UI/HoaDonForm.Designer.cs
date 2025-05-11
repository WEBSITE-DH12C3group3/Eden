using System;
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
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.xemct = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnApplyFilter = new Guna.UI2.WinForms.Guna2Button();
            this.nudMinPrice = new System.Windows.Forms.NumericUpDown();
            this.nudMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbFilterType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dghoadon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dghoadon
            // 
            this.dghoadon.AllowUserToAddRows = false;
            this.dghoadon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.dghoadon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dghoadon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dghoadon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dghoadon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dghoadon.ColumnHeadersHeight = 50;
            this.dghoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dghoadon.Cursor = System.Windows.Forms.Cursors.PanSW;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dghoadon.DefaultCellStyle = dataGridViewCellStyle3;
            this.dghoadon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dghoadon.Location = new System.Drawing.Point(21, 148);
            this.dghoadon.Margin = new System.Windows.Forms.Padding(2);
            this.dghoadon.Name = "dghoadon";
            this.dghoadon.ReadOnly = true;
            this.dghoadon.RowHeadersVisible = false;
            this.dghoadon.RowHeadersWidth = 100;
            this.dghoadon.RowTemplate.Height = 40;
            this.dghoadon.RowTemplate.ReadOnly = true;
            this.dghoadon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dghoadon.Size = new System.Drawing.Size(921, 430);
            this.dghoadon.TabIndex = 0;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dghoadon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dghoadon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139)))));
            this.dghoadon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dghoadon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dghoadon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dghoadon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dghoadon.ThemeStyle.HeaderStyle.Height = 50;
            this.dghoadon.ThemeStyle.ReadOnly = true;
            this.dghoadon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dghoadon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dghoadon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dghoadon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Silver;
            this.dghoadon.ThemeStyle.RowsStyle.Height = 40;
            this.dghoadon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dghoadon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // addhoadon
            // 
            this.addhoadon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addhoadon.BorderRadius = 10;
            this.addhoadon.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.addhoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addhoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addhoadon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.addhoadon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addhoadon.ForeColor = System.Drawing.Color.White;
            this.addhoadon.Image = global::Eden.Properties.Resources.add;
            this.addhoadon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.addhoadon.Location = new System.Drawing.Point(126, 661);
            this.addhoadon.Margin = new System.Windows.Forms.Padding(2);
            this.addhoadon.Name = "addhoadon";
            this.addhoadon.Size = new System.Drawing.Size(160, 55);
            this.addhoadon.TabIndex = 1;
            this.addhoadon.Text = "Thêm";
            this.addhoadon.Click += new System.EventHandler(this.addhoadon_Click);
            // 
            // xoahoadon
            // 
            this.xoahoadon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.xoahoadon.BorderRadius = 10;
            this.xoahoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoahoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoahoadon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.xoahoadon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoahoadon.ForeColor = System.Drawing.Color.White;
            this.xoahoadon.Image = global::Eden.Properties.Resources.del;
            this.xoahoadon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xoahoadon.Location = new System.Drawing.Point(514, 661);
            this.xoahoadon.Margin = new System.Windows.Forms.Padding(2);
            this.xoahoadon.Name = "xoahoadon";
            this.xoahoadon.Size = new System.Drawing.Size(160, 55);
            this.xoahoadon.TabIndex = 3;
            this.xoahoadon.Text = "Xóa";
            this.xoahoadon.Click += new System.EventHandler(this.xoahoadon_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreviousPage.BorderRadius = 10;
            this.btnPreviousPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.btnPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(370, 590);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPreviousPage.Size = new System.Drawing.Size(40, 40);
            this.btnPreviousPage.TabIndex = 4;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNextPage.BorderRadius = 10;
            this.btnNextPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.btnNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(522, 590);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(40, 40);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.Text = ">";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageInfo.Location = new System.Drawing.Point(425, 595);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(2);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(84, 27);
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "Trang 1/1";
            this.lblPageInfo.Click += new System.EventHandler(this.lblPageInfo_Click);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.search.BorderRadius = 10;
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.search.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.search.ForeColor = System.Drawing.Color.Transparent;
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.search.IconLeft = global::Eden.Properties.Resources.seach;
            this.search.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.search.Location = new System.Drawing.Point(357, 22);
            this.search.Margin = new System.Windows.Forms.Padding(4);
            this.search.Name = "search";
            this.search.Padding = new System.Windows.Forms.Padding(2);
            this.search.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.search.PlaceholderText = "Nhập mã hóa đơn hoặc mã khách hàng";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(152, 41);
            this.search.TabIndex = 8;
            this.search.TextOffset = new System.Drawing.Point(5, 0);
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.Enter += new System.EventHandler(this.search_Enter);
            this.search.StyleChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // xemct
            // 
            this.xemct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.xemct.BorderRadius = 10;
            this.xemct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xemct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xemct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.xemct.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemct.ForeColor = System.Drawing.Color.White;
            this.xemct.Image = global::Eden.Properties.Resources.info;
            this.xemct.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xemct.Location = new System.Drawing.Point(307, 661);
            this.xemct.Margin = new System.Windows.Forms.Padding(2);
            this.xemct.Name = "xemct";
            this.xemct.Size = new System.Drawing.Size(186, 55);
            this.xemct.TabIndex = 9;
            this.xemct.Text = "Xem Chi Tiết";
            this.xemct.Click += new System.EventHandler(this.xemct_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportExcel.BorderRadius = 10;
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.FillColor = System.Drawing.Color.Green;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = global::Eden.Properties.Resources.exel;
            this.btnExportExcel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExportExcel.Location = new System.Drawing.Point(695, 661);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(160, 55);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(18, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(258, 40);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Quản Lý Hóa Đơn";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFilter.BorderRadius = 5;
            this.btnApplyFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApplyFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApplyFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApplyFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApplyFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyFilter.Location = new System.Drawing.Point(818, 22);
            this.btnApplyFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(109, 36);
            this.btnApplyFilter.TabIndex = 15;
            this.btnApplyFilter.Text = "Lọc";
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // nudMinPrice
            // 
            this.nudMinPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.nudMinPrice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nudMinPrice.Location = new System.Drawing.Point(629, 67);
            this.nudMinPrice.Margin = new System.Windows.Forms.Padding(2);
            this.nudMinPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMinPrice.Name = "nudMinPrice";
            this.nudMinPrice.Size = new System.Drawing.Size(99, 20);
            this.nudMinPrice.TabIndex = 17;
            this.nudMinPrice.Visible = false;
            // 
            // nudMaxPrice
            // 
            this.nudMaxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMaxPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.nudMaxPrice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nudMaxPrice.Location = new System.Drawing.Point(629, 104);
            this.nudMaxPrice.Margin = new System.Windows.Forms.Padding(2);
            this.nudMaxPrice.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMaxPrice.Name = "nudMaxPrice";
            this.nudMaxPrice.Size = new System.Drawing.Size(98, 20);
            this.nudMaxPrice.TabIndex = 18;
            this.nudMaxPrice.Visible = false;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.dtpStartDate.BorderRadius = 10;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStartDate.Location = new System.Drawing.Point(597, 66);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 24);
            this.dtpStartDate.TabIndex = 19;
            this.dtpStartDate.Value = new System.DateTime(2025, 5, 11, 15, 42, 55, 552);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.dtpEndDate.BorderRadius = 10;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEndDate.Location = new System.Drawing.Point(597, 98);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 26);
            this.dtpEndDate.TabIndex = 20;
            this.dtpEndDate.Value = new System.DateTime(2025, 5, 11, 15, 43, 50, 637);
            // 
            // cbFilterType
            // 
            this.cbFilterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.cbFilterType.BorderRadius = 10;
            this.cbFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.cbFilterType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterType.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cbFilterType.ItemHeight = 30;
            this.cbFilterType.Location = new System.Drawing.Point(597, 22);
            this.cbFilterType.Name = "cbFilterType";
            this.cbFilterType.Size = new System.Drawing.Size(200, 36);
            this.cbFilterType.TabIndex = 21;
            this.cbFilterType.SelectedIndexChanged += new System.EventHandler(this.cbFilterType_SelectedIndexChanged);
            // 
            // guna2Button2
            // 
            this.guna2Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Gray;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = global::Eden.Properties.Resources._ref;
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.Location = new System.Drawing.Point(629, 590);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(146, 40);
            this.guna2Button2.TabIndex = 22;
            this.guna2Button2.Text = "Làm mới";
            this.guna2Button2.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // HoaDonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(962, 749);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.cbFilterType);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.nudMaxPrice);
            this.Controls.Add(this.nudMinPrice);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.xemct);
            this.Controls.Add(this.search);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.xoahoadon);
            this.Controls.Add(this.addhoadon);
            this.Controls.Add(this.dghoadon);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HoaDonForm";
            this.Text = "HoaDonForm";
            ((System.ComponentModel.ISupportInitialize)(this.dghoadon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        private void lblPageInfo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // Add the missing event handler method definition for 'dghoadon_CellContentClick_1' in the HoaDonForm class.  
        

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dghoadon;
        private Guna.UI2.WinForms.Guna2Button addhoadon;
        private Guna.UI2.WinForms.Guna2Button xoahoadon;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageInfo;
        private Guna.UI2.WinForms.Guna2TextBox search;
        private Guna.UI2.WinForms.Guna2Button xemct;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private System.Windows.Forms.Label labelTitle; // Declaration for the title label
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2Button btnApplyFilter;
        private NumericUpDown nudMinPrice;
        private NumericUpDown nudMaxPrice;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterType;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}