
using FluentValidation;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart)
        :ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandBasketValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandBasketValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is required");
        }
    }

    public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;

            //var isSaved = await _repository.StoreBasket(cart)
            //update cache

            return new StoreBasketResult("Steve");
        }
    }
}
