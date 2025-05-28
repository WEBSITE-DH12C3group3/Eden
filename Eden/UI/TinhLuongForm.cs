using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Eden.DTO;
using Eden.BLLCustom;

namespace Eden.UI
{
    public partial class TinhLuongForm : Form
    {
        private readonly TINHLUONGBLL _bll;
        private List<LuongDTO> _luongList;
        private int currentPage = 1;
        private const int pageSize = 10;

        public TinhLuongForm()
        {
            InitializeComponent();
            _bll = new TINHLUONGBLL();
            SetupDataGridView();
            SetupControls();
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
                DataPropertyName = "MaNhanVien",
                HeaderText = "Mã Nhân Viên",
                Name = "MaNhanVien"
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

        private void SetupControls()
        {
            // Thêm các control để chọn tháng, năm và nhân viên
            var lblThang = new Label { Text = "Tháng:", Location = new System.Drawing.Point(10, 10), AutoSize = true };
            var numThang = new NumericUpDown { Name = "numThang", Minimum = 1, Maximum = 12, Value = DateTime.Now.Month, Location = new System.Drawing.Point(80, 10), Width = 50 };

            var lblNam = new Label { Text = "Năm:", Location = new System.Drawing.Point(140, 10), AutoSize = true };
            var numNam = new NumericUpDown { Name = "numNam", Minimum = 2020, Maximum = 2030, Value = DateTime.Now.Year, Location = new System.Drawing.Point(190, 10), Width = 70 };

            var lblNguoiDung = new Label { Text = "Nhân viên:", Location = new System.Drawing.Point(270, 10), AutoSize = true };
            var cmbNguoiDung = new ComboBox { Name = "cmbNguoiDung", Location = new System.Drawing.Point(340, 10), Width = 150 };
            var nguoiDungList = new NGUOIDUNGBLL().GetAll();
            cmbNguoiDung.DataSource = nguoiDungList;
            cmbNguoiDung.DisplayMember = "TenNguoiDung";
            cmbNguoiDung.ValueMember = "id";

            var btnTinhLuong = new Button { Text = "Tính Lương", Location = new System.Drawing.Point(500, 10), Width = 100 };
            btnTinhLuong.Click += BtnTinhLuong_Click;

            var lblSearch = new Label { Text = "Tìm kiếm:", Location = new System.Drawing.Point(10, 40), AutoSize = true };
            var txtSearch = new TextBox { Name = "txtSearch", Location = new System.Drawing.Point(80, 40), Width = 200 };
            txtSearch.TextChanged += TxtSearch_TextChanged;

            var btnPrevious = new Button { Text = "Trang trước", Location = new System.Drawing.Point(300, 40), Width = 100 };
            btnPrevious.Click += BtnPrevious_Click;

            var lblPageInfo = new Label { Name = "lblPageInfo", Text = "Trang 1/1", Location = new System.Drawing.Point(410, 40), AutoSize = true };

            var btnNext = new Button { Text = "Trang sau", Location = new System.Drawing.Point(480, 40), Width = 100 };
            btnNext.Click += BtnNext_Click;

            this.Controls.AddRange(new Control[] { lblThang, numThang, lblNam, numNam, lblNguoiDung, cmbNguoiDung, btnTinhLuong, lblSearch, txtSearch, btnPrevious, lblPageInfo, btnNext });

            // Điều chỉnh vị trí của DataGridView
            if (dgvLuong != null)
            {
                dgvLuong.Location = new System.Drawing.Point(10, 70);
                dgvLuong.Size = new System.Drawing.Size(600, 300);
            }
        }

        private void LoadData(string searchTerm = "", int page = 1)
        {
            try
            {
                if (_luongList == null)
                    _luongList = _bll.GetAll();

                var filteredList = _luongList
                    .Where(l => string.IsNullOrEmpty(searchTerm) ||
                                l.MaLuong.ToLower().Contains(searchTerm.ToLower()) ||
                                l.MaNhanVien.ToLower().Contains(searchTerm.ToLower()) ||
                                l.TenNguoiDung.ToLower().Contains(searchTerm.ToLower()) ||
                                l.ThangNam.ToLower().Contains(searchTerm.ToLower()))
                    .ToList();

                int totalItems = filteredList.Count;
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
                currentPage = Math.Max(1, Math.Min(page, totalPages));

                var pagedList = filteredList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .Select(l => new
                    {
                        l.MaLuong,
                        l.MaNhanVien,
                        l.TenNguoiDung,
                        l.ThangNam,
                        l.LuongCoDinh,
                        l.TongDoanhSo,
                        l.PhatDiMuon,
                        l.PhatNghiBuoi,
                        l.TroCap,
                        l.Thuong,
                        l.TongLuong,
                        NgayTinhLuong = l.NgayTinhLuong.ToString("dd/MM/yyyy HH:mm:ss"),
                        l.GhiChu
                    })
                    .ToList();

                dgvLuong.DataSource = pagedList;
                var lblPageInfo = this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblPageInfo");
                if (lblPageInfo != null)
                    lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

                var btnPrevious = this.Controls.OfType<Button>().FirstOrDefault(b => b.Text == "Trang trước");
                var btnNext = this.Controls.OfType<Button>().FirstOrDefault(b => b.Text == "Trang sau");
                if (btnPrevious != null) btnPrevious.Enabled = currentPage > 1;
                if (btnNext != null) btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTinhLuong_Click(object sender, EventArgs e)
        {
            try
            {
                var numThang = this.Controls.OfType<NumericUpDown>().FirstOrDefault(n => n.Name == "numThang");
                var numNam = this.Controls.OfType<NumericUpDown>().FirstOrDefault(n => n.Name == "numNam");
                var cmbNguoiDung = this.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Name == "cmbNguoiDung");

                if (numThang == null || numNam == null || cmbNguoiDung == null)
                {
                    MessageBox.Show("Không tìm thấy các điều khiển cần thiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int thang = (int)numThang.Value;
                int nam = (int)numNam.Value;
                int idNguoiDung = (int)cmbNguoiDung.SelectedValue;

                // Kiểm tra xem đã tính lương cho nhân viên trong tháng/năm này chưa
                if (_luongList.Any(l => l.IdNguoiDung == idNguoiDung && l.ThangNam == $"{thang}/{nam}"))
                {
                    MessageBox.Show($"Lương của nhân viên này trong tháng {thang}/{nam} đã được tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var luongDTO = _bll.CalculateSalary(idNguoiDung, thang, nam);
                _bll.SaveSalary(luongDTO);
                _luongList = null; // Reset để tải lại dữ liệu
                LoadData();
                MessageBox.Show($"Tính lương thành công cho nhân viên {luongDTO.TenNguoiDung} tháng {thang}/{nam}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var txtSearch = sender as TextBox;
            currentPage = 1;
            LoadData(txtSearch?.Text.Trim(), currentPage);
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            var txtSearch = this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txtSearch");
            LoadData(txtSearch?.Text.Trim(), currentPage);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            var txtSearch = this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txtSearch");
            LoadData(txtSearch?.Text.Trim(), currentPage);
        }
    }
}