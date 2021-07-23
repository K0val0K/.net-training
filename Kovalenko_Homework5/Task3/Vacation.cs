using System;

namespace Task3
{
    public class Vacation
    {
        public string EmployeeName { get; init; }
        public DateTime VacationStart { get; init; }
        public DateTime VacationEnd { get; init; }

        public Vacation(string employeeName, DateTime vacationStart, DateTime vacationEnd) 
        {
            if (string.IsNullOrEmpty(employeeName)) throw new ArgumentException(nameof(employeeName));
            if (vacationStart > vacationEnd) throw new ArgumentException("vacation cannot end before it starts :(");
            EmployeeName = employeeName;
            VacationStart = vacationStart;
            VacationEnd = vacationEnd;
        }
    }
}
