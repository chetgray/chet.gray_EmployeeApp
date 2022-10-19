using System.Configuration;

using DataLibrary.DAL;

namespace DataLibrary.Repositories
{
    public class BaseRepository
    {
        internal readonly IEmployeeAppDAL _dal = new EmployeeAppDAL(
            ConfigurationManager.ConnectionStrings["EmployeeDatabase"].ConnectionString
        );
    }
}