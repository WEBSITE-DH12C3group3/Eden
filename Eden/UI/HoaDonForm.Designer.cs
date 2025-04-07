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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dghoadon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.addhoadon = new Guna.UI2.WinForms.Guna2Button();
            this.suahoadon = new Guna.UI2.WinForms.Guna2Button();
            this.xoahoadon = new Guna.UI2.WinForms.Guna2Button();
            this.btnPreviousPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.searchHD = new Guna.UI2.WinForms.Guna2Button();
            this.search = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dghoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // dghoadon
            // 
            dghoadon.AllowUserToAddRows = false;
            dghoadon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = Color.AliceBlue;
            dghoadon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dghoadon.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dghoadon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dghoadon.ColumnHeadersHeight = 29;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dghoadon.DefaultCellStyle = dataGridViewCellStyle9;
            dghoadon.GridColor = Color.FromArgb(231, 229, 255);
            dghoadon.Location = new Point(20, 120);
            dghoadon.Name = "dghoadon";
            dghoadon.ReadOnly = true;
            dghoadon.RowHeadersVisible = false;
            dghoadon.RowHeadersWidth = 51;
            dghoadon.Size = new Size(912, 350);
            dghoadon.TabIndex = 3;
            dghoadon.ThemeStyle.AlternatingRowsStyle.BackColor = Color.AliceBlue;
            dghoadon.ThemeStyle.AlternatingRowsStyle.Font = null;
            dghoadon.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dghoadon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dghoadon.ThemeStyle.BackColor = Color.White;
            dghoadon.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dghoadon.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dghoadon.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dghoadon.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dghoadon.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dghoadon.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dghoadon.ThemeStyle.HeaderStyle.Height = 29;
            dghoadon.ThemeStyle.ReadOnly = true;
            dghoadon.ThemeStyle.RowsStyle.BackColor = Color.White;
            dghoadon.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dghoadon.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dghoadon.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dghoadon.ThemeStyle.RowsStyle.Height = 29; dghoadon.ThemeStyle.RowsStyle.SelectionBackColor = Color.LightBlue;
            dghoadon.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // addhoadon
            // 
            this.addhoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addhoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addhoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addhoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addhoadon.ForeColor = System.Drawing.Color.White;
            this.addhoadon.Location = new System.Drawing.Point(71, 650);
            this.addhoadon.Name = "addhoadon";
            this.addhoadon.Size = new System.Drawing.Size(180, 45);
            this.addhoadon.TabIndex = 1;
            this.addhoadon.Text = "Thêm Hóa Đơn";
            this.addhoadon.Click += new System.EventHandler(this.addhoadon_Click);
            // 
            // suahoadon
            // 
            this.suahoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.suahoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.suahoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.suahoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.suahoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.suahoadon.ForeColor = System.Drawing.Color.White;
            this.suahoadon.Location = new System.Drawing.Point(381, 650);
            this.suahoadon.Name = "suahoadon";
            this.suahoadon.Size = new System.Drawing.Size(180, 45);
            this.suahoadon.TabIndex = 2;
            this.suahoadon.Text = "Sửa Hóa Đơn";
            this.suahoadon.Click += new System.EventHandler(this.suahoadon_Click);
            // 
            // xoahoadon
            // 
            this.xoahoadon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoahoadon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoahoadon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoahoadon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.xoahoadon.ForeColor = System.Drawing.Color.White;
            this.xoahoadon.Location = new System.Drawing.Point(697, 650);
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
            this.btnPreviousPage.Location = new System.Drawing.Point(175, 539);
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
            this.btnNextPage.Location = new System.Drawing.Point(580, 539);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(180, 45);
            this.btnNextPage.TabIndex = 5;
            this.btnNextPage.Text = "Sau";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Location = new System.Drawing.Point(437, 555);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(66, 18);
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "Trang 1 / 1";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(208, 91);
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
            this.searchHD.Location = new System.Drawing.Point(666, 73);
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
            this.search.Location = new System.Drawing.Point(381, 73);
            this.search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.search.Name = "search";
            this.search.PlaceholderText = "";
            this.search.SelectedText = "";
            this.search.Size = new System.Drawing.Size(229, 48);
            this.search.TabIndex = 9;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            this.search.StyleChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // HoaDonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 724);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchHD);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.xoahoadon);
            this.Controls.Add(this.suahoadon);
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
        private Guna.UI2.WinForms.Guna2Button suahoadon;
        private Guna.UI2.WinForms.Guna2Button xoahoadon;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button searchHD;
        private Guna.UI2.WinForms.Guna2TextBox search;
    }
}