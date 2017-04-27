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
    public class BudgetSummaryNavBarController : Controller
    {
        // GET: BudgetSummaryNavBar
        public ActionResult BudgetSummary()
        {
            BudgetModel model = new BudgetModel();
            SessionManager session = new SessionManager();
            model.CurrentBudget = model.GetCurrentBudget(session.Get<User>(PageConstant.USER_ID_I_SESSION).Id).CurrentBudget;
            return View(model);
        }
    }
}