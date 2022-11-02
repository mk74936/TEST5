using AutoMapper;

namespace TEST5.API.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Domain.Product, Models.DTO.Product>()
                .ReverseMap();
        }   
    }
}
