using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Core.DTO;
using MinimalAPI.Core.ServiceContracts;

namespace MinimalAPI.Core.Services
{
    public class ProductGetterService : IProductGetterService
    {
        #region Fields

        private readonly IProductGetterRepository _productGetterRepository;

        #endregion

        #region Ctors

        public ProductGetterService(IProductGetterRepository productGetterRepository)
        {
            _productGetterRepository = productGetterRepository;
        }

        #endregion

        #region Methods

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var allProducts = await _productGetterRepository.GetAllProducts();
            var allProductsResponse = allProducts.ToProductResponseList();

            return allProductsResponse;
        }

        public async Task<ProductResponse?> GetProductById(Guid productID)
        {
            var matchingProduct = await _productGetterRepository.GetProductById(productID);
            if (matchingProduct == null)
            {
                return null;
            }

            return matchingProduct.ToProductResponse();
        }

        #endregion
    }
}
