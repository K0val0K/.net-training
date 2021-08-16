namespace Task2
{
    public class Boo
    {
        private string _secretName;
        private double _justDouble;

        public int Id { get; set; }
        public string Name {get; set;}

        public Boo() { }

        public Boo(string name, int id, string secret, double num)
        {
            Name = name;
            Id = id;
            _secretName = secret;
            _justDouble = num;
        }

        public override string ToString() => $"Id: {Id}, Name: {Name}," +
            $" SecretName: {_secretName}, double: {_justDouble}";

    }
}
