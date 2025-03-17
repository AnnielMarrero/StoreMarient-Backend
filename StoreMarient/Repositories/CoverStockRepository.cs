using Microsoft.EntityFrameworkCore;
using StoreMarient.Data;
using StoreMarient.Entities;
using StoreMarient.Repositories.Base;
using System.Linq.Expressions;

namespace StoreMarient.Repositories
{
    public interface ICoverStockRepository: IBaseRepository<CoverStock>
    {

    }
    public class CoverStockRepository : BaseRepository<CoverStock>, ICoverStockRepository
    {
        public CoverStockRepository(StoreContext context) : base(context)
        {
        }

        public override async Task<List<CoverStock>> GetAllAsync(params Expression<Func<CoverStock, object>>[] includeProperties) {
            var coverStocks = await _context.CoverStocks
                .Include(_ => _.Cover)
                    .ThenInclude(_ => _.PhoneType)
                .Include(_ => _.CoverType)
                .OrderBy(_ => _.Id)
                .ToListAsync();
            return coverStocks;
        }
    }
}
