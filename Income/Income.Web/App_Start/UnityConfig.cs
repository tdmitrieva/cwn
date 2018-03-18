using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using System.Web.Http;

namespace Income.Web
{
    public static class UnityConfig
    {
        public static void Configure()
        {
            IUnityContainer container = new UnityContainer();
            Services.App_Start.UnityConfig.Configure(container);

            UnityDependencyResolver resolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}