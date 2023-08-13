using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Core.DTO;
using MinimalAPI.Core.ServiceContracts;

namespace MinimalAPI.Core.Services
{
    public class ProductAdderService : IProductAdderService
    {
        #region Fields

        private readonly IProductAdderRepository _productAdderRepository;

        #endregion

        #region Ctors

        public ProductAdderService(IProductAdderRepository productAdderRepository)
        {
            _productAdderRepository = productAdderRepository;
        }

        #endregion

        #region Methods

        public async Task<ProductResponse> AddNewProduct(ProductAddRequest productToAddRequest)
        {
            var product = productToAddRequest.ToProduct();
            product.ProductId = Guid.NewGuid();
            var addedProduct = await _productAdderRepository.AddNewProduct(product);
            var productResponse = addedProduct.ToProductResponse();

            return productResponse;
        }

        #endregion
    }
}
