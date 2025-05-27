using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Eden.UI;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Eden
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            guna2HtmlLabel1.Text = CurrentUser.Username;
            picVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picVan.SizeMode = PictureBoxSizeMode.StretchImage;
            InitializeSidebarButtons();
        }

        private ContextMenuStrip salaryMenu;
        private List<Guna2GradientButton> sidebarButtons = new List<Guna2GradientButton>();

        private void InitializeSidebarButtons()
        {
            this.SuspendLayout();
            int yPosition = 70;

            // Tạo danh sách các nút với thông tin: Text, Name, Image
            var buttonInfos = new List<(string Text, string Name, string Image)>();
            if (CurrentUser.Permissions?.Contains("BCTK") == true)
                buttonInfos.Add(("Thống kê", "btnTK", "report"));
            if (CurrentUser.Permissions?.Contains("QLSP") == true)
            {
                buttonInfos.Add(("Sản phẩm", "btnSP", "product"));
                buttonInfos.Add(("Phân loại", "btnPL", "category"));
            }
            if (CurrentUser.Permissions?.Contains("QLND") == true)
            {
                buttonInfos.Add(("Người dùng", "btnND", "user"));
                buttonInfos.Add(("Nhóm người dùng", "btnNND", "group"));
            }
            if (CurrentUser.Permissions?.Contains("QLKH") == true)
                buttonInfos.Add(("Khách hàng", "btnKH", "cus"));
            if (CurrentUser.Permissions?.Contains("QLHD") == true)
                buttonInfos.Add(("Hóa đơn", "btnHD", "invoice"));
            if (CurrentUser.Permissions?.Contains("QLNH") == true)
            {
                buttonInfos.Add(("Nhập kho", "btnNK", "ware"));
                buttonInfos.Add(("Nhà cung cấp", "btnNCC", "cc"));
            }
            if (CurrentUser.Permissions?.Contains("TDQD") == true)
                buttonInfos.Add(("Quản lý lương", "btnS", "salary"));

            foreach (var info in buttonInfos)
            {
                var btn = CreateSBB(info.Text, info.Name, yPosition, info.Image);
                this.Controls.Add(btn); // Hoặc thêm vào Panel chứa sidebar
                btn.BringToFront();
                sidebarButtons.Add(btn);
                if (info.Name == "btnS")
                {
                    // Tạo menu dropdown
                    salaryMenu = new ContextMenuStrip();
                    salaryMenu.BackColor = Color.FromArgb(36, 59, 100);
                    salaryMenu.ForeColor = Color.White;
                    salaryMenu.Font = new Font("Segoe UI", 12F);
                    salaryMenu.ImageScalingSize = new Size(24, 24);
                    // Tạo các item
                    var item1 = new ToolStripMenuItem("Tính lương", Properties.Resources.balance_sheet);
                    var item2 = new ToolStripMenuItem("Thông tin nhân viên", Properties.Resources.information);
                    var item3 = new ToolStripMenuItem("Chấm công", Properties.Resources.calendar);

                    item1.Padding = new Padding(5);
                    item2.Padding = new Padding(5);
                    item3.Padding = new Padding(5);
                    // Gán sự kiện click
                    item1.Click += (s, e) => ShowForm(new TinhLuongForm());
                    item3.Click += (s, e) => ShowForm(new ChamCongForm());
                    item2.Click += (s, e) => ShowForm(new ThongTinNhanVienForm());

                    // Thêm vào menu
                    salaryMenu.Items.AddRange(new ToolStripItem[] { item1, item2, item3 });
                }

                yPosition += 65;
            }
            this.ResumeLayout(false);
        }

        private Guna2GradientButton CreateSBB(string text, string name, int y, string imgName)
        {
            Guna2GradientButton btn = new Guna2GradientButton
            {
                Name = name,
                Text = text,
                Size = new Size(guna2Panel2.Width, 69),
                Location = new Point(0, y),
                Margin = new Padding(0),
                Padding = new Padding(0),
                Anchor = AnchorStyles.Left,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(20, 0),
                Image = (Image)Properties.Resources.ResourceManager.GetObject(imgName),
                ImageAlign = HorizontalAlignment.Left,
                ImageOffset = new Point(10, 0),
                ImageSize = new Size(24, 24),
                FillColor = Color.FromArgb(26, 49, 80),
                FillColor2 = Color.FromArgb(26, 49, 80),
                HoverState =
                {
                    FillColor = Color.FromArgb(58, 125, 167),
                    FillColor2 = Color.FromArgb(26, 49, 80),
                    Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold)
                }
            };

            // Click event

            btn.Click += (sender, e) =>
            {
                // Reset màu tất cả các nút
                foreach (var control in this.Controls.OfType<Guna2GradientButton>())
                {
                    control.FillColor = Color.FromArgb(26, 49, 80);
                    control.FillColor2 = Color.FromArgb(26, 49, 80);
                    control.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
                }

                // Đặt màu cho nút được chọn
                var selectedBtn = (Guna2GradientButton)sender;
                selectedBtn.FillColor = Color.FromArgb(58, 125, 167);
                selectedBtn.FillColor2 = Color.FromArgb(26, 49, 80);
                selectedBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

                //Xử lý logic khi click vào từng nút
                switch (selectedBtn.Name)
                {
                    case "btnTK":
                        // Xử lý Thống kê
                        pnlMainContent.Controls.Clear();
                        ShowForm(new ThongKeForm());
                        break;

                    case "btnSP":
                        // Xử lý Sản phẩm
                        pnlMainContent.Controls.Clear();
                        ShowForm(new SanPhamForm());
                        break;

                    case "btnPL":
                        // Xử lý Phân loại
                        pnlMainContent.Controls.Clear();
                        ShowForm(new PhanLoaiForm());
                        break;

                    case "btnND":
                        // Xử lý Người dùng
                        pnlMainContent.Controls.Clear();
                        ShowForm(new NguoiDungForm());
                        break;

                    case "btnNND":
                        // Xử lý Nhóm người dùng
                        pnlMainContent.Controls.Clear();
                        ShowForm(new NhomNguoiDungForm());
                        break;

                    case "btnKH":
                        // Xử lý Khách hàng
                        pnlMainContent.Controls.Clear();
                        ShowForm(new KhachHangForm());
                        break;

                    case "btnHD":
                        // Xử lý Hóa đơn
                        pnlMainContent.Controls.Clear();
                        ShowForm(new HoaDonForm());
                        break;

                    case "btnNK":
                        // Xử lý Nhập kho
                        pnlMainContent.Controls.Clear();
                        ShowForm(new NhapKhoForm());
                        break;

                    case "btnNCC":
                        // Xử lý Nhà cung cấp
                        pnlMainContent.Controls.Clear();
                        ShowForm(new NhaCungCapForm());
                        break;

                    case "btnS":
                        // Hiện menu ở vị trí nút
                        var senderBtn = (Guna2GradientButton)sender;
                        var screenPoint = senderBtn.PointToScreen(new Point(0, senderBtn.Height));
                        salaryMenu.Show(screenPoint);
                        break;
                }
            };

            return btn;
        }

        private void ShowForm(Form form)
        {
            pnlMainContent.Controls.Clear();
            picVan.Visible = false;

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(form);
            form.Show();
        }

        private void gbOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa thông tin người dùng
                CurrentUser.Logout(sidebarButtons, guna2Panel2);

                // Mở lại màn hình đăng nhập
                LoginForm loginForm = new LoginForm();

                // Đóng form chính
                this.Close();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            picVan.Visible = true;
        }
    }
}