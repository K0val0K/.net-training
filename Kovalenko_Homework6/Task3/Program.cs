using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;

namespace Task3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading data...");
            var vacationList = ReadFile(Path.GetFullPath("data.csv"));
            Console.WriteLine("Data read completed.");

            var filteredVacationList = GetSecondHalf2016Vacations(vacationList);

            Console.WriteLine("All 2016 second half vacations: ");
            var currentLine = 1;
            foreach (var it in filteredVacationList)
            {
                Console.WriteLine(it + $" record number[{currentLine}]");
                currentLine++;
            }

            Console.WriteLine("Writing data to json...");
            WriteVacationsToJSONFile("persons.json", filteredVacationList);
            //WriteVacationsToJSONFile("full-persons.json", vacationList);
            Console.WriteLine("Data writing completed");
        }

        static List<Vacation> ReadFile(string filePath)
        {
            var valuesCollection = new List<Vacation>(); ;

            using (var reader = new StreamReader(filePath))
            {
                string line = string.Empty;
                
                var currentLine = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    { 
                        var parts = line.Split(',');
                        if (parts.Length != 3) 
                        {
                            throw new Exception("Number of arguments in record is incorrect");
                        }

                        if(string.IsNullOrEmpty(parts[0])) 
                        {
                            throw new Exception($"Name of employee shouldn't be empty or null");
                        }

                        var reg = new Regex(@"^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$");

                        if (!reg.IsMatch(parts[1]))
                        {
                            throw new Exception($"Beginning of vacation date is incorrect (must be in mm/dd/yyyy format)");
                        } 
                        var startDate = parts[1].Split('/').Select(int.Parse).ToArray();

                        if (!reg.IsMatch(parts[1]))
                        {
                            throw new Exception($"End of vacation date is incorrect (must be in mm/dd/yyyy format)");
                        }
                        var endDate = parts[2].Split('/').Select(int.Parse).ToArray();

                        var vacation = new Vacation(
                            parts[0],
                            new DateTime(startDate[2], startDate[0], startDate[1]),
                            new DateTime(endDate[2], endDate[0], endDate[1])
                            );
                            valuesCollection.Add(vacation);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + $" Incorrect t record number [{currentLine}]");
                    }

                    currentLine++;
                }
            }
            return valuesCollection;
        }

        static List<Vacation> GetSecondHalf2016Vacations(List<Vacation> vacations)
        {
            var lowerVacationBound = new DateTime(2016, 6, 1);
            var uppervacationBound = new DateTime(2016, 12, 31);

            return vacations
                .Where(vacation => (vacation.Start >= lowerVacationBound && vacation.End <= uppervacationBound))
                .ToList();
        }

        static void WriteVacationsToJSONFile(string filename, List<Vacation> vacations)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var formatted = vacations.GroupBy(item => item.Person)
                .Select(group => new
                {
                    Name = group.Key,
                    vacations = group.Select(vacation => new
                    {
                        Start = vacation.Start,
                        End = vacation.End
                    }).ToArray()
                });

            var json = JsonSerializer.Serialize(formatted, options);
            File.WriteAllText(filename, json);
        }
    }
}
