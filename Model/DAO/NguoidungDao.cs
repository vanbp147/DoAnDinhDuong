using Model.EF;
using PagedList;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class NguoidungDao
    {
        DinhduongData db = null;
        public NguoidungDao()
        {
            db = new DinhduongData();
        }
        public bool CheckUserName(string taikhoan)
        {
            return db.Nguoidungs.Count(x => x.Taikhoan == taikhoan) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Nguoidungs.Count(x => x.Email == email) > 0;
        }
        public long Insert(Nguoidung entity)
        {
            db.Nguoidungs.Add(entity);
            db.SaveChanges();
            return entity.ID_Nguoidung;
        }
        public bool Delete(int id)
        {
            try
            {
                var nguoidunger = db.Nguoidungs.Find(id);
                db.Nguoidungs.Remove(nguoidunger);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Nguoidung> ListAllPaing(string searchString, int page, int pageSize)// tra ds quan ly
        {

            IQueryable<Nguoidung> model = db.Nguoidungs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Ten_ND.Contains(searchString) || x.Taikhoan.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_Nguoidung).ToPagedList(page, pageSize);
        }
        public int Login(string UserName, string PassWord)
        {
            var result = db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == UserName);

            if (result == null)
            {
                return 0; //Tài khoản không tồn tại
            }
            else
            {
                if (result.Status == false)
                {
                    return -1; //Tài khoản đã bị khóa.
                }
                if (result.Matkhau == PassWord)
                {
                    return 1; // Đang nhap thành công.
                }
                else
                {
                    return -2;// Dang nhap khong dung.
                }
            }
        }
        public Nguoidung GetById(string userName)
        {
            return db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == userName);
        }
        public NguoidungViewModel GetThongtin(string userName)
        {
            var model = from a in db.Nguoidungs
                        join b in db.MuctieuNguoidungs
                        on a.ID_MuctieuNguoidung equals b.ID_MuctieuNguoidung
                        join c in db.Kieunguois on a.ID_Kieunguoi equals c.ID_Kieunguoi
                        where a.Taikhoan == userName
                        select new NguoidungViewModel()
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
                            TenMuctieu = b.TenMuctieu,
                            Loai = c.Loai
                        };

            return model.SingleOrDefault();
        }
        public Nguoidung ViewDetail(int id)
        {
            return db.Nguoidungs.Find(id);
        }
        public NguoidungViewModel ListBykieunguoimuctieu(int id)
        {
            var model =  from a in db.Nguoidungs
                         join b in db.MuctieuNguoidungs
                         on a.ID_MuctieuNguoidung equals b.ID_MuctieuNguoidung
                         join c in db.Kieunguois on a.ID_Kieunguoi equals c.ID_Kieunguoi
                         where a.ID_Nguoidung == id
                         select new NguoidungViewModel()
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
                             TenMuctieu = b.TenMuctieu,
                             Loai = c.Loai
                         };
            
            return model.SingleOrDefault();
        }
        public TheodoiViewModel Listbytheodoinguoidung(string username)
        {
            var model = from a in db.Nguoidungs
                        join b in db.Theodoibuaans
                        on a.ID_Nguoidung equals b.ID_Nguoidung
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
                            ID_sobuatrongngay = c.ID_sobuatrongngay,
                            Ten_bua = c.Ten_bua
                            
                        };

            return model.SingleOrDefault();
        }
        public bool Update(Nguoidung entity)
        {
            try
            {
                var nguoidunger = db.Nguoidungs.Find(entity.ID_Nguoidung);
                nguoidunger.Ten_ND = entity.Ten_ND;
                nguoidunger.Tuoi = entity.Tuoi;
                nguoidunger.Gioitinh = entity.Gioitinh;
                nguoidunger.Chieucao = entity.Chieucao;
                nguoidunger.Cannang = entity.Cannang;
                nguoidunger.ID_MuctieuNguoidung = entity.ID_MuctieuNguoidung;
                nguoidunger.ID_Kieunguoi = entity.ID_Kieunguoi;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Changethongtin(string username, int Tuoi, string Gioitinh, decimal Cannang, decimal Chieucao, string Kieunguoi)//ajax json
        {
            try
            {
                var nguoidunger = db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == username);
                if(Kieunguoi.Equals("Hoạt động nhẹ")){
                    nguoidunger.ID_Kieunguoi = 1;
                }
                else if (Kieunguoi.Equals("Hoạt động vừa"))
                {
                    nguoidunger.ID_Kieunguoi = 2;
                }
                else if (Kieunguoi.Equals("Hoạt động trung bình"))
                {
                    nguoidunger.ID_Kieunguoi = 3;
                }
                else if (Kieunguoi.Equals("Hoạt động nặng"))
                {
                    nguoidunger.ID_Kieunguoi = 4;
                }
                else if (Kieunguoi.Equals("Vận động viên"))
                {
                    nguoidunger.ID_Kieunguoi = 5;
                }
                nguoidunger.Tuoi = Tuoi;
                nguoidunger.Gioitinh = Gioitinh;
                nguoidunger.Chieucao = Chieucao;
                nguoidunger.Cannang = Cannang;                
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Changecalo(string username, decimal? calories)//ajax json
        {
            try
            {
                var nguoidunger = db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == username);               
                nguoidunger.CaloriesTrongngay = calories;                              
                
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
       
    }
}
