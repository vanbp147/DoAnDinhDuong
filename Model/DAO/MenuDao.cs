using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDao
    {
        DinhduongData db = null;
        public MenuDao()
        {
            db = new DinhduongData();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Trangthai == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
