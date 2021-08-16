namespace Task1
{
    public class NoAttributes
    {
        private int _id;

        public string Name { get; set; }
        public int Age { get; set; }

        public NoAttributes(int id)
        {
            _id = id;
        }
    }
}
