using Doandinhduong.Common;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Doandinhduong.Areas.Admin.Controllers
{
    public class QuanlyController : BaseController
    {
        //
        // GET: /Admin/Quanly/

        public ActionResult Index(string searchString,int page = 1,int pageSize = 10)
        {
            var dao = new QuanlyDao();
            var model = dao.ListAllPaing(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var quanly = new QuanlyDao().ViewDetail(id);

            return View(quanly);
        }
        [HttpPost]
        public ActionResult Create(Quanly quanly) // Tạo tài khoản
        {
            if (ModelState.IsValid)
            {
                var dao = new QuanlyDao();
                var encrytedMd5Pas = Encryptor.MD5Hash(quanly.Matkhau);
                quanly.Matkhau = encrytedMd5Pas;
                long id = dao.Insert(quanly);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Quanly");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");
            
        }
        [HttpPost]
        public ActionResult Edit(Quanly quanly) // Tạo tài khoản
        {
            if (ModelState.IsValid)
            {
                var dao = new QuanlyDao();
                if (!string.IsNullOrEmpty(quanly.Matkhau))
                {
                    
                    
                    var encrytedMd5Pas = Encryptor.MD5Hash(quanly.Matkhau);
                    quanly.Matkhau = encrytedMd5Pas;
                }
                
                var result = dao.Update(quanly);
                if (result)
                {
                    return RedirectToAction("Index", "Quanly");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");

        }
        [HttpDelete]

        public ActionResult Delete(int id)
        {
            new QuanlyDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
