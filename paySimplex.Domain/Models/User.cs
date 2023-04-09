using paySimplex.Domain.DTOs;

namespace paySimplex.Domain.Models
{
    public class User
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User()
        {
        }

        public User(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Name = userDTO.Name;
            Email = userDTO.Email;
        }
    }
}
