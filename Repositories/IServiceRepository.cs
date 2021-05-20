using PromotionCodeAPI.Domain;
using System.Collections.Generic;

namespace PromotionCodeAPI.Repositories
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAllServices();

        IEnumerable<Service> GetServiceByName(string name);

        Service GetServiceById(int serviceId);

        void AddServiceBonus(Bonus bonus);

        IEnumerable<Bonus> GetServiceBonusById(int bonusId);

        bool SaveChanges();
    }
}
