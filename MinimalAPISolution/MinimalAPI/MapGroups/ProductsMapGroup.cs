using MinimalAPI.Core.DTO;
using MinimalAPI.Core.ServiceContracts;

namespace MinimalAPI.MapGroups
{
    public static class ProductsMapGroup
    {
        public static RouteGroupBuilder ProductsAPI(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("/", async (HttpContext httpContext, IProductGetterService getterService) =>
            {
                var allProducts = await getterService.GetAllProducts();
                return Results.Json(allProducts);
            });

            groupBuilder.MapGet("/{productID:guid}", async (HttpContext httpContext,
                Guid productID, IProductGetterService getterService) =>
            {
                var matchingProduct = await getterService.GetProductById(productID);
                if (matchingProduct == null)
                {
                    return Results.BadRequest(new { error = "Invalid product id" });
                }
                return Results.Json(matchingProduct);
            });

            groupBuilder.MapPost("/", async (HttpContext httpContext,
                IProductAdderService adderService, ProductAddRequest newProduct) =>
            {
                var product = await adderService.AddNewProduct(newProduct);
                return Results.Json(product);
            });

            groupBuilder.MapPut("/{productID:guid}", async (HttpContext httpContext, Guid productID,
                IProductUpdaterService updaterService, ProductUpdateRequest productUpdateRequest) =>
            {
                if (productID != productUpdateRequest.ProductId)
                {
                    return Results.BadRequest(new { 
                        error = $"Given ID: {productID} do not match with given product to update" 
                    });
                }
                var updatedProduct = await updaterService.UpdateProduct(productUpdateRequest);
                if (updatedProduct == null)
                {
                    return Results.BadRequest(new { error = "Invalid product id" });
                }
                return Results.Json(updatedProduct);
            });

            groupBuilder.MapDelete("/{productID:guid}", async (HttpContext httpContext, Guid productID,
                IProductDeleterService deleterService) =>
            {
                var isDeleted = await deleterService.DeleteProductByID(productID);
                if (!isDeleted)
                {
                    return Results.BadRequest(new
                    {
                        error = "Invalid product id"
                    });
                }

                return Results.Ok(new { message = $"Product with ID: {productID} deleted successfuly" });
            });

            return groupBuilder;
        }
    }
}
