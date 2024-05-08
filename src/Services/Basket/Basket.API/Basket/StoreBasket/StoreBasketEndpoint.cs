﻿
using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UserName);

    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (ShoppingCart request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();

                var result = sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();

                return Results.Ok(response);
            })
            .WithName("StoreBasket")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Store Basket")
            .WithDescription("Store Basket"); ;
        }
    }
}
