using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DAL
{
    internal class EmployeeAppDAL : IEmployeeAppDAL
    {
        private string _connectionString;

        public EmployeeAppDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<object[]> GetRecordsViaStoredProcedure(
            string storedProcedure,
            Dictionary<string, object> parameters
        )
        {
            List<object[]> records = new List<object[]>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            object[] record = new object[reader.FieldCount];
                            reader.GetValues(record);
                            records.Add(record);
                        }
                    }
                }
            }

            return records;
        }
    }
}
