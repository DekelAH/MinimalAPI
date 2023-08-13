using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Core.ServiceContracts;

namespace MinimalAPI.Core.Services
{
    public class ProductDeleterService : IProductDeleterService
    {
        #region Fields

        private readonly IProductDeleterRepository _productDeleterRepository;

        #endregion

        #region Ctors

        public ProductDeleterService(IProductDeleterRepository productDeleterRepository)
        {
            _productDeleterRepository = productDeleterRepository;
        }

        #endregion

        #region Methods

        public async Task<bool> DeleteProductByID(Guid productID)
        {
            var isDeleted = await _productDeleterRepository.DeleteProductByID(productID);
            return isDeleted;
        }

        #endregion
    }
}
