using EntityDatabase.Models;
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
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index()
        {
            BudgetModel model = new BudgetModel();

            BudgetViewModel views = new BudgetViewModel()
            {
                Budgets = model.GetAll(CurrentContext.Instance.Get(Session.SessionID).CurrentUserId)
            };

            return View(views);
        }
    }
}