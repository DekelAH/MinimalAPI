using MinimalAPI.Core.ServiceContracts;
using System.Text.Json;

namespace MinimalAPI.MapGroups
{
    public static class ProductsMapGroup 
    {
        public static RouteGroupBuilder ProductsAPI(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("/", async (HttpContext httpContext, IProductGetterService getterService) =>
            {
                var allProducts = await getterService.GetAllProducts();
                var jsonProduct = JsonSerializer.Serialize(allProducts);
                await httpContext.Response.WriteAsync(jsonProduct);
            });

            groupBuilder.MapGet("/{productID:guid}", async (HttpContext httpContext, 
                Guid productID, IProductGetterService getterService) =>
            {
                var matchingProduct = await getterService.GetProductById(productID);
                if (matchingProduct == null)
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid product id");
                    return;
                }
                var jsonProduct = JsonSerializer.Serialize(matchingProduct);
                await httpContext.Response.WriteAsync(jsonProduct);
            });

            groupBuilder.MapPost("/products", async (httpContext) =>
            {
                await httpContext.Response.WriteAsync("Post - Hello");
            });

            groupBuilder.MapPut("/products/{productID:guid}", async (HttpContext httpContext, Guid productID) =>
            {
                await httpContext.Response.WriteAsync("Put - Hello");
            });

            groupBuilder.MapDelete("/products/{productID:guid}", async (HttpContext httpContext, Guid productID) =>
            {
                await httpContext.Response.WriteAsync("Delete - Hello");
            });

            return groupBuilder;
        }
    }
}
