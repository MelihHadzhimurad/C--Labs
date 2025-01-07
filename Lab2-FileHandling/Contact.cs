namespace Lab2_FileHandling
{
    public class Contact
    {
        public string Id { get; }
        public string Name { get; }
        public string Number { get; }

        public Contact(string id, string name, string number)
        {
            Id = id;
            Name = name;
            Number = number;
        }

        public string ShowDetails()
        {
            return $"{Id} -- {Name} -- {Number}";
        }
    }
}
