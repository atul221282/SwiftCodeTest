﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity;
using SwiftDemo.Core;
using System.Web.Optimization;

namespace SwiftDemo.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            // Tell WebApi to use our custom Ioc (Ninject)
            IocConfig.RegisterIoc(GlobalConfiguration.Configuration);
            // Web API template created these 3
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
#if DEBUG
            Database.SetInitializer(new SwiftDemoInitializer());
#endif
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);
        }
    }
}