using MPocket.Models;
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
            int userId = CurrentContext.Instance.Get(Session.SessionID).CurrentUserId;
            var expense = model.GetAll(bModel.GetCurrentBudgetId(userId));

            var viewModel = new SummaryModel()
            {
                Summary = expense
            };


            return View(viewModel);
        }
    }
}