using MPocket.Models;
using MPocketCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class MainPanelController : BaseController
    {
        // GET: MainPanel
        public ActionResult MainPanel()
        {
            return View();
        }
    }
}