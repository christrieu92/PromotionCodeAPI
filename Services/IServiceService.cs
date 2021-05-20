using PromotionCodeAPI.Domain;
using System.Collections.Generic;

namespace PromotionCodeAPI.Services
{
    public interface IServiceService
    {
        IEnumerable<Service> GetAllServices();

        IEnumerable<Service> GetServiceByName(string name);

        Service GetServiceById(int serviceId);

        void AddServiceBonus(Bonus bonus);

        IEnumerable<Bonus> GetServiceBonusById(int bonusId);
    }
}
