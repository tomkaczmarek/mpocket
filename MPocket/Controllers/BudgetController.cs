﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPocket.Models;

namespace MPocket.Controllers
{
    public class BudgetController : Controller
    {
        // GET: Budget
        public ActionResult Index(BudgetModel model)
        {
            return View(model);
        }
    }
}