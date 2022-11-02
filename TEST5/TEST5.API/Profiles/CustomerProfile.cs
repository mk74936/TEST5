using AutoMapper;

namespace TEST5.API.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Models.Domain.Customer,Models.DTO.Customer>()
            .ReverseMap();
        }
    }
}
