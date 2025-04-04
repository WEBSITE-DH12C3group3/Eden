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
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // addkhachhang
            // 
            this.addkhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addkhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addkhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addkhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addkhachhang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addkhachhang.ForeColor = System.Drawing.Color.White;
            this.addkhachhang.Location = new System.Drawing.Point(107, 541);
            this.addkhachhang.Name = "addkhachhang";
            this.addkhachhang.Size = new System.Drawing.Size(180, 45);
            this.addkhachhang.TabIndex = 1;
            this.addkhachhang.Text = "Thêm Khách Hàng";
            this.addkhachhang.Click += new System.EventHandler(this.addkhachhang_Click);
            // 
            // suakhachhang
            // 
            this.suakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.suakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.suakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.suakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.suakhachhang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.suakhachhang.ForeColor = System.Drawing.Color.White;
            this.suakhachhang.Location = new System.Drawing.Point(440, 541);
            this.suakhachhang.Name = "suakhachhang";
            this.suakhachhang.Size = new System.Drawing.Size(180, 45);
            this.suakhachhang.TabIndex = 2;
            this.suakhachhang.Text = "Sửa thông tin KH";
            this.suakhachhang.Click += new System.EventHandler(this.suakhachhang_Click);
            // 
            // xoakhachhang
            // 
            this.xoakhachhang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoakhachhang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoakhachhang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoakhachhang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoakhachhang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.xoakhachhang.ForeColor = System.Drawing.Color.White;
            this.xoakhachhang.Location = new System.Drawing.Point(755, 541);
            this.xoakhachhang.Name = "xoakhachhang";
            this.xoakhachhang.Size = new System.Drawing.Size(180, 45);
            this.xoakhachhang.TabIndex = 3;
            this.xoakhachhang.Text = "Xóa Khách Hàng";
            this.xoakhachhang.Click += new System.EventHandler(this.xoakhachhang_Click);
            // 
            // dgkhachhang
            // 
            dgkhachhang.AllowUserToAddRows = false;
            dgkhachhang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.AliceBlue;
            dgkhachhang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgkhachhang.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgkhachhang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgkhachhang.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgkhachhang.DefaultCellStyle = dataGridViewCellStyle3;
            dgkhachhang.GridColor = Color.FromArgb(231, 229, 255);
            dgkhachhang.Location = new Point(20, 120);
            dgkhachhang.Name = "dgkhachhang";
            dgkhachhang.ReadOnly = true;
            dgkhachhang.RowHeadersVisible = false;
            dgkhachhang.RowHeadersWidth = 51;
            dgkhachhang.Size = new Size(912, 350);
            dgkhachhang.TabIndex = 3;
            dgkhachhang.ThemeStyle.AlternatingRowsStyle.BackColor = Color.AliceBlue;
            dgkhachhang.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgkhachhang.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgkhachhang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgkhachhang.ThemeStyle.BackColor = Color.White;
            dgkhachhang.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgkhachhang.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgkhachhang.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgkhachhang.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgkhachhang.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgkhachhang.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgkhachhang.ThemeStyle.HeaderStyle.Height = 29;
            dgkhachhang.ThemeStyle.ReadOnly = true;
            dgkhachhang.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgkhachhang.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgkhachhang.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgkhachhang.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgkhachhang.ThemeStyle.RowsStyle.Height = 29; dgkhachhang.ThemeStyle.RowsStyle.SelectionBackColor = Color.LightBlue;
            dgkhachhang.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // KhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 702);
            this.Controls.Add(this.dgkhachhang);
            this.Controls.Add(this.xoakhachhang);
            this.Controls.Add(this.suakhachhang);
            this.Controls.Add(this.addkhachhang);
            this.Name = "KhachHangForm";
            this.Text = "6";
            ((System.ComponentModel.ISupportInitialize)(this.dgkhachhang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button addkhachhang;
        private Guna.UI2.WinForms.Guna2Button suakhachhang;
        private Guna.UI2.WinForms.Guna2Button xoakhachhang;
        private Guna.UI2.WinForms.Guna2DataGridView dgkhachhang;
    }
}