using AutoMapper;

namespace TEST5.API.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Models.Domain.Order, Models.DTO.Order>()
                .ReverseMap();
        }
    }
}
