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

    public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            //var isDeleted = _repository.Deletebasket(command.UserName);

            return new DeleteBasketResult(true);
        }
    }
}
