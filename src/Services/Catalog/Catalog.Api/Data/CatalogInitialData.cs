using Marten.Schema;

namespace Catalog.Api.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreConfiguredProducts());
            await session.SaveChangesAsync();
        }

        public static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Description = "The phone is the company biggest change",
                ImageFile = "product-1.png",
                Price = 950.00M, 
                Categories = new List<string> {"smart","device"}
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Air Fryer",
                Description = "Air fyer is the change we are looking for",
                ImageFile = "product-2.png",
                Price = 580.00M,
                Categories = new List<string> {"kitchen","device"}
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Freezer",
                Description = "Hight cooling device ever made",
                ImageFile = "product-3.png",
                Price = 680.00M,
                Categories = new List<string> { "kitchen", "device"}
            }
        };
    }
}
