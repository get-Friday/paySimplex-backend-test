using paySimplex.Domain.DTOs;

namespace paySimplex.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserDTO> GetAll();
        UserDTO GetById(int id);
        void Insert(UserDTO userDTO);
        void Update(UserDTO userDTO, int id);
        void Delete(int id);
    }
}
