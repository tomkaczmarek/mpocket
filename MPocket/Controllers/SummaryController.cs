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
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
            ExpensesModel model = new ExpensesModel();
            BudgetModel bModel = new BudgetModel();
            SessionManager session = new SessionManager();
            int budgetId = session.Get<Budget>(PageConstant.BUDGET_ID_IN_SESSION).Id;
            int userId = session.Get<User>(PageConstant.USER_ID_I_SESSION).Id;
            var expense = model.GetAll(budgetId);

            var viewModel = new SummaryModel()
            {
                Summary = expense
            };


            return View(viewModel);
        }
    }
}