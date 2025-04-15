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
            this.dghoadon.Location = new System.Drawing.Point(12, 120);
            this.dghoadon.Name = "dghoadon";
            this.dghoadon.ReadOnly = true;
            this.dghoadon.RowHeadersVisible = false;
            this.dghoadon.RowHeadersWidth = 51;
            this.dghoadon.RowTemplate.Height = 29;
            this.dghoadon.Size = new System.Drawing.Size(1018, 350);
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
            this.addhoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addhoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addhoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addhoadon.ForeColor = System.Drawing.Color.White;
            this.addhoadon.Location = new System.Drawing.Point(166, 599);
            this.addhoadon.Name = "addhoadon";
            this.addhoadon.Size = new System.Drawing.Size(180, 45);
            this.addhoadon.TabIndex = 1;
            this.addhoadon.Text = "Thêm Hóa Đơn";
            this.addhoadon.Click += new System.EventHandler(this.addhoadon_Click);
            // 
            // xoahoadon
            // 
            this.xoahoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoahoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoahoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.xoahoadon.ForeColor = System.Drawing.Color.White;
            this.xoahoadon.Location = new System.Drawing.Point(398, 599);
            this.xoahoadon.Name = "xoahoadon";
            this.xoahoadon.Size = new System.Drawing.Size(180, 45);
            this.xoahoadon.TabIndex = 3;
            this.xoahoadon.Text = "Xóa Hóa Đơn";
            this.xoahoadon.Click += new System.EventHandler(this.xoahoadon_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreviousPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreviousPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(202, 492);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(180, 45);
            this.btnPreviousPage.TabIndex = 4;
            this.btnPreviousPage.Text = "Trước";
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(607, 492);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(180, 45);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.Text = "Sau";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Location = new System.Drawing.Point(464, 508);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(66, 18);
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "Trang 1 / 1";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(209, 83);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(116, 18);
            this.guna2HtmlLabel2.TabIndex = 7;
            this.guna2HtmlLabel2.Text = "Tìm kiếm hóa đơn :";
            // 
            // searchHD
            // 
            this.searchHD.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.searchHD.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.searchHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.searchHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.searchHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchHD.ForeColor = System.Drawing.Color.White;
            this.searchHD.Location = new System.Drawing.Point(667, 65);
            this.searchHD.Name = "searchHD";
            this.searchHD.Size = new System.Drawing.Size(180, 45);
            this.searchHD.TabIndex = 8;
            this.searchHD.Text = "Tìm kiếm";
            this.searchHD.Click += new System.EventHandler(this.searchHD_Click);
            // 
            // search
            // 
            this.search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search.DefaultText = "";
            this.search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search.Location = new System.Drawing.Point(382, 65);
            this.search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.search.Name = "search";
            this.search.PlaceholderText = "";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(229, 48);
            this.search.TabIndex = 9;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.StyleChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // xemct
            // 
            this.xemct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xemct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xemct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xemct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.xemct.ForeColor = System.Drawing.Color.White;
            this.xemct.Location = new System.Drawing.Point(616, 599);
            this.xemct.Name = "xemct";
            this.xemct.Size = new System.Drawing.Size(180, 45);
            this.xemct.TabIndex = 10;
            this.xemct.Text = "Xem Chi Tiết";
            this.xemct.Click += new System.EventHandler(this.xemct_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(850, 599);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(180, 45);
            this.btnExportExcel.TabIndex = 11;
            this.btnExportExcel.Text = "Xuất excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // HoaDonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1151, 724);
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