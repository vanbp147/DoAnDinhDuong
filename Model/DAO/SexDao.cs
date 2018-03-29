using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SexDao
    {
         DinhduongData db = null;
         public SexDao()
        {
            db = new DinhduongData();
        }
        public List<Sex> ListAll()
        {
            return db.Sexes.ToList();
            
        }
    }
}
