using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Controllers
{
    public class TheodoiController : Controller
    {
        //
        // GET: /Theodoi/

        public ActionResult Index(string username)
        {
            var model = new TheodoiDao().Listbuaan(username);
            return View(model);
        }
        
        [HttpPost]
        public JsonResult Thembuaan(string username, string sobua, DateTime date, decimal pro, decimal fat, decimal carbs)
        {
            var result = new TheodoiDao().Thembua(username, sobua, date, pro, fat, carbs);
            return Json(new
            {
                status = result
            });
        }

       

    }
}
