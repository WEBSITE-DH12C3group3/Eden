using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.Excel;
using Eden.BLLCustom;
using Eden.DTO;
using Guna.UI2.WinForms;
using Excel = Microsoft.Office.Interop.Excel; // Thêm namespace cho Excel

namespace Eden.UI
{
    public partial class TinhLuongForm : Form
    {
        private readonly TinhLuongBLL tinhLuongBLL;
        private int currentPage = 1;
        private const int pageSize = 10;

        public TinhLuongForm()
        {
            InitializeComponent();
            tinhLuongBLL = new TinhLuongBLL();
            SetupDataGridView();
            SetupControls();
            LoadLuongData();
        }

        private void SetupDataGridView()
        {
            if (dgvLuong == null)
            {
                dgvLuong = new Guna2DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                this.Controls.Add(dgvLuong);
            }

            dgvLuong.AutoGenerateColumns = false;
            dgvLuong.Columns.Clear();
            dgvLuong.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id", Visible = false },
                new DataGridViewTextBoxColumn { DataPropertyName = "MaLuong", HeaderText = "Mã Lương", Name = "MaLuong" },
                new DataGridViewTextBoxColumn { DataPropertyName = "MaNhanVien", HeaderText = "Mã Nhân Viên", Name = "MaNhanVien" },
                new DataGridViewTextBoxColumn { DataPropertyName = "TenNguoiDung", HeaderText = "Tên Nhân Viên", Name = "TenNguoiDung" },
                new DataGridViewTextBoxColumn { DataPropertyName = "ThangNam", HeaderText = "Tháng Năm", Name = "ThangNam" },
                new DataGridViewTextBoxColumn { DataPropertyName = "LuongCoDinh", HeaderText = "Lương Cố Định", Name = "LuongCoDinh", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "TongDoanhSo", HeaderText = "Tổng Doanh Số", Name = "TongDoanhSo", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "PhatDiMuon", HeaderText = "Phạt Đi Muộn", Name = "PhatDiMuon", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "PhatNghiBuoi", HeaderText = "Phạt Nghỉ Buổi", Name = "PhatNghiBuoi", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "TroCap", HeaderText = "Trợ Cấp", Name = "TroCap", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "Thuong", HeaderText = "Thưởng", Name = "Thuong", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "TongLuong", HeaderText = "Tổng Lương", Name = "TongLuong", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } },
                new DataGridViewTextBoxColumn { DataPropertyName = "NgayTinhLuong", HeaderText = "Ngày Tính Lương", Name = "NgayTinhLuong" },
                new DataGridViewTextBoxColumn { DataPropertyName = "GhiChu", HeaderText = "Ghi Chú", Name = "GhiChu" }
            });

            dgvLuong.DataBindingComplete += DgvLuong_DataBindingComplete;
        }

        private void SetupControls()
        {
            int paddingX = 20;
            int paddingY = 20;
            int controlSpacing = 15;
            int rowSpacing = 20;

            var labelTitle = this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelTitle") ?? new Label { Top = 0, Height = 30 };
            int topControlsY = labelTitle.Bottom + paddingY + 10;

            var lblThang = new Label { Text = "Tháng:", Location = new System.Drawing.Point(paddingX, topControlsY), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F) };
            var numThang = new NumericUpDown { Name = "numThang", Minimum = 1, Maximum = 12, Value = DateTime.Now.Month, Location = new System.Drawing.Point(lblThang.Right + controlSpacing, topControlsY), Width = 60, Font = new System.Drawing.Font("Segoe UI", 12F) };

            var lblNam = new Label { Text = "Năm:", Location = new System.Drawing.Point(numThang.Right + controlSpacing, topControlsY), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F) };
            var numNam = new NumericUpDown { Name = "numNam", Minimum = 2020, Maximum = 2030, Value = DateTime.Now.Year, Location = new System.Drawing.Point(lblNam.Right + controlSpacing, topControlsY), Width = 80, Font = new System.Drawing.Font("Segoe UI", 12F) };

            var lblNguoiDung = new Label { Text = "Nhân viên:", Location = new System.Drawing.Point(numNam.Right + controlSpacing * 2, topControlsY), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F) };
            var cmbNguoiDung = new ComboBox
            {
                Name = "cmbNguoiDung",
                Location = new System.Drawing.Point(lblNguoiDung.Right + controlSpacing, topControlsY),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new System.Drawing.Font("Segoe UI", 12F),
                BackColor = System.Drawing.Color.FromArgb(42, 45, 86),
                ForeColor = System.Drawing.Color.WhiteSmoke
            };
            var nguoiDungList = new NGUOIDUNGBLL().GetAll()
                .Where(n => n.idNhomNguoiDung != 1 && n.TrangThai == "Đang làm")
                .ToList();
            if (!nguoiDungList.Any())
            {
                MessageBox.Show("Không có nhân viên nào để tính lương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cmbNguoiDung.DataSource = nguoiDungList;
            cmbNguoiDung.DisplayMember = "TenNguoiDung";
            cmbNguoiDung.ValueMember = "id";

            var btnTinhLuong = new Guna2Button
            {
                Text = "Tính Lương",
                Location = new System.Drawing.Point(cmbNguoiDung.Right + controlSpacing * 2, topControlsY),
                Width = 120,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(39, 63, 139),
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            btnTinhLuong.Click += BtnTinhLuong_Click;

            var btnDelete = new Guna2Button
            {
                Text = "Xóa",
                Location = new System.Drawing.Point(btnTinhLuong.Right + controlSpacing, topControlsY),
                Width = 100,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(139, 63, 63),
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            btnDelete.Click += BtnDelete_Click;

            // Hàng 2: Nhóm nút phân trang
            int currentRow2Y = lblThang.Bottom + rowSpacing;
            var btnPrevious = new Guna2Button
            {
                Text = "Trang trước",
                Location = new System.Drawing.Point(paddingX, currentRow2Y),
                Width = 100,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(39, 63, 139),
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            btnPrevious.Click += BtnPrevious_Click;

            var lblPageInfo = new Label
            {
                Name = "lblPageInfo",
                Text = "Trang 1/1",
                Location = new System.Drawing.Point(btnPrevious.Right + controlSpacing, currentRow2Y),
                AutoSize = true,
                ForeColor = System.Drawing.Color.WhiteSmoke,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };

            var btnNext = new Guna2Button
            {
                Text = "Trang sau",
                Location = new System.Drawing.Point(lblPageInfo.Right + controlSpacing, currentRow2Y),
                Width = 100,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(39, 63, 139),
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            btnNext.Click += BtnNext_Click;

            // Thêm nút Xuất Excel
            var btnExportExcel = new Guna2Button
            {
                Text = "Xuất Excel",
                Location = new System.Drawing.Point(btnNext.Right + controlSpacing, currentRow2Y),
                Width = 120,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(34, 139, 34), // Màu xanh lá cây
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            btnExportExcel.Click += BtnExportExcel_Click;

            this.Controls.AddRange(new Control[]
            {
                lblThang, numThang, lblNam, numNam, lblNguoiDung, cmbNguoiDung, btnTinhLuong, btnDelete,
                btnPrevious, lblPageInfo, btnNext, btnExportExcel
            });

            int dgvTopY = btnNext.Bottom + rowSpacing;
            if (dgvLuong != null)
            {
                dgvLuong.Location = new System.Drawing.Point(paddingX, dgvTopY);
                dgvLuong.Size = new System.Drawing.Size(this.ClientSize.Width - (paddingX * 2), this.ClientSize.Height - dgvTopY - paddingY);
                dgvLuong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        private void LoadLuongData()
        {
            try
            {
                var (data, totalRecords) = tinhLuongBLL.GetPagedLuong(currentPage, pageSize);

                if (CurrentUser.UserGroupId == 1)
                {
                    data = data.Where(x => x.TenNguoiDung != CurrentUser.Username).ToList();
                }

                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                var pagedList = data.Select(l => new
                {
                    Id = l.Id,
                    MaLuong = l.MaLuong,
                    l.MaNhanVien,
                    l.TenNguoiDung,
                    ThangNam = l.ThangNam?.Length == 6 ? $"{l.ThangNam.Substring(0, 2)}/{l.ThangNam.Substring(2)}" : l.ThangNam,
                    l.LuongCoDinh,
                    l.TongDoanhSo,
                    l.PhatDiMuon,
                    l.PhatNghiBuoi,
                    l.TroCap,
                    l.Thuong,
                    l.TongLuong,
                    NgayTinhLuong = l.NgayTinhLuong.ToString("dd/MM/yyyy HH:mm:ss"),
                    l.GhiChu
                }).ToList();

                dgvLuong.DataSource = pagedList;

                var lblPageInfo = this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblPageInfo");
                if (lblPageInfo != null)
                    lblPageInfo.Text = $"Trang {currentPage}/{totalPages}";

                var btnPrevious = this.Controls.OfType<Guna2Button>().FirstOrDefault(b => b.Text == "Trang trước");
                var btnNext = this.Controls.OfType<Guna2Button>().FirstOrDefault(b => b.Text == "Trang sau");
                if (btnPrevious != null) btnPrevious.Enabled = currentPage > 1;
                if (btnNext != null) btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvLuong_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CurrentUser.UserGroupId == 1)
            {
                foreach (DataGridViewRow row in dgvLuong.Rows)
                {
                    string tenNguoiDung = row.Cells["TenNguoiDung"].Value?.ToString();
                    if (tenNguoiDung == CurrentUser.Username)
                    {
                        row.Visible = false;
                    }
                }
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
                    MessageBox.Show("Không tìm thấy điều khiển cần thiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int thang = (int)numThang.Value;
                int nam = (int)numNam.Value;

                if (thang < 1 || thang > 12 || nam < 2020 || nam > 2030)
                {
                    MessageBox.Show("Tháng hoặc năm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int? idNguoiDung = null;
                if (cmbNguoiDung.SelectedValue != null && int.TryParse(cmbNguoiDung.SelectedValue.ToString(), out int id))
                {
                    idNguoiDung = id;
                }

                bool success = tinhLuongBLL.CalculateAndSaveSalary(idNguoiDung, thang, nam);
                if (success)
                {
                    LoadLuongData();
                    MessageBox.Show($"Tính lương thành công cho tháng {thang:D2}/{nam}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu lương được tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính lương: {ex.Message}\n{ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadLuongData();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            var (data, totalRecords) = tinhLuongBLL.GetPagedLuong(currentPage + 1, pageSize);
            if (data.Any())
            {
                currentPage++;
                LoadLuongData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLuong.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một bản ghi để xóa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa các bản ghi đã chọn không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                bool hasDeleted = false;

                foreach (DataGridViewRow row in dgvLuong.SelectedRows)
                {
                    if (row.Cells["Id"] == null || string.IsNullOrEmpty(row.Cells["Id"].Value?.ToString()))
                    {
                        MessageBox.Show($"Bản ghi không có Id hợp lệ.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    if (!int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                    {
                        MessageBox.Show($"Id '{row.Cells["Id"].Value}' không hợp lệ.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    tinhLuongBLL.DeleteLuong(id);
                    hasDeleted = true;
                }

                if (hasDeleted)
                {
                    LoadLuongData();
                    MessageBox.Show("Xóa bản ghi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được xóa do lỗi dữ liệu.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa bản ghi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvLuong.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng SaveFileDialog để người dùng chọn nơi lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = $"DanhSachLuong_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return; // Người dùng hủy lưu file
                }

                Excel.Application excelApp = null;
                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;

                try
                {
                    // Tạo ứng dụng Excel
                    excelApp = new Excel.Application();
                    excelApp.Visible = false; // Không hiển thị Excel

                    // Tạo workbook và worksheet
                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];
                    worksheet.Name = "DanhSachLuong";

                    // Xuất tiêu đề cột
                    int visibleColumnCount = 0;
                    for (int i = 0; i < dgvLuong.Columns.Count; i++)
                    {
                        if (dgvLuong.Columns[i].Visible)
                        {
                            visibleColumnCount++;
                            worksheet.Cells[1, visibleColumnCount] = dgvLuong.Columns[i].HeaderText;
                            worksheet.Cells[1, visibleColumnCount].Font.Bold = true;
                            worksheet.Cells[1, visibleColumnCount].Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                    }

                    // Xuất dữ liệu từ DataGridView
                    int rowIndex = 2;
                    foreach (DataGridViewRow row in dgvLuong.Rows)
                    {
                        if (!row.Visible) // Bỏ qua các hàng không hiển thị
                            continue;

                        int excelColumnIndex = 1;
                        for (int j = 0; j < dgvLuong.Columns.Count; j++)
                        {
                            if (!dgvLuong.Columns[j].Visible)
                                continue;

                            var cellValue = row.Cells[j].Value;
                            worksheet.Cells[rowIndex, excelColumnIndex] = cellValue?.ToString() ?? "";
                            excelColumnIndex++;
                        }
                        rowIndex++;
                    }

                    // Tự động điều chỉnh kích thước cột
                    worksheet.Columns.AutoFit();

                    // Lưu file
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Đóng workbook và ứng dụng Excel
                    if (worksheet != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    if (workbook != null)
                    {
                        workbook.Close(false);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    }
                    if (excelApp != null)
                    {
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    }
                }
            }
        }
    }
}