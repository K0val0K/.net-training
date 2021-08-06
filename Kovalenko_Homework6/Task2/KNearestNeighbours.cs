using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public static class KNearestNeighbours
    {
        public static string Calcualte(List<Item> neighbors, double unknownX, double unknownY, int k)
        {
            if(k > neighbors.Count)
            {
                throw new ArgumentException("k must be less then total amount of neighbours");
            }

            var unknown = new Item() { Name = null, CoordinateX = unknownX, CoordinateY = unknownY };

            var kNN = neighbors
                .AsParallel()
                .Select(item => new { Name = item.Name, Distance = CalulateEuclideanDistance(unknown, item) })
                .OrderBy(item => item.Distance)
                .Take(k);

            return kNN.GroupBy(item => item.Name)
                .OrderByDescending(name => name.Count())
                .First()
                .Key;
        }

        private static double CalulateEuclideanDistance(Item unknownItem, Item trainingItem)
        {
            return Math.Sqrt(Pow2(unknownItem.CoordinateX - trainingItem.CoordinateX)
                + Pow2(unknownItem.CoordinateY - trainingItem.CoordinateY));

            double Pow2(double number) => number * number;
        }
    }
}
