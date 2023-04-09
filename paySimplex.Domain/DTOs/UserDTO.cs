using paySimplex.Domain.Models;

namespace paySimplex.Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserDTO()
        {
        }
        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }
    }
}
