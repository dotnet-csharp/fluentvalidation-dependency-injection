using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace Tut.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();
        }
    }
}