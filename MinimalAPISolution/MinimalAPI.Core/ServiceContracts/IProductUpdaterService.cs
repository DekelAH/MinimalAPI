using MinimalAPI.Core.DTO;

namespace MinimalAPI.Core.ServiceContracts
{
    public interface IProductUpdaterService
    {
        #region Methods

        /// <summary>
        /// Receiving a product update request, if matched with existing product from db, 
        /// changes being made and sending it to db
        /// </summary>
        /// <param name="productToUpdate">Product to update</param>
        /// <returns>Updated product</returns>
        Task<ProductResponse> UpdateProduct(ProductUpdateRequest productToUpdate);

        #endregion
    }
}
