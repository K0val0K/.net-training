using System.Data;
using Microsoft.Data.SqlClient;

namespace Task1.Entities
{
    public static class DbEmployeeCrud
    {
        public static void Insert(this DbEmployee employee, SqlConnection connection)
        {
            var cmd = new SqlCommand("INSERT INTO Employee VALUES(@Id, @Email, @Name, @Surname)", connection);
            PopulateParameters(cmd, employee);
            
            cmd.ExecuteNonQuery();
        }

        private static void PopulateParameters(SqlCommand cmd, DbEmployee employee)
        {
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@Id"].Value = employee.Id;

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 128);
            cmd.Parameters["@Email"].Value = employee.Email;

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 128);
            cmd.Parameters["@Name"].Value = employee.Name;

            cmd.Parameters.Add("@Surname", SqlDbType.NVarChar, 128);
            cmd.Parameters["@Surname"].Value = employee.Surname;
        }
    }
}
