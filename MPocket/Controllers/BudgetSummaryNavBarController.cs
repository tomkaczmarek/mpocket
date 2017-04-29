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
    public class BudgetSummaryNavBarController : BaseController
    {
        // GET: BudgetSummaryNavBar
        public ActionResult BudgetSummary()
        {
            BudgetModel model = new BudgetModel();
            SessionManager session = new SessionManager();
            model.CurrentBudget = model.GetBudgetById(session.Get<Budget>(PageConstant.BUDGET_ID_IN_SESSION).Id).CurrentBudget;
            return View(model);
        }
    }
}