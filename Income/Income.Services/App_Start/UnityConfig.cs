using Income.Repositories;
using Income.Services.Implementations;
using Microsoft.Practices.Unity;

namespace Income.Services.App_Start
{
    public static class UnityConfig
    {
        public static void Configure(IUnityContainer container)
        {
            Repositories.App_Start.UnityConfig.Configure(container);
            RegisterTypes(container);
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserServise, UserService>();
            container.RegisterType<IFinanceService, FinanceService>();
            container.RegisterType<ICurrencyService, CurrencyService>();
        }
    }
}
