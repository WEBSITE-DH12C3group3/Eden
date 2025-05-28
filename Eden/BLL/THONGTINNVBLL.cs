using System;
using System.Collections.Generic;
using Eden.DTO;

namespace Eden
{
    public class THONGTINNVBLL
    {
        private readonly THONGTINNVDAL _dal;
        private readonly QLBanHoaEntities db; // Add this field

        public THONGTINNVBLL()
        {
            _dal = new THONGTINNVDAL();
            db = new QLBanHoaEntities(); // Initialize the db context
        }

        public List<ThongTinNhanVienDTO> GetAllDTO()
        {
            return _dal.GetAllDTO();
        }

        public (List<ThongTinNhanVienDTO> Data, int TotalRecords) GetPaged(int page, int pageSize)
        {
            return _dal.GetPaged(page, pageSize);
        }

        public bool Delete(int id)
        {
            try
            {
                _dal.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public THONGTINNHANVIEN GetById(int id)
        {
            return _dal.GetById(id);
        }
    }
}
