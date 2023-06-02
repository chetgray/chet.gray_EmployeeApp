using System.Collections.Generic;

namespace EmployeeApp.Data.DataAccess
{
    public interface IDAL
    {
        IList<object[]> GetRecordListFromStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        );
    }
}
