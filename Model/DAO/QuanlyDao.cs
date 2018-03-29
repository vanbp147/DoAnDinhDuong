using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.DAO
{
    public class QuanlyDao
    {
        DinhduongData db = null;
        public QuanlyDao()
        {
            db = new DinhduongData();
        }
        public int Insert(Quanly entity)
        {
            db.Quanlies.Add(entity);
            db.SaveChanges();
            return entity.ID_Quanly;
        }
        public bool Update(Quanly entity)
        {
            try
            {
                var quanlyer = db.Quanlies.Find(entity.ID_Quanly);
                quanlyer.Hoten = entity.Hoten;
                quanlyer.Taikhoan = entity.Taikhoan;
               // quanlyer.Gioitinh = entity.Gioitinh;
                if (!string.IsNullOrEmpty(entity.Matkhau))
                {
                    quanlyer.Matkhau = entity.Matkhau;
                }
                
              //  quanlyer.Ngaysinh = entity.Ngaysinh;
              //  quanlyer.SDT = entity.SDT;
              //  quanlyer.Status = entity.Status;
              //  quanlyer.Quyen = entity.Quyen;
               // quanlyer.Diachi = entity.Diachi;
                db.SaveChanges();
                return true;
            }catch(Exception ex){
                return false;
            }
            
        }
        public bool Delete(int id)
        {
            try {
                var quanlyer = db.Quanlies.Find(id);
                db.Quanlies.Remove(quanlyer);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public IEnumerable<Quanly> ListAllPaing(string searchString, int page,int pageSize)// tra ds quan ly
        {
            
            IQueryable<Quanly> model = db.Quanlies;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Hoten.Contains(searchString) || x.Taikhoan.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID_Quanly).ToPagedList(page, pageSize);
        }
        public Quanly GetById(string userName)
        {
            return db.Quanlies.SingleOrDefault(x => x.Taikhoan == userName);
        }
        public Quanly ViewDetail(int id)
        {
            return db.Quanlies.Find(id);
        }
        public int Login(string UserName, string PassWord)
        {
            var result = db.Quanlies.SingleOrDefault(x => x.Taikhoan == UserName);
            
            if (result == null){
                return 0; //Tài khoản không tồn tại
            }else {
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
    }
}
