using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using com.tg.WMS.Core;
using com.tg.WMS.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
         private Container container;
        protected void Application_Start()
        {
             try
            {
                IConfigurationSource source = (IConfigurationSource)ConfigurationManager.GetSection("ActiveRecord");
                ActiveRecordStarter.Initialize(typeof(SysUser).Assembly, source);
                container = Container.Instance;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        }
    
}