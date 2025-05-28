using System;
using System.Collections.Generic;
using Eden;
using Eden.DTO;

namespace Eden.BLLCustom
{
    public class TINHLUONGBLL
    {
        private TINHLUONGDAL tinhLuongDal = new TINHLUONGDAL();

        public List<LuongDTO> GetAll()
        {
            try
            {
                return tinhLuongDal.GetAllDTO();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lương: {ex.Message}", ex);
            }
        }

        public LuongDTO CalculateSalary(int idNguoiDung, int thang, int nam)
        {
            try
            {
                var luongDTO = tinhLuongDal.CalculateSalary(idNguoiDung, thang, nam);
                if (luongDTO.LuongCoDinh <= 0)
                    throw new Exception("Lương cố định phải lớn hơn 0.");
                return luongDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tính lương: {ex.Message}", ex);
            }
        }

        public void SaveSalary(LuongDTO luongDTO)
        {
            try
            {
                if (luongDTO.LuongCoDinh <= 0)
                    throw new Exception("Lương cố định phải lớn hơn 0.");
                if (luongDTO.TongLuong < 0)
                    throw new Exception("Tổng lương không được âm.");
                tinhLuongDal.SaveSalary(luongDTO);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu lương: {ex.Message}", ex);
            }
        }
    }
}