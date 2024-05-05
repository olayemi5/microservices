using BuildingBlocks.CQRS;
using Catalog.Api.Models;
using MediatR;

namespace Catalog.Api.Products.CreateProduct
{

    public record CreateProductCommand(string name, List<string>categories, string description, string imageFile, decimal price) 
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from incoming command object
            var product = new Product
            {
                Name = command.name, 
                Description = command.description,
                Categories = command.categories,
                Price = command.price,
                ImageFile = command.imageFile,
            };

            //save to database

            //return result - CreateProductResult
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
