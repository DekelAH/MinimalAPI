using MinimalAPI.Core.Domain.Entities;
using MinimalAPI.Core.DTO;
using MinimalAPI.Core.ServiceContracts;
using System.ComponentModel.DataAnnotations;

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

            }).AddEndpointFilter(async (EndpointFilterInvocationContext context, EndpointFilterDelegate next) =>
            {
                var product = context.Arguments.OfType<ProductAddRequest>().FirstOrDefault();
                if (product == null)
                {
                    return Results.BadRequest("Product details are not found in the request");
                }
                var validationContext = new ValidationContext(product);
                List<ValidationResult> ErrorsList = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(product, validationContext, ErrorsList, true);
                if (!isValid)
                {
                    return Results.BadRequest(ErrorsList.Select(error => error?.ErrorMessage));
                }

                var result = await next(context);
                return result;
            });

            groupBuilder.MapPut("/{productID:guid}", async (HttpContext httpContext, Guid productID,
                IProductUpdaterService updaterService, ProductUpdateRequest productUpdateRequest) =>
            {
                var updatedProduct = await updaterService.UpdateProduct(productUpdateRequest);
                return Results.Json(updatedProduct);

            }).AddEndpointFilter(async (EndpointFilterInvocationContext context, EndpointFilterDelegate next) =>
            {
                var id = context.Arguments.OfType<Guid>().FirstOrDefault();
                var product = context.Arguments.OfType<ProductUpdateRequest>().FirstOrDefault();
                if (product == null)
                {
                    return Results.BadRequest("Product details are not found in the request");
                }
                if (id != product.ProductId)
                {
                    return Results.BadRequest(new
                    {
                        error = $"Given ID: {id} do not match with given product to update"
                    });
                }

                var validationContext = new ValidationContext(product);
                List<ValidationResult> ErrorsList = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(product, validationContext, ErrorsList, true);
                if (!isValid)
                {
                    return Results.BadRequest(ErrorsList.Select(error => error?.ErrorMessage));
                }

                var result = await next(context);
                return result;
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
