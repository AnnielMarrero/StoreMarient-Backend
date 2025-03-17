using StoreMarient.Dtos;
using StoreMarient.Services.Base;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;

namespace StoreMarient.Services
{
    public interface IMicaService: IBaseService<Mica>
    {
        Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto);
    }
    public class MicaService : BaseService<Mica>, IMicaService
    {
        public MicaService(IUnitOfWork repositories, IHttpContextAccessor httpContext) : base(repositories, repositories.Micas, httpContext)
        {

        }
        public async Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto) {
            foreach (var item in updateStockItemDto) {
                if (item.NewQuantity >= 0) {
                   var Mica = await _baseRepository.GetByIdAsync(item.Id);
                    if (Mica != null && Mica.Quantity != item.NewQuantity) { 
                        Mica.Quantity = item.NewQuantity;
                        _baseRepository.Update(Mica);
                    }
                }
            }
            await _baseRepository.SaveChangesAsync();
        }
    }
}
