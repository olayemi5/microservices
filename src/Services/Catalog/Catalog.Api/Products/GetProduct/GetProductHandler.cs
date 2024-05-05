using Catalog.Api.Products.CreateProduct;

namespace Catalog.Api.Products.GetProduct
{
    public record GetProductsQuery()
       : IQuery<GetProductResult>;

    public record GetProductResult(IEnumerable<Product> Products);

    internal class GetProductQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
       : IQueryHandler<GetProductsQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductQueryHandler.Handle called with query {@query}", query);

            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductResult(products);
        }
    }
}
