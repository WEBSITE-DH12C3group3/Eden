namespace Eden
{
    using System.Drawing; // Added System.Drawing for Color
    using System.Windows.Forms;
    using Guna.UI2.WinForms;

    partial class AddEditNhomNguoiDungForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTenNhom;
        private Guna2TextBox txtTenNhom;
        private Label lblQuyen;
        private ListView listViewQuyen;
        private Label labelTitle; // Added title label

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTenNhom = new System.Windows.Forms.Label();
            this.txtTenNhom = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblQuyen = new System.Windows.Forms.Label();
            this.listViewQuyen = new System.Windows.Forms.ListView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTenNhom
            // 
            this.lblTenNhom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTenNhom.AutoSize = true;
            this.lblTenNhom.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhom.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTenNhom.Location = new System.Drawing.Point(245, 151);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(102, 25);
            this.lblTenNhom.TabIndex = 1;
            this.lblTenNhom.Text = "Tên Nhóm:";
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTenNhom.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtTenNhom.BorderRadius = 10;
            this.txtTenNhom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenNhom.DefaultText = "";
            this.txtTenNhom.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenNhom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenNhom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenNhom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.txtTenNhom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtTenNhom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhom.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtTenNhom.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(173)))));
            this.txtTenNhom.Location = new System.Drawing.Point(22, 143);
            this.txtTenNhom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtTenNhom.PlaceholderText = "Nhập tên nhóm";
            this.txtTenNhom.SelectedText = "";
            this.txtTenNhom.Size = new System.Drawing.Size(261, 36);
            this.txtTenNhom.TabIndex = 2;
            // 
            // lblQuyen
            // 
            this.lblQuyen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuyen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblQuyen.Location = new System.Drawing.Point(245, 221);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(71, 25);
            this.lblQuyen.TabIndex = 3;
            this.lblQuyen.Text = "Quyền:";
            // 
            // listViewQuyen
            // 
            this.listViewQuyen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listViewQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.listViewQuyen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewQuyen.CheckBoxes = true;
            this.listViewQuyen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewQuyen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listViewQuyen.HideSelection = false;
            this.listViewQuyen.Location = new System.Drawing.Point(22, 198);
            this.listViewQuyen.Name = "listViewQuyen";
            this.listViewQuyen.Size = new System.Drawing.Size(311, 364);
            this.listViewQuyen.TabIndex = 4;
            this.listViewQuyen.UseCompatibleStateImageBehavior = false;
            this.listViewQuyen.View = System.Windows.Forms.View.List;
            this.listViewQuyen.OwnerDraw = true;
            this.listViewQuyen.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewQuyen_DrawItem);
            this.listViewQuyen.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewQuyen_ItemChecked);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Location = new System.Drawing.Point(21, 19);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(428, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Thêm/Chỉnh Sửa Nhóm Người Dùng";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Eden.Properties.Resources.edit;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.Location = new System.Drawing.Point(593, 29);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(174, 61);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::Eden.Properties.Resources.del;
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.Location = new System.Drawing.Point(253, 29);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(174, 61);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnCancel);
            this.guna2Panel1.Controls.Add(this.btnSave);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 631);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(962, 118);
            this.guna2Panel1.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 631);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.txtTenNhom);
            this.guna2Panel3.Controls.Add(this.listViewQuyen);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(484, 3);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(475, 625);
            this.guna2Panel3.TabIndex = 1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.lblTenNhom);
            this.guna2Panel2.Controls.Add(this.lblQuyen);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(475, 625);
            this.guna2Panel2.TabIndex = 0;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.labelTitle);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(962, 64);
            this.guna2Panel4.TabIndex = 14;
            // 
            // AddEditNhomNguoiDungForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(962, 749);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditNhomNguoiDungForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Chỉnh Sửa Nhóm Người Dùng";
            this.guna2Panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        private void listViewQuyen_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();

            // Draw the checkbox manually
            int checkBoxSize = 20; // Keep the checkbox size
            Rectangle checkBoxRect = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + (e.Bounds.Height - checkBoxSize) / 2, checkBoxSize, checkBoxSize);

            // Draw the checkbox border
            using (Pen borderPen = new Pen(Color.WhiteSmoke, 2))
            {
                e.Graphics.DrawRectangle(borderPen, checkBoxRect);
            }

            // Draw the check mark if the item is checked
            if (e.Item.Checked)
            {
                using (Pen checkPen = new Pen(Color.WhiteSmoke, 3))
                {
                    // Draw a check mark (two lines forming a "V")
                    Point p1 = new Point(checkBoxRect.Left + 5, checkBoxRect.Top + checkBoxSize / 2);
                    Point p2 = new Point(checkBoxRect.Left + checkBoxSize / 3, checkBoxRect.Top + checkBoxSize - 5);
                    Point p3 = new Point(checkBoxRect.Left + checkBoxSize - 5, checkBoxRect.Top + 5);

                    e.Graphics.DrawLine(checkPen, p1, p2);
                    e.Graphics.DrawLine(checkPen, p2, p3);
                }
            }

            // Draw the text
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
            Rectangle textRect = new Rectangle(e.Bounds.Left + checkBoxSize + 6, e.Bounds.Top, e.Bounds.Width - checkBoxSize - 6, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, textRect, e.Item.ForeColor, flags);

            if (e.Item.Selected)
            {
                e.DrawFocusRectangle();
            }
        }

        private Guna2Button btnSave;
        private Guna2Button btnCancel;
        private Guna2Panel guna2Panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Guna2Panel guna2Panel3;
        private Guna2Panel guna2Panel2;
        private Guna2Panel guna2Panel4;
    }
}