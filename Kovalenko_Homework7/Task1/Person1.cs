using Task1Lib;

namespace Task1
{
    [TrackingEntity]
    public class Person1
    {
        [TrackingProperty]
        private int _id;

        [TrackingProperty]
        public string Name { get; set; }

        [TrackingProperty]
        public int Age { get; set; }

        public Person1(int id)
        {
            _id = id;
        }
    }
}
