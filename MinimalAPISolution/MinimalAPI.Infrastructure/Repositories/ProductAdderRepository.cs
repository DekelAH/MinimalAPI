using MinimalAPI.Core.Domain.Entities;
using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Infrastructure.DatabaseContext;

namespace MinimalAPI.Infrastructure.Repositories
{
    public class ProductAdderRepository : IProductAdderRepository
    {
        #region Fields

        private readonly ApplicationDbContext _db;

        #endregion

        #region Ctors

        public ProductAdderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Methods

        public async Task<Product> AddNewProduct(Product productToAdd)
        {
            await _db.AddAsync(productToAdd);
            await _db.SaveChangesAsync();
            return productToAdd;
        }

        #endregion
    }
}
