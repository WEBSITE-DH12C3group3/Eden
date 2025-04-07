using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class ProductStatistic
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    public class Dashboard
    {
        private readonly QLBanHoaEntities _context;
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<ProductStatistic> TopProductsList { get; private set; }
        public List<ProductStatistic> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        public Dashboard(QLBanHoaEntities context)
        {
            _context = context;
        }

        private void GetNumberItems()
        {
            NumCustomers = _context.KHACHHANGs.Count();
            NumSuppliers = _context.NHACUNGCAPs.Count();
            NumProducts = _context.SANPHAMs.Count();
            NumOrders = _context.HOADONs.Count(o => o.NgayLap >= startDate && o.NgayLap <= endDate);
        }

        private void GetProductAnalysis()
        {
            TopProductsList = _context.CHITIETHOADONs
                .Where(oi => oi.HOADON.NgayLap >= startDate && oi.HOADON.NgayLap <= endDate)
                .GroupBy(oi => oi.SANPHAM.TenSanPham)
                .Select(g => new ProductStatistic { Name = g.Key, Quantity = (int)g.Sum(oi => oi.SoLuong) })
                .OrderByDescending(ps => ps.Quantity)
                .Take(5)
                .ToList();

            UnderstockList = _context.SANPHAMs
                .Where(p => p.SoLuong <= 10)
                .Select(p => new ProductStatistic { Name = p.TenSanPham, Quantity = p.SoLuong }) // ✅ ĐÚNG
                .ToList();
        }

        private void GetOrderAnalysis()
        {
            var resultTable = _context.HOADONs
                .Where(o => o.NgayLap >= startDate && o.NgayLap <= endDate)
                .GroupBy(o => o.NgayLap)  // Sử dụng NgayLap nguyên gốc mà không cần tách phần ngày
                .Select(g => new { Date = g.Key, TotalAmount = g.Sum(o => o.TongTien) })
                .ToList();

            TotalRevenue = resultTable.Sum(r => r.TotalAmount);
            TotalProfit = TotalRevenue * 0.2m;

            if (numberDays <= 1)
            {
                // Nhóm theo giờ trong ngày
                GrossRevenueList = resultTable
                    .GroupBy(o => o.Date.ToString("hh:tt"))
                    .Select(g => new RevenueByDate { Date = g.Key, TotalAmount = g.Sum(r => r.TotalAmount) })
                    .ToList();
            }
            else if (numberDays <= 30)
            {
                // Nhóm theo ngày trong tháng
                GrossRevenueList = resultTable
                    .GroupBy(o => o.Date.ToString("dd/MMM"))
                    .Select(g => new RevenueByDate { Date = g.Key, TotalAmount = g.Sum(r => r.TotalAmount) })
                    .ToList();
            }
            else if (numberDays <= 92)
            {
                // Nhóm theo tuần trong năm
                GrossRevenueList = resultTable
                    .GroupBy(o => System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                        o.Date, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                    .Select(g => new RevenueByDate { Date = "Week " + g.Key, TotalAmount = g.Sum(r => r.TotalAmount) })
                    .ToList();
            }
            else if (numberDays <= (365 * 2))
            {
                // Nhóm theo tháng trong năm
                GrossRevenueList = resultTable
                    .GroupBy(o => o.Date.ToString("MMM/yyyy"))
                    .Select(g => new RevenueByDate { Date = g.Key, TotalAmount = g.Sum(r => r.TotalAmount) })
                    .ToList();
            }
            else
            {
                // Nhóm theo năm
                GrossRevenueList = resultTable
                    .GroupBy(o => o.Date.ToString("yyyy"))
                    .Select(g => new RevenueByDate { Date = g.Key, TotalAmount = g.Sum(r => r.TotalAmount) })
                    .ToList();
            }
        }

        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItems();
                GetProductAnalysis();
                GetOrderAnalysis();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data not refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
        }
    }
}