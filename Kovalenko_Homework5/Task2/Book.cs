using System;
using System.Collections.Generic;
using System.Text;


namespace Task2
{
    public class Book
    {
        public string Name { get; set; }
        public string Date { get; set; } = null;
        public SortedSet<string> Authors { get; set; } = new SortedSet<string>();

        public Book(string name, string date, IEnumerable<string> authors)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name of book must not be empty or null");
            Name = name;
            Date = date;
            if(authors != null)
            {
                foreach (var author in authors)
                {
                    Authors.Add(author);
                }
            }
        }

        public override string ToString()
        {
            var authors = new StringBuilder();
            foreach(var author in Authors)
            {
                authors.Append($"{author} ");
            }
            authors.Append('}');
            return $"{{Book: {Name}, date: {Date}, authors: {authors}";
        }

    }
}
