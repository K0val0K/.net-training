using Task1Lib;

namespace Task1
{
    [TrackingEntity]
    public class Person2
    {
        [TrackingProperty("ID")]
        private int _id;

        [TrackingProperty("Full name")]
        public string Name { get; set; }

        public int Age { get; set; }

        public Person2(int id)
        {
            _id = id;
        }
    }
}
