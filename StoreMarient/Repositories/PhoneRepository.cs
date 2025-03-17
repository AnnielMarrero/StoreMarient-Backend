using StoreMarient.Data;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;

namespace StoreMarient.Repositories
{
    public interface IPhoneRepository: IBaseRepository<Phone>
    {

    }
    public class PhoneRepository: BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(StoreContext context) : base(context)
        {
        }
    }
}
