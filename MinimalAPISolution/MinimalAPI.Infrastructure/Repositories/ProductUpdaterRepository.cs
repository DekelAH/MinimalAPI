using MinimalAPI.Core.Domain;
using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Infrastructure.DatabaseContext;

namespace MinimalAPI.Infrastructure.Repositories
{
    public class ProductUpdaterRepository : IProductUpdaterRepository
    {
        #region Fields

        private readonly ApplicationDbContext _db;

        #endregion

        #region Ctors

        public ProductUpdaterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        #endregion

        #region Methods

        public async Task<Product> UpdateProduct(Product productToUpdate)
        {
            var matchingProduct = await _db.Products.FindAsync(productToUpdate.ProductId);
            if (matchingProduct == null)
            {
                return productToUpdate;
            }

            matchingProduct.ProductId = productToUpdate.ProductId;
            matchingProduct.ProductName = productToUpdate.ProductName;
            matchingProduct.ProductQuantity = productToUpdate.ProductQuantity;
            matchingProduct.ProductPrice = productToUpdate.ProductPrice;

            await _db.SaveChangesAsync();

            return matchingProduct;
        }

        #endregion


    }
}
