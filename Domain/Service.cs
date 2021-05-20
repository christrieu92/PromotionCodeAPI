using System.ComponentModel.DataAnnotations;

namespace PromotionCodeAPI.Domain
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PromoCodes { get; set; }

    }
}
