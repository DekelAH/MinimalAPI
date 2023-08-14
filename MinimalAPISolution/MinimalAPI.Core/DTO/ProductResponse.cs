using MinimalAPI.Core.Domain.Entities;

namespace MinimalAPI.Core.DTO
{
    public class ProductResponse
    {
        #region Properties

        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        #endregion
    }

    public static class ProductExtensionMethods
    {
        public static ProductResponse ToProductResponse
            (this Product product)
        {
            return new ProductResponse
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductQuantity = product.ProductQuantity,
                ProductPrice = product.ProductPrice,
            };
        }

        public static List<ProductResponse> ToProductResponseList(this List<Product> products)
        {
            var productsResponse = new List<ProductResponse>();
            foreach (var product in products)
            {
                productsResponse.Add(product.ToProductResponse());
            }
            return productsResponse;
        }
    }
}
