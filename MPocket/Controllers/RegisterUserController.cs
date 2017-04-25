using MPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityDatabase.Models;

namespace MPocket.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: RegisterUser
        public ActionResult RegisterUserView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(UserModel model)
        {
            User user = model.Get(model);
            if(user == null)
            {
                model.Register(model);
            }
            ModelState.Clear();
            return View("RegisterUserView");
        }
    }
}