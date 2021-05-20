using PromotionCodeAPI.Domain;
using PromotionCodeAPI.Repositories;
using System;

namespace PromotionCodeAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);

            _userRepository.SaveChanges();
        }

        public User GetUser(string email)
        {
            return _userRepository.GetUser(email);
        }

        public User GetUser(string username, string password)
        {
            var user = _userRepository.GetUser(username, password);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public User GetUser(Guid userId)
        {
            return _userRepository.GetUser(userId);
        }
    }
}
