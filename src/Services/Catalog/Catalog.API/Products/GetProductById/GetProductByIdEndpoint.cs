using Catalog.API.Products.GetProducts;
using Microsoft.CodeAnalysis;

namespace Catalog.API.Products.GetProductById
{
    // public record GetProductByIdRequest();
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{productId:guid}", async (ISender sender, Guid productId) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(productId));

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get a product by its ID")
            .WithDescription("Retrieves a product from the catalog by its unique identifier (ID).");
        }
    }
}
