using AutoMapper;
using MediatR;
using OnionArch.Application.DTO;
using OnionArch.Application.Interfaces.Repository;
using OnionArch.Application.Wrappers;
using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArch.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<ProductViewDto>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<ProductViewDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);
                await productRepository.UpdateAsync(product);
                var viewModel = mapper.Map<ProductViewDto>(product);
                return new ServiceResponse<ProductViewDto>(viewModel);
            }
        }
    }
}
