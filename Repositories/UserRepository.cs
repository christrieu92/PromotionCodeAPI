using PromotionCodeAPI.DBContext;
using PromotionCodeAPI.Domain;
using System;
using System.Linq;

namespace PromotionCodeAPI.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly PromoCodeDbContext _context;

        public UserRepository(PromoCodeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Add users
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        /// <summary>
        /// Get users by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns a user object</returns>
        public User GetUser(Guid userId)
        {
            return _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }
        
        /// <summary>
        /// Get users by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User object</returns>
        public User GetUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }

        /// <summary>
        /// Get users by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User object</returns>
        public User GetUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }


            return _context.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}