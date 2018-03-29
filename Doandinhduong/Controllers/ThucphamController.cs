using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Controllers
{
    public class ThucphamController : Controller
    {
        //
        // GET: /Thucpham/

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListName(string q)
        {
            var data = new ThucphamDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 5)
        {
            
            int totalRecord = 0;
            var model = new ThucphamDao().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ActionResult Chitietthucpham(int id)
        {
            var model = new ThucphamDao().ViewDetail(id);
            return View(model);
        }

    }
}
