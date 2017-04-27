using EntityDatabase.Models;
using MPocket.Models;
using MPocket.Utils;
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
            SessionManager sessionManager = new SessionManager();
            int userid = sessionManager.Get<EntityDatabase.Models.User>(PageConstant.USER_ID_I_SESSION).Id;
            
            budgetModel = model.Budget;
            settingModel = model.Settings;                   
            budgetModel.UserId = settingModel.UserId = userid;
            budgetModel.AddBudget(budgetModel);
            settingModel.AddSettings(settingModel);

            Budget budget = budgetModel.GetCurrentBudget(userid);
            sessionManager.Add<Budget>(budget, PageConstant.BUDGET_ID_IN_SESSION);
            budgetModel.CurrentBudget = budget.CurrentBudget;
            budgetModel.StartBudget = budget.StartBudget;

            return View("MainPanel", budgetModel);
        }
    }
}