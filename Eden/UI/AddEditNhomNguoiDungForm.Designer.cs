namespace Eden
{
    using System.Windows.Forms;
    using Guna.UI2.WinForms;

    partial class AddEditNhomNguoiDungForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblTenNhom = new Label();
            this.txtTenNhom = new Guna2TextBox();
            this.lblQuyen = new Label();
            this.listViewQuyen = new ListView();
            this.btnSave = new Guna2Button();
            this.btnCancel = new Guna2Button();

            this.SuspendLayout();

            // lblTenNhom
            this.lblTenNhom.AutoSize = true;
            this.lblTenNhom.Location = new System.Drawing.Point(20, 20);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(60, 13);
            this.lblTenNhom.TabIndex = 0;
            this.lblTenNhom.Text = "Tên Nhóm";

            // txtTenNhom
            this.txtTenNhom.Location = new System.Drawing.Point(120, 20);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(200, 30);
            this.txtTenNhom.TabIndex = 1;

            // lblQuyen
            this.lblQuyen.AutoSize = true;
            this.lblQuyen.Location = new System.Drawing.Point(20, 60);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(40, 13);
            this.lblQuyen.TabIndex = 2;
            this.lblQuyen.Text = "Quyền";

            // listViewQuyen
            this.listViewQuyen.CheckBoxes = true;
            this.listViewQuyen.Location = new System.Drawing.Point(120, 60);
            this.listViewQuyen.Name = "listViewQuyen";
            this.listViewQuyen.Size = new System.Drawing.Size(200, 150);
            this.listViewQuyen.TabIndex = 3;
            this.listViewQuyen.View = View.List;
            this.listViewQuyen.ItemChecked += new ItemCheckedEventHandler(this.listViewQuyen_ItemChecked);

            // btnSave
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.btnSave.Location = new System.Drawing.Point(120, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.BorderRadius = 5;

            // btnCancel
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(255, 85, 85);
            this.btnCancel.Location = new System.Drawing.Point(205, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.BorderRadius = 5;

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 270);
            this.Controls.Add(this.lblTenNhom);
            this.Controls.Add(this.txtTenNhom);
            this.Controls.Add(this.lblQuyen);
            this.Controls.Add(this.listViewQuyen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditNhomNguoiDungForm";
            this.Text = "Thêm/Chỉnh Sửa Nhóm Người Dùng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTenNhom;
        private Guna2TextBox txtTenNhom;
        private Label lblQuyen;
        private ListView listViewQuyen;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;
    }
}