using FluentValidation;

namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string Username) 
        : ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBaskethandlerValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBaskethandlerValidator()
        {
                RuleFor(x => x.Username).NotEmpty().WithMessage("Username is nrequired");
        }
    }

    public class DeleteBasketCommandHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            var isDeleted = await repository.DeleteBasket(command.Username, cancellationToken);

            return new DeleteBasketResult(isDeleted);
        }
    }
}
