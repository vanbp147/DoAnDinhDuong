using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class TheodoiDao
    {
        DinhduongData db = null;
        public TheodoiDao()
        {
            db = new DinhduongData();
        }
        /*public List<Theodoibuaan> Listbuaan(string username)
        {
            var model = db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == username);
            var id = model.ID_Nguoidung;
            return db.Theodoibuaans.Where(x => x.ID_Nguoidung == id).ToList();
         *  
        }*/
        public Nguoidung GetById(string userName)
        {
            return db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == userName);
        }
       
        public int GetByiddate(int sobua,DateTime date, int id_nguoidung)
        {
            Theodoibuaan bien = db.Theodoibuaans.Where(x => DbFunctions.TruncateTime(x.Ngaythang) == date.Date && x.ID_Nguoidung == id_nguoidung && x.ID_sobuatrongngay == sobua).Take(1).SingleOrDefault();
            if(bien!= null)
            {
             return bien.ID_theodoi;
            }
            else
            {
                return 0;
            }   
        }
        public bool Thembua(string username, string sobua, DateTime date, decimal pro, decimal fat, decimal carbs)//ajax json
        {
            
            var sob = Int32.Parse(sobua);
            var id = GetById(username).ID_Nguoidung;
            var totalcalo = pro * 4 + carbs * 4 + fat * 9;
            Theodoibuaan entity = new Theodoibuaan();
            entity.ID_Nguoidung = id;
            entity.ID_sobuatrongngay = Int32.Parse(sobua);
            entity.Ngaythang = date;
            entity.Fat_ba = fat;
            entity.Protein_ba = pro;
            entity.Carb_ba = carbs;
            entity.Total_calos = totalcalo;
            int check = GetByiddate(sob,date,id);
            if (check != 0)
            {
                var buaaner = db.Theodoibuaans.Find(check);
                buaaner.ID_Nguoidung = id;
                buaaner.ID_sobuatrongngay = Int32.Parse(sobua);
                buaaner.Ngaythang = date;
                buaaner.Fat_ba = fat;
                buaaner.Protein_ba = pro;
                buaaner.Carb_ba = carbs;
                buaaner.Total_calos = totalcalo;
                db.SaveChanges();
                return true;
            }
            else
            {
                try
                {
                    db.Theodoibuaans.Add(entity);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            
        }
        public List<TheodoiViewModel> Listbuaan(string username)
        {
            var model = from a in db.Nguoidungs
                        join b in db.Theodoibuaans
                        on a.ID_Nguoidung equals b.ID_Nguoidung
                        join d in db.MuctieuNguoidungs on a.ID_MuctieuNguoidung equals d.ID_MuctieuNguoidung
                        join c in db.Sobuatrongngays on b.ID_sobuatrongngay equals c.ID_sobuatrongngay                       
                        where a.Taikhoan == username
                        select new TheodoiViewModel()
                        {
                            ID_Nguoidung = a.ID_Nguoidung,
                            Taikhoan = a.Taikhoan,
                            Ten_ND = a.Ten_ND,
                            Tuoi = a.Tuoi,
                            Gioitinh = a.Gioitinh,
                            Chieucao = a.Chieucao,
                            Cannang = a.Cannang,
                            CaloriesTrongngay = a.CaloriesTrongngay,
                            Email = a.Email,
                            ID_theodoi = b.ID_theodoi,
                            Ngaythang = b.Ngaythang,
                            Fat_ba = b.Fat_ba,
                            Protein_ba = b.Protein_ba,
                            Carb_ba = b.Carb_ba,
                            Total_calos = b.Total_calos,
                            ID_sobuatrongngay = c.ID_sobuatrongngay,
                            Ten_bua = c.Ten_bua,
                            TenMuctieu = d.TenMuctieu,

                        };

            return model.ToList();
        }

    }
}
