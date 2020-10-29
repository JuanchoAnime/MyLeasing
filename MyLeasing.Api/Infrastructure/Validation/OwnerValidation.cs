namespace MyLeasing.Api.Infrastructure.Validation
{
    using FluentValidation;
    using MyLeasing.Common.Rest;

    public class OwnerValidation: AbstractValidator<OwnerRest>
    {
        public OwnerValidation()
        {
            RuleFor(owner => owner.User.PhoneNumber)
                .NotNull()
                .WithMessage("The Phone Number Is Not Null")
                .Length(7, 10)
                .WithMessage("The Phone Number the charcaters of seven(7) to ten(10)");
        }
    }
}
