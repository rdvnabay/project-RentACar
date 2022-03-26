using Business.Handlers.Brands.Commands;
using FluentValidation;

namespace Business.Handlers.Colors.ValidationRules
{
    public class CreateColorValidator:AbstractValidator<CreateColorCommand>
    {
        public CreateColorValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public class UpdateColorValidator : AbstractValidator<UpdateColorCommand>
    {
        public UpdateColorValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
