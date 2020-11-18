using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mvc5Porject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var services = new ServiceCollection();
            ConfigureService(services);

            var resolver = new DotnetCoreDIDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        private void ConfigureService(ServiceCollection services)
        {
            var controllers = typeof(MvcApplication).Assembly.GetExportedTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => typeof(IController).IsAssignableFrom(x))
                .Where(x => x.Name.EndsWith("Controller"));
            foreach(var ctrl in controllers)
            {
                services.AddTransient(ctrl);
            }

            services.AddHttpClient();
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            var infos = myAssembly.DefinedTypes.Where(x => x.FullName.StartsWith("Mvc5Porject.Adapter"));
            //var infos2 = myAssembly.DefinedTypes.Where(x => x.FullName.StartsWith("LineClass.Models.BusinessDBAccess.Interface"));
            foreach (TypeInfo item in infos)
            {
                if (item.IsClass)
                {
                    var IsInterFace = infos.Where(x => x.Name == "I" + item.Name).FirstOrDefault();
                    if (IsInterFace != null)
                    {
                        services.AddScoped(IsInterFace, item);
                    }
                }

            }
        }
    }

    internal class DotnetCoreDIDependencyResolver : IDependencyResolver
    {
        private IServiceProvider serviceProvider;

        public DotnetCoreDIDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.serviceProvider.GetServices(serviceType);
        }
    }
}
