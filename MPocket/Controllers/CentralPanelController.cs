using MPocket.Models;
using MPocketCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class CentralPanelController : Controller
    {
        // GET: CentralPanel
        public ActionResult CentralView()
        {
            return View();
        }

        public ActionResult Save(ExpensesModel model)
        {
            model.Save((int)Session[Session.SessionID + PageConstant.USER_ID_I_SESSION]);
            return View("MainPanel");
        }

    }
}