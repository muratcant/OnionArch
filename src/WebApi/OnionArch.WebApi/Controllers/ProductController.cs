using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Interfaces.Repository;

namespace OnionArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            //Entity'e ulaşamamalı. DTO üzerinden ulaşmalı.
            //Bu durumda Mapping oluşturulmalı.
            var allList = await productRepository.GetAllAsync();
            //CQRS yöntemi Mediatr patterni ile yapılacak.
            return Ok(allList);
        }

    }
}