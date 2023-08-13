using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Infrastructure.DatabaseContext;

namespace MinimalAPI.Infrastructure.Repositories
{
    public class ProductDeleterRepository : IProductDeleterRepository
    {
        #region Fields

        private readonly ApplicationDbContext _db;

        #endregion

        #region Ctors

        public ProductDeleterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Methods

        public async Task<bool> DeleteProductByID(Guid productID)
        {
            var matchingProduct = await _db.Products.FindAsync(productID);
            if (matchingProduct == null)
            {
                return false;
            }

            _db.Products.Remove(matchingProduct);
            await _db.SaveChangesAsync();

            return true;
        }

        #endregion
    }
}
