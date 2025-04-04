using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Eden
{
    public class NHACUNGCAPDAL : IDisposable
    {
        private QLBanHoaEntities db = new QLBanHoaEntities();

        public List<NHACUNGCAP> GetAll() => db.NHACUNGCAPs.ToList();
        public void Add(NHACUNGCAP entity) { db.NHACUNGCAPs.Add(entity); db.SaveChanges(); }
        public void Update(NHACUNGCAP entity) {
            Console.WriteLine("Cập nhật nhà cung cấp: " + entity.MaNhaCungCap);

            var existingNCC = db.NHACUNGCAPs.FirstOrDefault(n => n.MaNhaCungCap == entity.MaNhaCungCap);
            if (existingNCC != null)
            {
                existingNCC.TenNhaCungCap = entity.TenNhaCungCap;
                existingNCC.DiaChi = entity.DiaChi;
                existingNCC.SoDienThoai = entity.SoDienThoai;
                existingNCC.Email = entity.Email;

                Console.WriteLine("Dữ liệu cập nhật: " + existingNCC.TenNhaCungCap);

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string errorMsg = "";
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            errorMsg += $"Thuộc tính: {validationError.PropertyName} - Lỗi: {validationError.ErrorMessage}\n";
                        }
                    }

                    Console.WriteLine(errorMsg);
                    throw new Exception("Lỗi khi cập nhật dữ liệu:\n" + errorMsg);
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy nhà cung cấp!");
                throw new Exception("Nhà cung cấp không tồn tại.");
            }
        }
        public void Delete(NHACUNGCAP entity) { db.NHACUNGCAPs.Remove(entity); db.SaveChanges(); }
        public void Dispose() { db.Dispose(); }
    }
}