using System.Collections.Generic;

namespace DataLibrary.DAL
{
    internal interface IEmployeeAppDAL
    {
        List<object[]> GetRecordsViaStoredProcedure(string storedProcedure, Dictionary<string, object> parameters);
    }
}
