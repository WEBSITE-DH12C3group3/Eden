using System;
using System.Windows.Forms;
using Eden.DTO;

namespace Eden.UI
{
    public partial class TinhLuongForm : Form
    {
        private readonly TINHLUONGBLL _bll;

        public TinhLuongForm()
        {
            InitializeComponent();
            _bll = new TINHLUONGBLL();
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            dgvLuong.AutoGenerateColumns = false;
            dgvLuong.Columns.Clear();
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaLuong",
                HeaderText = "Mã Lương",
                Name = "MaLuong"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNguoiDung",
                HeaderText = "Tên Nhân Viên",
                Name = "TenNguoiDung"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThangNam",
                HeaderText = "Tháng Năm",
                Name = "ThangNam"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LuongCoDinh",
                HeaderText = "Lương Cố Định",
                Name = "LuongCoDinh"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongDoanhSo",
                HeaderText = "Tổng Doanh Số",
                Name = "TongDoanhSo"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhatDiMuon",
                HeaderText = "Phạt Đi Muộn",
                Name = "PhatDiMuon"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhatNghiBuoi",
                HeaderText = "Phạt Nghỉ Buổi",
                Name = "PhatNghiBuoi"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TroCap",
                HeaderText = "Trợ Cấp",
                Name = "TroCap"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Thuong",
                HeaderText = "Thưởng",
                Name = "Thuong"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TongLuong",
                HeaderText = "Tổng Lương",
                Name = "TongLuong"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayTinhLuong",
                HeaderText = "Ngày Tính Lương",
                Name = "NgayTinhLuong"
            });
            dgvLuong.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GhiChu",
                HeaderText = "Ghi Chú",
                Name = "GhiChu"
            });
        }

        private void LoadData()
        {
            try
            {
                var data = _bll.GetAllDTO();
                dgvLuong.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}