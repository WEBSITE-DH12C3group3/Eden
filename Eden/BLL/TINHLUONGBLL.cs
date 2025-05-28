using System;
using System.Collections.Generic;
using Eden.DTO;

namespace Eden
{
    public class TINHLUONGBLL
    {
        private readonly TINHLUONGDAL _dal;

        public TINHLUONGBLL()
        {
            _dal = new TINHLUONGDAL();
        }

        public List<LuongDTO> GetAllDTO()
        {
            return _dal.GetAllDTO();
        }
    }
}