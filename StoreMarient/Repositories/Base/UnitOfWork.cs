using StoreMarient.Data;


 namespace StoreMarient.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }

        public IPhoneRepository Phones { get; }
        public IMicaRepository Micas { get; }

        public ICoverStockRepository CoverStocks { get; }

        public UnitOfWork(StoreContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            Products = new ProductRepository(context);
            Phones = new PhoneRepository(context);
            Micas = new MicaRepository(context);
            CoverStocks = new CoverStockRepository(context);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
