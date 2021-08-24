using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Email
        {
            //get => Name.ToLower() + Surname.ToLower() + "@isoft.by";
            get; 
            set;
        }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Vacation> Vacations;
        public ICollection<Training> Trainings;


        public Employee()
        {
            Vacations = new HashSet<Vacation>();
            Trainings = new HashSet<Training>();
        }
    }
}
