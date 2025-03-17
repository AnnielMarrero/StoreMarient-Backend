using StoreMarient.Dtos;
using StoreMarient.Services.Base;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;

namespace StoreMarient.Services
{
    public interface IProductService: IBaseService<Product>
    {
        Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto);
    }
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IUnitOfWork repositories, IHttpContextAccessor httpContext) : base(repositories, repositories.Products, httpContext)
        {

        }
        public async Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto) {
            foreach (var item in updateStockItemDto) {
                if (item.NewQuantity >= 0) {
                   var product = await _baseRepository.GetByIdAsync(item.Id);
                    if (product != null && product.Quantity != item.NewQuantity) { 
                        product.Quantity = item.NewQuantity;
                        _baseRepository.Update(product);
                    }
                }
            }
            await _baseRepository.SaveChangesAsync();
        }
    }
}
