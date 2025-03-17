namespace StoreMarient.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {

        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IPhoneRepository Phones { get; }
        public IMicaRepository Micas { get; }

        public ICoverStockRepository CoverStocks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
