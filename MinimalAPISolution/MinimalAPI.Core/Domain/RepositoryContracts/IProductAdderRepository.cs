namespace MinimalAPI.Core.Domain.RepositoryContracts
{
    public interface IProductAdderRepository
    {
        #region Methods

        /// <summary>
        /// Receiving a new product and adding him to the dabase
        /// </summary>
        /// <param name="productToAdd">New product to add</param>
        /// <returns>The added product</returns>
        Task<Product> AddNewProduct(Product productToAdd);

        #endregion
    }
}
