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
using Eden.UI;
using Guna.UI2.WinForms;

namespace Eden
{
    public partial class NhaCungCapForm : Form
    {
        private NHACUNGCAPBLL nhaCungCapBLL;
        public NhaCungCapForm()
        {
            InitializeComponent();
            nhaCungCapBLL = new NHACUNGCAPBLL();
            NhaCungCapForm_Load();
        }

        private void NhaCungCapForm_Load()
        {
            guna2DataGridViewNCC.DataSource = nhaCungCapBLL.GetAll();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (NhaCungCapFormAdd formAdd = new NhaCungCapFormAdd())
            {
                formAdd.ShowDialog();
                NhaCungCapForm_Load(); // Cập nhật danh sách sau khi thêm
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridViewNCC.CurrentRow != null)
            {
                string maNCC = guna2DataGridViewNCC.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
                NhaCungCapFormSua nhaCungCapFormSua = new NhaCungCapFormSua(maNCC);

                // Đặt Owner để form con có thể gọi UpdateDataGridView khi đóng
                nhaCungCapFormSua.Owner = this;

                nhaCungCapFormSua.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void UpdateDataGridView(NHACUNGCAP updatedNCC)
        {
            foreach (DataGridViewRow row in guna2DataGridViewNCC.Rows)
            {
                if (row.Cells["MaNhaCungCap"].Value.ToString() == updatedNCC.MaNhaCungCap)
                {
                    row.Cells["TenNhaCungCap"].Value = updatedNCC.TenNhaCungCap;
                    row.Cells["DiaChi"].Value = updatedNCC.DiaChi;
                    row.Cells["SoDienThoai"].Value = updatedNCC.SoDienThoai;
                    row.Cells["Email"].Value = updatedNCC.Email;
                    break;
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DataGridViewNCC.CurrentRow != null)
            {
                // Lấy mã nhà cung cấp từ cột trong DataGridView
                string maNCC = guna2DataGridViewNCC.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();

                // Hỏi người dùng có chắc chắn muốn xóa nhà cung cấp này không
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tìm nhà cung cấp trong cơ sở dữ liệu trước khi xóa
                        var existingNCC = nhaCungCapBLL.GetAll().FirstOrDefault(n => n.MaNhaCungCap == maNCC);

                        if (existingNCC != null) // Nếu nhà cung cấp tồn tại
                        {
                            // Gọi phương thức Delete để xóa
                            nhaCungCapBLL.Delete(existingNCC);

                            // Xóa dòng trong DataGridView mà không cần load lại toàn bộ
                            guna2DataGridViewNCC.Rows.Remove(guna2DataGridViewNCC.CurrentRow);

                            MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhà cung cấp cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ DataGridView
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in guna2DataGridViewNCC.Columns)
            {
                dt.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in guna2DataGridViewNCC.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < guna2DataGridViewNCC.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value?.ToString();
                    }
                    dt.Rows.Add(dr);
                }
            }

            // Lưu Excel
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "DanhSach.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "DanhSach");
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}