using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Eden.BLLCustom;
using Eden.Eden;
using Eden.DTO;
using Guna.UI2.WinForms;
using Eden.UI;

namespace Eden
{
    public partial class NhapKhoFormAdd : Form
    {
        private string maPhieuNhap;
        private PHIEUNHAPBLL phieuNhapBLL;
        private NHACUNGCAPBLL nhaCungCapBLL;
        private SANPHAMBLL sanPHAMBLL;
        private NGUOIDUNGBLL nguoiDungBLL;
        private CHITIETPHIEUNHAPBLL chiTietPhieuNhapBLL;
        private BindingList<CHITIETPHIEUNHAP> chiTietList = new BindingList<CHITIETPHIEUNHAP>();

        public NhapKhoFormAdd(string maPhieuNhap = "")
        {
            try
            {
                InitializeComponent();
                this.maPhieuNhap = maPhieuNhap;
                phieuNhapBLL = new PHIEUNHAPBLL();
                nhaCungCapBLL = new NHACUNGCAPBLL();
                sanPHAMBLL = new SANPHAMBLL();
                nguoiDungBLL = new NGUOIDUNGBLL();
                chiTietPhieuNhapBLL = new CHITIETPHIEUNHAPBLL();

                // Ẩn txtMaPhieuNhap
                txtMaPhieuNhap.Visible = false;
                txtMaPhieuNhap.Enabled = false;

                // Gán sự kiện SelectedIndexChanged cho cmbTenSP
                cmbTenSP.SelectedIndexChanged += CmbTenSP_SelectedIndexChanged;

                LoadNhaCungCap();
                LoadSanPham();
                LoadIDNguoiDung();
                SetupDataGridView();
                if (!string.IsNullOrEmpty(maPhieuNhap))
                {
                    LoadData(maPhieuNhap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void CmbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTenSP.SelectedItem is SanPhamDTO selectedSanPham)
                {
                    txtDonGia.Text = selectedSanPham.Gia.ToString("F0");
                }
                else
                {
                    txtDonGia.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật đơn giá: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDonGia.Text = string.Empty;
            }
        }

        private void SetupDataGridView()
        {
            try
            {
                dgvChiTiet.DataSource = chiTietList;
                if (dgvChiTiet.Columns["idPhieuNhap"] != null)
                    dgvChiTiet.Columns["idPhieuNhap"].Visible = false;
                if (dgvChiTiet.Columns["idSanPham"] != null)
                {
                    dgvChiTiet.Columns["idSanPham"].HeaderText = "Mã Sản Phẩm";
                    dgvChiTiet.Columns["idSanPham"].Width = 100;
                }
                if (dgvChiTiet.Columns["SoLuong"] != null)
                {
                    dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvChiTiet.Columns["SoLuong"].Width = 80;
                    dgvChiTiet.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChiTiet.Columns["DonGia"] != null)
                {
                    dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvChiTiet.Columns["DonGia"].Width = 100;
                    dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChiTiet.Columns["ThanhTien"] != null)
                {
                    dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                    dgvChiTiet.Columns["ThanhTien"].Width = 120;
                    dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }

                if (!dgvChiTiet.Columns.Contains("TenSanPham"))
                {
                    var colTenSP = new DataGridViewTextBoxColumn
                    {
                        Name = "TenSanPham",
                        HeaderText = "Tên Sản Phẩm",
                        DataPropertyName = "TenSanPham",
                        Width = 150
                    };
                    dgvChiTiet.Columns.Insert(0, colTenSP);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thiết lập DataGridView: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show($"Lỗi tải nhà cung cấp: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNhaCungCap.DataSource = null;
            }
        }

        private void LoadSanPham()
        {
            try
            {
                var list = sanPHAMBLL.GetAll();
                if (list == null)
                {
                    MessageBox.Show("Danh sách sản phẩm trả về null. Kiểm tra phương thức GetAll trong SANPHAMBLL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTenSP.DataSource = null;
                    return;
                }
                if (!list.Any())
                {
                    MessageBox.Show("Không có sản phẩm nào trong cơ sở dữ liệu. Vui lòng thêm sản phẩm trước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTenSP.DataSource = null;
                    return;
                }

                if (list.Any(sp => sp.idSanPham == 0))
                {
                    MessageBox.Show("Có sản phẩm với idSanPham không hợp lệ (0). Kiểm tra dữ liệu trong bảng SANPHAM.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTenSP.DataSource = null;
                    return;
                }

                cmbTenSP.DataSource = null;
                cmbTenSP.Items.Clear();
                cmbTenSP.DisplayMember = "TenSanPham";
                cmbTenSP.ValueMember = "idSanPham";
                cmbTenSP.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTenSP.DataSource = null;
            }
        }

        private void LoadIDNguoiDung()
        {
            try
            {
                var list = nguoiDungBLL.GetAll();
                if (list == null || !list.Any())
                {
                    MessageBox.Show("Không tìm thấy người dùng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbIDNguoiDung.DataSource = null;
                    return;
                }
                cmbIDNguoiDung.DataSource = null;
                cmbIDNguoiDung.Items.Clear();
                cmbIDNguoiDung.DisplayMember = "TenNguoiDung";
                cmbIDNguoiDung.ValueMember = "id";
                cmbIDNguoiDung.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải người dùng: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbIDNguoiDung.DataSource = null;
            }
        }

        private void LoadData(string maPhieuNhap)
        {
            try
            {
                var phieuNhap = phieuNhapBLL.GetByMaPhieuNhap(maPhieuNhap);
                if (phieuNhap == null)
                {
                    MessageBox.Show($"Không tìm thấy phiếu nhập với mã {maPhieuNhap}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                // Không gán txtMaPhieuNhap vì đã ẩn
                dtpNgayNhap.Value = phieuNhap.NgayNhap;
                cmbNhaCungCap.SelectedValue = phieuNhap.idNhaCungCap;
                cmbIDNguoiDung.SelectedValue = phieuNhap.idNguoiDung;

                var chiTietListDb = phieuNhapBLL.GetChiTietByPhieuNhap(phieuNhap.id);
                if (chiTietListDb == null || !chiTietListDb.Any())
                {
                    MessageBox.Show($"Không tìm thấy chi tiết phiếu nhập cho mã {maPhieuNhap}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                chiTietList.Clear();
                foreach (var chiTiet in chiTietListDb)
                {
                    var sanPham = sanPHAMBLL.GetById(chiTiet.idSanPham);
                    var chiTietItem = new CHITIETPHIEUNHAP
                    {
                        idPhieuNhap = chiTiet.idPhieuNhap,
                        idSanPham = chiTiet.idSanPham,
                        SoLuong = chiTiet.SoLuong,
                        DonGia = chiTiet.DonGia,
                        ThanhTien = chiTiet.ThanhTien,
                        TenSanPham = sanPham?.TenSanPham ?? "Không xác định"
                    };

                    if (chiTietItem.SoLuong <= 0)
                    {
                        MessageBox.Show($"Số lượng của sản phẩm {chiTietItem.TenSanPham} không hợp lệ (SoLuong = {chiTietItem.SoLuong}).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    chiTietList.Add(chiTietItem);
                }

                // Tải chi tiết đầu tiên vào các TextBox/ComboBox
                var firstChiTiet = chiTietList.FirstOrDefault();
                if (firstChiTiet != null)
                {
                    cmbTenSP.SelectedValue = firstChiTiet.idSanPham;
                    txtSoLuong.Text = firstChiTiet.SoLuong.ToString();
                    txtDonGia.Text = firstChiTiet.DonGia.ToString("F0");
                }

                // Cập nhật DataGridView
                dgvChiTiet.DataSource = null;
                dgvChiTiet.DataSource = chiTietList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu phiếu nhập: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnAddChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTenSP.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedSanPham = cmbTenSP.SelectedItem as SanPhamDTO;
                if (selectedSanPham == null)
                {
                    MessageBox.Show("Sản phẩm được chọn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
                {
                    MessageBox.Show("Đơn giá phải là số dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem sản phẩm đã tồn tại trong chiTietList chưa
                var existingChiTiet = chiTietList.FirstOrDefault(c => c.idSanPham == selectedSanPham.idSanPham);
                if (existingChiTiet != null)
                {
                    // Cập nhật chi tiết hiện có
                    existingChiTiet.SoLuong = soLuong;
                    existingChiTiet.DonGia = donGia;
                    existingChiTiet.ThanhTien = soLuong * donGia;
                    existingChiTiet.TenSanPham = selectedSanPham.TenSanPham;
                    MessageBox.Show("Cập nhật chi tiết sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Thêm chi tiết mới
                    var chiTiet = new CHITIETPHIEUNHAP
                    {
                        idSanPham = selectedSanPham.idSanPham,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        ThanhTien = soLuong * donGia,
                        TenSanPham = selectedSanPham.TenSanPham
                    };
                    chiTietList.Add(chiTiet);
                    MessageBox.Show("Thêm chi tiết sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cập nhật DataGridView
                dgvChiTiet.DataSource = null;
                dgvChiTiet.DataSource = chiTietList;

                // Xóa các TextBox để sẵn sàng cho chi tiết tiếp theo
                txtSoLuong.Clear();
                txtDonGia.Clear();
                cmbTenSP.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm/cập nhật chi tiết: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTiet.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chi tiết để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedChiTiet = dgvChiTiet.SelectedRows[0].DataBoundItem as CHITIETPHIEUNHAP;
                if (selectedChiTiet == null)
                {
                    MessageBox.Show("Chi tiết được chọn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                chiTietList.Remove(selectedChiTiet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa chi tiết: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đầu vào
                if (cmbNhaCungCap.SelectedValue == null || !int.TryParse(cmbNhaCungCap.SelectedValue.ToString(), out int idNhaCungCap))
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbIDNguoiDung.SelectedValue == null || !int.TryParse(cmbIDNguoiDung.SelectedValue.ToString(), out int idNguoiDung))
                {
                    MessageBox.Show("Vui lòng chọn người dùng hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!chiTietList.Any())
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một chi tiết phiếu nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new QLBanHoaEntities())
                {
                    db.Database.BeginTransaction();
                    try
                    {
                        PHIEUNHAP phieuNhap;
                        bool isNew = string.IsNullOrEmpty(maPhieuNhap);

                        if (isNew)
                        {
                            // Sinh MaPhieuNhap mới
                            string newMaPN = "PN001";
                            var phieuNhapList = db.PHIEUNHAPs.ToList();
                            if (phieuNhapList.Any())
                            {
                                var validPhieuNhaps = phieuNhapList
                                    .Where(p => p.MaPhieuNhap != null && p.MaPhieuNhap.StartsWith("PN") && int.TryParse(p.MaPhieuNhap.Substring(2), out _))
                                    .ToList();
                                if (validPhieuNhaps.Any())
                                {
                                    var lastPhieuNhap = validPhieuNhaps
                                        .OrderByDescending(p => int.Parse(p.MaPhieuNhap.Substring(2)))
                                        .First();
                                    int lastNumber = int.Parse(lastPhieuNhap.MaPhieuNhap.Substring(2));
                                    newMaPN = $"PN{(lastNumber + 1):D3}";
                                }
                            }

                            // Kiểm tra MaPhieuNhap trùng
                            if (db.PHIEUNHAPs.Any(p => p.MaPhieuNhap == newMaPN))
                            {
                                throw new Exception($"Mã phiếu nhập {newMaPN} đã tồn tại!");
                            }

                            phieuNhap = new PHIEUNHAP
                            {
                                MaPhieuNhap = newMaPN,
                                NgayNhap = dtpNgayNhap.Value,
                                idNhaCungCap = idNhaCungCap,
                                idNguoiDung = idNguoiDung,
                                TongTien = 0
                            };
                            db.PHIEUNHAPs.Add(phieuNhap);
                        }
                        else
                        {
                            phieuNhap = db.PHIEUNHAPs.FirstOrDefault(p => p.MaPhieuNhap == maPhieuNhap);
                            if (phieuNhap == null)
                            {
                                throw new Exception($"Phiếu nhập với mã {maPhieuNhap} không tồn tại!");
                            }
                            phieuNhap.NgayNhap = dtpNgayNhap.Value;
                            phieuNhap.idNhaCungCap = idNhaCungCap;
                            phieuNhap.idNguoiDung = idNguoiDung;
                            phieuNhap.TongTien = 0;

                            // Xóa chi tiết cũ
                            var oldChiTiet = db.CHITIETPHIEUNHAPs.Where(c => c.idPhieuNhap == phieuNhap.id).ToList();
                            foreach (var chiTiet in oldChiTiet)
                            {
                                var sanPham = db.SANPHAMs.Find(chiTiet.idSanPham);
                                if (sanPham != null)
                                {
                                    sanPham.SoLuong -= chiTiet.SoLuong;
                                    if (sanPham.SoLuong < 0)
                                    {
                                        throw new Exception($"Số lượng sản phẩm {sanPham.TenSanPham} không đủ để xóa (số lượng âm).");
                                    }
                                }
                            }
                            db.CHITIETPHIEUNHAPs.RemoveRange(oldChiTiet);
                        }

                        // Kiểm tra và thêm chi tiết phiếu nhập
                        decimal tongTien = 0;
                        foreach (var chiTiet in chiTietList)
                        {
                            if (chiTiet.SoLuong <= 0)
                            {
                                throw new Exception($"Số lượng của sản phẩm {chiTiet.TenSanPham} phải lớn hơn 0.");
                            }
                            if (chiTiet.DonGia <= 0)
                            {
                                throw new Exception($"Đơn giá của sản phẩm {chiTiet.TenSanPham} phải lớn hơn 0.");
                            }
                            if (Math.Abs(chiTiet.ThanhTien - chiTiet.SoLuong * chiTiet.DonGia) > 0.01m)
                            {
                                throw new Exception($"Thành tiền của sản phẩm {chiTiet.TenSanPham} không đúng.");
                            }

                            var sanPham = db.SANPHAMs.Find(chiTiet.idSanPham);
                            if (sanPham == null)
                            {
                                throw new Exception($"Sản phẩm với ID {chiTiet.idSanPham} không tồn tại!");
                            }

                            // Kiểm tra nhà cung cấp
                            if (sanPham.idNhaCungCap != idNhaCungCap)
                            {
                                var result = MessageBox.Show($"Sản phẩm {sanPham.TenSanPham} thuộc nhà cung cấp khác. Cập nhật nhà cung cấp?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.Yes)
                                {
                                    sanPham.idNhaCungCap = idNhaCungCap;
                                }
                            }

                            var newChiTiet = new CHITIETPHIEUNHAP
                            {
                                idPhieuNhap = phieuNhap.id,
                                idSanPham = chiTiet.idSanPham,
                                SoLuong = chiTiet.SoLuong,
                                DonGia = chiTiet.DonGia,
                                ThanhTien = chiTiet.ThanhTien
                            };
                            db.CHITIETPHIEUNHAPs.Add(newChiTiet);
                            sanPham.SoLuong += chiTiet.SoLuong;
                            tongTien += chiTiet.ThanhTien;
                        }

                        // Cập nhật TongTien
                        phieuNhap.TongTien = tongTien;

                        // Lưu tất cả thay đổi
                        db.SaveChanges();
                        db.Database.CurrentTransaction.Commit();
                        MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        db.Database.CurrentTransaction?.Rollback();
                        var dbUpdateEx = ex.InnerException as System.Data.Entity.Infrastructure.DbUpdateException;
                        var sqlEx = dbUpdateEx?.InnerException as System.Data.SqlClient.SqlException;
                        string errorDetails = sqlEx != null
                            ? $"SQL Error: {sqlEx.Message}\nError Number: {sqlEx.Number}\nLine Number: {sqlEx.LineNumber}"
                            : ex.InnerException?.Message ?? "Không có chi tiết lỗi cụ thể.";
                        MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}\nInner Exception: {errorDetails}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SanPhamFormAdd formAdd = new SanPhamFormAdd())
                {
                    formAdd.FormClosed += (s, args) =>
                    {
                        try
                        {
                            var sanPhamList = sanPHAMBLL.GetAll();
                            if (sanPhamList == null || !sanPhamList.Any())
                            {
                                MessageBox.Show("Không tìm thấy sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            cmbTenSP.DataSource = null;
                            cmbTenSP.Items.Clear();
                            cmbTenSP.DisplayMember = "TenSanPham";
                            cmbTenSP.ValueMember = "idSanPham";
                            cmbTenSP.DataSource = sanPhamList;
                            var lastSanPham = sanPhamList.OrderByDescending(sp => sp.MaSanPham).FirstOrDefault();
                            if (lastSanPham != null && lastSanPham.idSanPham != 0)
                            {
                                cmbTenSP.SelectedValue = lastSanPham.idSanPham;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi cập nhật danh sách sản phẩm: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    formAdd.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thêm sản phẩm: {ex.Message}\nInner Exception: {ex.InnerException?.Message}\nStack Trace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm logic kiểm tra định dạng đơn giá tại đây
        }
    }

    public partial class CHITIETPHIEUNHAP
    {
        public string TenSanPham { get; set; }
    }
}