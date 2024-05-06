
namespace Catalog.Api.Products.DeleteProduct
{
    public record DeleteRecordCommand(Guid Id) : ICommand<DeleteRecordResult>;

    public record DeleteRecordResult(bool IsSuccess);

    internal class DeleteProducthandler(IDocumentSession session, ILogger<DeleteProducthandler> logger)
        : ICommandHandler<DeleteRecordCommand, DeleteRecordResult>
    {
        public async Task<DeleteRecordResult> Handle(DeleteRecordCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Delete product with id {command.Id}");

            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteRecordResult(true);
        }
    }
}
