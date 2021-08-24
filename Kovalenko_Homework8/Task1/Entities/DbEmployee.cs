using System;
using System.Collections.Generic;

namespace Task1.Entities
{
    public class DbEmployee
    {
        public Guid Id { get; set; }
        public string Email 
        {
            get => Name.ToLower() + Surname.ToLower() + "@isoft.by";
        } 
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<DbVacation> EmployeeVacations;

        public DbEmployee() => EmployeeVacations = new HashSet<DbVacation>();

        public override string ToString()
        {
            string res = string.Empty;
            res = $"Person Id: {Id}, Email: {Email}  Name: {Name}, Surname {Surname}\nVacations:\n";
            foreach(var vacation in EmployeeVacations)
            {
                res += vacation + "\n";
            }
            res += "\nNext\n";
            return res;
        }
    }
}
