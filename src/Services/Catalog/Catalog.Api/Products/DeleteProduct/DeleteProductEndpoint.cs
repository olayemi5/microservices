
namespace Catalog.Api.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool IsSuccess);

    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/product/{id}", 
                async (Guid id, ISender sender) =>
                {
                    var result = await sender.Send(new DeleteRecordCommand(id));
                    var response = result.Adapt<DeleteProductResponse>();

                    return Results.Ok(response);
                })
              .WithName("DeleteProducts")
             .Produces<GetProductsResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Delete Products")
            . WithDescription("Delete Products");
        }
    }
}
