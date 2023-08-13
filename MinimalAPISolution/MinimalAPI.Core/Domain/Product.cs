using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Core.Domain
{
    public class Product
    {
        #region Properties

        [Key]
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Product ID: {ProductId}\nProduct Name: {ProductName}\nProduct Quantity: {ProductQuantity}" +
                $"\nProduct Price: {ProductPrice}";
        }

        #endregion
    }
}
