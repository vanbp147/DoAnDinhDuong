using Doandinhduong.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().Listfooter();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult TDEE(int age,float weight, string gender, int height, string activity)
        {
            PersonStat ps = new PersonStat();
            ps.Gender = gender;
            ps.Age = age;
            ps.Weight = weight;
            ps.Height = height;
            ps.Activity = activity;
            return View(ps);
        }

    }
}
