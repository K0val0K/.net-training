using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Entities
{
    public class Vacation
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Start: {StartDate}, End {EndDate}, PersonId {EmployeeId}";
        }
    }
}
