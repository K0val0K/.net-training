using System;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var booksArr = new Book[]
           {
               new Book("book1", "12/12/2003", null),
               new Book("book2", null, new[]{"Kevin"}),
               new Book("book3", "", new[]{"Kevin, John"}),
               new Book("book4", "", new[]{"Kevin, John", "Vasya"}),
               new Book("book5", "13/05/2003", new[]{"Vasya"}),
           };
            var catalog = new Catalog();
            var correctKeys = new string[]
            {
                "123-4-56-789012-3",//1
                "1234567890124",//2
                "233-4-56-789012-3",
                "444-4-56-789012-3",
                "9999999999999",
            };
            var i = 0;
            foreach (var book in booksArr)
            {
                Console.WriteLine(book);
                catalog[correctKeys[i]] = book;
                i++;
            }
            foreach(var rec in catalog)
            {
                Console.WriteLine(rec);
            }
            Console.WriteLine(catalog.ContaisKey("1234567890123"));//1
            Console.WriteLine(catalog.ContaisKey("123-4-56-789012-4"));//2
            Book book1, book2;
            catalog.TryGetValue("9999999999999", out book1);
            catalog.TryGetValue("999-9-99-999999-9", out book2);

            Console.WriteLine(book1);
            Console.WriteLine(book2);
            Console.WriteLine(book1.Equals(book2));

            try
            {
                catalog.Add("999-9-99-99999-99", new Book("author", null,null));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }





        }
    }
}
