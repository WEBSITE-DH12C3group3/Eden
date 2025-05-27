using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Eden.DTO;

namespace Eden
{
    public class ChamCongBLL
    {
        private ChamCongDAL chamCongDAL;

        public ChamCongBLL()
        {
            chamCongDAL = new ChamCongDAL();
        }

        // Lấy danh sách chấm công
        public List<ChamCongDTO> GetChamCongList()
        {
            return chamCongDAL.GetAllDTO();
        }

        // Lấy danh sách chấm công phân trang
        public (List<ChamCongDTO> Data, int TotalRecords) GetPagedChamCong(int page, int pageSize)
        {
            return chamCongDAL.GetPaged(page, pageSize);
        }

        // Thêm bản ghi chấm công với logic kiểm tra
        public void AddChamCong(CHAMCONG chamCong)
        {
            // Kiểm tra trạng thái dựa trên thời gian đăng nhập và ca làm việc
            if (chamCong.GioDangNhap.HasValue)
            {
                TimeSpan gioBatDauCa = GetStartTimeOfShift(chamCong.CaLamViec);
                if (chamCong.GioDangNhap > gioBatDauCa)
                {
                    chamCong.TrangThai = "Đi muộn";
                }
                else
                {
                    chamCong.TrangThai = "Đi làm";
                }
            }
            else if (!chamCong.GioDangNhap.HasValue && !chamCong.GioDangXuat.HasValue)
            {
                chamCong.TrangThai = "Nghỉ phép";
            }

            chamCongDAL.Add(chamCong);
        }

        // Cập nhật bản ghi chấm công với logic kiểm tra
        public void UpdateChamCong(CHAMCONG chamCong)
        {
            // Kiểm tra trạng thái dựa trên thời gian đăng nhập và ca làm việc
            if (chamCong.GioDangNhap.HasValue)
            {
                TimeSpan gioBatDauCa = GetStartTimeOfShift(chamCong.CaLamViec);
                if (chamCong.GioDangNhap > gioBatDauCa)
                {
                    chamCong.TrangThai = "Đi muộn";
                }
                else
                {
                    chamCong.TrangThai = "Đi làm";
                }
            }
            else if (!chamCong.GioDangNhap.HasValue && !chamCong.GioDangXuat.HasValue)
            {
                chamCong.TrangThai = "Nghỉ phép";
            }

            chamCongDAL.Update(chamCong);
        }

        // Xóa bản ghi chấm công
        public void DeleteChamCong(int id)
        {
            chamCongDAL.Delete(id);
        }

        // Lấy thời gian bắt đầu của ca làm việc
        private TimeSpan GetStartTimeOfShift(int caLamViec)
        {
            switch (caLamViec)
            {
                case 1: return new TimeSpan(7, 0, 0);  // Ca 1: 7h-12h
                case 2: return new TimeSpan(12, 0, 0); // Ca 2: 12h-17h
                case 3: return new TimeSpan(17, 0, 0); // Ca 3: 17h-22h
                default: throw new ArgumentException("Ca làm việc không hợp lệ!");
            }
        }
    }
}