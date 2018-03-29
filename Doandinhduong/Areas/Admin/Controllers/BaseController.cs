using Doandinhduong.Areas.Admin.Common;
using Doandinhduong.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doandinhduong.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Admin/Base/

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sessad = (UserLoginSS)Session[CommonConstants.ADMIN_SESSION];
            if (sessad == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }

    }
}
