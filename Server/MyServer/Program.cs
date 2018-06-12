using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace MyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = IocLoad();
            InitializeHangFire(container);
        }


        private static IUnityContainer IocLoad()
        {
            var container = new UnityContainer();

            var configSection = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            return UnityConfigurationSection.CurrentSection.Configure(container);

        }


        private static void InitializeHangFire(IUnityContainer container)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("server=.; Database=Hangfire; Integrated Security=SSPI;");
            GlobalConfiguration.Configuration.UseActivator(new UnityJobActivator(container));
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 5 });

            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Server Started");
                Console.WriteLine("Press Any  key to exit");
                Console.ReadLine();

            }
        }
    }
}
