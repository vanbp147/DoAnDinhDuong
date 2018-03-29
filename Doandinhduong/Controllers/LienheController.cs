using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Controllers
{
    public class LienheController : Controller
    {
        //
        // GET: /Lienhe/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Guimail(string Name, string mobile, string address, string Email, string Message)
        {
            try
            {
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Asset/client/template/maillienhe.html"));

                content = content.Replace("{{CustomerName}}", Name);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", Email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Message}}", Message);
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                
                new MailHelper().SendMail(toEmail, "Lời nhắn", content);
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("Index");
            }
            return Redirect("Index");
        }

    }
}
