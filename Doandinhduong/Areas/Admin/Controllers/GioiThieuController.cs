using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using Doandinhduong.Common;
namespace Doandinhduong.Areas.Admin.Controllers
{
    public class GioiThieuController : BaseController
    {
        //
        // GET: /Admin/GioiThieu/

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new GioiThieuDao();
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
            var gioithieu = new GioiThieuDao().ViewDetail(id);

            return View(gioithieu);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(about gioithieu) // Tạo tài khoản
        {
            if (ModelState.IsValid)
            {
                var dao = new GioiThieuDao();
                long id = dao.Insert(gioithieu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "GioiThieu");
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
        public ActionResult Edit(about gioithieu)
        {
            if (ModelState.IsValid)
            {
                var dao = new GioiThieuDao();
                var result = dao.Update(gioithieu);
                if (result)
                {
                    return RedirectToAction("Index", "GioiThieu");
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
            new GioiThieuDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
