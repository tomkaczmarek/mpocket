using EntityDatabase.Models;
using MPocket.Models;
using MPocket.Utils;
using MPocket.ViewsModel;
using MPocketCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index()
        {
            BudgetModel model = new BudgetModel();
            SessionManager session = new SessionManager();

            BudgetViewModel views = new BudgetViewModel()
            {
                Budget = model.GetAll(session.Get<User>(PageConstant.USER_ID_I_SESSION).Id)
            };

            return View(views);
        }

        public ActionResult Load(string[] selected)
        {
            SessionManager session = new SessionManager();
            BudgetModel bmodel = new BudgetModel();
            Budget budget = bmodel.GetBudgetById(int.Parse(selected.First()));

            session.Replace<Budget>(budget, PageConstant.BUDGET_ID_IN_SESSION);
            bmodel.StartBudget = budget.StartBudget;
            bmodel.CurrentBudget = budget.CurrentBudget;
            return View("MainPanel", bmodel);
        }
    }
}