using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class ThucphamDao
    {
        DinhduongData db = null;
        public ThucphamDao()
        {
            db = new DinhduongData();
        }
        public long Insert(Thucpham entity)
        {
            db.Thucphams.Add(entity);
            db.SaveChanges();
            return entity.ID_thucpham;
        }
        public bool Update(Thucpham entity)
        {
            try
            {
                var thucpham = db.Thucphams.Find(entity.ID_thucpham);
                thucpham.Image_thucpham = entity.Image_thucpham;
                thucpham.Ten_thucpham = entity.Ten_thucpham;
                thucpham.Mota = entity.Mota;
                thucpham.Total_Fat = entity.Total_Fat;
                thucpham.Calories = entity.Calories;
                thucpham.Cholesterol = entity.Cholesterol;
                thucpham.Sodium = entity.Sodium;
                thucpham.Total_Carbohydrate = entity.Total_Carbohydrate;
                thucpham.Total_Sugar = entity.Total_Sugar;
                thucpham.Protein = entity.Protein;
                thucpham.ID_loaithucpham = entity.ID_loaithucpham;
                
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
                var thucpham = db.Thucphams.Find(id);
                db.Thucphams.Remove(thucpham);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<Thucpham> ListAllPaing(string searchString, int page, int pageSize)// tra ds thucpham
        {

            IQueryable<Thucpham> model = db.Thucphams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ten_thucpham.Contains(searchString) || x.Mota.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_thucpham).ToPagedList(page, pageSize);
        }

        public Thucpham ViewDetail(int id)
        {
            return db.Thucphams.Find(id);
        }
        public Thucpham GetByID(long id)
        {
            return db.Thucphams.Find(id);
        }
        public List<string> ListName(string keyword)
        {
            return db.Thucphams.Where(x => x.Ten_thucpham.Contains(keyword)).Select(x => x.Ten_thucpham).ToList();
        }
        public List<Thucpham> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 5)
        {
            if(keyword.Equals("all")|| keyword.Equals("")){
                totalRecord = db.Thucphams.Count();
                var model = db.Thucphams.ToList();
                model.OrderByDescending(x => x.ID_loaithucpham).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return model.ToList();
            }
            else
            {
                totalRecord = db.Thucphams.Where(x => x.Ten_thucpham == keyword).Count();
                var model = db.Thucphams.Where(x => x.Ten_thucpham == keyword);
                model.OrderByDescending(x => x.ID_loaithucpham).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return model.ToList();
            }
            
        }

        public Thucpham GetRandom(){
           var  totalRecord = db.Thucphams.Count();
            var rand = new Random();
            var id = rand.Next(1, totalRecord);
            var model = db.Thucphams.Find(id);
            do
            {
               id = rand.Next(1, totalRecord);
                model = db.Thucphams.Find(id);

            }while(model == null);           
                   
            return model;
            
        }
     
    }
}
