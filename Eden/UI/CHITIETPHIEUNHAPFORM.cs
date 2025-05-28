using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using Eden;
using Guna.UI2.WinForms;

namespace Eden.UI
{
    public partial class CHITIETPHIEUNHAPFORM : Form
    {
        private readonly int _idPhieuNhap;
        private readonly PHIEUNHAPDAL dal = new PHIEUNHAPDAL();

        public CHITIETPHIEUNHAPFORM(int idPhieuNhap)
        {
            InitializeComponent();  // RẤT QUAN TRỌNG
            _idPhieuNhap = idPhieuNhap;
            LoadData();
        }

        // Constructor phụ dùng string → gọi lại constructor chính
        public CHITIETPHIEUNHAPFORM(string maPhieuNhap)
            : this(GetIdPhieuNhapFromMa(maPhieuNhap))
        {
        }

        // Hàm hỗ trợ convert từ mã phiếu nhập sang id
        private static int GetIdPhieuNhapFromMa(string maPhieuNhap)
        {
            // Ví dụ bạn có thể truy vấn DB để lấy id từ maPhieuNhap
            using (var db = new QLBanHoaEntities())
            {
                var phieu = db.PHIEUNHAPs.FirstOrDefault(p => p.MaPhieuNhap == maPhieuNhap);
                return phieu?.id ?? 0;
            }
        }

        private void LoadData()
        {
            try
            {
                using (var db = new QLBanHoaEntities())
                {
                    var data = dal.GetChiTietByPhieuNhap(_idPhieuNhap)
                                  .Select(c => new
                                  {
                                      MaPhieuNhap = db.PHIEUNHAPs
                                                     .Where(p => p.id == c.idPhieuNhap)
                                                     .Select(p => p.MaPhieuNhap)
                                                     .FirstOrDefault() ?? "N/A",
                                      MaSanPham = c.SANPHAM != null ? c.SANPHAM.MaSanPham : "N/A", // Thay idSanPham bằng MaSanPham
                                      TenSanPham = c.SANPHAM != null ? c.SANPHAM.TenSanPham : "N/A",
                                      c.SoLuong,
                                      c.DonGia,
                                      c.ThanhTien
                                  }).ToList();

                    dgvChiTiet.DataSource = data;

                    // Cập nhật tiêu đề cột
                    dgvChiTiet.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
                    dgvChiTiet.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm"; // Cập nhật tiêu đề
                    dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                    dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu chi tiết phiếu nhập: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            //this.Close();
            NhapKhoForm form = new NhapKhoForm();
            this.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            form.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ DataGridView
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgvChiTiet.Columns)
                {
                    dt.Columns.Add(column.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvChiTiet.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < dgvChiTiet.Columns.Count; i++)
                        {
                            dr[i] = row.Cells[i].Value?.ToString() ?? "N/A";
                        }
                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu chi tiết để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin người dùng, mặc định là "admin" nếu không có
                string userName = "admin"; // Thay bằng CurrentUser.Username nếu có thông tin người dùng đăng nhập
                System.Diagnostics.Debug.WriteLine($"[CHITIETPHIEUNHAPFORM] Xuất Excel: Người xuất = {userName} at {DateTime.Now}");

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                    saveFileDialog.Title = "Lưu file Excel";

                    // Kiểm tra nếu có dữ liệu để lấy MaPhieuNhap
                    string maPhieuNhap = dgvChiTiet.Rows.Count > 0 ? (dgvChiTiet.Rows[0].Cells["MaPhieuNhap"].Value?.ToString() ?? "Unknown") : "Unknown";
                    saveFileDialog.FileName = $"ChiTietPhieuNhap_{maPhieuNhap}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("ChiTietPhieuNhap");
                            ws.PageSetup.PaperSize = XLPaperSize.A4Paper;
                            ws.PageSetup.Margins.Left = 0.5;
                            ws.PageSetup.Margins.Right = 0.5;
                            ws.PageSetup.Margins.Top = 0.75;
                            ws.PageSetup.Margins.Bottom = 0.75;
                            ws.PageSetup.CenterHorizontally = true;
                            ws.PageSetup.PageOrientation = XLPageOrientation.Portrait;

                            ws.Cell(1, 1).Value = "Cửa Hàng Hoa Tươi EDEN";
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 18;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            ws.Range(1, 1, 1, 6).Merge();

                            ws.Cell(2, 1).Value = $"Chi Tiết Phiếu Nhập - {maPhieuNhap}";
                            ws.Cell(2, 1).Style.Font.Bold = true;
                            ws.Cell(2, 1).Style.Font.FontSize = 16;
                            ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Range(2, 1, 2, 6).Merge();

                            string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            ws.Cell(3, 5).Value = $"Người xuất: {userName}";
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            ws.Cell(3, 5).Style.Font.Bold = true;
                            ws.Range(3, 5, 3, 6).Merge();
                            ws.Cell(4, 5).Value = $"Ngày xuất: {exportDateTime}";
                            ws.Cell(4, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            ws.Cell(4, 5).Style.Font.Bold = true;
                            ws.Range(4, 5, 4, 6).Merge();

                            var dataRange = ws.Cell(6, 1).InsertTable(dt.AsEnumerable()).AsRange();
                            var headerRow = dataRange.FirstRow();
                            headerRow.Style.Font.Bold = true;
                            headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Đặt màu chữ của dữ liệu về màu đen
                            dataRange.Rows().Style.Font.FontColor = XLColor.Black;

                            ws.Column(4).Style.NumberFormat.Format = "#,##0"; // Số Lượng
                            ws.Column(5).Style.NumberFormat.Format = "#,##0"; // Đơn Giá
                            ws.Column(6).Style.NumberFormat.Format = "#,##0"; // Thành Tiền

                            var lastRow = dataRange.LastRow().RowNumber();
                            ws.Cell(lastRow + 1, 5).Value = "Tổng cộng:";
                            ws.Cell(lastRow + 1, 6).Value = dt.AsEnumerable().Sum(row => Convert.ToDecimal(row["Thành Tiền"] ?? 0));
                            ws.Cell(lastRow + 1, 5).Style.Font.Bold = true;
                            ws.Cell(lastRow + 1, 6).Style.Font.Bold = true;
                            ws.Cell(lastRow + 1, 6).Style.NumberFormat.Format = "#,##0";

                            ws.Cell(lastRow + 3, 1).Value = "Địa chỉ: Cây nhà lá vườn";
                            ws.Cell(lastRow + 3, 1).Style.Font.Bold = true;
                            ws.Cell(lastRow + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            ws.Range(lastRow + 3, 1, lastRow + 3, 6).Merge();

                            ws.Cell(lastRow + 4, 1).Value = "Sdt: 0909090909";
                            ws.Cell(lastRow + 4, 1).Style.Font.Bold = true;
                            ws.Cell(lastRow + 4, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            ws.Range(lastRow + 4, 1, lastRow + 4, 6).Merge();

                            ws.Columns().AdjustToContents();
                            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            wb.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}