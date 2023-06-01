using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeApp.Data.DataAccess
{
    internal class DAL : IDAL
    {
        private readonly string _connectionString;

        public DAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<object[]> GetRecordListFromStoredProcedure(
            string storedProcedureName,
            Dictionary<string, object> parameters
        )
        {
            List<object[]> records = new List<object[]>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (KeyValuePair<string, object> parameter in parameters)
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
                            for (int i = 0; i < record.Length; i++)
                            {
                                if (record[i] == System.DBNull.Value)
                                {
                                    record[i] = null;
                                }
                            }

                            records.Add(record);
                        }
                    }
                }
            }

            return records;
        }
    }
}
