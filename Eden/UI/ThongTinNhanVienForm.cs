using System;
using System.Windows.Forms;
using Eden.DTO;

namespace Eden.UI
{
    public partial class ThongTinNhanVienForm : Form
    {
        //private readonly THONGTINNVBLL _bll;
        //private int _currentPage = 1;
        //private readonly int _pageSize = 10;

        //public ThongTinNhanVienForm()
        //{
        //    InitializeComponent();
        //    _bll = new THONGTINNVBLL();
        //    SetupDataGridView();
        //    LoadData();
        //}

        //private void SetupDataGridView()
        //{
        //    dgvNhanVien.AutoGenerateColumns = false;
        //    dgvNhanVien.Columns.Clear();
        //    dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        DataPropertyName = "MaNhanVien",
        //        HeaderText = "Mã Nhân Viên",
        //        Name = "MaNhanVien"
        //    });
        //    dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        DataPropertyName = "TenNguoiDung",
        //        HeaderText = "Tên Người Dùng",
        //        Name = "TenNguoiDung"
        //    });
        //    dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        DataPropertyName = "LuongCoDinh",
        //        HeaderText = "Lương Cố Định",
        //        Name = "LuongCoDinh"
        //    });
        //    dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        DataPropertyName = "NgayBatDauLam",
        //        HeaderText = "Ngày Bắt Đầu Làm",
        //        Name = "NgayBatDauLam"
        //    });
        //    dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        DataPropertyName = "TrangThai",
        //        HeaderText = "Trạng Thái",
        //        Name = "TrangThai"
        //    });
        //}

        //private void LoadData()
        //{
        //    try
        //    {
        //        var (data, totalRecords) = _bll.GetPaged(_currentPage, _pageSize);
        //        dgvNhanVien.DataSource = data;
        //        //UpdatePagingControls(totalRecords);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        ////private void UpdatePagingControls(int totalRecords)
        ////{
        ////    int totalPages = (int)Math.Ceiling((double)totalRecords / _pageSize);
        ////    lblPageInfo.Text = $"Trang {_currentPage} / {totalPages}";
        ////    btnPrevious.Enabled = _currentPage > 1;
        ////    btnNext.Enabled = _currentPage < totalPages;
        ////}

        //private void btnPrevious_Click(object sender, EventArgs e)
        //{
        //    if (_currentPage > 1)
        //    {
        //        _currentPage--;
        //        LoadData();
        //    }
        //}

        //private void btnNext_Click(object sender, EventArgs e)
        //{
        //    _currentPage++;
        //    LoadData();
        //}
    }
}