using PromotionCodeAPI.Domain;
using System;

namespace PromotionCodeAPI.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(string email);

        User GetUser(string username, string password);

        User GetUser(Guid userId);
    }
}
