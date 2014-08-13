﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Rastreabilidade.Infrastructure;

namespace Rastreabilidade {

    public class MvcApplication : System.Web.HttpApplication {
        
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Static/{*filename}");

            routes.MapRoute(
                null, // Route name
                "{controller}/{id}/{action}/", // URL with parameters
                new { controller = "Home", action = "Get", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}