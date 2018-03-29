using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Controllers
{
    public class ThucphamRanController : Controller
    {
        //
        // GET: /ThucphamRan/

        public ActionResult Index()
        {
            var model = new ThucphamDao().GetRandom();
            return View(model);
        }
        

    }
}
