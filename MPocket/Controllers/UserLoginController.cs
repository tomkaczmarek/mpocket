using EntityDatabase.Models;
using MPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPocketCommon.Helpers;
using MPocketCommon.Cryptography;
using MPocket.Utils;

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
                SessionManager sessionManager = new SessionManager();
                bool passwordCorrect = CheckPassword(user.Password, model.Password);

                if (passwordCorrect)
                {
                    if (!user.IsActive)
                    {
                        user.IsActive = true;
                        model.UpdateUser(user);                       
                    }

                    sessionManager.Add<User>(user, PageConstant.USER_ID_I_SESSION);
                    ViewBag.Name = user.Name;

                    BudgetModel bmodel = new BudgetModel();
                    Budget budget = bmodel.GetCurrentBudget(user.Id);

                    if (budget == null)
                    {
                        return RedirectToAction("FirstLaunch", "FirstLaunch");
                    }
                  
                    sessionManager.Add<Budget>(budget, PageConstant.BUDGET_ID_IN_SESSION);

                    bmodel.CurrentBudget = budget.CurrentBudget;
                    bmodel.StartBudget = budget.StartBudget;
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

    }
}