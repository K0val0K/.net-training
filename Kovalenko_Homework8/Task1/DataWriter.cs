using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Task1.Entities;

namespace Task1
{
    public class DataWriter
    {
        private readonly SqlConnection _dbConnection;

        public DataWriter(SqlConnection dbConnection)
        {
            if (dbConnection == null)
            {
                throw new ArgumentNullException(nameof(dbConnection));
            }

            _dbConnection = dbConnection;
        }

        public void Write(IEnumerable<DbEmployee> employees)
        {
            foreach(var employee in employees)
            {
                employee.Insert(_dbConnection);
                foreach (var vacation in employee.EmployeeVacations)
                {
                    vacation.Insert(_dbConnection);
                }
            }
        }

        
    }
}
