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
            LoadChamCongData();
        }

        private void LoadChamCongData()
        {
            try
            {
                var (data, totalRecords) = chamCongBLL.GetPagedChamCong(1, 10); // Trang 1, 10 bản ghi
                if (dataGridViewChamCong != null) // Sử dụng dataGridViewChamCong
                {
                    dataGridViewChamCong.DataSource = data;
                    dataGridViewChamCong.Columns["id"].Visible = false; // Ẩn cột id nếu không cần
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChamCongForm_Load(object sender, EventArgs e)
        {
            if (dataGridViewChamCong == null) // Khởi tạo Guna2DataGridView
            {
                dataGridViewChamCong = new Guna2DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                this.Controls.Add(dataGridViewChamCong);
            }
        }
    }
}