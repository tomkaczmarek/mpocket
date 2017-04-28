using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPocket.Models;
using EntityDatabase.Models;
using MPocketCommon.Helpers;
using MPocket.Utils;

namespace MPocket.Controllers
{
    public class BudgetController : Controller
    {
        // GET: Budget
        public ActionResult Index()
        {
            BudgetModel model = new BudgetModel();
            SessionManager session = new SessionManager();
            Budget budget = model.GetBudgetById(session.Get<Budget>(PageConstant.BUDGET_ID_IN_SESSION).Id);
            model.CurrentBudget = budget.CurrentBudget;
            model.EndDate = budget.EndDate;
            model.StartDate = budget.StartDate;
            model.StartBudget = budget.StartBudget;
            return View(model);
        }

        public ActionResult Update(BudgetModel model)
        {
            SessionManager session = new SessionManager();
            Budget budget = model.GetBudgetById(session.Get<Budget>(PageConstant.BUDGET_ID_IN_SESSION).Id);
            model.StartBudget = budget.StartBudget + model.AddedBudget;
            model.CurrentBudget = budget.CurrentBudget + model.AddedBudget;
            budget.StartBudget = model.StartBudget;
            budget.CurrentBudget = model.CurrentBudget;
            model.UpdateBudget(budget);
            return View("MainPanel", model);
        }
    }
}