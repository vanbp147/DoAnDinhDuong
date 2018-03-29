using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doandinhduong.Common;
using Model.DAO;
using Model.EF;

namespace Doandinhduong.Areas.Admin.Controllers
{
    public class ThucphamController : BaseController
    {
        //
        // GET: /Admin/Thucpham/

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ThucphamDao();
            var model = dao.ListAllPaing(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new LoaithucphamDao();
            ViewBag.ID_loaithucpham = new SelectList(dao.ListAll(), "ID_loaithucpham", "Ten_loaithucpham", selectedId);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var thucpham = new ThucphamDao().ViewDetail(id);
            SetViewBag(thucpham.ID_loaithucpham);            
            return View(thucpham);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Thucpham thucpham)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThucphamDao();
                thucpham.MetaTitle = VietNamChar.ReplaceUnicode(thucpham.Ten_thucpham);
                var result = dao.Update(thucpham);
                if (result)
                {
                    return RedirectToAction("Index", "Thucpham");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Thucpham thucpham) // Tạo tài khoản
        {
            if (ModelState.IsValid)
            {
                var dao = new ThucphamDao();
                thucpham.MetaTitle = VietNamChar.ReplaceUnicode(thucpham.Ten_thucpham);
                long id = dao.Insert(thucpham);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Thucpham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }
            }

            return View("Index");

        }
        [HttpDelete]

        public ActionResult Delete(int id)
        {
            new ThucphamDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
