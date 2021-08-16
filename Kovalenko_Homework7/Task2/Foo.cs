namespace Task2
{

    class Foo
    {
        public int _id;
        public string Name { get; set; }
        public Foo()
        { }
        
        public override string ToString() => $"Id: {_id}, Name: {Name}";
    }
}
