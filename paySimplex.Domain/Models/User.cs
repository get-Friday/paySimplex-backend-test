namespace paySimplex.Domain.Models
{
    internal class User
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User()
        {
        }
    }
}
