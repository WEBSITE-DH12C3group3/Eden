using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPw.Text = "1";
            txtUser.Text = "admin";
            this.AcceptButton = btnLog;
            // Tắt các tính năng không cần thiết ban đầu
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // Preload data (nếu cần)
            Task.Run(() => PreloadResources());
        }

        private void PreloadResources()
        {
            using (var db = new QLBanHoaEntities())
            {
                // Load một bản ghi để khởi động EF
                var temp = db.NGUOIDUNGs.FirstOrDefault();
            }
        }

        private void forgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để lấy lại mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPw.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginBLL loginBLL = new LoginBLL();
            if (loginBLL.ValidateUser(username, password))
            {
                this.Hide(); // Ẩn LoginForm

                using (MainForm mainForm = new MainForm())
                {
                    mainForm.ShowDialog(); // Đảm bảo vòng đời form hợp lý
                    mainForm.Dispose(); // Giải phóng tài nguyên
                }
                // Khi MainForm đóng, LoginForm sẽ hiện lại
                txtPw.Clear();
                txtUser.Clear();
                this.Show();
                txtUser.Focus();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPw.Clear();
                txtUser.Focus();
            }
        }

        private void switch1_CheckedChanged(object sender, EventArgs e)
        {
            if (switch1.Checked)
                txtPw.PasswordChar = (char)0;
            else
                txtPw.PasswordChar = '*';
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED => Giảm nhấp nháy
                return cp;
            }
        }
    }
}