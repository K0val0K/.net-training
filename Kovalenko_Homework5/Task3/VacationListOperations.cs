using System;
using System.Collections.Generic;
using System.Linq;


namespace Task3
{
    public static class VacationListOperations
    {
        public static double AverageVacationDuration(IEnumerable<Vacation> vacationList) //2
        {
            return vacationList.Select(rec => (rec.VacationEnd - rec.VacationStart))
                .Average(range => range.Days);
        }

        public static IEnumerable<(string, double)> AverageEmployeeVacationDuration(IEnumerable<Vacation> vacationList) //3
        {
            return vacationList.GroupBy(rec => rec.EmployeeName)
                .Select(group => (group.Key, AverageVacationDuration(group)));            
        }

        public static IEnumerable<(int, int)> MonthlyEmployeeVacationAmount(IEnumerable<Vacation> vacationList) //4
        {
            return Enumerable.Range(1, 12).
                Select(month => (month, vacationList.Select(rec => new Range(rec.VacationStart.Month, rec.VacationEnd.Month))
                                                            .Count(monthRange => monthRange.End.Value >= month && monthRange.Start.Value <= month)));
        }

        public static IEnumerable<DateTime> DaysWithoutVacation(IEnumerable<Vacation> vacationList) //5
        {
            return GetDateRange(new DateTime(2020, 1, 1), new DateTime(2020, 12, 31))
                .Where(date =>
                {
                    foreach (var vacation in vacationList)
                    {
                        if (date.CompareTo(vacation.VacationStart) >= 0 && date.CompareTo(vacation.VacationEnd) < 0)
                        {
                            return false;
                        }
                    }
                    return true;
                });
        }

        public static bool IsCorrectVacationData(IEnumerable<Vacation> vacationList) //6
        {
            var list = vacationList.OrderBy(rec => rec.VacationStart).GroupBy(rec => rec.EmployeeName);
            bool isAnyIncorrectSequence = false;
            foreach(var employee in list)
            {
                var endDate = DateTime.MinValue;
                foreach(var dateRange in employee)
                {
                    if (dateRange.VacationStart < endDate)
                    {
                        isAnyIncorrectSequence = true;
                        break;
                    }
                    endDate = dateRange.VacationEnd;
                    
                }
                if (isAnyIncorrectSequence) break;
            }
            return !isAnyIncorrectSequence;
        }


        private static IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("endDate must be greater than or equal to startDate");

            while (startDate <= endDate)
            {
                yield return startDate;
                startDate = startDate.AddDays(1);
            }
        }
    }
}
