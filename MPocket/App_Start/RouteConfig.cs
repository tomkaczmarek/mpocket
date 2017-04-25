using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EntityDatabase.Models;
using MPocket.Models;

namespace MPocket
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UserLogin", action = "UserLoginView", id = UrlParameter.Optional }
            );

            Mapper.Initialize(cfg => cfg.CreateMap<ExpensesModel, Expenses>());
            Mapper.Initialize(cfg => cfg.CreateMap<UserModel, User>());
            Mapper.Initialize(cfg => cfg.CreateMap<BudgetModel, Budget>());
            Mapper.Initialize(cfg => cfg.CreateMap<SettingsModel, Settings>());
        }

    }
}
