using MPocket.Models;
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
        public ActionResult Index(BudgetModel model)
        {
            return View(model);
        }
    }
}