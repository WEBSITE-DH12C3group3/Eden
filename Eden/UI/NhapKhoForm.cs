using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using Eden.BLLCustom;
using Eden.Eden;
using Guna.UI2.WinForms;
using System.Data.Entity;
using Eden.UI;

namespace Eden
{
    public partial class NhapKhoForm : Form
    {
        private PHIEUNHAPBLL phieuNhapBLL;
        private PHIEUNHAPDAL phieuNhapDAL;
        private SANPHAMBLL sanPHAMBLL;
        private CHITIETPHIEUNHAPBLL chiTietPhieuNhapBLL;
        private NHACUNGCAPBLL nhaCungCapBLL;
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 1;
        private string searchTerm = "";

        public NhapKhoForm()
        {
            InitializeComponent();
            phieuNhapBLL = new PHIEUNHAPBLL();
            phieuNhapDAL = new PHIEUNHAPDAL();
            sanPHAMBLL = new SANPHAMBLL();
            chiTietPhieuNhapBLL = new CHITIETPHIEUNHAPBLL();
            nhaCungCapBLL = new NHACUNGCAPBLL();

            // Thiết lập ComboBox lọc
            cmbLoc.Items.AddRange(new string[] { "Tất cả", "Lọc theo ngày", "Lọc theo nhà cung cấp", "Lọc theo tổng tiền" });
            cmbLoc.SelectedIndex = 0;

            // Ẩn các điều khiển lọc ban đầu
            dtpTuNgay.Visible = false;
            dtpDenNgay.Visible = false;
            lblTuNgay.Visible = false;
            lblDenNgay.Visible = false;
            cmbNhaCungCap.Visible = false;
            txtTongTienTu.Visible = false;
            txtTongTienDen.Visible = false;
            lblTongTienTu.Visible = false;
            lblTongTienDen.Visible = false;

            // Tải danh sách nhà cung cấp và dữ liệu phiếu nhập
            LoadNhaCungCap();
            LoadData();
        }

        private void LoadNhaCungCap()
        {
            try
            {
                var list = nhaCungCapBLL.GetAll();
                if (list == null || !list.Any())
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNhaCungCap.DataSource = null;
                    return;
                }
                cmbNhaCungCap.DataSource = null;
                cmbNhaCungCap.Items.Clear();
                cmbNhaCungCap.DisplayMember = "TenNhaCungCap";
                cmbNhaCungCap.ValueMember = "id";
                cmbNhaCungCap.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải nhà cung cấp: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNhaCungCap.DataSource = null;
            }
        }

        private List<PHIEUNHAP> GetFilteredPhieuNhapList(string searchTerm)
        {
            using (var db = new QLBanHoaEntities())
            {
                // Tải trước NHACUNGCAP và NGUOIDUNG để tránh lazy loading
                var phieuNhapList = db.PHIEUNHAPs
                    .Include(p => p.NHACUNGCAP)
                    .Include(p => p.NGUOIDUNG)
                    .AsQueryable();

                // Áp dụng tìm kiếm
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    phieuNhapList = phieuNhapList.Where(p =>
                        p.MaPhieuNhap.ToLower().Contains(searchTerm) ||
                        p.NHACUNGCAP.TenNhaCungCap.ToLower().Contains(searchTerm) ||
                        p.NGUOIDUNG.TenNguoiDung.ToLower().Contains(searchTerm));
                }

                // Áp dụng lọc
                switch (cmbLoc.SelectedItem?.ToString())
                {
                    case "Lọc theo ngày":
                        if (dtpTuNgay.Value > dtpDenNgay.Value)
                        {
                            MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return new List<PHIEUNHAP>();
                        }
                        var tuNgay = dtpTuNgay.Value.Date;
                        var denNgay = dtpDenNgay.Value.Date;
                        phieuNhapList = phieuNhapList
                            .Where(p => DbFunctions.TruncateTime(p.NgayNhap) >= tuNgay
                                     && DbFunctions.TruncateTime(p.NgayNhap) <= denNgay);
                        break;
                    case "Lọc theo nhà cung cấp":
                        if (cmbNhaCungCap.SelectedValue != null && int.TryParse(cmbNhaCungCap.SelectedValue.ToString(), out int idNhaCungCap))
                        {
                            phieuNhapList = phieuNhapList
                                .Where(p => p.idNhaCungCap == idNhaCungCap);
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return new List<PHIEUNHAP>();
                        }
                        break;
                    case "Lọc theo tổng tiền":
                        if (!decimal.TryParse(txtTongTienTu.Text, out decimal tongTienTu) || tongTienTu < 0)
                        {
                            MessageBox.Show("Tổng tiền từ phải là số không âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return new List<PHIEUNHAP>();
                        }
                        if (!decimal.TryParse(txtTongTienDen.Text, out decimal tongTienDen) || tongTienDen < tongTienTu)
                        {
                            MessageBox.Show("Tổng tiền đến phải lớn hơn hoặc bằng tổng tiền từ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return new List<PHIEUNHAP>();
                        }
                        phieuNhapList = phieuNhapList
                            .Where(p => p.TongTien >= tongTienTu && p.TongTien <= tongTienDen);
                        break;
                }

                return phieuNhapList.ToList();
            }
        }

        private void LoadData(string searchTerm = "")
        {
            try
            {
                // Lấy danh sách đã lọc
                var filteredList = GetFilteredPhieuNhapList(searchTerm);
                totalRecords = filteredList.Count;

                // Phân trang
                var pagedList = filteredList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => new
                    {
                        p.MaPhieuNhap,
                        NgayNhap = p.NgayNhap.ToString("dd/MM/yyyy"),
                        TenNhaCungCap = p.NHACUNGCAP != null ? p.NHACUNGCAP.TenNhaCungCap : "N/A",
                        p.TongTien
                    }).ToList();

                // Tính tổng số trang
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                if (totalPages == 0) totalPages = 1;

                // Gán dữ liệu cho DataGridView
                dgvPhieuNhap.DataSource = pagedList;

                // Cập nhật tiêu đề cột
                dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
                dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvPhieuNhap.Columns["TenNhaCungCap"].HeaderText = "Nhà Cung Cấp";
                dgvPhieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";

                // Cập nhật label trang
                lblPage.Text = $"Trang {currentPage}/{totalPages}";

                // Cập nhật trạng thái nút
                btnPrev.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtpTuNgay.Visible = false;
                dtpDenNgay.Visible = false;
                lblTuNgay.Visible = false;
                lblDenNgay.Visible = false;
                cmbNhaCungCap.Visible = false;
                txtTongTienTu.Visible = false;
                txtTongTienDen.Visible = false;
                lblTongTienTu.Visible = false;
                lblTongTienDen.Visible = false;

                switch (cmbLoc.SelectedItem?.ToString())
                {
                    case "Lọc theo ngày":
                        dtpTuNgay.Visible = true;
                        dtpDenNgay.Visible = true;
                        lblTuNgay.Visible = true;
                        lblDenNgay.Visible = true;
                        break;
                    case "Lọc theo nhà cung cấp":
                        cmbNhaCungCap.Visible = true;
                        break;
                    case "Lọc theo tổng tiền":
                        txtTongTienTu.Visible = true;
                        txtTongTienDen.Visible = true;
                        lblTongTienTu.Visible = true;
                        lblTongTienDen.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thay đổi tùy chọn lọc: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                currentPage = 1;
                LoadData(searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc phiếu nhập: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTerm = txtSearch.Text.Trim();
            currentPage = 1;
            LoadData(searchTerm);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                searchTerm = "";
                txtSearch.Text = "";
                cmbLoc.SelectedIndex = 0;
                dtpTuNgay.Value = DateTime.Now;
                dtpDenNgay.Value = DateTime.Now;
                txtTongTienTu.Text = "";
                txtTongTienDen.Text = "";
                currentPage = 1;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData(searchTerm);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData(searchTerm);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var formAdd = new NhapKhoFormAdd())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadData(searchTerm);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieuNhap = dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value?.ToString();
            if (string.IsNullOrEmpty(maPhieuNhap))
            {
                MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var formAdd = new NhapKhoFormAdd(maPhieuNhap))
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadData(searchTerm);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieuNhap = dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value?.ToString();
            if (string.IsNullOrEmpty(maPhieuNhap))
            {
                MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PHIEUNHAP phieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
            if (phieuNhap == null)
            {
                MessageBox.Show("Phiếu nhập không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu nhập này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = phieuNhapBLL.Delete(phieuNhap);
                    if (isDeleted)
                    {
                        MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(searchTerm);
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách phiếu nhập đã lọc
                var filteredPhieuNhap = GetFilteredPhieuNhapList(searchTerm);
                if (filteredPhieuNhap == null || filteredPhieuNhap.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu phiếu nhập để xuất. Vui lòng kiểm tra điều kiện lọc hoặc thêm dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Phiếu Nhập");
                dt.Columns.Add("Ngày Nhập");
                dt.Columns.Add("Mã Nhà Cung Cấp");
                dt.Columns.Add("Tên Nhà Cung Cấp");
                dt.Columns.Add("Tên Người Dùng");
                dt.Columns.Add("Tổng Tiền");
                dt.Columns.Add("Mã Sản Phẩm");
                dt.Columns.Add("Tên Sản Phẩm");
                dt.Columns.Add("Số Lượng");
                dt.Columns.Add("Đơn Giá");
                dt.Columns.Add("Thành Tiền");

                foreach (var pn in filteredPhieuNhap)
                {
                    var chiTietList = phieuNhapBLL.GetChiTietByPhieuNhap(pn.id);
                    if (chiTietList != null && chiTietList.Any())
                    {
                        foreach (var chiTiet in chiTietList)
                        {
                            var sanPham = sanPHAMBLL.GetById(chiTiet.idSanPham);
                            if (sanPham == null)
                            {
                                System.Diagnostics.Debug.WriteLine($"Sản phẩm với id {chiTiet.idSanPham} không tìm thấy cho phiếu nhập {pn.MaPhieuNhap}.");
                            }
                            dt.Rows.Add(
                                pn.MaPhieuNhap,
                                pn.NgayNhap.ToString("dd/MM/yyyy"),
                                pn.NHACUNGCAP?.MaNhaCungCap ?? "N/A",
                                pn.NHACUNGCAP?.TenNhaCungCap ?? "N/A",
                                pn.NGUOIDUNG?.TenNguoiDung ?? "N/A",
                                pn.TongTien,
                                sanPham?.MaSanPham ?? "N/A",
                                sanPham?.TenSanPham ?? "N/A",
                                chiTiet.SoLuong,
                                chiTiet.DonGia,
                                chiTiet.ThanhTien
                            );
                        }
                    }
                    else
                    {
                        dt.Rows.Add(
                            pn.MaPhieuNhap,
                            pn.NgayNhap.ToString("dd/MM/yyyy"),
                            pn.NHACUNGCAP?.MaNhaCungCap ?? "N/A",
                            pn.NHACUNGCAP?.TenNhaCungCap ?? "N/A",
                            pn.NGUOIDUNG?.TenNguoiDung ?? "N/A",
                            pn.TongTien,
                            "", "", "", "", ""
                        );
                    }
                }

                // Hiển thị SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Lưu file Excel";
                saveFileDialog.FileName = $"DanhSachPhieuNhap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("PhieuNhap");

                        ws.Cell(1, 1).Value = "Danh Sách Phiếu Nhập";
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 11).Merge();

                        ws.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                        ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        ws.Range(2, 1, 2, 11).Merge();

                        var dataRange = ws.Cell(4, 1).InsertTable(dt.AsEnumerable()).AsRange();

                        var headerRow = dataRange.FirstRow();
                        headerRow.Style.Font.Bold = true;
                        headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;
                        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        var ngayNhapColumn = ws.Column(2);
                        ngayNhapColumn.Style.DateFormat.Format = "dd/MM/yyyy";

                        ws.Column(9).Style.NumberFormat.Format = "0";
                        ws.Column(10).Style.NumberFormat.Format = "0";
                        ws.Column(11).Style.NumberFormat.Format = "0";
                        ws.Column(6).Style.NumberFormat.Format = "0";

                        var lastRow = dataRange.LastRow().RowNumber();
                        ws.Cell(lastRow + 1, 5).Value = "Tổng cộng:";
                        ws.Cell(lastRow + 1, 6).Value = filteredPhieuNhap.Sum(pn => pn.TongTien);
                        ws.Cell(lastRow + 1, 5).Style.Font.Bold = true;
                        ws.Cell(lastRow + 1, 6).Style.Font.Bold = true;
                        ws.Cell(lastRow + 1, 6).Style.NumberFormat.Format = "0";

                        ws.Columns().AdjustToContents();

                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null)
            {
                var maPhieuNhapCell = dgvPhieuNhap.CurrentRow.Cells["MaPhieuNhap"].Value;
                if (maPhieuNhapCell != null)
                {
                    string maPhieuNhap = maPhieuNhapCell.ToString();
                    try
                    {
                        var form = new CHITIETPHIEUNHAPFORM(maPhieuNhap);
                        form.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi mở chi tiết phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTongTienTu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}