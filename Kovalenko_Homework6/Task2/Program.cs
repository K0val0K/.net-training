using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var unknownList = new (double,double)[]
            {                //for k = 5
                (1, 1),      //orange
                (2, 2),      //orange
                (3, 3),      //orange
                (3.5, 3.5),  //orange
                (4, 4),      //orange
                (4.5, 4.5),  //orange
                (4.8, 5.9),  //grapefruit
                (5, 5),      //orange
                (6, 6),      //grapefruit
                (7, 7),      //grapefruit
                (8, 8),      //grapefruit
                (9, 9),      //grapefruit

            };

            var data = File.ReadAllLines(Path.GetFullPath("data.txt"));
            var itemList = new List<Item>();
            foreach(var line in data)
            {
                var itemParams = line.Split(',');
                var name = itemParams[0];
                var coordinateX = double.Parse(itemParams[1], CultureInfo.InvariantCulture);
                var coordinateY = double.Parse(itemParams[2], CultureInfo.InvariantCulture);
                itemList.Add(new Item { Name = name, CoordinateX = coordinateX, CoordinateY = coordinateY });
            }

            Console.WriteLine("Training Data: ");
            foreach(var it in itemList)
            {
                Console.WriteLine(it);
            }

            Console.WriteLine("\nRecognized Data: ");
            foreach(var unknown in unknownList)
            {
                Console.WriteLine(KNearestNeighbours.Calcualte(itemList, unknown.Item1, unknown.Item2, 5));
            }
        }
    }
}
