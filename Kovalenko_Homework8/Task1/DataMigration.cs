using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Task1
{
    public class DataMigration
    {
        private string _filePath;
        private SqlConnection _dbConnection;

        public DataMigration(string from, SqlConnection to)
        {
            _filePath = from;
            _dbConnection = to;
        }

        public void Migrate()
        {
            var data = new DataReader(_filePath).Read();
            var writer = new DataWriter(_dbConnection);
            writer.Write(data);
        }
    }
}
