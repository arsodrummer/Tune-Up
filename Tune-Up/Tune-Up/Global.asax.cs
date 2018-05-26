using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tune_Up.App_Start;
using Tune_Up.Models.DbModels;

namespace Tune_Up
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // Init database with some data
            if (!Database.Exists("name=DataDB"))
            {
                Database.SetInitializer(new DataDBInitialiser());
            }

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
