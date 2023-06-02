using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeApp.Data.DataAccess
{
    public class DAL : IDAL
    {
        private readonly string _connectionString;
        public Func<string, SqlConnection> ConnectionFactory { get; set; }
        public Func<string, SqlConnection, SqlCommand> CommandFactory { get; set; }
        public Func<int, object[]> RecordFactory { get; set; }
        public Func<IList<object[]>> RecordListFactory { get; set; }

        public DAL(
            string connectionString,
            Func<string, SqlConnection> connectionFactory,
            Func<string, SqlConnection, SqlCommand> commandFactory,
            Func<int, object[]> recordFactory,
            Func<IList<object[]>> recordListFactory
        )
        {
            _connectionString =
                connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            ConnectionFactory = connectionFactory;
            CommandFactory = commandFactory;
            RecordFactory = recordFactory;
            RecordListFactory = recordListFactory;
        }

        public IList<object[]> GetRecordListFromStoredProcedure(
            string storedProcedureName,
            IDictionary<string, object> parameters
        )
        {
            IList<object[]> records = RecordListFactory();

            using (SqlConnection connection = ConnectionFactory(_connectionString))
            {
                connection.Open();
                SqlCommand command = CommandFactory(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
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
                            object[] record = RecordFactory(reader.FieldCount);
                            reader.GetValues(record);
                            for (int i = 0; i < record.Length; i++)
                            {
                                if (record[i] == DBNull.Value)
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
