using MPocket.Models;
using MPocketCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class FirstLaunchController : Controller
    {
        // GET: FirstLaunch
        public ActionResult FirstLaunch(FirstLaunchModel model)
        {
            return View(model);
        }

        public ActionResult Save(FirstLaunchModel model)
        {
            BudgetModel budgetModel = new BudgetModel();
            SettingsModel settingModel = new SettingsModel();

            budgetModel = model.Budget;
            settingModel = model.Settings;

            int userid = (int)Session[Session.SessionID + PageConstant.USER_ID_I_SESSION];
            budgetModel.UserId = settingModel.UserId = userid;
            budgetModel.AddBudget(budgetModel);
            settingModel.AddSettings(settingModel);
            return View("MainPanel");
        }
    }
}