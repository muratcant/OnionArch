using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Queries.GetAllProducts;
using OnionArch.Application.Interfaces.Repository;

namespace OnionArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var list = new GetAllProductsQuery();
            var result = await mediator.Send(list);
            return Ok(result);
        }

    }
}