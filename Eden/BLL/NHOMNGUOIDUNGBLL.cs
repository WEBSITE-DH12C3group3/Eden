using System;
using System.Collections.Generic;
using System.Linq;
using Eden.DALCustom;

namespace Eden.BLLCustom
{
    public class NHOMNGUOIDUNGBLL
    {
        private NHOMNGUOIDUNGDAL nhomNguoiDungDal = new NHOMNGUOIDUNGDAL();

        public List<NHOMNGUOIDUNG> GetAll()
        {
            return nhomNguoiDungDal.GetAll();
        }

        public int Add(NHOMNGUOIDUNG nhom)
        {
            if (nhomNguoiDungDal.CheckIfGroupNameExists(nhom.TenNhomNguoiDung))
                throw new Exception("Tên nhóm đã tồn tại.");

            // Kiểm tra MaNhomNguoiDung có trùng không
            using (var context = new QLBanHoaEntities())
            {
                int attempt = 0;
                string originalMaNhom = nhom.MaNhomNguoiDung;
                while (context.NHOMNGUOIDUNGs.Any(n => n.MaNhomNguoiDung == nhom.MaNhomNguoiDung))
                {
                    attempt++;
                    nhom.MaNhomNguoiDung = $"{originalMaNhom.Substring(0, 3)}{attempt:D3}";
                }
            }

            return nhomNguoiDungDal.Add(nhom);
        }

        public void Update(NHOMNGUOIDUNG nhom)
        {
            if (nhomNguoiDungDal.CheckIfGroupNameExistsForOther(nhom.TenNhomNguoiDung, nhom.id))
                throw new Exception("Tên nhóm đã tồn tại.");

            nhomNguoiDungDal.Update(nhom);
        }

        public void Delete(NHOMNGUOIDUNG nhom)
        {
            using (var context = new QLBanHoaEntities())
            {
                if (context.NGUOIDUNGs.Any(u => u.idNhomNguoiDung == nhom.id))
                    throw new Exception("Không thể xóa nhóm vì đã có người dùng thuộc nhóm này.");
            }

            nhomNguoiDungDal.Delete(nhom);
        }

        public List<CHUCNANG> GetAllPermissions()
        {
            return nhomNguoiDungDal.GetAllPermissions();
        }

        public List<int> GetPermissionsForGroup(int groupId)
        {
            return nhomNguoiDungDal.GetPermissionsForGroup(groupId);
        }

        public void UpdatePermissionsForGroup(int groupId, List<int> permissionIds)
        {
            nhomNguoiDungDal.UpdatePermissionsForGroup(groupId, permissionIds);
        }
    }
}