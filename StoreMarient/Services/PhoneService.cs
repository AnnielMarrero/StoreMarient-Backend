using StoreMarient.Dtos;
using StoreMarient.Services.Base;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;

namespace StoreMarient.Services
{
    public interface IPhoneService: IBaseService<Phone>
    {
        Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto);
    }
    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        public PhoneService(IUnitOfWork repositories, IHttpContextAccessor httpContext) : base(repositories, repositories.Phones, httpContext)
        {

        }
        public async Task UpdateStock(List<UpdateStockItemDto> updateStockItemDto) {
            foreach (var item in updateStockItemDto) {
                if (item.NewQuantity >= 0) {
                   var phone = await _baseRepository.GetByIdAsync(item.Id);
                    if (phone != null && phone.Quantity != item.NewQuantity) { 
                        phone.Quantity = item.NewQuantity;
                        _baseRepository.Update(phone);
                    }
                }
            }
            await _baseRepository.SaveChangesAsync();
        }
    }
}
