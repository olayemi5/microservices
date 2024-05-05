namespace Catalog.Api.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string>Categories, string Description, string ImageFile, decimal Price) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from incoming command object
            var product = new Product
            {
                Name = command.Name, 
                Description = command.Description,
                Categories = command.Categories,
                Price = command.Price,
                ImageFile = command.ImageFile,
            };

            //save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //return result - CreateProductResult
            return new CreateProductResult(product.Id);
        }
    }
}
