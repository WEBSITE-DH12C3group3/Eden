using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden.BLLCustom;
using Eden.DTO;
using Guna.UI2.WinForms;
using Excel = Microsoft.Office.Interop.Excel; // Thêm namespace cho Excel

namespace Eden.UI
{
    public partial class ChamCongForm : Form
    {
        private ChamCongBLL chamCongBLL;

        public ChamCongForm()
        {
            InitializeComponent();
            chamCongBLL = new ChamCongBLL();
            SetupDataGridView();
            SetupControls();
            LoadChamCongData();
        }

        private void SetupDataGridView()
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

            dataGridViewChamCong.DataBindingComplete += dataGridViewChamCong_DataBindingComplete;
        }

        private void SetupControls()
        {
            int paddingX = 20;
            int paddingY = 20;
            int controlSpacing = 15;

            // Thêm label và Guna2ComboBox cho nhân viên
            var lblNguoiDung = new Label { Text = "Nhân viên:", Location = new System.Drawing.Point(paddingX, paddingY), AutoSize = true, ForeColor = System.Drawing.Color.WhiteSmoke, Font = new System.Drawing.Font("Segoe UI", 12F) };
            var cmbloc = new Guna2ComboBox
            {
                Name = "cmbloc",
                Location = new System.Drawing.Point(lblNguoiDung.Right + controlSpacing, paddingY),
                Width = 200,
                Font = new System.Drawing.Font("Segoe UI", 12F),
                FillColor = System.Drawing.Color.FromArgb(42, 45, 86),
                ForeColor = System.Drawing.Color.WhiteSmoke,
                BorderRadius = 10
            };

            // Lấy danh sách nhân viên và gán vào Guna2ComboBox
            var nguoiDungList = new NGUOIDUNGBLL().GetAll()
                .Where(n => n.idNhomNguoiDung != 1 && n.TrangThai == "Đang làm")
                .Select(n => new { n.MaNhanVien, n.TenNguoiDung })
                .ToList();

            if (nguoiDungList == null || !nguoiDungList.Any())
            {
                MessageBox.Show("Không tìm thấy nhân viên nào thỏa mãn điều kiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát nếu không có dữ liệu
            }

            cmbloc.DataSource = nguoiDungList;
            cmbloc.DisplayMember = "TenNguoiDung"; // Hiển thị tên nhân viên
            cmbloc.ValueMember = "MaNhanVien";     // Giá trị thực tế là MaNhanVien

            // Thêm nút Lọc
            var loc = new Guna2Button
            {
                Text = "Lọc",
                Location = new System.Drawing.Point(cmbloc.Right + controlSpacing, paddingY),
                Width = 100,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(39, 63, 139),
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            loc.Click += Loc_Click;

            // Thêm nút Xuất Excel
            var exportExcel = new Guna2Button
            {
                Text = "Xuất Excel",
                Location = new System.Drawing.Point(loc.Right + controlSpacing, paddingY),
                Width = 120,
                Height = 30,
                FillColor = System.Drawing.Color.FromArgb(34, 139, 34), // Màu xanh lá cây
                ForeColor = System.Drawing.Color.White,
                BorderRadius = 10,
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            exportExcel.Click += ExportExcel_Click;

            this.Controls.AddRange(new Control[] { lblNguoiDung, cmbloc, loc, exportExcel });
        }

        private void LoadChamCongData()
        {
            try
            {
                var (data, totalRecords) = chamCongBLL.GetPagedChamCong(1, 10); // Trang 1, 10 bản ghi

                // Nếu là admin, lọc dữ liệu: loại bỏ dòng có tên == tên Admin hiện tại
                if (CurrentUser.UserGroupId == 1)
                {
                    data = data.Where(x => x.TenNguoiDung != CurrentUser.Username).ToList();
                }

                if (dataGridViewChamCong != null)
                {
                    dataGridViewChamCong.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loc_Click(object sender, EventArgs e)
        {
            try
            {
                var cmbloc = this.Controls.OfType<Guna2ComboBox>().FirstOrDefault(c => c.Name == "cmbloc");
                if (cmbloc == null || cmbloc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một nhân viên để lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maNhanVien = cmbloc.SelectedValue.ToString();
                var (data, totalRecords) = chamCongBLL.GetPagedChamCong(1, 10); // Lấy dữ liệu ban đầu

                // Lọc dữ liệu dựa trên MaNhanVien
                data = data.Where(x => x.MaNhanVien == maNhanVien).ToList();

                // Nếu là admin, loại bỏ dòng có tên == tên Admin hiện tại
                if (CurrentUser.UserGroupId == 1)
                {
                    data = data.Where(x => x.TenNguoiDung != CurrentUser.Username).ToList();
                }

                if (dataGridViewChamCong != null)
                {
                    dataGridViewChamCong.DataSource = data;
                }

                // Cập nhật thông tin phân trang (nếu cần)
                var lblPageInfo = this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblPageInfo");
                if (lblPageInfo != null)
                {
                    lblPageInfo.Text = $"Trang 1/{(int)Math.Ceiling((double)data.Count / 10)}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewChamCong.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng SaveFileDialog để người dùng chọn nơi lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = $"DanhSachChamCong_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

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
                    worksheet.Name = "DanhSachChamCong";

                    // Xuất tiêu đề cột
                    for (int i = 0; i < dataGridViewChamCong.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dataGridViewChamCong.Columns[i].HeaderText;
                        worksheet.Cells[1, i + 1].Font.Bold = true;
                        worksheet.Cells[1, i + 1].Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                    }

                    // Xuất dữ liệu từ DataGridView
                    for (int i = 0; i < dataGridViewChamCong.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridViewChamCong.Columns.Count; j++)
                        {
                            var cellValue = dataGridViewChamCong.Rows[i].Cells[j].Value;
                            worksheet.Cells[i + 2, j + 1] = cellValue?.ToString() ?? "";
                        }
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
            // Có thể thêm logic xử lý sau khi dữ liệu được gắn vào DataGridView
        }
    }
}