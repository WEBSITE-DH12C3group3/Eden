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
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.searchHD = new Guna.UI2.WinForms.Guna2Button();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            this.xemct = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dghoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // dghoadon
            // 
            this.dghoadon.AllowUserToAddRows = false;
            this.dghoadon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dghoadon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dghoadon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dghoadon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dghoadon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dghoadon.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dghoadon.DefaultCellStyle = dataGridViewCellStyle3;
            this.dghoadon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dghoadon.Location = new System.Drawing.Point(7, 55);
            this.dghoadon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dghoadon.Name = "dghoadon";
            this.dghoadon.ReadOnly = true;
            this.dghoadon.RowHeadersVisible = false;
            this.dghoadon.RowHeadersWidth = 51;
            this.dghoadon.RowTemplate.Height = 29;
            this.dghoadon.Size = new System.Drawing.Size(945, 486);
            this.dghoadon.TabIndex = 3;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dghoadon.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dghoadon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dghoadon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dghoadon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dghoadon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dghoadon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dghoadon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dghoadon.ThemeStyle.HeaderStyle.Height = 29;
            this.dghoadon.ThemeStyle.ReadOnly = true;
            this.dghoadon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dghoadon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dghoadon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dghoadon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dghoadon.ThemeStyle.RowsStyle.Height = 29;
            this.dghoadon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dghoadon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dghoadon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dghoadon_CellContentClick_1);
            // 
            // addhoadon
            // 
            this.addhoadon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addhoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addhoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addhoadon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.addhoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addhoadon.ForeColor = System.Drawing.Color.White;
            this.addhoadon.Location = new System.Drawing.Point(149, 639);
            this.addhoadon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addhoadon.Name = "addhoadon";
            this.addhoadon.Size = new System.Drawing.Size(135, 37);
            this.addhoadon.TabIndex = 1;
            this.addhoadon.Text = "Thêm Hóa Đơn";
            this.addhoadon.Click += new System.EventHandler(this.addhoadon_Click);
            // 
            // xoahoadon
            // 
            this.xoahoadon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.xoahoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoahoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoahoadon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.xoahoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.xoahoadon.ForeColor = System.Drawing.Color.White;
            this.xoahoadon.Location = new System.Drawing.Point(323, 639);
            this.xoahoadon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.xoahoadon.Name = "xoahoadon";
            this.xoahoadon.Size = new System.Drawing.Size(135, 37);
            this.xoahoadon.TabIndex = 3;
            this.xoahoadon.Text = "Xóa Hóa Đơn";
            this.xoahoadon.Click += new System.EventHandler(this.xoahoadon_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreviousPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreviousPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreviousPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(268, 557);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(85, 37);
            this.btnPreviousPage.TabIndex = 4;
            this.btnPreviousPage.Text = "Trước";
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNextPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(571, 557);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(85, 37);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.Text = "Sau";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Location = new System.Drawing.Point(432, 569);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(57, 15);
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "Trang 1 / 1";
            this.lblPageInfo.Click += new System.EventHandler(this.lblPageInfo_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(196, 18);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(108, 19);
            this.guna2HtmlLabel2.TabIndex = 7;
            this.guna2HtmlLabel2.Text = "Tìm kiếm hóa đơn";
            // 
            // searchHD
            // 
            this.searchHD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchHD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.searchHD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.searchHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.searchHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.searchHD.FillColor = System.Drawing.Color.Blue;
            this.searchHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchHD.ForeColor = System.Drawing.Color.White;
            this.searchHD.Location = new System.Drawing.Point(627, 11);
            this.searchHD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchHD.Name = "searchHD";
            this.searchHD.Size = new System.Drawing.Size(135, 37);
            this.searchHD.TabIndex = 8;
            this.searchHD.Text = "Tìm kiếm";
            this.searchHD.Click += new System.EventHandler(this.searchHD_Click);
            // 
            // search
            // 
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Location = new System.Drawing.Point(341, 11);
            this.search.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.search.Name = "search";
            this.search.PlaceholderText = "";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(262, 39);
            this.search.TabIndex = 9;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.StyleChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // xemct
            // 
            this.xemct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.xemct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xemct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xemct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.xemct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.xemct.ForeColor = System.Drawing.Color.White;
            this.xemct.Location = new System.Drawing.Point(486, 639);
            this.xemct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.xemct.Name = "xemct";
            this.xemct.Size = new System.Drawing.Size(135, 37);
            this.xemct.TabIndex = 10;
            this.xemct.Text = "Xem Chi Tiết";
            this.xemct.Click += new System.EventHandler(this.xemct_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.FillColor = System.Drawing.Color.Green;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(662, 639);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(135, 37);
            this.btnExportExcel.TabIndex = 11;
            this.btnExportExcel.Text = "Xuất excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // HoaDonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(962, 749);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.xemct);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchHD);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.xoahoadon);
            this.Controls.Add(this.addhoadon);
            this.Controls.Add(this.dghoadon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HoaDonForm";
            this.Text = "HoaDonForm";
            ((System.ComponentModel.ISupportInitialize)(this.dghoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dghoadon;
        private Guna.UI2.WinForms.Guna2Button addhoadon;
        private Guna.UI2.WinForms.Guna2Button xoahoadon;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button searchHD;
        private Guna.UI2.WinForms.Guna2TextBox search;
        private Guna.UI2.WinForms.Guna2Button xemct;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
    }
}