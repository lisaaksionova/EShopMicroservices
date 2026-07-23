namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
    }
}

internal class DeleteProductCommandHandler
    (IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Product>(command.ProductId);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}