using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Core.Domain.Entities
{
    public class Product
    {
        #region Properties

        [Key]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Product Name Cannot be blank")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimun characters of Product Name are 3")]
        public string? ProductName { get; set; }

        [Range(1, 1000, ErrorMessage = "Minimum number of Product Quantity cannot be 0, less than 0 or higher than 1000")]
        public int ProductQuantity { get; set; }

        [Range(1, 100000, ErrorMessage = "Minimum number of Product Price cannot be 0, less than 0 or higher than 100,000")]
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
