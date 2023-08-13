namespace MinimalAPI.Core.Domain.RepositoryContracts
{
    public interface IProductUpdaterRepository
    {
        #region Methods

        /// <summary>
        /// Receiving a product to update, if matched with existing product from db, 
        /// changes being made and sending it to db
        /// </summary>
        /// <param name="productToUpdate">Product to update</param>
        /// <returns>Updated product</returns>
        Task<Product> UpdateProduct(Product productToUpdate);

        #endregion
    }
}
