using MediatR;
using OnionArch.Application.Interfaces.Repository;
using OnionArch.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArch.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ServiceResponse<bool>>
    {
        public Guid Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<bool>>
        {
            private readonly IProductRepository productRepository;

            public DeleteProductCommandHandler(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }
            public async Task<ServiceResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var data = await productRepository.DeleteAsync(request.Id);
                return new ServiceResponse<bool>(data);
            }
        }

    }
}
