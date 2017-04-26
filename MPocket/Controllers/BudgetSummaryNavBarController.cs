using MPocket.Models;
using MPocketCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class BudgetSummaryNavBarController : Controller
    {
        // GET: BudgetSummaryNavBar
        public ActionResult BudgetSummary()
        {
            BudgetModel model = new BudgetModel();
            model.CurrentBudget = model.GetCurrentBudget(CurrentContext.Instance.Get(Session.SessionID).CurrentUserId).CurrentBudget;
            return View(model);
        }
    }
}