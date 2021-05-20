using PromotionCodeAPI.Domain;
using System;

namespace PromotionCodeAPI.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string email);

        User GetUser(string username, string password);

        User GetUser(Guid userId);

        bool SaveChanges();
    }
}
