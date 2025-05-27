namespace Eden
{
    using System.Data.Entity;

    public partial class QLBanHoaEntities : DbContext
    {
        public QLBanHoaEntities() : base("name=QLBanHoaEntities")
        {
        }

        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<CHITIETPHIEUNHAP> CHITIETPHIEUNHAPs { get; set; }
        public virtual DbSet<CHUCNANG> CHUCNANGs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAMs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; } // Thêm thủ công nếu không có
        public virtual DbSet<PHIEUNHAP> PHIEUNHAPs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<THAMSO> THAMSOs { get; set; }
    }

    public partial class PHANQUYEN
    {
        public int? idNhomNguoiDung { get; set; }
        public int? idChucNang { get; set; }

        public virtual CHUCNANG CHUCNANG { get; set; }
        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }
    }

    // Các class khác (CHITIETHOADON, CHITIETPHIEUNHAP, v.v.) giữ nguyên
}