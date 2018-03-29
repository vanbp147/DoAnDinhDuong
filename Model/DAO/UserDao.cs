using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class UserDao
    {
        DinhduongData db = null;
        public UserDao()
        {
            db = new DinhduongData();
        }
        public int Insert(Nguoidung entity)
        {
            db.Nguoidungs.Add(entity);
            db.SaveChanges();
            return entity.ID_Nguoidung;
        }
        public Nguoidung GetById(string userName)
        {
            return db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == userName);
        }
        public int Login(string UserName, string PassWord)
        {
            var result = db.Nguoidungs.SingleOrDefault(x => x.Taikhoan == UserName);
            
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
