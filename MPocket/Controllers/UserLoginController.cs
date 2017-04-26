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
                    if (!user.IsActive)
                    {
                        user.IsActive = true;
                        model.UpdateUser(user);                       
                    }

                    AddToSession(user);
                    ViewBag.Name = user.Name;

                    BudgetModel bmodel = new BudgetModel();
                    Budget budget = bmodel.GetCurrentBudget(user.Id);

                    if (budget == null)
                    {
                        return RedirectToAction("FirstLaunch", "FirstLaunch");
                    }
                    bmodel.CurrentBudget = budget.CurrentBudget;
                    return View("MainPanel", bmodel);
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

        private void AddToSession(User user)
        {
            SessionBags sessionBags = new SessionBags();
            sessionBags.CurrentUserId = user.Id;
            sessionBags.CurrentUserName = user.Name;
            CurrentContext.Instance.Add(Session.SessionID, sessionBags);
        }

    }
}