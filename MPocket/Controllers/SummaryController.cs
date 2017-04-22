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
            var expense = model.GetAll((int)Session[Session.SessionID + PageConstant.USER_ID_I_SESSION]);

            var viewModel = new SummaryModel()
            {
                Summary = expense
            };


            return View(viewModel);
        }
    }
}