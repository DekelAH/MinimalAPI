using MinimalAPI.Core.Domain.Entities;

namespace MinimalAPI.Core.Domain.RepositoryContracts
{
    public interface IProductGetterRepository
    {
        #region Methods

        /// <summary>
        /// Getting a list of products from database
        /// </summary>
        /// <returns>list of products</returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// Getting a specific prodcut by productID
        /// </summary>
        /// <param name="productID">productID to search</param>
        /// <returns>Matching product</returns>
        Task<Product?> GetProductById(Guid productID);

        #endregion
    }
}
