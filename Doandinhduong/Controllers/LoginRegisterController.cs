using BotDetect.Web.Mvc;
using BotDetect.Web.UI;
using Doandinhduong.Areas.Admin.Common;
using Doandinhduong.Common;
using Doandinhduong.Models;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Controllers
{
    public class LoginRegisterController : Controller
    {
        //
        // GET: /LoginRegister/
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
       
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                var dao = new NguoidungDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLoginSS();
                    userSession.UserName = user.Taikhoan;
                    userSession.UserID = user.ID_Nguoidung;
                    

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("/");
                }
                else if (result == 0 || result == -2)
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa.");
                }
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoidungDao();
                if (dao.CheckUserName(model.Taikhoan))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new Nguoidung();
                    user.Taikhoan = model.Taikhoan;
                    user.Matkhau = Encryptor.MD5Hash(model.Matkhau);
                    user.Email = model.Email;
                    user.ID_MuctieuNguoidung = 1;
                    user.ID_Kieunguoi = 1;
                    user.Status = true;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
    }
}
