using OnionArch.Application.Interfaces.Repository;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }
    }
}
