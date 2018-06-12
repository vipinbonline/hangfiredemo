using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using Microsoft.Owin;
using MyDashboard;
using Owin;
[assembly: OwinStartup(typeof(Startup))]
namespace MyDashboard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("server=.; Database=Hangfire; Integrated Security=SSPI;");
        //    app.UseHangfireDashboard();

          
			app.UseHangfireDashboard("/hangfire", new DashboardOptions() 
			  {
				  Authorization = new [] {new HangFireAuthorizationFilter()}
			  });
			
			
        }
    }
}