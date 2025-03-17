using StoreMarient.Dtos;
using StoreMarient.Services.Base;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;
using System.Linq.Expressions;

namespace StoreMarient.Services
{
    public interface ICoverStockService: IBaseService<CoverStock>
    {
        Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto);
    }
    public class CoverStockService : BaseService<CoverStock>, ICoverStockService
    {
        public CoverStockService(IUnitOfWork repositories, IHttpContextAccessor httpContext) : base(repositories, repositories.CoverStocks, httpContext)
        {

        }
        public async Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto) {
            foreach (var item in updateStockItemDto) {
                if (item.NewQuantity >= 0) {
                   var CoverStock = await _baseRepository.GetByIdAsync(item.Id);
                    if (CoverStock != null && CoverStock.Quantity != item.NewQuantity) { 
                        CoverStock.Quantity = item.NewQuantity;
                        _baseRepository.Update(CoverStock);
                    }
                }
            }
            await _baseRepository.SaveChangesAsync();
        }


    }
}
