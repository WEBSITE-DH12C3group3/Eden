﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
namespace Eden
{
    public class LOAISANPHAMBLL : IDisposable
    {
        private LOAISANPHAMDAL dal = new LOAISANPHAMDAL();
        public LOAISANPHAMBLL()
        {
            dal = new LOAISANPHAMDAL();
        }

        public List<LOAISANPHAM> GetAll()
        {
            return dal.GetAll();
        }

        public void Add(LOAISANPHAM lsp)
        {
            dal.Add(lsp);
        }

        public void Update(LOAISANPHAM lsp)
        {
            dal.Update(lsp);
        }

        public void Delete(LOAISANPHAM lsp)
        {
            dal.Delete(lsp);
        }
        

        public void Dispose()
        {
            dal.Dispose();
        }
    }
}
