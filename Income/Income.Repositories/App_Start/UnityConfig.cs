using Microsoft.Practices.Unity;

namespace Income.Repositories.App_Start
{
    public static class UnityConfig
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}
