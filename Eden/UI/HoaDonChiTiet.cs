using System;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden; // Thêm namespace để sử dụng CHITIETHOADONBLL


namespace Eden.UI
{
    public partial class HoaDonChiTiet : Form
    {
        private CHITIETHOADONBLL chiTietHoaDonBLL;
        private int idHoaDon; // Lưu idHoaDon được truyền từ HoaDonForm

        public HoaDonChiTiet(int idHoaDon)
        {
            InitializeComponent();
            this.idHoaDon = idHoaDon;
            chiTietHoaDonBLL = new CHITIETHOADONBLL();

            // Cấu hình DataGridView
            dgvChiTietHD.AutoGenerateColumns = false;
            dgvChiTietHD.Columns.Clear();
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaHoaDon",
                HeaderText = "Mã Hóa Đơn"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSanPham",
                HeaderText = "Mã Sản Phẩm"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSanPham",
                HeaderText = "Tên Sản Phẩm"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "Số Lượng"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn Giá"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Thành Tiền"
            });

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var chiTietList = chiTietHoaDonBLL.GetByHoaDonId(idHoaDon);
                dgvChiTietHD.DataSource = null;
                dgvChiTietHD.DataSource = chiTietList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTietHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Có thể thêm xử lý nếu cần (ví dụ: hiển thị thông tin chi tiết hơn)
        }

        private void back_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại và quay lại HoaDonForm
            // this.Close();
            HoaDonForm form = new HoaDonForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }

        private void HoaDonChiTiet_Load(object sender, EventArgs e)
        {
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ DataGridView
            DataTable dt = new DataTable();

            // Thêm các cột từ DataGridView
            foreach (DataGridViewColumn column in dgvChiTietHD.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            // Thêm cột "Tổng tiền"
            dt.Columns.Add("Tổng tiền", typeof(decimal));

            // Duyệt qua các dòng trong DataGridView và thêm vào DataTable
            foreach (DataGridViewRow row in dgvChiTietHD.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    decimal tongTien = 0; // Khởi tạo biến tính tổng tiền

                    for (int i = 0; i < dgvChiTietHD.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value?.ToString();

                        // Giả sử cột số lượng và đơn giá có index tương ứng là 'soLuongColumnIndex' và 'donGiaColumnIndex'
                        // Bạn cần thay thế các giá trị này bằng index thực tế của cột trong DataGridView
                        int soLuongColumnIndex = -1;
                        int donGiaColumnIndex = -1;

                        // Tìm index của cột "Số lượng" và "Đơn giá" (chú ý tên cột có thể khác)
                        for (int j = 0; j < dgvChiTietHD.Columns.Count; j++)
                        {
                            if (dgvChiTietHD.Columns[j].HeaderText.ToLower().Contains("số lượng"))
                            {
                                soLuongColumnIndex = j;
                            }
                            if (dgvChiTietHD.Columns[j].HeaderText.ToLower().Contains("đơn giá"))
                            {
                                donGiaColumnIndex = j;
                            }
                        }

                        // Tính toán tổng tiền nếu tìm thấy cả hai cột
                        if (i == soLuongColumnIndex && donGiaColumnIndex != -1 && row.Cells[i].Value != null && decimal.TryParse(row.Cells[i].Value.ToString(), out decimal soLuong))
                        {
                            if (row.Cells[donGiaColumnIndex].Value != null && decimal.TryParse(row.Cells[donGiaColumnIndex].Value.ToString(), out decimal donGia))
                            {
                                tongTien = soLuong * donGia;
                            }
                        }
                    }
                    dr["Tổng tiền"] = tongTien;
                    dt.Rows.Add(dr);
                }
            }

            // Lưu Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "ChiTietHoaDon.xlsx"; // Đổi tên file cho phù hợp

            if (saveFileDialog.ShowDialog() == DialogResult.OK)

            {
                string userName = CurrentUser.Username;
                if (string.IsNullOrEmpty(userName))
                {
                    userName = Environment.UserName;
                    MessageBox.Show($"Không tìm thấy thông tin người dùng. Sử dụng tên hệ thống: {userName}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Diagnostics.Debug.WriteLine($"[HoaDonForm] Xuất Excel: CurrentUser.Username is null, sử dụng {userName} at {DateTime.Now}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[HoaDonForm] Xuất Excel: CurrentUser.Username = {userName} at {DateTime.Now}");
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Chi Tiết Hóa Đơn"); // Đổi tên worksheet

                    // Tiêu đề
                    ws.Cell("A1").Value = "Cửa hàng bán hoa EDEN";
                    ws.Cell("A1").Style.Font.Bold = true;
                    ws.Cell("A1").Style.Font.FontSize = 16;


                    string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ws.Cell(2, 5).Value = $"Người xuất: {userName}";
                    ws.Cell(2, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(2, 5).Style.Font.Bold = true;
                    ws.Range(2, 5, 2, 6).Merge();
                    ws.Cell(3, 5).Value = $"Ngày xuất: {exportDateTime}";
                    ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(3, 5).Style.Font.Bold = true;
                    ws.Range(3, 5, 3, 6).Merge();

                    // Đổ dữ liệu từ DataTable
                    ws.Cell("A4").InsertTable(dt.AsEnumerable());


                    // Chân trang: Tổng tiền
                    var lastRow = 4 + dt.Rows.Count;
                    object sumResult = dt.Compute("Sum([Tổng tiền])", "");
                    if (sumResult != null && decimal.TryParse(sumResult.ToString(), out decimal totalSum))
                    {
                        ws.Cell(lastRow + 2, dt.Columns.Count).Value = totalSum;
                    }
                    else
                    {
                        ws.Cell(lastRow + 2, dt.Columns.Count).Value = "N/A"; // Hoặc một giá trị mặc định khác
                    }
                    ws.Cell(lastRow + 2, dt.Columns.Count).Style.Font.Bold = true;
                    ws.Cell(lastRow + 2, dt.Columns.Count - 1).Value = "Tổng tiền:";
                    ws.Cell(lastRow + 2, dt.Columns.Count - 1).Style.Font.Bold = true;

                    // Chân trang: Địa chỉ và số điện thoại
                    ws.Cell(lastRow + 3, 1).Value = "Địa chỉ: [Địa chỉ cửa hàng: Cây nhà lá vườn]"; // Thay bằng địa chỉ thực tế
                    ws.Cell(lastRow + 4, 1).Value = "Điện thoại: [Số điện thoại cửa hàng: 0987654321]"; // Thay bằng số điện thoại thực tế

                    // Lưu file Excel
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}