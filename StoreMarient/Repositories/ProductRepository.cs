using StoreMarient.Data;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;

namespace StoreMarient.Repositories
{
    public interface IProductRepository: IBaseRepository<Product>
    {

    }
    public class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext context) : base(context)
        {
        }
    }
}
