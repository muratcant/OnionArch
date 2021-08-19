using AutoMapper;
using MediatR;
using OnionArch.Application.Interfaces.Repository;
using OnionArch.Application.Wrappers;
using OnionArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArch.Application.Features.Commands.AddProduct
{
    public class AddProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public AddProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<Guid>> Handle(AddProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Product>(request);
                await productRepository.AddAsync(product); //tip dönüşümü oldu
                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
