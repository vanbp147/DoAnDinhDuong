using Doandinhduong.Areas.Admin.Common;
using Doandinhduong.Areas.Admin.Models;
using Doandinhduong.Common;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.ADMIN_SESSION] = null;
            return Redirect("/");
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new QuanlyDao();
                var result = dao.Login(model.UserName,Encryptor.MD5Hash(model.Password));
                if (result==1)
                {
                    var user = dao.GetById(model.UserName);
                    var adminSession = new UserLoginSS();
                    adminSession.UserName = user.Taikhoan;
                    adminSession.UserID = user.ID_Quanly;

                    Session.Add(CommonConstants.ADMIN_SESSION,adminSession);
                    return RedirectToAction("Index", "Home");
                }
                else if(result==0 || result == -2)
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa.");
                }
            }
            return View("Index");
        }
    }
}
