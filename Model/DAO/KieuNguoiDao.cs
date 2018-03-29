using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class KieuNguoiDao
    {
         DinhduongData db = null;
         public KieuNguoiDao()
        {
            db = new DinhduongData();
        }
        public List<Kieunguoi> ListAll()
        {
            return db.Kieunguois.ToList();
            
        }
    }
}
