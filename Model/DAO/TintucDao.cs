using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class TintucDao
    {
        DinhduongData db = null;
        public TintucDao()
        {
            db = new DinhduongData();
        }
        public long Insert(Tintuc entity)
        {
            db.Tintucs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Tintuc entity)
        {
            try
            {
                var tintuc = db.Tintucs.Find(entity.ID);
                //Bổ sung update
                tintuc.ID = entity.ID;
                tintuc.Name = entity.Name;
                tintuc.Mota = entity.Mota;
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
                var tintuc = db.Tintucs.Find(id);
                db.Tintucs.Remove(tintuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Tintuc> ListAllPaing(string searchString, int page, int pageSize)
        {

            IQueryable<Tintuc> model = db.Tintucs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Tintuc ViewDetail(int id)
        {
            return db.Tintucs.Find(id);
        }
        public Tintuc GetByID(long id)
        {
            return db.Tintucs.Find(id);
        }
    }
}
