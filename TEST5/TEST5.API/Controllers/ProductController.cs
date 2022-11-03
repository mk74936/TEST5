﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEST5.API.Models.DTO;
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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetProductAsync")]
        public async Task<IActionResult> GetProductAsync(Guid id)
        {
            var product=await productInterface.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDTO = mapper.Map<Models.DTO.Product>(product);
            return Ok(productDTO);
        }

        [HttpPost]

        public async Task<IActionResult> AddProductAsync(AddProductRequest addProductRequest)
        {
            var product = new Models.Domain.Product()
            {
                Name = addProductRequest.Name,
                Price = addProductRequest.Price
            };
            product=await productInterface.AddProductAsync(product);
            var productDTO = new Models.DTO.Product
            {
                ID = product.ID,
                Name = product.Name,
                Price = product.Price
            };
            return CreatedAtAction(nameof(GetProductAsync), new { id = productDTO.ID }, productDTO);
        }
    }
}
