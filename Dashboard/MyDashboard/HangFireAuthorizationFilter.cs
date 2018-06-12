using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace MyDashboard
{


    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            //can add some more logic here...
         //   return HttpContext.Current.User.Identity.IsAuthenticated;
           return true;
        }
    }

}