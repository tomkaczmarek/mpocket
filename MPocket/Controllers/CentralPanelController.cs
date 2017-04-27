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
    public class CentralPanelController : Controller
    {
        // GET: CentralPanel
        public ActionResult CentralView()
        {
            return View();
        }

        public ActionResult Save(ExpensesModel model)
        {
            BudgetModel bmodel = new BudgetModel();
            SessionManager session = new SessionManager();
            int userId = session.Get<User>(PageConstant.USER_ID_I_SESSION).Id;
            model.BudgetId = session.Get<Budget>(PageConstant.BUDGET_ID_IN_SESSION).Id;
            model.Save(model);

            Budget budget = bmodel.GetCurrentBudget(userId);
            budget.CurrentBudget = budget.CurrentBudget - model.Amount;
            bmodel.UpdateBudget(budget);

            bmodel.CurrentBudget = budget.CurrentBudget;
            bmodel.StartBudget = budget.StartBudget;
            return View("MainPanel", bmodel);
        }

    }
}