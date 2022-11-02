using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEST5.API.Repositories;

namespace TEST5.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductInterface productInterface;
        private readonly IMapper mapper;

        public ProductController(IProductInterface productInterface,IMapper mapper)
        {
            this.productInterface = productInterface;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products=await productInterface.GetAllProductsAsync();
            var productsDTO=mapper.Map<List<Models.DTO.Product>>(products);
            return Ok(productsDTO);
        }
    }
}
