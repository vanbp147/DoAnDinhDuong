using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class LoaithucphamDao
    {
        DinhduongData db = null;
        public LoaithucphamDao()
        {
            db = new DinhduongData();
        }
        public List<Loaithucpham> ListAll()
        {
            return db.Loaithucphams.ToList();
            
        }
    }
}
