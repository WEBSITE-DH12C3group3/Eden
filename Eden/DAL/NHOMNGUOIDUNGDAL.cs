using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Eden;

namespace Eden.DALCustom
{
    public class NHOMNGUOIDUNGDAL
    {
        public List<NHOMNGUOIDUNG> GetAll()
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NHOMNGUOIDUNGs.ToList();
            }
        }

        public int Add(NHOMNGUOIDUNG nhom)
        {
            using (var context = new QLBanHoaEntities())
            {
                context.NHOMNGUOIDUNGs.Add(nhom);
                context.SaveChanges();
                return nhom.id;
            }
        }

        public void Update(NHOMNGUOIDUNG nhom)
        {
            using (var context = new QLBanHoaEntities())
            {
                var existingGroup = context.NHOMNGUOIDUNGs.Find(nhom.id);
                if (existingGroup == null)
                    throw new Exception($"Không tìm thấy nhóm với ID: {nhom.id}");

                existingGroup.TenNhomNguoiDung = nhom.TenNhomNguoiDung;
                context.SaveChanges();
            }
        }

        public void Delete(NHOMNGUOIDUNG nhom)
        {
            using (var context = new QLBanHoaEntities())
            {
                var group = context.NHOMNGUOIDUNGs
                    .Include(g => g.CHUCNANGs)
                    .Include(g => g.NGUOIDUNGs)
                    .FirstOrDefault(g => g.id == nhom.id);

                if (group == null)
                    throw new Exception($"Không tìm thấy nhóm với ID: {nhom.id}");

                // Xóa các quyền liên quan trước (sử dụng navigation property)
                group.CHUCNANGs.Clear();

                // Kiểm tra xem nhóm có người dùng nào không
                if (group.NGUOIDUNGs.Any())
                    throw new Exception("Không thể xóa nhóm vì vẫn còn người dùng thuộc nhóm này.");

                context.NHOMNGUOIDUNGs.Remove(group);
                context.SaveChanges();
            }
        }

        public bool CheckIfGroupNameExists(string groupName)
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NHOMNGUOIDUNGs.Any(g => g.TenNhomNguoiDung == groupName);
            }
        }

        public bool CheckIfGroupNameExistsForOther(string groupName, int groupId)
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.NHOMNGUOIDUNGs.Any(g => g.TenNhomNguoiDung == groupName && g.id != groupId);
            }
        }

        public List<CHUCNANG> GetAllPermissions()
        {
            using (var context = new QLBanHoaEntities())
            {
                return context.CHUCNANGs.ToList();
            }
        }

        public List<int> GetPermissionsForGroup(int groupId)
        {
            using (var context = new QLBanHoaEntities())
            {
                var group = context.NHOMNGUOIDUNGs
                    .Include(g => g.CHUCNANGs)
                    .FirstOrDefault(g => g.id == groupId);

                if (group == null)
                    throw new Exception($"Không tìm thấy nhóm với ID: {groupId}");

                return group.CHUCNANGs.Select(c => c.id).ToList();
            }
        }

        public void UpdatePermissionsForGroup(int groupId, List<int> permissionIds)
        {
            using (var context = new QLBanHoaEntities())
            {
                var group = context.NHOMNGUOIDUNGs
                    .Include(g => g.CHUCNANGs)
                    .FirstOrDefault(g => g.id == groupId);

                if (group == null)
                    throw new Exception($"Không tìm thấy nhóm với ID: {groupId}");

                // Xóa các quyền cũ
                group.CHUCNANGs.Clear();

                if (permissionIds == null || !permissionIds.Any())
                {
                    context.SaveChanges();
                    return;
                }

                // Thêm các quyền mới
                foreach (int permissionId in permissionIds)
                {
                    var chucNang = context.CHUCNANGs.Find(permissionId);
                    if (chucNang == null)
                        throw new Exception($"Không tìm thấy chức năng với ID: {permissionId}");

                    group.CHUCNANGs.Add(chucNang);
                }
                context.SaveChanges();
            }
        }
    }
}