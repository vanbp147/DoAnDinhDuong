using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
namespace Doandinhduong.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        //
        // GET: /Admin/Footer/

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FooterDao();
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
            var footer = new FooterDao().ViewDetail(id);

            return View(footer);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Footer footer) // Tạo tài khoản
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDao();
                long id = dao.Insert(footer);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Footer");
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
        public ActionResult Edit(Footer footer)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDao();
                var result = dao.Update(footer);
                if (result)
                {
                    return RedirectToAction("Index", "Footer");
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
            new FooterDao().Delete(id);
            return RedirectToAction("Index");
        }

    }

}
