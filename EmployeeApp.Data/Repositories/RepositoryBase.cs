using System.Configuration;

using EmployeeApp.Data.DataAccess;

namespace EmployeeApp.Data.Repositories
{
    public class RepositoryBase
    {
        internal readonly IDAL _dal = new DAL(
            ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString
        );
    }
}
