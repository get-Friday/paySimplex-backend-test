using paySimplex.Domain.DTOs;
using paySimplex.Domain.Models;
using paySimplex.Domain.Interfaces.Repositories;
using paySimplex.Domain.Interfaces.Services;

namespace paySimplex.Domain.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<UserDTO> GetAll()
        {
            IQueryable<User> query = _userRepository.GetAll();

            return query
                .Select(u => new UserDTO(u))
                .ToList();
        }

        public UserDTO GetById(int id)
        {
            User data = _userRepository.GetById(id);

            return new UserDTO(data);
        }

        public void Insert(UserDTO userDTO)
        {
            User data = new(userDTO);

            _userRepository.Insert(data);
        }

        public void Update(UserDTO userDTO, int id)
        {
            User user = _userRepository.GetById(id);

            user.Name = userDTO.Name;
            user.Email = userDTO.Email;

            _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            User data = _userRepository.GetById(id);

            _userRepository.Delete(data);
        }
    }
}
