using EmployeeApp.Data.DataAccess;

using Unity;

namespace EmployeeApp.Data.Repositories
{
    public class RepositoryBase
    {
        [Dependency]
        public IDAL Dal { get; } = UnityBootstrapper.Resolve<IDAL>();
    }
}
