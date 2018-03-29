using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class FooterDao
    {
        DinhduongData db = null;
        public FooterDao()
        {
            db = new DinhduongData();
        }
        public long Insert(Footer entity)
        {
            db.Footers.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Footer Listfooter()
        {
            return db.Footers.SingleOrDefault(x => x.Trangthai == true);
        }
        public bool Update(Footer entity)
        {
            try
            {
                var footer = db.Footers.Find(entity.ID);
                //Bổ sung update
                footer.Context = entity.Context;
                footer.Trangthai = entity.Trangthai;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var footer = db.Footers.Find(id);
                db.Footers.Remove(footer);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Footer> ListAllPaing(string searchString, int page, int pageSize)
        {

            IQueryable<Footer> model = db.Footers;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Context.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Footer ViewDetail(int id)
        {
            return db.Footers.Find(id);
        }
        public Footer GetByID(long id)
        {
            return db.Footers.Find(id);
        }
    }
}
