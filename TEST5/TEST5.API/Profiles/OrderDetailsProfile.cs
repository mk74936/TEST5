using AutoMapper;

namespace TEST5.API.Profiles
{
    public class OrderDetailsProfile:Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<Models.Domain.OrderDetails, Models.DTO.OrderDetails>().ReverseMap();
        }
    }
}
