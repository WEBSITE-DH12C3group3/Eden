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
            this.btnPreviousPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.searchHK = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // addkhachhang
            // 
            this.addkhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addkhachhang.BorderRadius = 10;
            this.addkhachhang.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.addkhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addkhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addkhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addkhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addkhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.addkhachhang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addkhachhang.ForeColor = System.Drawing.Color.White;
            this.addkhachhang.Image = global::Eden.Properties.Resources.add;
            this.addkhachhang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.addkhachhang.Location = new System.Drawing.Point(126, 661);
            this.addkhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addkhachhang.Name = "addkhachhang";
            this.addkhachhang.Size = new System.Drawing.Size(160, 55);
            this.addkhachhang.TabIndex = 1;
            this.addkhachhang.Text = "Thêm";
            this.addkhachhang.Click += new System.EventHandler(this.addkhachhang_Click);
            // 
            // suakhachhang
            // 
            this.suakhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.suakhachhang.BorderRadius = 10;
            this.suakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.suakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.suakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.suakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.suakhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.suakhachhang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suakhachhang.ForeColor = System.Drawing.Color.White;
            this.suakhachhang.Image = global::Eden.Properties.Resources.edit;
            this.suakhachhang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.suakhachhang.Location = new System.Drawing.Point(316, 661);
            this.suakhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.suakhachhang.Name = "suakhachhang";
            this.suakhachhang.Size = new System.Drawing.Size(160, 55);
            this.suakhachhang.TabIndex = 2;
            this.suakhachhang.Text = "Sửa";
            this.suakhachhang.Click += new System.EventHandler(this.suakhachhang_Click);
            // 
            // xoakhachhang
            // 
            this.xoakhachhang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.xoakhachhang.BorderRadius = 10;
            this.xoakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoakhachhang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.xoakhachhang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoakhachhang.ForeColor = System.Drawing.Color.White;
            this.xoakhachhang.Image = global::Eden.Properties.Resources.del;
            this.xoakhachhang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.xoakhachhang.Location = new System.Drawing.Point(506, 661);
            this.xoakhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.xoakhachhang.Name = "xoakhachhang";
            this.xoakhachhang.Size = new System.Drawing.Size(160, 55);
            this.xoakhachhang.TabIndex = 3;
            this.xoakhachhang.Text = "Xóa";
            this.xoakhachhang.Click += new System.EventHandler(this.xoakhachhang_Click);
            // 
            // dgkhachhang
            // 
            this.dgkhachhang.AllowUserToAddRows = false;
            this.dgkhachhang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.dgkhachhang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgkhachhang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgkhachhang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgkhachhang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgkhachhang.ColumnHeadersHeight = 50;
            this.dgkhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgkhachhang.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgkhachhang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgkhachhang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dgkhachhang.Location = new System.Drawing.Point(21, 104);
            this.dgkhachhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgkhachhang.Name = "dgkhachhang";
            this.dgkhachhang.ReadOnly = true;
            this.dgkhachhang.RowHeadersVisible = false;
            this.dgkhachhang.RowHeadersWidth = 100;
            this.dgkhachhang.RowTemplate.Height = 40;
            this.dgkhachhang.RowTemplate.ReadOnly = true;
            this.dgkhachhang.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgkhachhang.Size = new System.Drawing.Size(921, 474);
            this.dgkhachhang.TabIndex = 4;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgkhachhang.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dgkhachhang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dgkhachhang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139)))));
            this.dgkhachhang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgkhachhang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgkhachhang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgkhachhang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgkhachhang.ThemeStyle.HeaderStyle.Height = 50;
            this.dgkhachhang.ThemeStyle.ReadOnly = true;
            this.dgkhachhang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dgkhachhang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgkhachhang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgkhachhang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Silver;
            this.dgkhachhang.ThemeStyle.RowsStyle.Height = 40;
            this.dgkhachhang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgkhachhang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPreviousPage.BorderRadius = 10;
            this.btnPreviousPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.btnPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(370, 590);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPreviousPage.Size = new System.Drawing.Size(40, 40);
            this.btnPreviousPage.TabIndex = 7;
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
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(40, 40);
            this.btnNextPage.TabIndex = 8;
            this.btnNextPage.Text = ">";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPageInfo.Location = new System.Drawing.Point(426, 596);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(84, 27);
            this.lblPageInfo.TabIndex = 9;
            this.lblPageInfo.Text = "Trang 1/1";
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
            this.btnExportExcel.Location = new System.Drawing.Point(696, 661);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(160, 55);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "Xuất Exel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(18, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(302, 40);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Quản Lý Khách Hàng";
            // 
            // searchHK
            // 
            this.searchHK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchHK.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.searchHK.BorderRadius = 10;
            this.searchHK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchHK.DefaultText = "";
            this.searchHK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.searchHK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.searchHK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchHK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.searchHK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.searchHK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.searchHK.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.searchHK.ForeColor = System.Drawing.Color.Transparent;
            this.searchHK.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.searchHK.IconLeft = global::Eden.Properties.Resources.seach;
            this.searchHK.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.searchHK.Location = new System.Drawing.Point(490, 22);
            this.searchHK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchHK.Name = "searchHK";
            this.searchHK.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchHK.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.searchHK.PlaceholderText = "";
            this.searchHK.SelectedText = "";
            this.searchHK.Size = new System.Drawing.Size(452, 55);
            this.searchHK.TabIndex = 19;
            this.searchHK.TextOffset = new System.Drawing.Point(5, 0);
            this.searchHK.TextChanged += new System.EventHandler(this.searchHK_TextChanged_1);
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Gray;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::Eden.Properties.Resources._ref;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.Location = new System.Drawing.Point(588, 590);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(146, 40);
            this.guna2Button1.TabIndex = 20;
            this.guna2Button1.Text = "Làm mới";
            this.guna2Button1.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // KhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(962, 749);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.searchHK);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.dgkhachhang);
            this.Controls.Add(this.xoakhachhang);
            this.Controls.Add(this.suakhachhang);
            this.Controls.Add(this.addkhachhang);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "KhachHangForm";
            this.Text = "Quản Lý Khách Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button addkhachhang; // Button "Thêm"
        private Guna.UI2.WinForms.Guna2Button suakhachhang; // Button "Sửa"
        private Guna.UI2.WinForms.Guna2Button xoakhachhang; // Button "Xóa"
        private Guna.UI2.WinForms.Guna2DataGridView dgkhachhang;
        private Guna.UI2.WinForms.Guna2Button btnPreviousPage; // Previous Page Button
        private Guna.UI2.WinForms.Guna2Button btnNextPage; // Next Page Button
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageInfo; // Page Info Label
        private Guna.UI2.WinForms.Guna2Button btnExportExcel; // Export Excel Button
        private System.Windows.Forms.Label labelTitle; // Declaration for the title label
        private Guna.UI2.WinForms.Guna2TextBox searchHK;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}