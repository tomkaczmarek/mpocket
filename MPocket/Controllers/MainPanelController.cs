﻿using MPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPocket.Controllers
{
    public class MainPanelController : Controller
    {
        // GET: MainPanel
        public ActionResult MainPanel()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(ExpensesModel model)
        {
            model.Save();
            return View("MainPanel");
        }

    }
}