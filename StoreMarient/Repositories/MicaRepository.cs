using StoreMarient.Data;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;

namespace StoreMarient.Repositories
{
    public interface IMicaRepository: IBaseRepository<Mica>
    {

    }
    public class MicaRepository: BaseRepository<Mica>, IMicaRepository
    {
        public MicaRepository(StoreContext context) : base(context)
        {
        }
    }
}
