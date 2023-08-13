using MinimalAPI.Core.Domain;
using MinimalAPI.Core.DTO;

namespace MinimalAPI.Core.ServiceContracts
{
    public interface IProductGetterService
    {
        /// <summary>
        /// Getting a list of product responses from database
        /// </summary>
        /// <returns>list of products</returns>
        Task<List<ProductResponse>> GetAllProducts();

        /// <summary>
        /// Getting a specific prodcut by productID
        /// </summary>
        /// <param name="productID">productID to search</param>
        /// <returns>ProductResponse</returns>
        Task<ProductResponse?> GetProductById(Guid productID);
    }
}
