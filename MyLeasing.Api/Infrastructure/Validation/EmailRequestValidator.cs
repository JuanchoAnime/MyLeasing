namespace MyLeasing.Api.Infrastructure.Validation
{
    using FluentValidation;
    using MyLeasing.Common.Rest;

    public class EmailRequestValidator : AbstractValidator<EmailRequest>
    {
        public EmailRequestValidator()
        {
            RuleFor(emailReq => emailReq.Email)
                .NotNull()
                .EmailAddress();
        }
    }
}
