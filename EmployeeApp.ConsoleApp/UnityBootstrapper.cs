using System;

using Unity;
using Unity.Resolution;

namespace EmployeeApp
{
    public static class UnityBootstrapper
    {
        private static readonly Lazy<IUnityContainer> _container =
            new Lazy<IUnityContainer>(() =>
            {
                IUnityContainer container =
                    Business.UnityBootstrapper.Container.CreateChildContainer();
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

        private static void RegisterTypes(IUnityContainer container) { }
    }
}
