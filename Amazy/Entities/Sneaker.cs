namespace Amazy.Entities
{
    public class Sneaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Level { get; set; }
        public int Wear { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
