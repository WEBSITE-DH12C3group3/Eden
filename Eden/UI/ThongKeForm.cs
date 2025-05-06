using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ClosedXML.Excel;
using System.IO;
using DocumentFormat.OpenXml.Math;

namespace Eden
{
    public partial class ThongKeForm : Form
    {
        private QLBanHoaEntities db = new QLBanHoaEntities(); // DbContext của Entity Framework
        private Dashboard model;
        private Guna2Button currentButton;

        public ThongKeForm()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();
            this.chartGrossRevenue.MouseMove += chart1_MouseMove;

            SetDateMenuButtonUI(btnLast7Days);
            model = new Dashboard(db);
            LoadData();
        }

        private void LoadData()
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData)
            {
                // Gán số liệu
                lblNumOrders.Text = model.NumOrders.ToString();
                lblTotalRevenue.Text = model.TotalRevenue.ToString("#,##0") + "đ";
                lblTotalProfit.Text = model.TotalProfit.ToString("#,##0") + "đ";
                lblNumCustomers.Text = model.NumCustomers.ToString();
                lblNumSuppliers.Text = model.NumSuppliers.ToString();
                lblNumProducts.Text = model.NumProducts.ToString();

                // Cập nhật Chart Doanh thu
                var series = chartGrossRevenue.Series[0];
                series.Points.Clear();

                foreach (var item in model.GrossRevenueList)
                {
                    int pointIndex = series.Points.AddXY(item.Date, item.TotalAmount);
                    double amount = (double)item.TotalAmount;
                    string label = amount >= 1000 ? (amount / 1000).ToString("0.#") + "k" : amount.ToString("0");
                    series.Points[pointIndex].Label = label;
                }

                // Cập nhật biểu đồ Top Products
                chartTopProducts.DataSource = model.TopProductsList
                    .Select(p => new { Key = p.Name, Value = (double)p.Quantity })
                    .ToList();
                chartTopProducts.Series[0].XValueMember = "Key";
                chartTopProducts.Series[0].YValueMembers = "Value";
                chartTopProducts.DataBind();

                // Bảng dưới mức tồn kho
                dgvUnderstock.DataSource = model.UnderstockList
                    .Select(p => new { Name = p.Name, Quantity = (double)p.Quantity })
                    .ToList();
                dgvUnderstock.ClearSelection();
            }
        }

        private void SetDateMenuButtonUI(object button)
        {
            var btn = (Guna.UI2.WinForms.Guna2Button)button;

            // Highlight: nút đang được chọn
            btn.FillColor = Color.FromArgb(46, 117, 173); // màu nền khi được chọn
            btn.ForeColor = Color.White;

            // Contrast: reset lại nút trước đó
            if (currentButton != null && currentButton != btn)
            {
                currentButton.FillColor = Color.Transparent;
                currentButton.ForeColor = Color.FromArgb(124, 141, 181);
            }
            currentButton = btn; // Gán nút hiện tại là đang active

            // Enable customdate
            if (btn == btnCustomDate)
            {
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
                btnOkCustomDate.Visible = true;
                lblStartDate.Cursor = Cursors.Hand;
                lblEndDate.Cursor = Cursors.Hand;
            }
            else
            {
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                btnOkCustomDate.Visible = false;
                lblStartDate.Cursor = Cursors.Default;
                lblEndDate.Cursor = Cursors.Default;
            }
        }

        //Event methods
        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            SetDateMenuButtonUI(sender);
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            btnOkCustomDate.Visible = true;
            SetDateMenuButtonUI(sender);
        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lblStartDate_Click(object sender, EventArgs e)
        {
            if (currentButton == btnCustomDate)
            {
                dtpStartDate.Select();
                SendKeys.Send("{F4}"); // Mở lịch chọn ngày
            }
        }

        private void lblEndDate_Click(object sender, EventArgs e)
        {
            if (currentButton == btnCustomDate)
            {
                dtpEndDate.Select();
                SendKeys.Send("{F4}"); // Mở lịch chọn ngày
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            lblStartDate.Text = dtpStartDate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            lblEndDate.Text = dtpEndDate.Value.ToString("dd/MM/yyyy");
        }

        private void ThongKeForm_Load(object sender, EventArgs e)
        {
            lblStartDate.Text = dtpStartDate.Value.ToString("dd/MM/yyyy");
            lblEndDate.Text = dtpEndDate.Value.ToString("dd/MM/yyyy");
            dgvUnderstock.Columns[0].HeaderText = "Tên sản phẩm";
            dgvUnderstock.Columns[1].HeaderText = "Số lượng";
            dgvUnderstock.Columns[0].Width = 200;
            dgvUnderstock.Columns[1].Width = 100;
            dgvUnderstock.Columns[1].DefaultCellStyle.NullValue = "0"; // Hiển thị 0 nếu không có giá trị
            dgvUnderstock.DefaultCellStyle.Padding = new Padding(5); // Thêm khoảng cách nếu cần
            dgvUnderstock.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUnderstock.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var result = chartGrossRevenue.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var pointIndex = result.PointIndex;
                var series = result.Series;
                if (pointIndex >= 0 && series != null)
                {
                    var point = series.Points[pointIndex];

                    // Lấy giá trị X, Y
                    string xValue = point.AxisLabel ?? point.XValue.ToString();
                    string yValue = point.YValues[0].ToString("N0");

                    chartGrossRevenue.Series[0].ToolTip = $"Ngày: {xValue}\nThu: {yValue}đ";
                }
            }
            else
            {
                // Clear tooltip nếu không nằm trên datapoint
                chartGrossRevenue.Series[0].ToolTip = string.Empty;
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            ExportThongKeToPDF();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("DoanhThu");
                dt.Columns.Add("Ngày", typeof(string)); // Hoặc typeof(DateTime) nếu item.Date là DateTime
                dt.Columns.Add("Tổng Doanh Thu", typeof(decimal));

                if (model != null && model.GrossRevenueList != null)
                {
                    foreach (var item in model.GrossRevenueList)
                    {
                        dt.Rows.Add(item.Date, item.TotalAmount);
                    }
                }

                DataTable dtUnderstock = new DataTable("TonKhoThap");
                dtUnderstock.Columns.Add("Tên Sản Phẩm", typeof(string));
                dtUnderstock.Columns.Add("Số Lượng", typeof(double)); // Hoặc typeof(int) tùy loại dữ liệu

                if (model != null && model.UnderstockList != null)
                {
                    foreach (var row in model.UnderstockList)
                    {
                        dtUnderstock.Rows.Add(row.Name, row.Quantity);
                    }
                }

                DataTable dtChartPieData = new DataTable("DuLieuBieuDoTron");
                dtChartPieData.Columns.Add("Sản phẩm", typeof(string)); // Hoặc "Nhãn", "Tên Loại", v.v.
                dtChartPieData.Columns.Add("Đã bán", typeof(double)); // Hoặc kiểu dữ liệu phù hợp với giá trị Y của bạn

                bool hasPieChartDataForTable = false;
                if (chartTopProducts != null && chartTopProducts.Series.Count > 0)
                {
                    // Giả sử bạn muốn lấy dữ liệu từ Series đầu tiên của biểu đồ tròn
                    var pieSeries = chartTopProducts.Series.FirstOrDefault(s => s.ChartType == SeriesChartType.Pie || s.Points.Count > 0);
                    if (pieSeries != null)
                    {
                        foreach (DataPoint dp in pieSeries.Points)
                        {
                            string label = !string.IsNullOrEmpty(dp.AxisLabel) ? dp.AxisLabel :
                                           !string.IsNullOrEmpty(dp.LegendText) ? dp.LegendText :
                                           !string.IsNullOrEmpty(dp.Label) ? dp.Label :
                                           $"Điểm {pieSeries.Points.IndexOf(dp) + 1}"; // Nhãn mặc định nếu không tìm thấy
                            double value = dp.YValues.Length > 0 ? dp.YValues[0] : 0;
                            dtChartPieData.Rows.Add(label, value);
                        }
                        if (dtChartPieData.Rows.Count > 0)
                        {
                            hasPieChartDataForTable = true;
                        }
                    }
                }

                // Kiểm tra dữ liệu trước khi xuất
                if ((dt.Rows.Count == 0) && (dtUnderstock.Rows.Count == 0) && !hasPieChartDataForTable)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- 2. Chọn vị trí lưu file ---
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    FileName = $"ThongKeChiTiet_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                    Title = "Lưu file Excel Thống Kê Chi Tiết" // Thêm tiêu đề cho dialog
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // --- 3. Tạo và điền dữ liệu vào Workbook sử dụng ClosedXML ---
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // Thông tin người xuất và ngày xuất (từ mã mẫu)
                        string userName = !string.IsNullOrEmpty(CurrentUser.Username) ? CurrentUser.Username : "N/A";
                        string exportDateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        // --- Xử lý Sheet "Doanh Thu" ---
                        var ws1 = wb.Worksheets.Add("Doanh Thu");

                        // Thiết lập kích thước giấy A4 và các cài đặt in (từ mã mẫu)
                        ws1.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        ws1.PageSetup.Margins.Left = 0.5; // Lề trái 0.5 inch
                        ws1.PageSetup.Margins.Right = 0.5; // Lề phải 0.5 inch
                        ws1.PageSetup.Margins.Top = 0.75; // Lề trên 0.75 inch
                        ws1.PageSetup.Margins.Bottom = 0.75; // Lề dưới 0.75 inch
                        ws1.PageSetup.CenterHorizontally = true; // Căn giữa ngang khi in
                        ws1.PageSetup.PageOrientation = XLPageOrientation.Portrait; // Hướng giấy dọc

                        // Thêm tiêu đề chính (từ mã mẫu - áp dụng cho báo cáo chung)
                        ws1.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ";
                        ws1.Cell(1, 1).Style.Font.Bold = true;
                        ws1.Cell(1, 1).Style.Font.FontSize = 18;
                        ws1.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Căn giữa
                        ws1.Range(1, 1, 1, dt.Columns.Count).Merge(); // Merge các cột tương ứng với dữ liệu

                        // Thêm tiêu đề Sheet (từ mã mẫu - áp dụng cho sheet này)
                        ws1.Cell(2, 1).Value = "Báo Cáo Doanh Từ " + dtpStartDate.Value.ToString("dd/MM/yyyy") + " đến " + dtpEndDate.Value.ToString("dd/MM/yyyy");
                        ws1.Cell(2, 1).Style.Font.Bold = true;
                        ws1.Cell(2, 1).Style.Font.FontSize = 14;
                        ws1.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Căn giữa
                        ws1.Range(2, 1, 2, dt.Columns.Count).Merge(); // Merge các cột tương ứng với dữ liệu

                        // Đặt thông tin người xuất và ngày xuất ở góc phải, căn chỉnh phù hợp với số cột dữ liệu
                        int lastColumn1 = dt.Columns.Count;
                        ws1.Cell(3, lastColumn1 - 1).Value = $"Người xuất: {userName}"; // Đặt ở cột cuối - 1
                        ws1.Cell(3, lastColumn1 - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        ws1.Cell(3, lastColumn1 - 1).Style.Font.Bold = true;
                        ws1.Range(3, lastColumn1 - 1, 3, lastColumn1).Merge();

                        ws1.Cell(4, lastColumn1 - 1).Value = $"Ngày xuất: {exportDateTime}"; // Đặt ở cột cuối - 1
                        ws1.Cell(4, lastColumn1 - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        ws1.Cell(4, lastColumn1 - 1).Style.Font.Bold = true;
                        ws1.Range(4, lastColumn1 - 1, 4, lastColumn1).Merge();

                        // Thêm dữ liệu từ DataTable, bắt đầu từ hàng 6 để chừa chỗ cho tiêu đề (từ mã mẫu)
                        // Sử dụng InsertTable để tạo cấu trúc bảng và dễ dàng định dạng
                        var dataRange1 = ws1.Cell(6, 1).InsertTable(dt.AsEnumerable(), "tblDoanhThu").AsRange();

                        // Định dạng tiêu đề cột (từ mã mẫu)
                        var headerRow1 = dataRange1.FirstRow();
                        headerRow1.Style.Font.Bold = true;
                        headerRow1.Style.Fill.BackgroundColor = XLColor.LightGray;
                        headerRow1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Định dạng cột "Ngày" (Cột 1 trong DataTable)
                        // ClosedXML nhận diện cột Ngày khi InsertTable, nhưng ta có thể định dạng lại nếu cần
                        var ngayColumn1 = dataRange1.Column(1);
                        // Kiểm tra nếu dữ liệu trong cột là chuỗi ngày tháng, có thể cần parse hoặc định dạng lại
                        // Ví dụ: nếu dữ liệu là string "yyyy-MM-dd", bạn có thể muốn nó hiển thị "dd/MM/yyyy"
                        // Nếu dt.Columns.Add("Ngày", typeof(string)); thì dữ liệu đã là chuỗi, có thể không cần format này
                        // Nếu dt.Columns.Add("Ngày", typeof(DateTime)); thì dòng dưới sẽ có tác dụng
                        // ngayColumn1.Style.DateFormat.Format = "dd/MM/yyyy";

                        // Định dạng cột "Tổng Doanh Thu" (Cột 2 trong DataTable)
                        var tongDoanhThuColumn = dataRange1.Column(2);
                        tongDoanhThuColumn.Style.NumberFormat.Format = "#,##0"; // Định dạng số có dấu phân cách hàng nghìn

                        // Thêm hàng tổng cộng ở cuối bảng (từ mã mẫu)
                        var lastRow1 = dataRange1.LastRow().RowNumber();
                        ws1.Cell(lastRow1 + 1, dataRange1.FirstColumn().ColumnNumber()).Value = "Tổng cộng:"; // Căn chỉnh cột tổng cộng
                        ws1.Cell(lastRow1 + 1, dataRange1.Column(2).ColumnNumber()).FormulaA1 = $"=SUM({dataRange1.Column(2).RangeAddress.ToString()})"; // Công thức tính tổng
                        ws1.Cell(lastRow1 + 1, dataRange1.FirstColumn().ColumnNumber()).Style.Font.Bold = true;
                        ws1.Cell(lastRow1 + 1, dataRange1.Column(2).ColumnNumber()).Style.Font.Bold = true;
                        ws1.Cell(lastRow1 + 1, dataRange1.Column(2).ColumnNumber()).Style.NumberFormat.Format = "#,##0"; // Định dạng số tổng cộng

                        // Fix for the CS1061 error: 'IXLCell' does not contain a definition for 'RowNumber'.
                        // The issue is that 'IXLCell' does not have a 'RowNumber' property. Instead, you can use the 'Address.RowNumber' property of the cell's address.

                        int lastContentRow1 = ws1.LastCellUsed().Address.RowNumber; // Corrected to use Address.RowNumber
                        ws1.Cell(lastContentRow1 + 2, 1).Value = "Địa chỉ: Cây nhà lá vườn";
                        ws1.Cell(lastContentRow1 + 2, 1).Style.Font.Bold = true;
                        ws1.Cell(lastContentRow1 + 2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        ws1.Range(lastContentRow1 + 2, 1, lastContentRow1 + 2, lastColumn1).Merge(); // Merge các cột

                        ws1.Cell(lastContentRow1 + 3, 1).Value = "Sdt: 0909090909";
                        ws1.Cell(lastContentRow1 + 3, 1).Style.Font.Bold = true;
                        ws1.Cell(lastContentRow1 + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        ws1.Range(lastContentRow1 + 3, 1, lastContentRow1 + 3, lastColumn1).Merge(); // Merge các cột

                        // Tự động điều chỉnh độ rộng cột cho ws1
                        //ws1.Columns().AdjustToContents();

                        // Tăng độ rộng của cột thứ 2 ("Tổng Doanh Thu")
                        // Bạn có thể thay đổi giá trị 20.0 này tùy theo độ rộng mong muốn
                        ws1.Column(2).Width = 50.0;
                        // Thêm đường viền cho bảng dữ liệu (từ mã mẫu)
                        dataRange1.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        dataRange1.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        // --- Xử lý Sheet "Tồn Kho Thấp" ---
                        var ws2 = wb.Worksheets.Add("Tồn Kho Thấp");

                        // Thiết lập kích thước giấy A4 và các cài đặt in (copy từ ws1)
                        ws2.PageSetup.PaperSize = XLPaperSize.A4Paper;
                        ws2.PageSetup.Margins.Left = 0.5; // Lề trái 0.5 inch
                        ws2.PageSetup.Margins.Right = 0.5; // Lề phải 0.5 inch
                        ws2.PageSetup.Margins.Top = 0.75; // Lề trên 0.75 inch
                        ws2.PageSetup.Margins.Bottom = 0.75; // Lề dưới 0.75 inch
                        ws2.PageSetup.CenterHorizontally = true; // Căn giữa ngang khi in
                        ws2.PageSetup.PageOrientation = XLPageOrientation.Portrait; // Hướng giấy dọc

                        // Thêm tiêu đề chính (giống ws1)
                        ws2.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ";
                        ws2.Cell(1, 1).Style.Font.Bold = true;
                        ws2.Cell(1, 1).Style.Font.FontSize = 18;
                        ws2.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Căn giữa
                        ws2.Range(1, 1, 1, dtUnderstock.Columns.Count).Merge(); // Merge các cột tương ứng với dữ liệu

                        // Thêm tiêu đề Sheet
                        ws2.Cell(2, 1).Value = "Danh Sách Sản Phẩm Tồn Kho Thấp";
                        ws2.Cell(2, 1).Style.Font.Bold = true;
                        ws2.Cell(2, 1).Style.Font.FontSize = 14;
                        ws2.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; // Căn giữa
                        ws2.Range(2, 1, 2, dtUnderstock.Columns.Count).Merge(); // Merge các cột tương ứng với dữ liệu

                        // Thông tin người xuất và ngày xuất (giống ws1)
                        int lastColumn2 = dtUnderstock.Columns.Count;
                        ws2.Cell(3, lastColumn2 - 1).Value = $"Người xuất: {userName}"; // Đặt ở cột cuối - 1
                        ws2.Cell(3, lastColumn2 - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        ws2.Cell(3, lastColumn2 - 1).Style.Font.Bold = true;
                        ws2.Range(3, lastColumn2 - 1, 3, lastColumn2).Merge();

                        ws2.Cell(4, lastColumn2 - 1).Value = $"Ngày xuất: {exportDateTime}"; // Đặt ở cột cuối - 1
                        ws2.Cell(4, lastColumn2 - 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        ws2.Cell(4, lastColumn2 - 1).Style.Font.Bold = true;
                        ws2.Range(4, lastColumn2 - 1, 4, lastColumn2).Merge();

                        // Thêm dữ liệu từ DataTable, bắt đầu từ hàng 6 (chừa chỗ cho tiêu đề)
                        var dataRange2 = ws2.Cell(6, 1).InsertTable(dtUnderstock.AsEnumerable(), "tblTonKhoThap").AsRange();

                        // Định dạng tiêu đề cột
                        var headerRow2 = dataRange2.FirstRow();
                        headerRow2.Style.Font.Bold = true;
                        headerRow2.Style.Fill.BackgroundColor = XLColor.LightGray;
                        headerRow2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Định dạng cột "Số Lượng" (Cột 2 trong DataTable)
                        var soLuongColumn = dataRange2.Column(2);
                        soLuongColumn.Style.NumberFormat.Format = "0"; // Định dạng số nguyên

                        // Thêm hàng tổng cộng Số Lượng ở cuối bảng (nếu cần)
                        // Lưu ý: Tính tổng số lượng các sản phẩm tồn kho thấp có thể không có ý nghĩa kinh doanh cao
                        // nhưng chúng ta thêm vào để đáp ứng yêu cầu "đủ thông tin như ws1".
                        var lastRow2 = dataRange2.LastRow().RowNumber();
                        ws2.Cell(lastRow2 + 1, dataRange2.FirstColumn().ColumnNumber()).Value = "Tổng số lượng:"; // Căn chỉnh cột
                        ws2.Cell(lastRow2 + 1, dataRange2.Column(2).ColumnNumber()).FormulaA1 = $"=SUM({dataRange2.Column(2).RangeAddress.ToString()})"; // Công thức tính tổng
                        ws2.Cell(lastRow2 + 1, dataRange2.FirstColumn().ColumnNumber()).Style.Font.Bold = true;
                        ws2.Cell(lastRow2 + 1, dataRange2.Column(2).ColumnNumber()).Style.Font.Bold = true;
                        ws2.Cell(lastRow2 + 1, dataRange2.Column(2).ColumnNumber()).Style.NumberFormat.Format = "0"; // Định dạng số nguyên tổng

                        // Thêm thông tin cửa hàng ở dưới cùng (giống ws1)
                        int lastContentRow2 = ws2.LastCellUsed().Address.RowNumber; // Lấy hàng cuối cùng có nội dung
                        ws2.Cell(lastContentRow2 + 2, 1).Value = "Địa chỉ: Cây nhà lá vườn";
                        ws2.Cell(lastContentRow2 + 2, 1).Style.Font.Bold = true;
                        ws2.Cell(lastContentRow2 + 2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        ws2.Range(lastContentRow2 + 2, 1, lastContentRow2 + 2, lastColumn2).Merge(); // Merge các cột

                        ws2.Cell(lastContentRow2 + 3, 1).Value = "Sdt: 0909090909";
                        ws2.Cell(lastContentRow2 + 3, 1).Style.Font.Bold = true;
                        ws2.Cell(lastContentRow2 + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        ws2.Range(lastContentRow2 + 3, 1, lastContentRow2 + 3, lastColumn2).Merge(); // Merge các cột

                        // Thêm đường viền cho bảng dữ liệu
                        dataRange2.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        dataRange2.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        ws2.Column(1).Width = 30.0;
                        ws2.Column(2).Width = 20.0;

                        if (hasPieChartDataForTable)
                        {
                            var wsPieData = wb.Worksheets.Add("Bán Chạy"); // Tên sheet mới
                            int currentRowWsPie = 1;

                            // Thiết lập chung cho sheet (tùy chọn)
                            wsPieData.PageSetup.PaperSize = XLPaperSize.A4Paper;
                            wsPieData.PageSetup.PageOrientation = XLPageOrientation.Portrait;
                            // wsPieData.PageSetup.CenterHorizontally = true;

                            // **Sửa: Chỉ sử dụng 2 cột cho tiêu đề và nội dung chính của sheet này**
                            int numberOfColumnsForLayout = 2;

                            // Tiêu đề chính của báo cáo
                            wsPieData.Cell(currentRowWsPie, 1).Value = "BÁO CÁO THỐNG KÊ";
                            wsPieData.Cell(currentRowWsPie, 1).Style.Font.Bold = true;
                            wsPieData.Cell(currentRowWsPie, 1).Style.Font.FontSize = 18;
                            wsPieData.Cell(currentRowWsPie, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            // Merge qua 2 cột
                            wsPieData.Range(currentRowWsPie, 1, currentRowWsPie, numberOfColumnsForLayout).Merge();
                            currentRowWsPie++;

                            // Tiêu đề của sheet dữ liệu biểu đồ
                            // **Sửa lại tên biến chartPie nếu cần, tôi dùng chartTopProducts như trong đoạn code bạn gửi**
                            string pieChartTitle = chartTopProducts.Titles.FirstOrDefault()?.Text ?? "Dữ Liệu Biểu Đồ"; // Lấy từ chartTopProducts hoặc chartPie
                            wsPieData.Cell(currentRowWsPie, 1).Value = pieChartTitle;
                            wsPieData.Cell(currentRowWsPie, 1).Style.Font.Bold = true;
                            wsPieData.Cell(currentRowWsPie, 1).Style.Font.FontSize = 14;
                            wsPieData.Cell(currentRowWsPie, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            // Merge qua 2 cột
                            wsPieData.Range(currentRowWsPie, 1, currentRowWsPie, numberOfColumnsForLayout).Merge();
                            currentRowWsPie++;
                            currentRowWsPie++; // Thêm một dòng trống sau tiêu đề sheet

                            // Người xuất
                            wsPieData.Cell(currentRowWsPie, 1).Value = $"Người xuất: {userName}";
                            wsPieData.Range(currentRowWsPie, 1, currentRowWsPie, numberOfColumnsForLayout).Merge();
                            wsPieData.Cell(currentRowWsPie, 1).Style.Font.Bold = true;
                            wsPieData.Cell(currentRowWsPie, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            currentRowWsPie++;

                            // Ngày xuất
                            wsPieData.Cell(currentRowWsPie, 1).Value = $"Ngày xuất: {exportDateTime:dd/MM/yyyy HH:mm:ss}";
                            wsPieData.Range(currentRowWsPie, 1, currentRowWsPie, numberOfColumnsForLayout).Merge();
                            wsPieData.Cell(currentRowWsPie, 1).Style.Font.Bold = true;
                            wsPieData.Cell(currentRowWsPie, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            currentRowWsPie++;

                            // Chèn bảng dữ liệu từ dtChartPieData
                            var dataRangePie = wsPieData.Cell(currentRowWsPie, 1).InsertTable(dtChartPieData.AsEnumerable(), "tblDuLieuBieuDo", true).AsRange();

                            // Định dạng tiêu đề bảng
                            var headerRowPie = dataRangePie.FirstRow();
                            headerRowPie.Style.Font.Bold = true;
                            headerRowPie.Style.Fill.BackgroundColor = XLColor.LightGray;
                            headerRowPie.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Định dạng cột giá trị (ví dụ: cột thứ 2)
                            if (dtChartPieData.Columns.Count >= 2)
                            {
                                dataRangePie.Column(2).Style.NumberFormat.Format = "#,##0"; // Định dạng số, có thể thay đổi
                            }

                            // Thêm đường viền cho bảng
                            dataRangePie.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            dataRangePie.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // Tự động điều chỉnh độ rộng cột
                            wsPieData.Columns().AdjustToContents();
                            if (dataRangePie.ColumnCount() >= 1) wsPieData.Column(1).Width = Math.Max(wsPieData.Column(1).Width, 30); // Đảm bảo cột nhãn đủ rộng
                            if (dataRangePie.ColumnCount() >= 2) wsPieData.Column(2).Width = Math.Max(wsPieData.Column(2).Width, 20); // Đảm bảo cột giá trị đủ rộng

                            // Cập nhật currentRowWsPie nếu bạn muốn thêm gì đó bên dưới bảng
                            currentRowWsPie = dataRangePie.LastRow().RowNumber() + 2; // +2 để chừa dòng trống

                            // Thêm thông tin cửa hàng ở dưới cùng (giống ws1)
                            int lastContentRow3 = wsPieData.LastCellUsed().Address.RowNumber; // Lấy hàng cuối cùng có nội dung
                            wsPieData.Cell(lastContentRow3 + 2, 1).Value = "Địa chỉ: Cây nhà lá vườn";
                            wsPieData.Cell(lastContentRow3 + 2, 1).Style.Font.Bold = true;
                            wsPieData.Cell(lastContentRow3 + 2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            wsPieData.Range(lastContentRow3 + 2, 1, lastContentRow3 + 2, lastColumn2).Merge(); // Merge các cột

                            wsPieData.Cell(lastContentRow3 + 3, 1).Value = "Sdt: 0909090909";
                            wsPieData.Cell(lastContentRow3 + 3, 1).Style.Font.Bold = true;
                            wsPieData.Cell(lastContentRow3 + 3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            wsPieData.Range(lastContentRow3 + 3, 1, lastContentRow3 + 3, lastColumn2).Merge(); // Merge các cột
                        }

                        // Lưu file
                        wb.SaveAs(saveDialog.FileName);

                        // Thông báo thành công (từ mã gốc và mã mẫu)
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ghi log lỗi chi tiết nếu cần
                System.Diagnostics.Debug.WriteLine($"[Export Excel Error] {ex.Message}\n{ex.StackTrace}");
            }
        }

        private Bitmap CaptureForm()
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            return bmp;
        }

        private void ExportThongKeToPDF()
        {
            try
            {
                Bitmap bmp = CaptureForm();
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    FileName = $"ThongKe_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    PdfDocument pdf = new PdfDocument();
                    PdfPage page = pdf.AddPage();
                    page.Width = XUnit.FromPoint(bmp.Width);
                    page.Height = XUnit.FromPoint(bmp.Height);

                    using (XGraphics gfx = XGraphics.FromPdfPage(page))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            ms.Seek(0, SeekOrigin.Begin);
                            using (XImage img = XImage.FromStream(ms))
                            {
                                gfx.DrawImage(img, 0, 0);
                            }
                        }
                    }

                    pdf.Save(saveDialog.FileName);
                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message);
            }
        }
    }
}