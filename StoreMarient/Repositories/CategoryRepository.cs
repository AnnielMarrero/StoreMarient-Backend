using StoreMarient.Data;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;

namespace StoreMarient.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>{ 
    
    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext context) : base(context)
        {
        }
    }
}
