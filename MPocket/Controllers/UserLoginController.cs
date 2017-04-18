using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult UserLoginView()
        {
            return View();
        }
    }
}