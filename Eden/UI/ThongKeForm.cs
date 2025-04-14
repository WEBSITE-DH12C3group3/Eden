using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;

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
            dgvUnderstock.Columns[1].Width = 80;
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
    }
}