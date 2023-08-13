﻿using MinimalAPI.Core.Domain;

namespace MinimalAPI.Core.DTO
{
    public class ProductUpdateRequest
    {
        #region Properties

        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }

        #endregion

        #region Methods

        public Product ToProduct()
        {
            return new Product
            {
                ProductId = ProductId,
                ProductName = ProductName,
                ProductQuantity = ProductQuantity,
                ProductPrice = ProductPrice
            };

        }

        #endregion
    }
}