using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Eden.DTO;
using Eden.BLLCustom;
using Guna.UI2.WinForms;

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
            // Define spacing and padding
            int paddingX = 20; // Horizontal padding from the left edge of the form
            int paddingY = 20; // Vertical padding from the top of the relevant control
            int controlSpacing = 15; // Space between controls
            int rowSpacing = 20; // Space between rows of controls

            // Get the bottom position of the existing labelTitle
            // This assumes labelTitle is the top-most visual element you want to respect.
            int topControlsY = labelTitle.Bottom + paddingY;

            // Row 1: Month, Year, Employee
            var lblThang = new Label { Text = "Tháng:", Location = new System.Drawing.Point(paddingX, topControlsY), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };
            var numThang = new NumericUpDown { Name = "numThang", Minimum = 1, Maximum = 12, Value = DateTime.Now.Month, Location = new System.Drawing.Point(lblThang.Right + controlSpacing, topControlsY), Width = 60, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };

            var lblNam = new Label { Text = "Năm:", Location = new System.Drawing.Point(numThang.Right + controlSpacing, topControlsY), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };
            var numNam = new NumericUpDown { Name = "numNam", Minimum = 2020, Maximum = 2030, Value = DateTime.Now.Year, Location = new System.Drawing.Point(lblNam.Right + controlSpacing, topControlsY), Width = 80, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };

            var lblNguoiDung = new Label { Text = "Nhân viên:", Location = new System.Drawing.Point(numNam.Right + controlSpacing * 2, topControlsY), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };
            var cmbNguoiDung = new ComboBox { Name = "cmbNguoiDung", Location = new System.Drawing.Point(lblNguoiDung.Right + controlSpacing, topControlsY), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };
            var nguoiDungList = new NGUOIDUNGBLL().GetAll();
            cmbNguoiDung.DataSource = nguoiDungList;
            cmbNguoiDung.DisplayMember = "TenNguoiDung";
            cmbNguoiDung.ValueMember = "id";
            // Style for ComboBox to match dark theme
            cmbNguoiDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            cmbNguoiDung.ForeColor = System.Drawing.Color.WhiteSmoke;
            cmbNguoiDung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // Row 2: Calculate Button, Search, Pagination
            int currentRow2Y = lblThang.Bottom + rowSpacing; // Start of the second row of controls

            var btnTinhLuong = new Guna2Button // Using Guna2Button for consistency
            {
                Text = "Tính Lương",
                Location = new System.Drawing.Point(cmbNguoiDung.Right + controlSpacing * 2, topControlsY), // Position relative to cmbNguoiDung or a fixed point
                Width = 120,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))), // Matching DGV header
                ForeColor = System.Drawing.Color.White, // White text for contrast
                BorderRadius = 10 // Apply border radius for Guna button style
                ,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
            };
            btnTinhLuong.Click += BtnTinhLuong_Click;

            var lblSearch = new Label { Text = "Tìm kiếm:", Location = new System.Drawing.Point(paddingX, currentRow2Y), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };
            var txtSearch = new TextBox { Name = "txtSearch", Location = new System.Drawing.Point(lblSearch.Right + controlSpacing, currentRow2Y), Width = 200, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            // Style for TextBox to match dark theme
            txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            txtSearch.ForeColor = System.Drawing.Color.WhiteSmoke;

            var btnPrevious = new Guna2Button // Using Guna2Button for consistency
            {
                Text = "Trang trước",
                Location = new System.Drawing.Point(txtSearch.Right + controlSpacing * 2, currentRow2Y),
                Width = 100,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))), // Matching DGV header
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
            };
            btnPrevious.Click += BtnPrevious_Click;

            var lblPageInfo = new Label { Name = "lblPageInfo", Text = "Trang 1/1", Location = new System.Drawing.Point(btnPrevious.Right + controlSpacing, currentRow2Y), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) };

            var btnNext = new Guna2Button // Using Guna2Button for consistency
            {
                Text = "Trang sau",
                Location = new System.Drawing.Point(lblPageInfo.Right + controlSpacing, currentRow2Y),
                Width = 100,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(63)))), ((int)(((byte)(139))))), // Matching DGV header
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
            };
            btnNext.Click += BtnNext_Click;

            this.Controls.AddRange(new Control[] {
                lblThang, numThang, lblNam, numNam, lblNguoiDung, cmbNguoiDung, btnTinhLuong,
                lblSearch, txtSearch, btnPrevious, lblPageInfo, btnNext
            });

            // Adjust the DataGridView position to be below the newly added controls
            int dgvTopY = Math.Max(btnTinhLuong.Bottom, btnNext.Bottom) + rowSpacing; // Get the max bottom of the last row of controls

            if (dgvLuong != null)
            {
                dgvLuong.Location = new System.Drawing.Point(paddingX, dgvTopY);
                // For full screen, ensure it anchors properly
                dgvLuong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                // Calculate size based on remaining client area, considering the Excel button at the bottom
                dgvLuong.Size = new System.Drawing.Size(this.ClientSize.Width - (paddingX * 2), this.ClientSize.Height - dgvTopY - (btnExcel.Height + paddingY)); // Reserve space for btnExcel and bottom padding
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