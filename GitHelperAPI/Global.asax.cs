﻿using GitHelperDAL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GitHelperAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            string dataSourceName = ConfigurationManager.AppSettings["dataSourceName"];
            DbService.setDataSorce(dataSourceName, ConfigurationManager.ConnectionStrings[dataSourceName].ConnectionString);
           
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;
            context.Response.SuppressFormsAuthenticationRedirect = true;

            //if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            //{
            //    HttpContext.Current.Response.Flush();
            //}
        }
    }
}
