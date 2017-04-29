using MPocket.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            SessionManager session = new SessionManager();
            session.RemoveSession();
            return RedirectToAction("UserLoginView", "UserLogin");
        }
    }
}