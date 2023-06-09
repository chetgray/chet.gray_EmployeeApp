using System;
using System.Configuration;

using EmployeeApp.Data.DataAccess;
using EmployeeApp.Data.DTOs;
using EmployeeApp.Data.Repositories;

using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace EmployeeApp.Data
{
    public static class UnityBootstrapper
    {
        private static readonly Lazy<IUnityContainer> _container =
            new Lazy<IUnityContainer>(() =>
            {
                IUnityContainer container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });

        public static IUnityContainer Container
        {
            get => _container.Value;
        }

        public static T Resolve<T>(params ResolverOverride[] overrides)
        {
            return Container.Resolve<T>(overrides);
        }

        public static T Resolve<T>(string name, params ResolverOverride[] overrides)
        {
            return Container.Resolve<T>(name, overrides);
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[
                "EmployeeDatabase"
            ].ConnectionString;

            container.RegisterType<IAddressDTO, AddressDTO>();
            container.RegisterType<IEmployeeDTO, EmployeeDTO>();
            container.RegisterSingleton<IDAL, DAL>(new InjectionConstructor(connectionString));
            container.RegisterSingleton<IAddressRepository, AddressRepository>();
            container.RegisterSingleton<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
