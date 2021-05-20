using System;

namespace PromotionCodeAPI.Dtos
{
    public class BonusDto
    {
        public int BonusId { get; set; }

        public int ServiceId { get; set; }

        public Guid UserId { get; set; }
    }
}
