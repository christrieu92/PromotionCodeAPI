using AutoMapper;
using PromotionCodeAPI.Domain;
using PromotionCodeAPI.Dtos;

namespace PromotionCodeAPI.Profiles
{
    public class ProfilesMapper : Profile
    {
        public ProfilesMapper()
        {
            // Soruce -> Target
            // Calendar Mapping
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();

            CreateMap<Service, ServiceDto>();

            CreateMap<ServiceDto, Service>();

            CreateMap<Bonus, BonusDto>();

            CreateMap<BonusDto, Bonus>();
        }
    }
}
