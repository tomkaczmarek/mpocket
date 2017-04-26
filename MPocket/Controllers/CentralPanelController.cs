using EntityDatabase.Models;
using MPocket.Models;
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
            int userId = CurrentContext.Instance.Get(Session.SessionID).CurrentUserId;
            model.BudgetId = bmodel.GetCurrentBudgetId(userId);
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