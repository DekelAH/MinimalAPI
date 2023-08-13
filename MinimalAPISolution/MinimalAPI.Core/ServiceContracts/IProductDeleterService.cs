namespace MinimalAPI.Core.ServiceContracts
{
    public interface IProductDeleterService
    {
        #region Methods

        /// <summary>
        /// Receiving an id to search a matching product to delete
        /// </summary>
        /// <param name="productID">id to search by</param>
        /// <returns>True if deleted, false if not</returns>
        Task<bool> DeleteProductByID(Guid productID);

        #endregion
    }
}
