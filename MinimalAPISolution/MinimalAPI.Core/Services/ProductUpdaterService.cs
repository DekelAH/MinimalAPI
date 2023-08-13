using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Core.DTO;
using MinimalAPI.Core.ServiceContracts;

namespace MinimalAPI.Core.Services
{
    public class ProductUpdaterService : IProductUpdaterService
    {
        #region Fields

        private readonly IProductUpdaterRepository _productUpdaterRepository;

        #endregion

        #region Ctors

        public ProductUpdaterService(IProductUpdaterRepository productUpdaterRepository)
        {
            _productUpdaterRepository = productUpdaterRepository;
        }

        #endregion

        #region Methods

        public async Task<ProductResponse> UpdateProduct(ProductUpdateRequest productToUpdate)
        {
            var product = productToUpdate.ToProduct();
            var updatedProduct = await _productUpdaterRepository.UpdateProduct(product);
            var productResponse = updatedProduct.ToProductResponse();

            return productResponse;
        }

        #endregion

    }
}
