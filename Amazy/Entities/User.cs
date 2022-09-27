namespace Amazy.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string JWT { get; set; }
        public int AMTLimit { get; set; }
    }
}