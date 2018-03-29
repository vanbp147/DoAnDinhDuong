using Doandinhduong.Areas.Admin.Common;
using Doandinhduong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sessus = (UserLoginSS)Session[CommonConstants.USER_SESSION];
            if (sessus == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "LoginRegister", action = "Login" }));
            }
            base.OnActionExecuted(filterContext);
        }

    }
}
