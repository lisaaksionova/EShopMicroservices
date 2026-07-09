namespace Catalog.API.Products.DeleteProduct;

//public record DeleteProductRequest(Guid ProductId);
public record DeleteProductResponse(bool IsSuccess);
public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{productId:guid}", async (Guid productId, ISender sender) =>
        {
            var command = new DeleteProductCommand(productId);

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(response);
        })
        .WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Deletes a product by its ID.")
        .WithDescription("Deletes a product from the catalog based on the provided product ID. Returns a success response if the deletion is successful, or an error response if the product is not found or if there is a validation error.");
    }
}