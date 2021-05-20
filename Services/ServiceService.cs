using PromotionCodeAPI.Domain;
using PromotionCodeAPI.Repositories;
using System.Collections.Generic;

namespace PromotionCodeAPI.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository )
        {
            _serviceRepository = serviceRepository;
        }

        public void AddServiceBonus(Bonus bonus)
        {
            _serviceRepository.AddServiceBonus(bonus);

            _serviceRepository.SaveChanges();
        }

        public IEnumerable<Service> GetAllServices()
        {
            return _serviceRepository.GetAllServices();
        }

        public IEnumerable<Bonus> GetServiceBonusById(int bonusId)
        {
            return _serviceRepository.GetServiceBonusById(bonusId);
        }

        public Service GetServiceById(int serviceId)
        {
            return _serviceRepository.GetServiceById(serviceId);
        }

        public IEnumerable<Service> GetServiceByName(string name)
        {
            return _serviceRepository.GetServiceByName(name);
        }
    }
}
