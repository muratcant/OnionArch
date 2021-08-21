using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Commands.AddProduct;
using OnionArch.Application.Features.Commands.DeleteProduct;
using OnionArch.Application.Features.Commands.UpdateProduct;
using OnionArch.Application.Features.Queries.GetAllProducts;
using OnionArch.Application.Features.Queries.GetProductById;

namespace OnionArch.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var list = new GetAllProductsQuery();
            var result = await mediator.Send(list);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var data = new GetProductByIdQuery() { Id = Id };
            return Ok(await mediator.Send(data));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] AddProductCommand addProductCommand)
        {
            return Ok(await mediator.Send(addProductCommand));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            return Ok(await mediator.Send(updateProductCommand));
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteProductCommand() { Id = Id };
            return Ok(await mediator.Send(command));
        }
    }
}