namespace Task2
{
    public record Item
    {
        public string Name { get; init; }
        public double CoordinateX { get; init; }
        public double CoordinateY { get; init; }

        public override string ToString()
        {
            return $"Name = {Name}, X = {CoordinateX}, Y = {CoordinateY}";
        }
    }
}
