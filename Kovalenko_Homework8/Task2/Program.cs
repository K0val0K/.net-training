using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Task2.Entities;

namespace Task2
{
    public class Program
    {
        static void Main(string[] args)
        {
            MoreThan30DaysVacationEmployees();
            TrainingCompletion();
        }

        public static void MoreThan30DaysVacationEmployees()
        {
            using var context = new CompanyInfoContext();

            var employeesId = context.Vacation
                .Where(x => EF.Functions.DateDiffDay(x.StartDate, x.EndDate) > 30)
                .Select(x => x.EmployeeId);

            var result = context.Employee
                .Where(x => employeesId.Contains(x.Id));

            Console.WriteLine("Employees with more than 30 days vacations: ");
            foreach(var employee in result)
            {
                Console.WriteLine(employee.Name + " " + employee.Surname);
            }

            Console.WriteLine();
        }

        public static void TrainingCompletion()
        {
            using var context = new CompanyInfoContext();

            var trainings = context.Training.ToList();

            Console.WriteLine("Training completion info: ");
            foreach (var training in trainings)
            {
                var employees = context.Employee
                    .Where(x => x.Vacations.Any(x => x.StartDate > training.EndDate || x.EndDate < training.StartDate))
                    .ToList();
                training.Employees = employees;

                Console.WriteLine($"Training: {training.TrainingName} StartDate: {training.StartDate.Date}" +
                    $"End Date {training.EndDate.Date};\nAmount of Employees {employees.Count}");
            }
            context.SaveChanges();
        }
    }
}
