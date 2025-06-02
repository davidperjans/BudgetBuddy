using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateTransactionDtoValidator : AbstractValidator<UpdateTransactionDto>
    {
        public UpdateTransactionDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}
