using Task1Lib;

namespace Task1
{
    [TrackingEntity]
    public struct Person3
    {
        [TrackingProperty]
        private int _id;

        public string Name { get; set; }

        [TrackingProperty("age")]
        public int Age { get; set; }
        
       public Person3(int id)
        {
            _id = id;
            Name = null;
            Age = 0;
        }
    }
}
