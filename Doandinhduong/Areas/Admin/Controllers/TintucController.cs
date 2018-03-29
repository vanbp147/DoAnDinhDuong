using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using Doandinhduong.Common;
namespace Doandinhduong.Areas.Admin.Controllers
{
    public class TintucController : BaseController
    {
        //
        // GET: /Admin/Tintuc/

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TintucDao();
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
            var tintuc = new TintucDao().ViewDetail(id);

            return View(tintuc);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TintucDao();
                long id = dao.Insert(tintuc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Tintuc");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }
            return View("Index");

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TintucDao();
                var result = dao.Update(tintuc);
                if (result)
                {
                    return RedirectToAction("Index", "Tintuc");
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
            new TintucDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
