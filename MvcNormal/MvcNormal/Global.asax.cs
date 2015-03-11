using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace MvcNormal
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AddDisplayModes();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        private void AddDisplayModes()
        {
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("Mobile")
                {
                    ContextCondition = ctx => ctx.Request.UserAgent.Contains("iPad")
                });
            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("Silk")
                {
                    ContextCondition = c => c.Request.UserAgent.Contains("Silk/")
                });
        }
    }
}