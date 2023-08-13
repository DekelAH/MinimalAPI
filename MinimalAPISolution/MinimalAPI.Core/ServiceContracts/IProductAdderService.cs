using MinimalAPI.Core.DTO;

namespace MinimalAPI.Core.ServiceContracts
{
    public interface IProductAdderService
    {
        #region Methods

        /// <summary>
        /// Receiving a new product add request and adding him to the dabase
        /// </summary>
        /// <param name="productToAddRequest">New product to add</param>
        /// <returns>The added productResponse</returns>
        Task<ProductResponse> AddNewProduct(ProductAddRequest productToAddRequest);

        #endregion
    }
}
