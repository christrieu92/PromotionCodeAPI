using PromotionCodeAPI.DBContext;
using PromotionCodeAPI.Domain;
using PromotionCodeAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionCodeAPI.Data
{
    public class ServiceRepository : IServiceRepository, IDisposable
    {
        private readonly PromoCodeDbContext _context;

        public ServiceRepository(PromoCodeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Returns a list of services from Service table
        /// </summary>
        /// <returns>Returns a list of Services</returns>
        public IEnumerable<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        /// <summary>
        /// Retrieve all services from service table by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns a list of Service filtered by name</returns>
        public IEnumerable<Service> GetServiceByName(string name)
        {
            return _context.Services.Where(c => c.Name == name).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public Service GetServiceById(int serviceId)
        {
            return _context.Services.Where(s => s.ServiceId == serviceId).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bonus"></param>
        public void AddServiceBonus(Bonus bonus)
        {
            _context.Bonus.Add(bonus);
        }

        public IEnumerable<Bonus> GetServiceBonusById(int bonusId)
        {
            return _context.Bonus.Where(b => b.BonusId == bonusId);
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