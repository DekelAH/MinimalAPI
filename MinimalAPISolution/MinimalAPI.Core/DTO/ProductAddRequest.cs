using MinimalAPI.Core.Domain;

namespace MinimalAPI.Core.DTO
{
    public class ProductAddRequest
    {
        #region Properties

        public string? ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        #endregion

        #region Methods

        public Product ToProduct()
        {
            return new Product
            {
                ProductName = ProductName,
                ProductQuantity = ProductQuantity,
                ProductPrice = ProductPrice
            };
        }

        #endregion
    }
}
