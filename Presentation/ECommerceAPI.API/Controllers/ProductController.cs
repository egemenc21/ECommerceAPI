using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet()]
        public async Task Get()
        {
            // await _productWriteRepository.AddRangeAsync(new()
            // {
            //     new()
            //     {
            //         Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDateTime = DateTime.UtcNow, Stock = 10
            //     },
            //     new()
            //     {
            //         Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDateTime = DateTime.UtcNow, Stock = 10
            //     },
            //     new()
            //     {
            //         Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDateTime = DateTime.UtcNow, Stock = 10
            //     },
            // });
            // await _productWriteRepository.SaveAsync();
            var p = await _productReadRepository.GetByIdAsync("ca3ea3b7-5cff-471e-9a4c-cb0e5e4f220c", false);
            p.Name = "Mehmet"; //changes will no longer effect the database because tracking is false.
            await _productWriteRepository.SaveAsync();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var p = await _productReadRepository.GetByIdAsync(id);
            return Ok(p);
        }
        
    }
}