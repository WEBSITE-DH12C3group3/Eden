using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden.DTO;
using Guna.UI2.WinForms; // Thêm namespace Guna

namespace Eden.UI
{
    public partial class ChamCongForm : Form
    {
        private ChamCongBLL chamCongBLL;

        public ChamCongForm()
        {
            InitializeComponent();
            chamCongBLL = new ChamCongBLL();
            dataGridViewChamCong.AutoGenerateColumns = false;
            dataGridViewChamCong.Columns.Clear();
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaChamCong",
                HeaderText = "Mã chấm công"
            });
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNhanVien",
                HeaderText = "Mã nhân viên"
            });
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNguoiDung",
                HeaderText = "Tên người dùng",
                Name = "TenNguoiDung"
            });
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayChamCong",
                HeaderText = "Ngày chấm công"
            });
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioDangNhap",
                HeaderText = "Giờ đăng nhập"
            });
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioDangXuat",
                HeaderText = "Giờ đăng xuất"
            });
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CaLamViec",
                HeaderText = "Ca làm việc"
            });
            dataGridViewChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái"
            });

            LoadChamCongData();
        }

        private void LoadChamCongData()
        {
            try
            {
                var (data, totalRecords) = chamCongBLL.GetPagedChamCong(1, 10); // Trang 1, 10 bản ghi
                if (dataGridViewChamCong != null)
                {
                    dataGridViewChamCong.DataSource = data;
                    //dataGridViewChamCong.Columns["id"].Visible = false; // Ẩn cột id nếu không cần
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChamCongForm_Load(object sender, EventArgs e)
        {
            if (dataGridViewChamCong == null)
            {
                dataGridViewChamCong = new Guna2DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                this.Controls.Add(dataGridViewChamCong);
            }
        }

        private void dataGridViewChamCong_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Kiểm tra xem người dùng hiện tại có phải là Admin hay không
            if (CurrentUser.UserGroupId == 1)
            {
                foreach (DataGridViewRow row in dataGridViewChamCong.Rows)
                {
                    // Lấy tên người dùng từ hàng hiện tại
                    // Đảm bảo "TenNguoiDung" là DataPropertyName hoặc Name của cột tên người dùng
                    string tenNguoiDungTrongHang = row.Cells["TenNguoiDung"].Value?.ToString();

                    // Nếu tên người dùng trong hàng khớp với tên người dùng Admin đang đăng nhập
                    if (tenNguoiDungTrongHang == CurrentUser.Username)
                    {
                        row.Visible = false; // Ẩn hàng đó đi
                    }
                }
            }
        }
    }
}