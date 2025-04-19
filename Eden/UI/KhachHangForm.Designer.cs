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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.searchHK = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreviousPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // addkhachhang
            // 
            this.addkhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addkhachhang.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addkhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addkhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addkhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addkhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addkhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.addkhachhang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addkhachhang.ForeColor = System.Drawing.Color.White;
            this.addkhachhang.Location = new System.Drawing.Point(99, 621);
            this.addkhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addkhachhang.Name = "addkhachhang";
            this.addkhachhang.Size = new System.Drawing.Size(135, 37);
            this.addkhachhang.TabIndex = 1;
            this.addkhachhang.Text = "Thêm Khách Hàng";
            this.addkhachhang.Click += new System.EventHandler(this.addkhachhang_Click);
            // 
            // suakhachhang
            // 
            this.suakhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.suakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.suakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.suakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.suakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.suakhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.suakhachhang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suakhachhang.ForeColor = System.Drawing.Color.White;
            this.suakhachhang.Location = new System.Drawing.Point(297, 621);
            this.suakhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.suakhachhang.Name = "suakhachhang";
            this.suakhachhang.Size = new System.Drawing.Size(135, 37);
            this.suakhachhang.TabIndex = 2;
            this.suakhachhang.Text = "Sửa thông tin KH";
            this.suakhachhang.Click += new System.EventHandler(this.suakhachhang_Click);
            // 
            // xoakhachhang
            // 
            this.xoakhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.xoakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoakhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.xoakhachhang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoakhachhang.ForeColor = System.Drawing.Color.White;
            this.xoakhachhang.Location = new System.Drawing.Point(484, 621);
            this.xoakhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.xoakhachhang.Name = "xoakhachhang";
            this.xoakhachhang.Size = new System.Drawing.Size(135, 37);
            this.xoakhachhang.TabIndex = 3;
            this.xoakhachhang.Text = "Xóa Khách Hàng";
            this.xoakhachhang.Click += new System.EventHandler(this.xoakhachhang_Click);
            // 
            // dgkhachhang
            // 
            this.dgkhachhang.AllowUserToAddRows = false;
            this.dgkhachhang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgkhachhang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgkhachhang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgkhachhang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgkhachhang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgkhachhang.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgkhachhang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgkhachhang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgkhachhang.Location = new System.Drawing.Point(8, 55);
            this.dgkhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgkhachhang.Name = "dgkhachhang";
            this.dgkhachhang.ReadOnly = true;
            this.dgkhachhang.RowHeadersVisible = false;
            this.dgkhachhang.RowHeadersWidth = 51;
            this.dgkhachhang.RowTemplate.Height = 29;
            this.dgkhachhang.Size = new System.Drawing.Size(945, 486);
            this.dgkhachhang.TabIndex = 3;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgkhachhang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgkhachhang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgkhachhang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgkhachhang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgkhachhang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgkhachhang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgkhachhang.ThemeStyle.HeaderStyle.Height = 29;
            this.dgkhachhang.ThemeStyle.ReadOnly = true;
            this.dgkhachhang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgkhachhang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgkhachhang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgkhachhang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgkhachhang.ThemeStyle.RowsStyle.Height = 29;
            this.dgkhachhang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dgkhachhang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(125, 18);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(125, 19);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "Tìm kiếm khách hàng";
            // 
            // searchHK
            // 
            this.searchHK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchHK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchHK.DefaultText = "";
            this.searchHK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchHK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchHK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchHK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchHK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchHK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchHK.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.searchHK.Location = new System.Drawing.Point(304, 11);
            this.searchHK.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.searchHK.Name = "searchHK";
            this.searchHK.PlaceholderText = "";
            this.searchHK.SelectedText = "";
            this.searchHK.Size = new System.Drawing.Size(276, 39);
            this.searchHK.TabIndex = 5;
            this.searchHK.TextChanged += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.FillColor = System.Drawing.Color.Blue;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(591, 11);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 37);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreviousPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreviousPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreviousPage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(269, 548);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(70, 37);
            this.btnPreviousPage.TabIndex = 7;
            this.btnPreviousPage.Text = "Trước ";
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNextPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(510, 548);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(74, 37);
            this.btnNextPage.TabIndex = 8;
            this.btnNextPage.Text = "Sau";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(392, 559);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(68, 19);
            this.lblPageInfo.TabIndex = 9;
            this.lblPageInfo.Text = "Trang 1 / 1";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.FillColor = System.Drawing.Color.Green;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(687, 621);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(135, 37);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "Xuất excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // KhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(962, 749);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchHK);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.dgkhachhang);
            this.Controls.Add(this.xoakhachhang);
            this.Controls.Add(this.suakhachhang);
            this.Controls.Add(this.addkhachhang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "KhachHangForm";
            this.Text = "6";
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button addkhachhang;
        private Guna.UI2.WinForms.Guna2Button suakhachhang;
        private Guna.UI2.WinForms.Guna2Button xoakhachhang;
        private Guna.UI2.WinForms.Guna2DataGridView dgkhachhang;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox searchHK;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageInfo;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
    }
}