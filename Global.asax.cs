using AzureChatApp.Repository;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace AzureChatApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly List<string> _sessions = new List<string>();
        private static readonly object padlock = new object();

        public static List<string> Sessions
        {
            get
            {
                return _sessions;
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            lock (padlock)
            {
                _sessions.Add(Session.SessionID);
            }
        }
        protected void Session_End(object sender, EventArgs e)
        {
            lock (padlock)
            {
                _sessions.Remove(Session.SessionID);
            }
        }
    }
}
