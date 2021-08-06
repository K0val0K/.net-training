using System;

namespace Task3
{
    public class Vacation //: IEnumerable<DateTime>
    {
        public string Person { get; }
        public DateTime Start { get; }
        public DateTime End { get; }

        public Vacation(string person, DateTime start, DateTime end)
        {
            if (string.IsNullOrEmpty(person))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(person));
            }

            if (end < start)
            {
                throw new ArgumentException("'end' date must be greater or equals to 'start' date");
            }

            Person = person;
            Start = start.Date;
            End = end.Date;
        }

        public override string ToString() => $"{Person} {Start:d} - {End:d}";
    }
}
