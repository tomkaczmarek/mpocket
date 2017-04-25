using EntityDatabase.Models;
using MPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPocketCommon.Helpers;
using MPocketCommon.Cryptography;

namespace MPocket.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult UserLoginView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            User user = model.Get(model);           
            if (user != null)
            {
                bool passwordCorrect = CheckPassword(user.Password, model.Password);
                if (passwordCorrect)
                {
                    AddUserToSession(user);
                    ViewBag.Name = user.Name;
                    if (!user.IsActive)
                    {
                        user.IsActive = true;
                        model.UpdateUser(user);                       
                    }
                    BudgetModel bmodel = new BudgetModel();
                    Budget budget = bmodel.GetBudget(user.Id);
                    if (budget == null)
                    {
                        return RedirectToAction("FirstLaunch", "FirstLaunch");
                    }
                    return View("MainPanel");
                }                             
            }
            else
            {
                ModelState.AddModelError("", "Error");
            }

            ModelState.Clear();
            return View("UserLoginView");
        }

        private bool CheckPassword(string password, string passwordToCheck)
        {
            ICryptography pass = new PasswordManager();
            return pass.IsMatch(password, pass.Encrypt(passwordToCheck)); 
        }

        private void AddUserToSession(User user)
        {
            Session[Session.SessionID + PageConstant.USER_NAME_IN_SESSION] = user.Name;
            Session[Session.SessionID + PageConstant.USER_ID_I_SESSION] = user.Id;
        }

    }
}