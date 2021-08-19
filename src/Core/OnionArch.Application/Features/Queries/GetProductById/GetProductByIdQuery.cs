using AutoMapper;
using MediatR;
using OnionArch.Application.DTO;
using OnionArch.Application.Interfaces.Repository;
using OnionArch.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArch.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<ProductViewDto>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<ProductViewDto>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) //viewmodel oluştur.
            {
                var data = await productRepository.GetByIdAsync(request.Id);
                var viewModel = mapper.Map<ProductViewDto>(data);
                return new ServiceResponse<ProductViewDto>(viewModel);
            }
        }
    }
}
