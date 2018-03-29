using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class GioiThieuDao
    {
        DinhduongData db = null;
        public GioiThieuDao()
        {
            db = new DinhduongData();
        }
        public long Insert(about entity)
        {
            db.abouts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(about entity)
        {
            try
            {
                var about = db.abouts.Find(entity.ID);
                //Bổ sung update
                about.Images = entity.Images;
                about.MetaTitle = entity.MetaTitle;
                about.Mota = entity.Mota;
                about.Ten = entity.Ten;
                about.Trangthai = entity.Trangthai;
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
                var about = db.abouts.Find(id);
                db.abouts.Remove(about);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<about> ListAllPaing(string searchString, int page, int pageSize)
        {

            IQueryable<about> model = db.abouts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ten.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public about ViewDetail(int id)
        {
            return db.abouts.Find(id);
        }
        public about GetByID(long id)
        {
            return db.abouts.Find(id);
        }
    }
}
