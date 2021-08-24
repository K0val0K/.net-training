using Microsoft.Data.SqlClient;
using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=(local);Initial Catalog=CompanyInfo;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            Console.WriteLine("Migration Started...");
            connection.Open();
            var deleteEmployeeTableInfoCommand = new SqlCommand("DELETE Employee", connection);
            var deleteVacationTableInfoCommand = new SqlCommand("DELETE Vacation", connection);

            deleteEmployeeTableInfoCommand.ExecuteNonQuery();
            deleteVacationTableInfoCommand.ExecuteNonQuery();

            var dm = new DataMigration("data.csv", connection);
            dm.Migrate();

            connection.Close();

            Console.WriteLine("MigrationEnded...");

        }
    }
}
