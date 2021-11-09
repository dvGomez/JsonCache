namespace JsonCache.Models
{
    public class User
    {
        public User(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
