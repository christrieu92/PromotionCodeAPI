using System;
using System.ComponentModel.DataAnnotations;

namespace PromotionCodeAPI.Domain
{
    public class Bonus
    {
        [Key]
        public int BonusId { get; set; }

        public int ServiceId { get; set; }

        public Guid UserId { get; set; }
    }
}
