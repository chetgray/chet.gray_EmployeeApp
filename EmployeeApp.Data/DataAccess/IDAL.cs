using System.Collections.Generic;

namespace EmployeeApp.Data.DataAccess
{
    internal interface IDAL
    {
        List<object[]> GetRecordListFromStoredProcedure(
            string storedProcedureName,
            Dictionary<string, object> parameters
        );
    }
}
