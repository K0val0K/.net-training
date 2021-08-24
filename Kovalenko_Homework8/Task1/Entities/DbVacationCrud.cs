using System.Data;
using Microsoft.Data.SqlClient;

namespace Task1.Entities
{
    public static class DbVacationCrud
    {
        public static void Insert(this DbVacation vacation, SqlConnection connection)
        {
            var cmd = new SqlCommand("INSERT INTO Vacation VALUES(@Id, @EmployeeId, @StartDate, @EndDate)", connection);
            PopulateParameters(cmd, vacation);

            cmd.ExecuteNonQuery();
        }

        private static void PopulateParameters(SqlCommand cmd, DbVacation vacation)
        {
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@Id"].Value = vacation.Id;

            cmd.Parameters.Add("@EmployeeId", SqlDbType.UniqueIdentifier);
            cmd.Parameters["@EmployeeId"].Value = vacation.EmployeeId;

            cmd.Parameters.Add("@StartDate", SqlDbType.Date);
            cmd.Parameters["@StartDate"].Value = vacation.StartDate;

            cmd.Parameters.Add("@EndDate", SqlDbType.Date);
            cmd.Parameters["@EndDate"].Value = vacation.EndDate;
        }
    }
}
