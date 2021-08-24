using System;

namespace Task1
{
    public class Vacation
    {
        public string Person { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public Vacation(string person, DateTime start, DateTime end)
        {
            if (string.IsNullOrEmpty(person))
            {
                throw new ArgumentException("Cannot be null or empty.", nameof(person));
            }

            if (end < start)
            {
                throw new ArgumentException("The 'end' date must be greater than or equal to the 'start' date.");
            }

            Person = person;
            Start = start.Date;
            End = end.Date;
        }

        public static Vacation Parse(string s)
        {
            var words = s.Split(',');
            var startDate = ParseDate(words[1]);
            var endDate = ParseDate(words[2]);
            return new Vacation(words[0], startDate, endDate);

            static DateTime ParseDate(string s)
            {
                var parts = s.Split('/');
                return new DateTime(int.Parse(parts[2]), int.Parse(parts[0]), int.Parse(parts[1]));
            }
        }

        public bool InSegment(DateTime low, DateTime high)
        {
            return low <= Start && End <= high;
        }

        public override string ToString() => $"{Person} {Start:d} - {End:d}";
    }
}
