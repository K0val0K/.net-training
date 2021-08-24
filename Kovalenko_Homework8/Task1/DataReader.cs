using System;
using System.Collections.Generic;
using System.IO;
using Task1.Entities;
using System.Linq;

namespace Task1
{
    public class DataReader
    {
        private readonly string _fullPath;

        public DataReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            _fullPath = Path.GetFullPath(fileName);

            if (!File.Exists(_fullPath))
            {
                throw new FileNotFoundException("File Not Found", _fullPath);
            }
        }

        public IEnumerable<DbEmployee> Read()
        {
            var list = new List<Vacation>();
            var lineNumber = 1;
            foreach (var line in File.ReadLines(_fullPath))
            {
                try
                {
                    list.Add(Vacation.Parse(line));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{lineNumber}: {e.Message}");
                }

                lineNumber++;
            }

            var result = list.GroupBy(v => v.Person)
                .Select(p => 
                {
                    var employee = new DbEmployee();
                    var splitName = p.Key.Split(" ");
                    var employeeId = Guid.NewGuid();

                    employee.Id = employeeId;
                    employee.Name = splitName[0];
                    employee.Surname = splitName[1];

                    foreach (var vacation in p)
                    {
                        employee.EmployeeVacations.Add(new DbVacation()
                        {
                            Id = Guid.NewGuid(),
                            StartDate = vacation.Start,
                            EndDate = vacation.End,
                            EmployeeId = employeeId
                        });
                    }

                    return employee;
                });

            return result;
        }
    }
}
