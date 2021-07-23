using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var vacationList = new List<Vacation>()
            {
                new Vacation("Viktor", new DateTime(2020,6,12), new DateTime(2020,6,16)),
                new Vacation("Andrey", new DateTime(2020,2,12), new DateTime(2020,2,21)),
                new Vacation("Viktor", new DateTime(2020,8,28), new DateTime(2020,9,9)),
                new Vacation("Vasily", new DateTime(2020,3,1), new DateTime(2020,7,13)),
            };

            Console.WriteLine(VacationListOperations.AverageVacationDuration(vacationList)); // 2
            foreach (var employee in VacationListOperations.AverageEmployeeVacationDuration(vacationList))
            {
                Console.WriteLine(employee);
            } //3
            foreach(var month in VacationListOperations.MonthlyEmployeeVacationAmount(vacationList))
            {
                Console.WriteLine(month);
            } //4

            foreach (var day in VacationListOperations.DaysWithoutVacation(vacationList))
            {
                Console.WriteLine(day);
            }; //5

            var incorrectVacationList = new List<Vacation>()
            {
                new Vacation("Viktor", new DateTime(2020,6,12), new DateTime(2020,6,21)),
                new Vacation("Viktor", new DateTime(2020,6,20), new DateTime(2020,6,23)),
                new Vacation("Viktor", new DateTime(2020,6,12), new DateTime(2020,6,16)),
            };
            Console.WriteLine(VacationListOperations.IsCorrectVacationData(incorrectVacationList));
            Console.WriteLine(VacationListOperations.IsCorrectVacationData(vacationList));

        }
    }
}
