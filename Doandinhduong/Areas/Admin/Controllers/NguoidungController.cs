using Doandinhduong.Common;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Areas.Admin.Controllers
{
    public class NguoidungController : BaseController
    {
        //
        // GET: /Admin/Nguoidung/


        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NguoidungDao();
            var model = dao.ListAllPaing(searchString, page, pageSize);
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
            var nguoidung = new NguoidungDao().ViewDetail(id);

            return View(nguoidung);
        }
        [HttpPost]
        public ActionResult Create(Nguoidung nguoidung) // Tạo tài khoản
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoidungDao();
                var encrytedMd5Pas = Encryptor.MD5Hash(nguoidung.Matkhau);
                nguoidung.Matkhau = encrytedMd5Pas;
                long id = dao.Insert(nguoidung);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Nguoidung");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");

        }
        [HttpPost]
        public ActionResult Edit(Nguoidung nguoidung) // Tạo tài khoản
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoidungDao();
                if (!string.IsNullOrEmpty(nguoidung.Matkhau))
                {

                    var encrytedMd5Pas = Encryptor.MD5Hash(nguoidung.Matkhau);
                    nguoidung.Matkhau = encrytedMd5Pas;
                }

                var result = dao.Update(nguoidung);
                if (result)
                {
                    return RedirectToAction("Index", "Nguoidung");
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
            new NguoidungDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
