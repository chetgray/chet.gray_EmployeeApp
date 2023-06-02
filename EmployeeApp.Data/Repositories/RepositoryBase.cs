using EmployeeApp.Data.DataAccess;

namespace EmployeeApp.Data.Repositories
{
    public class RepositoryBase
    {
        protected readonly IDAL _dal;

        protected RepositoryBase(IDAL dal)
        {
            _dal = dal ?? throw new System.ArgumentNullException(nameof(dal));
        }
    }
}
