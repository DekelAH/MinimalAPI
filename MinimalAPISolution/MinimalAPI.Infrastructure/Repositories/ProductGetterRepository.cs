using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Domain.Entities;
using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Infrastructure.DatabaseContext;

namespace MinimalAPI.Infrastructure.Repositories
{
    public class ProductGetterRepository : IProductGetterRepository
    {
        #region Fields

        private readonly ApplicationDbContext _db;

        #endregion

        #region Ctors

        public ProductGetterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Methods

        public async Task<List<Product>> GetAllProducts()
        {
            var allProducts = await _db.Products.ToListAsync();
            return allProducts;
        }

        public async Task<Product?> GetProductById(Guid productID)
        {
            var matchingProduct = await _db.Products.FindAsync(productID);
            if (matchingProduct == null)
            {
                return null;
            }

            return matchingProduct;
        }

        #endregion
    }
}
