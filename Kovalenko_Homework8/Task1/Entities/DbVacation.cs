using System;

namespace Task1.Entities
{
    public class DbVacation
    {
        public Guid Id { get; set; }
        public DateTime StartDate {get; set;}
        public DateTime EndDate { get; set; }

        public Guid EmployeeId { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Start: {StartDate}, End {EndDate}, PersonId {EmployeeId}";
        }
    }
}
