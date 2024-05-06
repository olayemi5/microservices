
using System.Linq;

namespace Catalog.Api.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category)
      : IQuery<GetProductByCategoryResult>;

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
       : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"About to get product by category with {query.Category}");

            var products = await session.Query<Product>()
                .Where(p => p.Categories.Contains(query.Category))
                .ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }
}
